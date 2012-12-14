using System;
using System.Linq;
using System.Windows.Forms;

namespace SDA_DonationTracker
{
	// TODO: 
	// - Add code such that tabs can intercept the 'close' notification, and decide whether or not to close
	//   - Possibly an 'ITab' interface with a 'bool ConfirmClose()' method

	public partial class MainForm : Form
	{
		public TrackerContext Context = new TrackerContext();

		public MainForm()
		{
			this.InitializeComponent();

			this.StatusBarLabel.Text = "Testing...";

			this.TabControl.OnClose += this.OnTabClose;
			this.TabControl.ConfirmOnClose = false;
		}

		public void SetStatusMessage(string message)
		{
			this.StatusBarLabel.Text = message;
		}

		public void RemoveTab(Control tabPanel)
		{
			TabPageEx result = this.FindTabOf(tabPanel);

			if (result != null)
			{
				this.TabControl.InvokeEx(() => this.TabControl.TabPages.Remove(result));
				result.InvokeEx(() => result.Dispose());
			}
		}

		public void SetTabName(Control tabPanel, string name)
		{
			TabPageEx result = this.FindTabOf(tabPanel);

			if (result != null)
			{
				result.InvokeEx(() => result.Text = name);
			}
		}

		private TabPageEx FindTabOf(Control tabPanel)
		{
			foreach (TabPageEx page in this.TabControl.TabPages)
			{
				if (page.Controls.Cast<Control>().Where(c => c == tabPanel).Any())
				{
					return page;
				}
			}

			return null;
		}

		private TabPageEx FindTabOf(string model, int id)
		{
			foreach (TabPageEx page in this.TabControl.TabPages)
			{
				var controls = page.Controls.Cast<Control>().Where(c => c is IEntityTab);

				if (controls.Count() == 1)
				{
					var result = controls.Single() as IEntityTab;

					if (result.Id == id && result.ModelName == model)
					{
						return page;
					}
				}
			}

			return null;
		}

		public bool IsNavigable(string model)
		{
			return EntityTabHelpers.HasEditPanel(model);
		}

		public void NavigateTo(string model, int? id)
		{
			if (!this.IsNavigable(model))
			{
				string message = "Error, cannot navigate to " + model + ", no edit page for it exists.";
				this.SetStatusMessage(message);
				MessageBox.Show(message);
				return;
			}

			TabPageEx alreadyExists = null;
			
			if (id != null)
				alreadyExists = this.FindTabOf(model, id ?? 0);

			// if a tab to the specified entity exists already, simply select that tab rather than create a new one
			if (alreadyExists != null)
			{
				this.TabControl.SelectedTab = alreadyExists;
			}
			else
			{
				EntityTab content = EntityTabHelpers.CreateEntityTab(model, this, this.Context);
				content.Dock = DockStyle.Fill;
				TabPageEx tab = new TabPageEx()
				{
					Controls =
					{
						content,
					}
				};
				this.TabControl.TabPages.Add(tab);
				this.TabControl.SelectTab(tab);
				content.SetInstanceId(id);
			}
		}

		public void NavigateToDonor(int? id)
		{
			this.NavigateTo("donor", id);
		}

		public void NavigateToDonation(int? id)
		{
			this.NavigateTo("donation", id);
		}

		public void NavigateToPrize(int? id)
		{
			this.NavigateTo("prize", id);
		}

		public void NavigateToPrizeCategory(int? id)
		{
			this.NavigateTo("prizecategory", id);
		}

		public void NavigateToRun(int? id)
		{
			this.NavigateTo("run", id);
		}

		public void NavigateToChoice(int? id)
		{
			this.NavigateTo("choice", id);
		}

		public void NavigateToChallenge(int? id)
		{
			this.NavigateTo("challenge", id);
		}

		public void CreateNewChoice()
		{
			this.NavigateToChoice(null);
		}

		public void CreateNewDonor()
		{
			this.NavigateToDonor(null);
		}

		public void CreateNewDonation()
		{
			this.NavigateToDonation(null);
		}

		public void CreateNewPrize()
		{
			this.NavigateToPrize(null);
		}

		public void CreateNewRun()
		{
			this.NavigateToRun(null);
		}

		public void CreateNewChallenge()
		{
			this.NavigateToChallenge(null);
		}

