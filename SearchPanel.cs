using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace SDA_DonationTracker
{
	public partial class SearchPanel : UserControl
	{
		public bool AllowMultiSelect
		{
			get
			{
				return this.ResultsList.SelectionMode == SelectionMode.MultiExtended || this.ResultsList.SelectionMode == SelectionMode.MultiSimple;
			}
			set
			{
				this.ResultsList.SelectionMode = value ? SelectionMode.MultiExtended : SelectionMode.One;
			}
		}

		public TrackerContext Context { get; set; }
		public event Action<IEnumerable<int>> OnSelect;

		private ListBinding<JObjectEntityDisplay> ListBinding;
		private SearchContext CurrentSearch;
		public EntityModel Model { get; private set; }
		private FormBinding FormBinding;
		private string[] SearchFields;

		public SearchPanel(EntityModel model, IEnumerable<string> searchFields)
		{
			this.InitializeComponent();

			this.Model = model;
			this.SearchFields = searchFields.ToArray();

			int currentFieldIndex = 2;

			this.FormBinding = new FormBinding(model.ModelName, searchForm: true);
			this.ListBinding = new ListBinding<JObjectEntityDisplay>(this.ResultsList, x => new JObjectFuncDisplay(x, model.DisplayConverter), "Display");

			foreach (string field in this.SearchFields)
			{
				SearchFieldModel searchField = this.Model.GetSearchField(field);
				FieldBinding binding = FieldBindingHelper.CreateBindingField(searchField.FieldType, fieldName: field);
				this.FormBinding.AddBinding(field, binding);
				++this.SearchParamsTable.RowCount;
				this.SearchParamsTable.Controls.Add(new Label()
				{
					Text = field.SymbolToNatural(), 
					Dock = DockStyle.Fill 
				}, 0, currentFieldIndex);
				this.SearchParamsTable.Controls.Add(binding.BoundControl, 1, currentFieldIndex);
				binding.BoundControl.Dock = DockStyle.Fill;
				++currentFieldIndex;
			}

			this.SearchButton = new Button()
			{
				Text = "Search",
				Dock = DockStyle.Fill,
			};

			++this.SearchParamsTable.RowCount;
			this.SearchButton.Click += this.SearchButton_Click;
			this.SearchParamsTable.Controls.Add(this.SearchButton, 1, currentFieldIndex);
			this.BasicSearchButton.Click += this.BasicSearchButton_Click;

			this.FormBinding.AddAssociatedControl(this.SearchButton);
			this.FormBinding.AddAssociatedControl(this.BasicSearchButton);
			this.FormBinding.AddAssociatedControl(this.BasicSearchText);

			this.ListBinding.OnSelection += (selections) =>
			{
				if (this.OnSelect != null)
					this.OnSelect.Invoke(this.GetSelections());
			};
		}

		public IEnumerable<int> GetSelections()
		{
			return this.GetSelectionObjects().Select(s => s.Value<int>("pk"));
		}

		public IEnumerable<JObject> GetSelectionObjects()
		{
			return this.ListBinding.GetSelections().Select(t => t.Source);
		}

		public void AddSelectionControl(Control c)
		{
			this.ListBinding.AddSelectionControl(c);
		}

		private void AbortExistingSearch()
		{
			if (this.CurrentSearch != null && this.CurrentSearch.Busy)
				this.CurrentSearch.Abort();
		}

		private Dictionary<string, string> GetSearchParams()
		{
			Dictionary<string, string> result = new Dictionary<string, string>();

			JObject searchObj = this.FormBinding.SaveObject();

			foreach (string field in this.SearchFields)
			{
				string value = searchObj.GetField(field);
				if (!string.IsNullOrEmpty(value))
					result.Add(field, value);
			}

			return result;
		}

		private void SearchButton_Click(object sender, EventArgs e)
		{
			if (this.Context == null)
				throw new Exception("Error, no TrackerContext was set.");

			this.AbortExistingSearch();

			this.CurrentSearch = this.Context.DeferredSearch(this.Model.ModelName, this.GetSearchParams());

			this.CurrentSearch.OnComplete += results =>
			{
				this.ListBinding.LoadArray(results);
				this.FormBinding.EnableControls();
				this.ListBinding.EnableControls();
			};

			this.FormBinding.DisableControls();
			this.ListBinding.DisableControls();
			this.CurrentSearch.Begin();
		}

		private void BasicSearchButton_Click(object sender, EventArgs e)
		{
			this.AbortExistingSearch();

			this.CurrentSearch = this.Context.DeferredSearch(this.Model.ModelName, new Dictionary<string, string> { { "q", BasicSearchText.Text } });

			this.CurrentSearch.OnComplete += results =>
			{
				this.ListBinding.LoadArray(results);
				this.FormBinding.EnableControls();
				this.ListBinding.EnableControls();
			};

			this.FormBinding.DisableControls();
			this.ListBinding.DisableControls();
			this.CurrentSearch.Begin();
		}
	}
}
