using System;
using System.Windows.Forms;

namespace SDA_DonationTracker
{
	public partial class SearchTab : UserControl, ITab
	{
		public MainForm Owner { get; set; }
		public TrackerContext TrackerContext
		{
			get
			{
				return this.SearchPanel.Context;
			}
			set
			{
				this.SearchPanel.Context = value;
			}
		}

		public SearchTab(SearchPanel searchPanel)
		{
			this.SearchPanel = searchPanel;
			this.InitializeComponent();
			this.SearchPanel.AddSelectionControl(this.OpenButton);
		}

		public bool ConfirmClose()
		{
			return true;
		}

		private void OpenButton_Click(object sender, EventArgs e)
		{
			//Console.WriteLine(string.Join("\n", this.SearchPanel.GetSelections()));

			foreach (int id in this.SearchPanel.GetSelections())
				this.Owner.NavigateTo(this.SearchPanel.Model.ModelName, id);
		}
	}
}
