using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace SDA_DonationTracker
{
	public class EntityFormPanelConstruct : EntityFormPanel
	{
		public TrackerContext Context { get; private set; }
		public MainForm Owner { get; private set; }

		private TableLayoutPanel TableLayout;

		public EntityFormPanelConstruct(string modelName, IEnumerable<string> fields, TrackerContext context = null, MainForm owner = null)
			: base(modelName)
		{
			this.Context = context;
			this.Owner = owner;

			this.TableLayout = new TableLayoutPanel()
			{
				Dock = DockStyle.Fill,
				AutoSize = true,
				AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink,
			};
			this.TableLayout.ColumnCount = 2;
			this.TableLayout.ColumnStyles.Add(new ColumnStyle() { SizeType = SizeType.AutoSize });
			this.TableLayout.ColumnStyles.Add(new ColumnStyle() { SizeType = SizeType.Percent, Width = 100.0f });

			foreach (var fieldName in fields)
			{
				++this.TableLayout.RowCount;
				RowStyle currentRowStyle = new RowStyle()
				{
					SizeType = SizeType.AutoSize,
				};
				this.TableLayout.RowStyles.Add(currentRowStyle);

				FieldModel fieldModel = this.Model.GetField(fieldName);

				Label label = new Label()
				{
					Text = Util.SymbolToNatural(fieldName),
					Dock = DockStyle.Right,
				};

				this.TableLayout.Controls.Add(label, 0, this.TableLayout.RowCount - 1);

				FieldBinding fieldBinding = FieldBindingHelper.CreateBindingField(fieldModel, fieldName, this.Context, this.Owner);
				fieldBinding.BoundControl.Dock = DockStyle.Fill;

				if (IsLargeField(fieldModel))
				{
					++this.TableLayout.RowCount;
					RowStyle nextRowStyle = new RowStyle()
					{
						SizeType = SizeType.Percent,
						Height = 100.0f,
					};
					this.TableLayout.RowStyles.Add(nextRowStyle);
					this.TableLayout.Controls.Add(fieldBinding.BoundControl, 0, this.TableLayout.RowCount - 1);
					this.TableLayout.SetColumnSpan(fieldBinding.BoundControl, 2);
				}
				else
				{
					this.TableLayout.Controls.Add(fieldBinding.BoundControl, 1, this.TableLayout.RowCount - 1);
				}

				Binding.AddBinding(fieldName, fieldBinding);
			}

			++this.TableLayout.RowCount;
			this.TableLayout.RowStyles.Add(new RowStyle() { SizeType = System.Windows.Forms.SizeType.Percent, Height = 100.0f });

			this.Controls.Add(this.TableLayout);

			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
		}

		private static bool IsLargeField(FieldModel fieldModel)
		{
			if (fieldModel is StringFieldModel)
			{
				return (fieldModel as StringFieldModel).LongText;
			}
			else
			{
				return false;
			}
		}

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
		}
	}
}
