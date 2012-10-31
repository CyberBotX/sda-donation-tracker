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
            Context = context;

            InitializeComponent();

            TableBinding = new TableBinding(ResultsView, "firstName", "lastName", "alias", "email");
            TableBinding.AddAssociatedControl(BasicSearchText);
            TableBinding.AddAssociatedControl(SearchButton);
            TableBinding.AddAssociatedControl(BasicSearchButton);
            TableBinding.AddAssociatedControl(FirstNameText);
            TableBinding.AddAssociatedControl(LastNameText);
            TableBinding.AddAssociatedControl(AliasText);
            TableBinding.AddAssociatedControl(EmailText);
        }

        private Dictionary<string,string> GetSearchParams()
        {
            return new Dictionary<string,string>(StringComparer.OrdinalIgnoreCase)
            { 
                { "firstname", FirstNameText.Text }, 
                { "lastname", LastNameText.Text },
                { "alias", AliasText.Text },
                { "email", EmailText.Text },
            };
        }

        private void AbortExistingSearch()
        {
            if (CurrentSearch != null && CurrentSearch.Busy)
            {
                CurrentSearch.Abort();
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            AbortExistingSearch();

            CurrentSearch = Context.DeferredSearch("donor", GetSearchParams());

            CurrentSearch.OnComplete += (results) =>
            {
                TableBinding.LoadArray(results);
                TableBinding.EnableControls();
            };

            TableBinding.DisableControls();
            CurrentSearch.Begin();
        }

        private void BasicSearchButton_Click(object sender, EventArgs e)
        {
            AbortExistingSearch();

            CurrentSearch = Context.DeferredSearch("donor", new Dictionary<string, string> { { "q", BasicSearchText.Text } });

            CurrentSearch.OnComplete += (results) =>
            {
                TableBinding.LoadArray(results);
                TableBinding.EnableControls();
            };

            TableBinding.DisableControls();
            CurrentSearch.Begin();
        }

        // TODO: add an OnSelect event to the table, s.t. external controls can embed this
        // and use the search results
    }
}
