using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace SDA_DonationTracker
{
	public partial class SelectEventDialog : Form
	{
		private MainForm MainForm;
		private TrackerContext Context;
		private ListBinding<JObjectSimpleDisplay> ListBinding;
		private SearchContext CurrentSearch;

		public SelectEventDialog(MainForm mainForm, TrackerContext context)
		{
			this.InitializeComponent();

			this.MainForm = mainForm;

			this.ListBinding = new ListBinding<JObjectSimpleDisplay>(this.EventsList, x => new JObjectSimpleDisplay(x as JObject, "name"), "Display");
			this.ListBinding.AddSelectionControl(this.SelectButton);

			this.Context = context;

			this.CurrentSearch = this.Context.DeferredSearch("event", new Dictionary<string, string> { { "q", "" } });

			this.CurrentSearch.OnComplete += results =>
			{
				this.ListBinding.LoadArray(results);
				this.ListBinding.EnableControls();
			};

			this.ListBinding.DisableControls();
			this.CurrentSearch.Begin();
		}

		private void SelectButton_Click(object sender, EventArgs e)
		{
			JObjectSimpleDisplay[] results = this.ListBinding.GetSelections().ToArray();

			if (results.Length == 1)
			{
				this.Context.SetCurrentEvent(results[0].Source);
				this.MainForm.ResetMenus();
				this.Close();
			}
		}

		private void CancelButton_Click(object sender, EventArgs e)
		{
			this.CurrentSearch.Abort();
			this.Close();
		}
	}
}
