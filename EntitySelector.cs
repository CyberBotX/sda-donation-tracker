using System;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace SDA_DonationTracker
{
	// TODO: 
	// - Add a search button to set the value as well (note, this will require working search dialogs too)
	// - Allow the text representation to be defined based on the model (i.e. it will read the appropriate
	// representation off of its EntityModel, requires, again, more external work)
	public partial class EntitySelector : UserControl
	{
		public TrackerContext Context
		{
			get
			{
				return this.Cache != null ? this.Cache.Context : null;
			}
		}

		public string ModelName
		{
			get
			{
				return this.Cache != null ? this.Cache.ModelName : null;
			}
		}

		public EntitySelectionCache Cache { get; private set; }

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

		private MainForm _Owner;

		public int? Value
		{
			get
			{
				return this.GetSelectedId();
			}
			set
			{
				this.SetSelectedId(value);
			}
		}

		public bool UseSelectionCache
		{
			get
			{
				return this._UseSelectionCache;
			}
			set
			{
				this._UseSelectionCache = value;
				this.NameText.ReadOnly = !value;
				this.ClearButton.Visible = !value;

				if (value && this.Cache != null)
				{
					this.Cache.RequestRefresh(EntitySelectionCacheRefreshType.Light);
				}
			}
		}

		private bool _UseSelectionCache;

		private int? SelectedId;

		public EntitySelector()
		{
			this.InitializeComponent();

			this.NameText.AutoCompleteCustomSource = new AutoCompleteStringCollection();
			this.NameText.TextChanged += OnTextChanged;

			this.SelectedId = null;
		}

		public void Deinitialize()
		{
			if (this.Cache != null)
			{
				this.Cache.DataRefreshed -= this.RebuildMappingInfo;
			}

			this.Cache = null;
		}

		public void Initialize(TrackerContext context, string modelName)
		{
			if (this.Cache != null)
			{
				this.Cache.DataRefreshed -= this.RebuildMappingInfo;
			}

			this.Cache = context.GetEntitySelectionCache(modelName);
			this.Cache.DataRefreshed += this.RebuildMappingInfo;

			this.SelectedId = null;
			this.NameText.InvokeEx(() => this.NameText.AutoCompleteCustomSource = new AutoCompleteStringCollection());
			this.NameText.InvokeEx(() => this.NameText.Text = "");

			this.RebuildMappingInfo(this.Cache.GetLatestCache());

			if (this.UseSelectionCache)
			{
				this.Cache.RequestRefresh(EntitySelectionCacheRefreshType.Strong);
			}

			this.SearchButton.Visible = SearchPanelHelpers.HasSearchPanel(this.ModelName);

		}

		private void SetOpenButtonState()
		{
			this.OpenButton.InvokeEx(() => this.OpenButton.Visible = (this.Owner != null && this.SelectedId != null));
		}

		public override Size GetPreferredSize(Size proposedSize)
		{
			Size textSize = this.NameText.GetPreferredSize(proposedSize);
			Size buttonSize = this.SearchButton.GetPreferredSize(proposedSize);
			return new Size(proposedSize.Width, Math.Max(textSize.Height, buttonSize.Height) + 5);
		}

		public void SetSelectorText(string text)
		{
			this.NameText.InvokeEx(() => this.NameText.Text = text);
		}

		public string GetSelectorText()
		{
			return this.NameText.Text;
		}

		public void SetSelectedId(int? target)
		{
			this.SelectedId = target;

			if (this.UseSelectionCache)
			{
				this.Cache.RequestRefresh();
			}

			bool found = false;
			string selectionText;

			if (this.SelectedId != null)
			{
				if (UseSelectionCache)
				{
					found = this.Cache.GetLatestCache().TryGetLeftToRight(this.SelectedId ?? 0, out selectionText);

					if (found)
					{
						this.NameText.InvokeEx(() => this.NameText.Text = selectionText);
						this.SetOpenButtonState();
					}
				}
				else
				{
					SearchContext searcher = this.Context.DeferredIdSearch(this.ModelName, this.SelectedId ?? 0);
					searcher.OnComplete += (results) =>
					{
						JObject result = results.First as JObject;
						this.NameText.InvokeEx(() => this.NameText.Text = result.GetDisplayName());
						this.SetOpenButtonState();
					};
					searcher.OnError += (type, message) =>
					{
						this.SelectedId = null;
					};
					searcher.Begin();
				}
			}
			else
			{
				this.NameText.InvokeEx(() => this.NameText.Text = "");
				this.SetOpenButtonState();
			}
		}

		public int? GetSelectedId()
		{
			return this.SelectedId;
		}

		private void RebuildMappingInfo(IBiMap<int, string> latestData)
		{
			AutoCompleteStringCollection autoComplete = new AutoCompleteStringCollection();

			foreach (var entry in latestData.EnumerateRightToLeft())
			{
				autoComplete.Add(entry.Key);

				if (this.SelectedId == entry.Value)
				{
					this.NameText.InvokeEx(() => this.NameText.Text = entry.Key);
				}
			}

			this.NameText.InvokeEx(() => this.NameText.AutoCompleteCustomSource = autoComplete);
			this.SetSelectionFromText();
		}

		private void OnTextChanged(object obj, EventArgs args)
		{
			if (this.UseSelectionCache)
			{
				this.Cache.RequestRefresh();
				this.SetSelectionFromText();
			}
		}

		private void SetSelectionFromText()
		{
			IBiMap<int, string> latestCache = this.Cache.GetLatestCache();

			int value;

			if (latestCache.TryGetRightToLeft(this.NameText.Text, out value))
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

		private void OpenButton_Click(object sender, EventArgs e)
		{
			if (this.Owner != null && this.SelectedId != null)
				this.Owner.NavigateTo(this.Cache.ModelName, this.SelectedId ?? 0);
		}

		private void SearchButton_Click(object sender, EventArgs e)
		{
			if (this.Context != null && SearchPanelHelpers.HasSearchPanel(this.ModelName))
			{
				SearchPanel panel = SearchPanelHelpers.CreatePanelForModel(this.ModelName);
				panel.Context = this.Context;

				SearchDialog dialog = new SearchDialog(panel);
				dialog.ShowDialog();

				if (dialog.Result != null)
				{
					this.SelectedId = dialog.Result.GetId();
					this.NameText.InvokeEx(() => this.NameText.Text = dialog.Result.GetDisplayName());
					this.SetOpenButtonState();
				}
			}
		}

		private void ClearButton_Click(object sender, EventArgs e)
		{
			this.SetSelectedId(null);
		}
	}
}
