using System;
using System.Linq;
using System.Windows.Forms;

namespace SDA_DonationTracker
{
	// TODO: figure out a reasonable way to deal with tabbing:
	// - there should be a way to cut down on the repetitious code between different tab initializations
	public partial class MainForm : Form
	{
		private static readonly string[] NavigableEntities = new string[]
		{
			"donor",
			"donation",
			"run",
			"choice",
			"challenge",
			"prize",
			"bid",
			"prizecategory",
		};

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
				var controls = page.Controls.Cast<Control>().Where(c => c is EntityTab);

				if (controls.Count() == 1)
				{
					var result = controls.Single() as EntityTab;

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
			return NavigableEntities.Contains(model);
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
				if (model.IEquals("donor"))
					this.NavigateToDonor(id);
				else if (model.IEquals("donation"))
					this.NavigateToDonation(id);
				else if (model.IEquals("prize"))
					this.NavigateToPrize(id);
				else if (model.IEquals("prizecategory"))
					this.NavigateToPrizeCategory(id);
				else if (model.IEquals("run"))
					this.NavigateToRun(id);
				else if (model.IEquals("choice"))
					this.NavigateToChoice(id);
				else if (model.IEquals("challenge"))
					this.NavigateToChallenge(id);
				else
					throw new Exception("Error, navigation to " + model + " not supported");
			}
		}

		private void NavigateToDonor(int? id)
		{
			DonorTab content = new DonorTab(this, this.Context)
			{
				Dock = DockStyle.Fill,
			};

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

		private void NavigateToDonation(int? id)
		{
			DonationTab form = new DonationTab(this, this.Context)
			{
				Dock = DockStyle.Fill,
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
			form.SetInstanceId(id);
		}

		private void NavigateToPrize(int? id)
		{
			PrizeTab content = new PrizeTab(this, this.Context)
			{
				Dock = DockStyle.Fill,
			};

			TabPageEx prizeTab = new TabPageEx()
			{
				Controls =
				{
					content
				}
			};

			this.TabControl.TabPages.Add(prizeTab);
			this.TabControl.SelectTab(prizeTab);

			content.SetInstanceId(id);
		}

		private void NavigateToPrizeCategory(int? id)
		{
			PrizeCategoryTab content = new PrizeCategoryTab(this, this.Context)
			{
				Dock = DockStyle.Fill,
			};

			TabPageEx prizeTab = new TabPageEx()
			{
				Controls =
				{
					content
				}
			};

			this.TabControl.TabPages.Add(prizeTab);
			this.TabControl.SelectTab(prizeTab);

			content.SetInstanceId(id);
		}

		private void NavigateToRun(int? id)
		{
			RunTab form = new RunTab(this, this.Context)
			{
				Dock = DockStyle.Fill,
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

			form.SetInstanceId(id);
		}

		public void NavigateToChoice(int? id)
		{
			ChoiceTab form = new ChoiceTab(this, this.Context)
			{
				Dock = DockStyle.Fill,
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

			form.SetInstanceId(id);
		}

		public void NavigateToChallenge(int? id)
		{
			ChallengeTab form = new ChallengeTab(this, this.Context)
			{
				Dock = DockStyle.Fill,
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

			form.SetInstanceId(id);
		}

		public void CreateNewChoice()
		{
			this.NavigateToChoice(null);
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

		private void donorToolStripMenuItem_Click(object sender, EventArgs e)
		{
			TabPageEx donorTab = new TabPageEx()
			{
				Text = "Donor Search",
				Controls =
				{
					new SearchTab(new SearchDonorPanel())
					{
						TrackerContext = this.Context,
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
			SelectEventDialog dialog = new SelectEventDialog(this, this.Context);
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
						TrackerContext = this.Context,
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
						TrackerContext = this.Context,
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
						TrackerContext = this.Context,
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

		private void choiceToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			this.CreateNewChoice();
		}

		private void choiceToolStripMenuItem_Click(object sender, EventArgs e)
		{
			TabPageEx choiceTab = new TabPageEx()
			{
				Text = "Choice Search",
				Controls =
				{
					new SearchTab(new SearchChoicePanel())
					{
						TrackerContext = this.Context,
						Owner = this,
						Dock = DockStyle.Fill
					}
				}
			};
			this.TabControl.TabPages.Add(choiceTab);
			this.TabControl.SelectTab(choiceTab);
		}

		private void challengeToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			this.CreateNewChallenge();
		}

		private void challengeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			TabPageEx challengeSearchTab = new TabPageEx()
			{
				Text = "Challenge Search",
				Controls =
				{
					new SearchTab(new SearchChallengePanel())
					{
						TrackerContext = this.Context,
						Owner = this,
						Dock = DockStyle.Fill
					}
				}
			};
			this.TabControl.TabPages.Add(challengeSearchTab);
			this.TabControl.SelectTab(challengeSearchTab);
		}

		private void prizeCategoryToolStripMenuItem_Click(object sender, EventArgs e)
		{
			TabPageEx prizeCategorySearchTab = new TabPageEx()
			{
				Text = "Prize Category Search",
				Controls =
				{
					new SearchTab(new SearchPrizeCategoryPanel())
					{
						TrackerContext = this.Context,
						Owner = this,
						Dock = DockStyle.Fill
					}
				}
			};
			this.TabControl.TabPages.Add(prizeCategorySearchTab);
			this.TabControl.SelectTab(prizeCategorySearchTab);
		}

		private void prizeCategoryToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			this.CreateNewPrizeCategory();
		}
	}
}
