using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SDA_DonationTracker
{
	public class DonationEditPanel : EntityEditPanel
	{
		private TableLayoutPanel RootPanel;
		private EntityFormPanelConstruct FormPanel;
		private EntityTablePanelConstruct BidsPanel;

		public DonationEditPanel(MainForm owner, TrackerContext context)
			: base("donation", context, owner)
		{
			this.RootPanel = new TableLayoutPanel()
			{
				Dock = DockStyle.Fill,
				ColumnCount = 1,
				RowCount = 2,
				ColumnStyles =
				{
					new ColumnStyle(SizeType.Percent, 100.0f),
				},
				RowStyles =
				{
					new RowStyle(SizeType.Percent, 60.0f),
					new RowStyle(SizeType.Percent, 40.0f),
				},
			};

			this.FormPanel = new EntityFormPanelConstruct("donation",
				new string[]
				{
					"domain",
					"domainId",
					"timereceived",
					"amount",
					"donor",
					"comment",
					"modcomment",
					"readstate",
					"commentstate",
					"bidstate",
				},
				this.Context,
				this.Owner
			)
			{
				Dock = DockStyle.Fill,
			};

			this.BidsPanel = new EntityTablePanelConstruct("donationbid", this.Owner, this.Context,
				new string[]
				{
					"amount",
					"target",
				}
			)
			{
				Dock = DockStyle.Fill,
				AddAllowed = true,
			};

			this.BidsPanel.Binding.AddModelMapping("choicebid",
				new Dictionary<string, string>()
				{
					{ "amount", "amount" },
					{ "option", "target" },
				});

			this.BidsPanel.Binding.AddModelMapping("challengebid",
				new Dictionary<string, string>()
				{
					{ "amount", "amount" },
					{ "challenge", "target" },
				});

			this.RootPanel.Controls.Add(this.FormPanel, 0, 0);
			this.RootPanel.Controls.Add(this.BidsPanel, 0, 1);
			this.Controls.Add(this.RootPanel);
		}

		public override IEnumerable<FormBinding> Forms
		{
			get 
			{ 
				return new FormBinding[]{ this.FormPanel.Binding }; 
			}
		}

		public override IEnumerable<TableBinding> Tables
		{
			get 
			{ 
				return new TableBinding[]{ this.BidsPanel.Binding }; 
			}
		}
	}
}
