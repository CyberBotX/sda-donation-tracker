using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SDA_DonationTracker
{
	public class ChoiceEditPanel : EntityEditPanel
	{
		private TableLayoutPanel RootPanel;
		private EntityFormPanelConstruct ChoiceForm;
		private EntityTablePanelConstruct OptionsTable;

		public ChoiceEditPanel(MainForm owner, TrackerContext context)
			: base("choice", context, owner)
		{
			this.RootPanel = new TableLayoutPanel()
			{
				Dock = DockStyle.Fill,
				RowCount = 2,
				ColumnCount = 1,
				RowStyles = 
				{
					new RowStyle(SizeType.Percent, 60.0f),
					new RowStyle(SizeType.Percent, 40.0f),
				},
				ColumnStyles =
				{
					new ColumnStyle(SizeType.Percent, 100.0f),
				},
			};

			this.ChoiceForm = new EntityFormPanelConstruct("choice",
				new string[]
				{
					"total",
					"name",
					"description",
					"state",
					"speedrun",
				},
				this.Context,
				this.Owner
			)
			{
				Dock = DockStyle.Fill,
			};

			this.OptionsTable = new EntityTablePanelConstruct("choiceoption",
				this.Owner, this.Context,
				new string[]
				{
					"name",
					"total",
				}
			)
			{
				Dock = DockStyle.Fill,
			};

			this.RootPanel.Controls.Add(this.ChoiceForm, 0, 0);
			this.RootPanel.Controls.Add(this.OptionsTable, 0, 1);
			this.Controls.Add(this.RootPanel);
		}

		public override IEnumerable<FormBinding> Forms
		{
			get { return new FormBinding[] { this.ChoiceForm.Binding }; }
		}

		public override IEnumerable<TableBinding> Tables
		{
			get { return new TableBinding[] { this.OptionsTable.Binding }; }
		}
	}
}
