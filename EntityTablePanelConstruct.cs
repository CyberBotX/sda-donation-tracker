using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;

namespace SDA_DonationTracker
{
	public class EntityTablePanelConstruct : EntityTablePanel
	{
		private DataGridView Table;
		private TableLayoutPanel RootLayout;
		private Panel ButtonsPanel;
		private Button NavigateToButton;
		private Label TableLabel;
		private Button AddInstanceButton;

		public MainForm Owner { get; private set; }

		public bool AddAllowed
		{
			get
			{
				return this.AddInstanceButton.Visible;
			}
			set
			{
				this.AddInstanceButton.Visible = value;
			}
		}

		public bool NavigateAllowed
		{
			get
			{
				return this.Owner != null && this.Owner.IsNavigable(this.ModelName);
			}
		}

		public TrackerContext Context
		{
			get
			{
				return this.Binding.Context;
			}
		}

		public EntityTablePanelConstruct(string modelName, MainForm owner, TrackerContext context, params string[] columns)
			: base(modelName)
		{
			this.Owner = owner;

			this.Table = new DataGridView()
			{
				Dock = DockStyle.Fill,
				SelectionMode = DataGridViewSelectionMode.FullRowSelect,
				MultiSelect = false,
				AutoSize = true,
				AllowUserToAddRows = false,
				TabIndex = 1,
			};
			this.SetTableBinding(new TableBinding(this.Table, columns) { Context = context });
			
			if (!DonationModels.GetModel(modelName).IsAbstract)
				this.Binding.AddDefaultModelMapping(modelName);

			this.TableLabel = new Label()
			{
				Text = Util.SymbolToNatural(modelName) + "s"
			};

			this.NavigateToButton = new Button()
			{
				Text = "Open",
				Visible = this.NavigateAllowed,
			};
			this.NavigateToButton.Click += (o, e) =>
			{
				this.OpenSelectedEntities();
			};

			this.AddInstanceButton = new Button()
			{
				Text = "New",
			};
			this.AddInstanceButton.Click += (o, e) =>
			{
				this.CreateNewEntity();
			};

			this.ButtonsPanel = new FlowLayoutPanel()
			{
				FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight,
				Dock = DockStyle.Fill,
				AutoSize = true,
				AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink,
				Controls = 
				{
					this.TableLabel, 
					this.NavigateToButton,
					this.AddInstanceButton,
				},
				TabIndex = 0,
			};

			this.RootLayout = new TableLayoutPanel()
			{
				Dock = DockStyle.Fill,
				ColumnCount = 1,
				RowCount = 2,
			};
			this.RootLayout.RowStyles.Add(new RowStyle() { SizeType = System.Windows.Forms.SizeType.AutoSize, });
			this.RootLayout.RowStyles.Add(new RowStyle() { SizeType = System.Windows.Forms.SizeType.Percent, Height = 100.0f, });

			this.RootLayout.Controls.Add(this.Table, 0, 1);
			this.RootLayout.Controls.Add(this.ButtonsPanel, 0, 0);

			this.Controls.Add(this.RootLayout);

			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;

			this.Binding.AddAssociatedControl(this.ButtonsPanel);
		}

		private void CreateNewEntity()
		{
			IEnumerable<string> models = this.Binding.GetModelNames();

			if (models.Count() > 1)
			{
				SelectModelTypeDialog dialog = new SelectModelTypeDialog(models);

				dialog.ShowDialog();

				if (dialog.Selection != null)
				{
					this.Binding.AddRow(JObjectEntityHelpers.CreateEntityObject(dialog.Selection));
				}
			}
			else
			{
				this.Binding.AddRow(JObjectEntityHelpers.CreateEntityObject(models.First()));
			}
		}

		private void OpenSelectedEntities()
		{
			if (this.NavigateAllowed)
			{
				foreach (DataGridViewRow row in this.Table.SelectedRows)
				{
					DataRowView result = row.DataBoundItem as DataRowView;
					int? key = result[TableBinding.KeyColumn] as int?;
					string model = result[TableBinding.ModelColumn] as string;

					if (key != null)
						this.Owner.NavigateTo(model, key ?? 0);
					else
						MessageBox.Show("Cannot navigate to a non-persistent instance.  Save this object first.");
				}
			}
		}

		protected override void Dispose(bool disposing)
		{
			foreach (Control control in this.Controls)
			{
				control.Dispose();
			}

			base.Dispose(disposing);
		}
	}
}
