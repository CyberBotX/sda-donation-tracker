using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

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
			this.InitializeComponent();

			this.MainForm = mainForm;

			this.ListBinding = new ListBinding<JTokenListElement>(this.EventsList, x => new JTokenListElement(x, "name"), "Display");
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
			JTokenListElement[] results = this.ListBinding.GetSelections().ToArray();

			if (results.Length == 1)
			{
				this.Context.EventId = results[0].Source.Value<int>("pk");
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