		public void CreateNewPrizeCategory()
		{
			this.NavigateToPrizeCategory(null);
		}

		public void OpenReadTaskTab()
		{
			foreach (TabPageEx page in this.TabControl.TabPages)
			{
				var controls = page.Controls.Cast<Control>().Where(c => c is ReadTaskTab);

				if (controls.Count() == 1)
				{
					this.TabControl.SelectTab(page);
					return;
				}
			}

			ReadTaskTab readTab = new ReadTaskTab()
			{
				Owner = this,
				Context = this.Context,
				Dock = DockStyle.Fill,
			};

			readTab.RefreshData();

			TabPageEx tab = new TabPageEx()
			{
				Text = "Read Task",
				Controls =
				{
					readTab
				}
			};

			this.TabControl.TabPages.Add(tab);
			this.TabControl.SelectTab(tab);
		}

		public bool IsSearchable(string model)
		{
			return SearchPanelHelpers.HasSearchPanel(model);
		}

		public void OpenSearchTab(string model)
		{
			if (!this.IsSearchable(model))
			{
				string message = "Error, cannot open search for " + model + ", no search page for it exists.";
				this.SetStatusMessage(message);
				MessageBox.Show(message);
				return;
			}

			SearchPanel panel = SearchPanelHelpers.CreatePanelForModel(model);

			TabPageEx tab = new TabPageEx()
			{
				Text = model + " Search",
				Controls =
				{
					new SearchTab(panel)
					{
						TrackerContext = this.Context,
						Owner = this,
						Dock = DockStyle.Fill,
					}
				}
			};
			this.TabControl.TabPages.Add(tab);
			this.TabControl.SelectTab(tab);
		}

		private void QuitMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		public void ResetMenus()
		{
			this.TrackerDisconnectMenuItem.Visible = this.Context.SessionSet;
			this.TrackertestManualMenuItem.Visible = !this.Context.SessionSet;
			this.SearchMenu.Visible = this.Context.SessionSet;
			this.SelectEventMenuItem.Visible = this.Context.SessionSet;
			this.CreateMenu.Visible = this.Context.SessionSet;
			this.TasksMenu.Visible = this.Context.SessionSet;
		}

		private void TrackertestManualMenuItem_Click(object sender, EventArgs e)
		{
			ConnectOpenIDManualForm form = new ConnectOpenIDManualForm(this)
			{
				Context = this.Context
			};
			form.ShowInTaskbar = false;
			form.ShowDialog(this);

			this.ResetMenus();
		}

		private void TrackerDisconnectMenuItem_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show(this, "Are you sure you want to disconnect?", "Confirm Disconnect...", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
			{
				this.Context.ClearSessionId();
				this.ResetMenus();
			}
		}

		private void OnTabClose(object sender, CloseEventArgs e)
		{
			TabPage toClose = this.TabControl.TabPages[e.TabIndex];

			var controls = toClose.Controls.Cast<Control>().Where(c => c is ITab);

			if (!controls.Any() || (controls.First() as ITab).ConfirmClose())
			{
				this.TabControl.Controls.Remove(toClose);
			}
		}

		private void selectEventToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SelectEventDialog dialog = new SelectEventDialog(this, this.Context);
			dialog.ShowInTaskbar = false;
			dialog.Show(this);
		}

		private void donorToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.OpenSearchTab("donor");
		}

		private void donationToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.OpenSearchTab("donation");
		}

		private void prizeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.OpenSearchTab("prize");
		}

		private void runToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.OpenSearchTab("run");
		}

		private void choiceToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.OpenSearchTab("choice");
		}

		private void challengeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.OpenSearchTab("challenge");
		}

		private void prizeCategoryToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.OpenSearchTab("prizecategory");
		}

		private void CreateDonorMenuItem_Click(object sender, EventArgs e)
		{
			this.CreateNewDonor();
		}

		private void donationToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			this.CreateNewDonation();
		}

		private void prizeToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			this.CreateNewPrize();
		}

		private void runToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			this.CreateNewRun();
		}

		private void choiceToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			this.CreateNewChoice();
		}

		private void challengeToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			this.CreateNewChallenge();
		}

		private void prizeCategoryToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			this.CreateNewPrizeCategory();
		}

		private void readTaskToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.OpenReadTaskTab();
		}
	}
}
