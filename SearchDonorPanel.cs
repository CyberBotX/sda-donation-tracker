using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SDA_DonationTracker
{
	// TODO: 
	// - generalize this using a model class to represent any entity
	// object, to cut down on repetition.  It should take a set of strings
	// identifying which fields to search on, and which fields to show in the results
	// - Create specific uses of that general search model, such as the SearchTab, which 
	// has a 'navigate to' button, that activates on selection, etc...

	public partial class SearchDonorPanel : UserControl
	{
		public TrackerContext Context;
		private TableBinding TableBinding;
		private SearchContext CurrentSearch;

		public SearchDonorPanel(TrackerContext context)
		{
			this.Context = context;

			this.InitializeComponent();

			this.TableBinding = new TableBinding(this.ResultsView, "firstName", "lastName", "alias", "email");
			this.TableBinding.AddAssociatedControl(this.BasicSearchText);
			this.TableBinding.AddAssociatedControl(this.SearchButton);
			this.TableBinding.AddAssociatedControl(this.BasicSearchButton);
			this.TableBinding.AddAssociatedControl(this.FirstNameText);
			this.TableBinding.AddAssociatedControl(this.LastNameText);
			this.TableBinding.AddAssociatedControl(this.AliasText);
			this.TableBinding.AddAssociatedControl(this.EmailText);
		}

		private Dictionary<string, string> GetSearchParams()
		{
			return new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
			{
				{ "firstname", this.FirstNameText.Text }, 
				{ "lastname", this.LastNameText.Text },
				{ "alias", this.AliasText.Text },
				{ "email", this.EmailText.Text },
			};
		}

		private void AbortExistingSearch()
		{
			if (this.CurrentSearch != null && this.CurrentSearch.Busy)
				this.CurrentSearch.Abort();
		}

		private void SearchButton_Click(object sender, EventArgs e)
		{
			this.AbortExistingSearch();

			this.CurrentSearch = this.Context.DeferredSearch("donor", this.GetSearchParams());

			this.CurrentSearch.OnComplete += results =>
			{
				this.TableBinding.LoadArray(results);
				this.TableBinding.EnableControls();
			};

			this.TableBinding.DisableControls();
			this.CurrentSearch.Begin();
		}

		private void BasicSearchButton_Click(object sender, EventArgs e)
		{
			this.AbortExistingSearch();

			this.CurrentSearch = this.Context.DeferredSearch("donor", new Dictionary<string, string> { { "q", BasicSearchText.Text } });

			this.CurrentSearch.OnComplete += results =>
			{
				this.TableBinding.LoadArray(results);
				this.TableBinding.EnableControls();
			};

			this.TableBinding.DisableControls();
			this.CurrentSearch.Begin();
		}

		// TODO: add an OnSelect event to the table, s.t. external controls can embed this
		// and use the search results
	}
}
