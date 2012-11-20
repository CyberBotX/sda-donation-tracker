using System;
using System.Windows.Forms;
using System.Linq;

namespace SDA_DonationTracker
{
	// TODO: figure out a reasonable way to deal with tabbing:
	// - there should be a way to cut down on the repetitious code between different tab initializations
	public partial class MainForm : Form
	{
		public TrackerContext TrackerContext = new TrackerContext();

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
				var controls = page.Controls.Cast<Control>().Where(c => c is EntityTab);

				if (controls.Count() == 1)
				{
					var result = controls.Single() as EntityTab;

					if (result.Id == id && result.Model == model)
					{
						return page;
					}
				}
			}

			return null;
		}

		public void NavigateTo(string model, int id)
		{
			TabPageEx alreadyExists = this.FindTabOf(model, id);

			// if a tab to the specified entity exists already, simply select that tab rather than create a new one
			if (alreadyExists != null)
			{
				this.TabControl.SelectedTab = alreadyExists;
			}
			else
			{
				if (model.Equals("donor", StringComparison.OrdinalIgnoreCase))
					this.NavigateToDonor(id);
				else if (model.Equals("donation", StringComparison.OrdinalIgnoreCase))
					this.NavigateToDonation(id);
				else if (model.Equals("prize", StringComparison.OrdinalIgnoreCase))
					this.NavigateToPrize(id);
				else if (model.Equals("run", StringComparison.OrdinalIgnoreCase))
					this.NavigateToRun(id);
				else
					throw new Exception("Error, navigation to " + model + " not supported");
			}
		}

		private void NavigateToDonor(int id)
		{
			DonorTab form = new DonorTab()
			{
				Id = id,
				TrackerContext = this.TrackerContext,
				Dock = DockStyle.Fill,
				Owner = this,
			};

			TabPageEx donorTab = new TabPageEx()
			{
				Controls =
				{
					form
				}
			};

			this.TabControl.TabPages.Add(donorTab);
			this.TabControl.SelectTab(donorTab);
			form.RefreshData();
		}

		private void NavigateToDonation(int id)
		{
			DonationTab form = new DonationTab()
			{
				Id = id,
				TrackerContext = this.TrackerContext,
				Dock = DockStyle.Fill,
				Owner = this,
			};

			TabPageEx donationTab = new TabPageEx()
			{
				Controls =
				{
					form
				}
			};

			this.TabControl.TabPages.Add(donationTab);
			this.TabControl.SelectTab(donationTab);
			form.RefreshData();
		}

		private void NavigateToPrize(int id)
		{
			PrizeTab form = new PrizeTab()
			{
				Id = id,
				TrackerContext = this.TrackerContext,
				Dock = DockStyle.Fill,
				Owner = this,
			};

			TabPageEx prizeTab = new TabPageEx()
			{
				Controls =
				{
					form
				}
			};

			this.TabControl.TabPages.Add(prizeTab);
			this.TabControl.SelectTab(prizeTab);
			form.RefreshData();
		}

		private void NavigateToRun(int id)
		{
			RunTab form = new RunTab()
			{
				Id = id,
				TrackerContext = this.TrackerContext,
				Dock = DockStyle.Fill,
				Owner = this,
			};

			TabPageEx runTab = new TabPageEx()
			{
				Controls =
				{
					form
				}
			};

			this.TabControl.TabPages.Add(runTab);
			this.TabControl.SelectTab(runTab);
			form.RefreshData();
		}

		private void QuitMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		public void ResetMenus()
		{
			this.TrackerDisconnectMenuItem.Visible = this.TrackerContext.SessionSet;
			this.TrackertestManualMenuItem.Visible = !this.TrackerContext.SessionSet;
			this.SearchMenu.Visible = this.TrackerContext.SessionSet;
			this.SelectEventMenuItem.Visible = this.TrackerContext.SessionSet;
			this.CreateMenu.Visible = this.TrackerContext.SessionSet;
		}

		public void CreateNewDonor()
		{
			DonorTab form = new DonorTab()
			{
				Id = null,
				TrackerContext = this.TrackerContext,
				Dock = DockStyle.Fill,
				Owner = this,
			};

			TabPageEx donorTab = new TabPageEx()
			{
				Text = "New Donor",
				Controls =
				{
					form
				}
			};

			this.TabControl.TabPages.Add(donorTab);
			this.TabControl.SelectTab(donorTab);
		}

		public void CreateNewDonation()
		{
			DonationTab form = new DonationTab()
			{
				Id = null,
				TrackerContext = this.TrackerContext,
				Dock = DockStyle.Fill,
				Owner = this,
			};

			TabPageEx donationTab = new TabPageEx()
			{
				Text = "New Donation",
				Controls =
				{
					form
				}
			};

			this.TabControl.TabPages.Add(donationTab);
			this.TabControl.SelectTab(donationTab);
		}

		public void CreateNewPrize()
		{
			PrizeTab form = new PrizeTab()
			{
				Id = null,
				TrackerContext = this.TrackerContext,
				Dock = DockStyle.Fill,
				Owner = this,
			};

			TabPageEx prizeTab = new TabPageEx()
			{
				Text = "New Prize",
				Controls =
				{
					form
				}
			};

			this.TabControl.TabPages.Add(prizeTab);
			this.TabControl.SelectTab(prizeTab);
		}

		public void CreateNewRun()
		{
			RunTab form = new RunTab()
			{
				Id = null,
				TrackerContext = this.TrackerContext,
				Dock = DockStyle.Fill,
				Owner = this,
			};

			TabPageEx runTab = new TabPageEx()
			{
				Text = "New Run",
				Controls =
				{
					form
				}
			};

			this.TabControl.TabPages.Add(runTab);
			this.TabControl.SelectTab(runTab);
		}

		private void TrackertestManualMenuItem_Click(object sender, EventArgs e)
		{
			ConnectOpenIDManualForm form = new ConnectOpenIDManualForm()
			{
				Context = this.TrackerContext
			};
			form.ShowInTaskbar = false;
			form.ShowDialog(this);

			this.ResetMenus();
		}

		private void TrackerDisconnectMenuItem_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show(this, "Are you sure you want to disconnect?", "Confirm Disconnect...", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
			{
				this.TrackerContext.ClearSessionId();
				this.ResetMenus();
			}
		}

		private void donorToolStripMenuItem_Click(object sender, EventArgs e)
		{
			TabPageEx donorTab = new TabPageEx()
			{
				Text = "Donor Search",
				Controls =
				{
					new SearchTab(new SearchDonorPanel())
					{
						TrackerContext = this.TrackerContext,
						Owner = this,
						Dock = DockStyle.Fill,
					}
				}
			};
			this.TabControl.TabPages.Add(donorTab);
			this.TabControl.SelectTab(donorTab);
		}

		private void OnTabClose(object sender, CloseEventArgs e)
		{
			// eventually this should ask the current tab if it wants to close first
			this.TabControl.Controls.Remove(this.TabControl.TabPages[e.TabIndex]);
		}

		private void selectEventToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SelectEventDialog dialog = new SelectEventDialog(this, this.TrackerContext);
			dialog.ShowInTaskbar = false;
			dialog.Show(this);
		}

		private void donationToolStripMenuItem_Click(object sender, EventArgs e)
		{
			TabPageEx donationTab = new TabPageEx()
			{
				Text = "Donation Search",
				Controls =
				{
					new SearchTab(new SearchDonationPanel())
					{
						TrackerContext = this.TrackerContext,
						Owner = this,
						Dock = DockStyle.Fill
					}
				}
			};
			this.TabControl.TabPages.Add(donationTab);
			this.TabControl.SelectTab(donationTab);
		}
		
		private void CreateDonorMenuItem_Click(object sender, EventArgs e)
		{
			this.CreateNewDonor();
		}

		private void donationToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			this.CreateNewDonation();
		}

		private void prizeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			TabPageEx prizeTab = new TabPageEx()
			{
				Text = "Prize Search",
				Controls =
				{
					new SearchTab(new SearchPrizePanel())
					{
						TrackerContext = this.TrackerContext,
						Owner = this,
						Dock = DockStyle.Fill
					}
				}
			};
			this.TabControl.TabPages.Add(prizeTab);
			this.TabControl.SelectTab(prizeTab);
		}

		private void runToolStripMenuItem_Click(object sender, EventArgs e)
		{
			TabPageEx runTab = new TabPageEx()
			{
				Text = "Run Search",
				Controls =
				{
					new SearchTab(new SearchRunPanel())
					{
						TrackerContext = this.TrackerContext,
						Owner = this,
						Dock = DockStyle.Fill
					}
				}
			};
			this.TabControl.TabPages.Add(runTab);
			this.TabControl.SelectTab(runTab);
		}

		private void prizeToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			this.CreateNewPrize();
		}

		private void runToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			this.CreateNewRun();
		}
	}
}
