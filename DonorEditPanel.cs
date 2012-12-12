using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SDA_DonationTracker
{
	public class DonorEditPanel : EntityEditPanel
	{
		private TableLayoutPanel RootPanel;
		private EntityFormPanelConstruct DonorForm;
		private EntityTablePanelConstruct DonationTable;
		private EntityTablePanelConstruct PrizeTable;

		public DonorEditPanel(MainForm owner, TrackerContext context)
			: base("donor", context, owner)
		{
			this.RootPanel = new TableLayoutPanel()
			{
				Dock = DockStyle.Fill,
				ColumnCount = 1,
				RowCount = 3,
				RowStyles =
				{
					new RowStyle(SizeType.AutoSize),
					new RowStyle(SizeType.Percent, 66.0f),
					new RowStyle(SizeType.Percent, 34.0f),
				}
			};

			this.DonorForm = new EntityFormPanelConstruct("donor",
				new string[]
				{
					"firstname",
					"lastname",
					"alias",
					"email",
					"anonymous",
				}, this.Context, this.Owner
			)
			{
				Dock = DockStyle.Fill,
			};

			this.DonationTable = new EntityTablePanelConstruct("donation",
				this.Owner,
				this.Context,
				new string[]
				{
					"domain",
					"amount",
					"comment",
					"modcomment",
					"timereceived",
				}
			)
			{
				Dock = DockStyle.Fill,
				AddAllowed = false, // maybe true...
			};

			this.PrizeTable = new EntityTablePanelConstruct("prize",
				this.Owner,
				this.Context,
				new string[]
				{
					"name",
					"provided",
					"description",
				}
			)
			{
				Dock = DockStyle.Fill,
				AddAllowed = false,
			};

			this.PrizeTable.Binding.Context = this.Context;

			this.RootPanel.Controls.Add(this.DonorForm, 0, 0);
			this.RootPanel.Controls.Add(this.DonationTable, 0, 1);
			this.RootPanel.Controls.Add(this.PrizeTable, 0, 2);

			this.Controls.Add(this.RootPanel);
		}

		public override IEnumerable<FormBinding> Forms
		{
			get
			{
				return new FormBinding[] { this.DonorForm.Binding };
			}
		}

		public override IEnumerable<TableBinding> Tables
		{
			get
			{
				return new TableBinding[] { this.DonationTable.Binding, this.PrizeTable.Binding };
			}
		}

		public FormBinding GetDonorFormBinding()
		{
			return this.DonorForm.Binding;
		}

		public TableBinding GetDonationsTableBinding()
		{
			return this.DonationTable.Binding;
		}

		public TableBinding GetPrizeTableBinding()
		{
			return this.PrizeTable.Binding;
		}
	}
}
