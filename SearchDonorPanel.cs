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
    public partial class SearchDonorPanel : UserControl
    {
        public TrackerContext Context;
        private TableBinding TableBinding;
        private SearchContext CurrentSearch;

        // TODO: need to add a mutex to indicate when a search is active, and lock on that
        // it should also lock the search buttons while a search is active, and then unlock
        // when the search is complete

        // TODO: generalize this using a model class to represent any entity
        // object, to cut down on repetition

        public SearchDonorPanel()
        {
            InitializeComponent();

            TableBinding = new TableBinding(ResultsView, "firstName", "lastName", "alias", "email");
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
            };

            CurrentSearch.Begin();
        }

        private void BasicSearchButton_Click(object sender, EventArgs e)
        {
            AbortExistingSearch();

            CurrentSearch = Context.DeferredSearch("donor", new Dictionary<string, string> { { "q", BasicSearchText.Text } });

            CurrentSearch.OnComplete += (results) =>
            {
                TableBinding.LoadArray(results);
            };

            CurrentSearch.Begin();
        }
    }
}
