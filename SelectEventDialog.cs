using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace SDA_DonationTracker
{
    public partial class SelectEventDialog : Form
    {
        private MainForm MainForm;
        private TrackerContext Context;
        private ListBinding<JTokenListElement> ListBinding;
        private SearchContext CurrentSearch;

        public SelectEventDialog(MainForm mainForm, TrackerContext context)
        {
            InitializeComponent();

            MainForm = mainForm;

            ListBinding = new ListBinding<JTokenListElement>(EventsList, x => new JTokenListElement(x, "name"), "Display");
            ListBinding.AddSelectionControl(SelectButton);

            Context = context;

            CurrentSearch = Context.DeferredSearch("event", new KeyValuePair<string, string>[] { new KeyValuePair<string, string>("q", "") });

            CurrentSearch.OnComplete += (results) =>
            {
                ListBinding.LoadArray(results);
                ListBinding.EnableControls();
            };

            ListBinding.DisableControls();
            CurrentSearch.Begin();
        }

        private void SelectButton_Click(object sender, EventArgs e)
        {
            JTokenListElement[] results = ListBinding.GetSelections().ToArray();

            if (results.Length == 1)
            {
                Context.EventId = results[0].Source.Value<int>("pk");
                MainForm.ResetMenus();
                Close();
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            CurrentSearch.Abort();
            Close();
        }
    }
}
