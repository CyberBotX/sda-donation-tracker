using System;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

namespace SDA_DonationTracker
{
	// TODO: 
	// - Create a 'Process Donations' task, that can handle assigning bids and dealing with comment approval
	// - Add a way to call Chipin merge, gdoc merge, and prize drawings

	public partial class MainForm : Form
	{
		public TrackerContext Context = new TrackerContext();
		private static readonly string RootTitle = "SDA Donation Tracker";

		public MainForm()
		{
			this.InitializeComponent();

			this.StatusBarLabel.Text = "Testing...";

			this.TabControl.OnClose += this.OnTabClose;
			this.TabControl.ConfirmOnClose = false;

			this.Context.EventChanged += this.OnEventChanged;
		}

		private void OnEventChanged(TrackerContext c)
		{
			this.InvokeEx(() =>
			{
				this.Text = RootTitle + " - " + this.Context.EventName;
				this.TabControl.TabPages.Clear();
			});
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

		public void OpenProcessDonationsTaskTab()
		{
			foreach (TabPageEx page in this.TabControl.TabPages)
			{
				var controls = page.Controls.Cast<Control>().Where(c => c is ProcessDonationsTaskTab1);

				if (controls.Count() == 1)
				{
					this.TabControl.SelectTab(page);
					return;
				}
			}

			ProcessDonationsTaskTab1 processTab = new ProcessDonationsTaskTab1()
			{
				Owner = this,
				Context = this.Context,
				Dock = DockStyle.Fill,
			};

			processTab.RefreshData();

			TabPageEx tab = new TabPageEx()
			{
				Text = "Donations Task",
				Controls =
				{
					processTab
				}
			};

			this.TabControl.TabPages.Add(tab);
			this.TabControl.SelectTab(tab);
		}

		public void OpenProcessDonationsTaskTab2()
		{
			foreach (TabPageEx page in this.TabControl.TabPages)
			{
				var controls = page.Controls.Cast<Control>().Where(c => c is ProcessDonationsTaskTab2);

				if (controls.Count() == 1)
				{
					this.TabControl.SelectTab(page);
					return;
				}
			}

			ProcessDonationsTaskTab2 processTab = new ProcessDonationsTaskTab2()
			{
				Dock = DockStyle.Fill,
			};

			processTab.Initialize(this, this.Context);

			processTab.RefreshData();

			TabPageEx tab = new TabPageEx()
			{
				Text = "Donations Task MK 2",
				Controls =
				{
					processTab
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

		private void OpenExternalProcessTab(ExternalProcessTab panel, bool unique = false, bool autoStart = true)
		{
			if (unique)
			{
				foreach (TabPage page in this.TabControl.TabPages)
				{
					IEnumerable<ExternalProcessTab> processControls = page.Controls.Cast<Control>().Where(x => x is ExternalProcessTab).Cast<ExternalProcessTab>();

					if (processControls.Any() && processControls.First().TaskName.IEquals(panel.TaskName))
					{
						this.TabControl.SelectTab(page);
					}
				}
			}

			TabPageEx tab = new TabPageEx()
			{
				Text = panel.TaskName,
				Controls =
				{
					panel,
				}
			};
			this.TabControl.TabPages.Add(tab);
			this.TabControl.SelectTab(tab);

			if (autoStart)
			{
				panel.StartProcess();
			}
		}

		private void QuitMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		public void ResetMenus()
		{
      this.ManualConnectMenuItem.Visible = !this.Context.SessionSet;
			this.TrackerDisconnectMenuItem.Visible = this.Context.SessionSet;
			this.TrackerOpenIDConnectMenuItem.Visible = !this.Context.SessionSet;
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
				PanelHelpers.DeinitializeEntitySelectors(toClose);
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

		private void processDonationsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.OpenProcessDonationsTaskTab();
		}

		private void processDonations2ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.OpenProcessDonationsTaskTab2();
		}

		private void chipinMergeToolStripMenuItem_Click_1(object sender, EventArgs e)
		{
			this.OpenExternalProcessTab(new ChipinMergeTab() { Context = this.Context }, true, true);
		}

		private void scheduleMergeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.OpenExternalProcessTab(new ScheduleMergeTab() { Context = this.Context }, true, true);
		}

    private void manuallySetSessionIdToolStripMenuItem_Click(object sender, EventArgs e)
    {
      SetSessionIdForm form = new SetSessionIdForm()
      {
        Context = this.Context,
      };

      form.ShowDialog();

      this.ResetMenus();
    }
	}
}
