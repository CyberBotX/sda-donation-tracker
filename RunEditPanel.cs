using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SDA_DonationTracker
{
	/**
	 * Currently adding bids from this panel is disabled, but eventually I would like to make that 
	 * possible somehow...
	 */
	public class RunEditPanel : EntityEditPanel
	{
		private TableLayoutPanel RootPanel;
		public EntityFormPanelConstruct RunForm { get; private set; }
		public EntityTablePanelConstruct BidTable { get; private set; }
		public EntityTablePanelConstruct PrizeTable { get; private set; }

		public RunEditPanel(TrackerContext context, MainForm owner)
			: base("run", context, owner)
		{
			this.RootPanel = new TableLayoutPanel()
			{
				Dock = DockStyle.Fill,
			};

			this.RootPanel.RowCount = 2;
			this.RootPanel.ColumnCount = 2;

			this.RootPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.0f));
			this.RootPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.0f));
			this.RootPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 60.0f));
			this.RootPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 40.0f));

			this.RunForm = new EntityFormPanelConstruct(this.ModelName,
				new string[]
				{
					"name",
					"runners",
					"description",
					"starttime",
					"endtime"
				}, this.Context, this.Owner)
			{
				Dock = DockStyle.Fill
			};

			this.BidTable = new EntityTablePanelConstruct("bid",
				this.Owner,
				this.Context,
				new string[]
				{
					"name",
					"description",
					"state",
				}
			)
			{
				Dock = DockStyle.Fill,
				AddAllowed = false,
			};

			this.PrizeTable = new EntityTablePanelConstruct("prize", this.Owner, this.Context,
				new string[]
				{
					"name",
				}
			)
			{
				Dock = DockStyle.Fill,
				AddAllowed = false,
			};

			this.BidTable.Binding.AddDefaultModelMapping("choice");
			this.BidTable.Binding.AddDefaultModelMapping("challenge");
			this.PrizeTable.Binding.AddDefaultModelMapping("prize");

			this.RootPanel.Controls.Add(this.RunForm, 0, 0);
			this.RootPanel.SetColumnSpan(this.RunForm, 2);
			this.RootPanel.Controls.Add(this.BidTable, 0, 1);
			this.RootPanel.Controls.Add(this.PrizeTable, 1, 1);

			this.Controls.Add(this.RootPanel);
		}

		protected override void Dispose(bool disposing)
		{
			this.RunForm.Dispose();
			this.BidTable.Dispose();
			base.Dispose(disposing);
		}

		public override IEnumerable<FormBinding> Forms
		{
			get 
			{ 
				return new FormBinding[]{ this.RunForm.Binding };
			}
		}

		public override IEnumerable<TableBinding> Tables
		{
			get
			{
				return new TableBinding[] { this.BidTable.Binding, this.PrizeTable.Binding };
			}
		}
	}
}
