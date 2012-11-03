using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace SDA_DonationTracker
{
	public partial class SearchPanel : UserControl
	{
		public TrackerContext TrackerContext { get; set; }
		public event Action<IEnumerable<int>> OnSelect;

		private ListBinding<JTokenListElement> TableBinding;
		private SearchContext CurrentSearch;
		public EntityModel Model { get; private set; }
		private FormBinding FormBinding;
		private string[] SearchFields;
		private string[] LabelFields;

		public SearchPanel(EntityModel model, IEnumerable<string> searchFields, IEnumerable<string> labelFields)
		{
			InitializeComponent();

			this.Model = model;
			this.SearchFields = searchFields.ToArray();
			this.LabelFields = labelFields.ToArray();

			int currentFieldIndex = 2;

			this.FormBinding = new FormBinding();
			this.TableBinding = new ListBinding<JTokenListElement>(this.ResultsList, x => new JTokenListElement(x, this.LabelFields), "Display");

			foreach (var field in this.SearchFields)
			{
				FieldBinding binding = FieldBindingHelper.CreateBindingField(model.GetField(field));
				this.FormBinding.AddBinding(field, binding);
				++this.SearchParamsTable.RowCount;
				this.SearchParamsTable.Controls.Add(
					new Label() 
					{
						Text = field.SymbolToNatural(), 
						Dock = DockStyle.Fill 
					}, 0, currentFieldIndex);
				this.SearchParamsTable.Controls.Add(binding.BoundControl, 1, currentFieldIndex);
				binding.BoundControl.Dock = DockStyle.Fill;
				++currentFieldIndex;
			}

			SearchButton = new Button()
			{
				Text = "Search",
				Dock = DockStyle.Fill,
			};

			++this.SearchParamsTable.RowCount;
			this.SearchButton.Click += SearchButton_Click;
			this.SearchParamsTable.Controls.Add(this.SearchButton, 1, currentFieldIndex);
			this.BasicSearchButton.Click += BasicSearchButton_Click;

			this.FormBinding.AddAssociatedControl(this.SearchButton);
			this.FormBinding.AddAssociatedControl(this.BasicSearchButton);
			this.FormBinding.AddAssociatedControl(this.BasicSearchText);

			this.TableBinding.OnSelection += (selections) =>
			{
				if (OnSelect != null)
				{
					OnSelect.Invoke(GetSelections());
				}
			};
		}

		public IEnumerable<int> GetSelections()
		{
			return this.TableBinding.GetSelections().Select(t => t.Source.Value<int>("pk"));
		}

		public void AddSelectionControl(Control c)
		{
			this.TableBinding.AddSelectionControl(c);
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
			JObject fieldsObj = searchObj.Value<JObject>("fields");

			foreach (var field in this.SearchFields)
			{
				string value = fieldsObj.Value<string>(field);
				if (!string.IsNullOrEmpty(value))
					result.Add(field, value);
			}

			return result;
		}

		private void SearchButton_Click(object sender, EventArgs e)
		{
			if (this.TrackerContext == null)
			{
				throw new Exception("Error, no TrackerContext was set.");
			}

			this.AbortExistingSearch();

			this.CurrentSearch = this.TrackerContext.DeferredSearch(this.Model.ModelName, this.GetSearchParams());

			this.CurrentSearch.OnComplete += results =>
			{
				this.TableBinding.LoadArray(results);
				this.FormBinding.EnableControls();
				this.TableBinding.EnableControls();
			};

			this.FormBinding.DisableControls();
			this.TableBinding.DisableControls();
			this.CurrentSearch.Begin();
		}

		private void BasicSearchButton_Click(object sender, EventArgs e)
		{
			this.AbortExistingSearch();

			this.CurrentSearch = this.TrackerContext.DeferredSearch(this.Model.ModelName, new Dictionary<string, string> { { "q", BasicSearchText.Text } });

			this.CurrentSearch.OnComplete += results =>
			{
				this.TableBinding.LoadArray(results);
				this.FormBinding.EnableControls();
				this.TableBinding.EnableControls();
			};

			this.FormBinding.DisableControls();
			this.TableBinding.DisableControls();
			this.CurrentSearch.Begin();
		}
	}
}
