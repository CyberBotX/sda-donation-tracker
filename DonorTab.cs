using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SDA_DonationTracker
{
    public partial class DonorTab : UserControl
    {
        private FormBinding FormBinding;
        private TrackerContext Context;
        private SearchContext CurrentDonorSearch;
        private int Id;

        public DonorTab(TrackerContext context, int id)
        {
            Id = id;
            InitializeComponent();

            Context = context;

            FormBinding = new FormBinding();

            FormBinding.AddBinding("firstname", FirstNameText);
            FormBinding.AddBinding("lastname", LastNameText);
            FormBinding.AddBinding("alias", AliasText);
            FormBinding.AddBinding("email", EmailText);

            RefreshData();
        }

        private void RefreshData()
        {
            CurrentDonorSearch = Context.DeferredSearch("donor", Util.CreateSearchParams("id", Id.ToString()));

            CurrentDonorSearch.OnComplete += results =>
            {
                FormBinding.LoadObject(results.First());
                FormBinding.EnableControls();
            };

            FormBinding.DisableControls();
            CurrentDonorSearch.Begin();
        }
    }
}
