using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using System.Threading;

namespace SDA_DonationTracker
{
	// TODO: 
	// - Add a search button to set the value as well (note, this will require working search dialogs too)
	// - Allow the text representation to be defined based on the model (i.e. it will read the appropriate
	// representation off of its EntityModel, requires, again, more external work)
	public partial class EntitySelector : UserControl
	{
		private static readonly TimeSpan RefreshOffset = new TimeSpan(0, 0, 30);

		public EntityModel Model { get; set; }
		public TrackerContext TrackerContext { get; set; }

		public MainForm Owner
		{
			get
			{
				return this._Owner;
			}
			set
			{
				this._Owner = value;
				this.SetOpenButtonState();
			}
		}

		private TrackerContext _Context;
		private MainForm _Owner;
		private int? SelectedId;
		private DateTime LastRefreshedAutoComplete;
		private AutoCompleteStringCollection AutoCompleteCollection;
		private Dictionary<string, int> LabelMapping;
		private BindingContext Binding;
		private Mutex ModificationMutex;
		private SearchContext Searcher;

		public EntitySelector()
		{
			InitializeComponent();

			this.ModificationMutex = new Mutex();
			this.Binding = new BindingContext();

			this.Binding.AddAssociatedControl(this.NameText);
			this.Binding.AddAssociatedControl(this.OpenButton);

			this.LabelMapping = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
			this.AutoCompleteCollection = new AutoCompleteStringCollection();

			this.NameText.AutoCompleteCustomSource = this.AutoCompleteCollection;
			this.NameText.TextChanged += OnTextChanged;

			this.LastRefreshedAutoComplete = DateTime.MinValue;

			this.SelectedId = null;
		}

		public void Initialize(TrackerContext context, string model)
		{
			try
			{
				this.ModificationMutex.WaitOne();
				this.AutoCompleteCollection.Clear();
				this.LabelMapping.Clear();

				this.TrackerContext = context;
				this.Model = DonationModels.GetModel(model);
				this.SelectedId = null;
				this.NameText.InvokeEx(() => this.NameText.Text = "");
				this.RefreshAutoComplete();
			}
			finally
			{
				this.ModificationMutex.ReleaseMutex();
			}
		}

		private void SetOpenButtonState()
		{
			this.OpenButton.InvokeEx(() => this.OpenButton.Visible = (this.Owner != null && this.SelectedId != null));
		}

		public override Size GetPreferredSize(Size proposedSize)
		{
			Size textSize = this.NameText.GetPreferredSize(proposedSize);
			Size buttonSize = this.ButtonsPanel.GetPreferredSize(proposedSize);
			return new Size(textSize.Width + buttonSize.Width, Math.Max(textSize.Height, buttonSize.Height));
		}

		public void SetSelectedId(int? target)
		{
			this.SelectedId = target;
			this.RefreshAutoComplete();

			bool found = false;
			string selectionText = null;

			try
			{
				this.ModificationMutex.WaitOne();

				foreach (var entry in this.LabelMapping)
				{
					if (entry.Value == target)
					{
						selectionText = entry.Key;
						found = true;
					}
				}
			}
			finally
			{
				this.ModificationMutex.ReleaseMutex();
			}

			if (found)
			{
				this.NameText.InvokeEx(() => this.NameText.Text = selectionText);
				this.SetOpenButtonState();
			}
			else if (this.SelectedId == null)
			{
				this.NameText.InvokeEx(() => this.NameText.Text = "");
				this.SetOpenButtonState();
			}
		}

		public int? GetSelectedId()
		{
			return this.SelectedId;
		}

		private void RefreshAutoComplete(bool waitOnResults = false)
		{
			if (this.LastRefreshedAutoComplete.Add(RefreshOffset) < DateTime.Now && (this.Searcher == null || !this.Searcher.Busy))
			{
				this.LastRefreshedAutoComplete = DateTime.Now;

				this.Searcher = this.TrackerContext.DeferredSearch(this.Model.ModelName, new Dictionary<string, string>());

				this.Searcher.OnComplete += (results) =>
				{
					try
					{
						this.ModificationMutex.WaitOne();

						this.AutoCompleteCollection = new AutoCompleteStringCollection();
						this.LabelMapping.Clear();

						foreach (JObject obj in results.Values<JObject>())
						{
							int id = obj.GetId() ?? 0;
							string label = this.Model.DisplayConverter(obj);

							this.LabelMapping[label] = id;
							this.AutoCompleteCollection.Add(label);
						}

						this.NameText.InvokeEx(() => this.NameText.AutoCompleteCustomSource = this.AutoCompleteCollection);
						//this.NameText.InvokeEx(() => this.NameText.Enabled = true);
					}
					finally
					{
						this.ModificationMutex.ReleaseMutex();
					}

					if (this.SelectedId != null && string.IsNullOrEmpty(this.NameText.Text))
					{
						this.SetSelectedId(this.SelectedId);
					}
					else if (!string.IsNullOrEmpty(this.NameText.Text))
					{
						this.SetSelectionFromText();
					}
				};

				this.Searcher.Begin();

				// busy wait 
				while (waitOnResults && this.Searcher.Busy)
					;
			}
		}

		private void OnTextChanged(object obj, EventArgs args)
		{
			RefreshAutoComplete();
			SetSelectionFromText();
		}

		private void SetSelectionFromText()
		{
			try
			{
				this.ModificationMutex.WaitOne();

				int value;

				if (this.LabelMapping.TryGetValue(this.NameText.Text, out value))
				{
					this.SelectedId = value;
					this.SetOpenButtonState();
				}
				// Not sure if this is a good idea or not..., what happens when you try to save w/ a null donor for example?
				else if (string.IsNullOrEmpty(this.NameText.Text))
				{
					this.SelectedId = null;
					this.SetOpenButtonState();
				}
			}
			finally
			{
				this.ModificationMutex.ReleaseMutex();
			}
		}

		private void OpenButton_Click(object sender, EventArgs e)
		{
			if (this.Owner != null && this.SelectedId != null)
			{
				this.Owner.NavigateTo(this.Model.ModelName, this.SelectedId ?? 0);
			}
		}
	}
}
