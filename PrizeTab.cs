using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace SDA_DonationTracker
{
	public class PrizeTab : EntityTab
	{
		private EntityFormPanelConstruct PrizeForm;
		private TableLayoutPanel RootPanel;
		private Button DrawPrizeButton;
		private TextBox DrawResultsText;

		public PrizeTab(MainForm owner, TrackerContext context)
			: base(owner, context, "prize")
		{
			this.RootPanel = new TableLayoutPanel()
			{
				Dock = DockStyle.Fill,
				RowCount = 2,
				ColumnCount = 2,
				RowStyles = 
				{
					new RowStyle(SizeType.Percent, 100.0f),
					new RowStyle(SizeType.AutoSize),
				},
				ColumnStyles =
				{
					new ColumnStyle(SizeType.AutoSize),
					new ColumnStyle(SizeType.Percent, 100.0f),
				},
			};

			this.PrizeForm = new EntityFormPanelConstruct(this.ModelName,
				new string[]
				{
					"name", 
					"image",
					"category",
					"minimumbid",
					"maximumbid",
					"sumdonations",
					"randomdraw",
					"provided",
					"description",
					"winner",
					"startrun",
					"endrun",
					"starttime",
					"endtime",
					"pin",
				}, this.Context, this.Owner)
				{
					Dock = DockStyle.Fill,
				};

			this.DrawPrizeButton = new Button()
			{
				Text = "Draw Prize",
			};
			this.DrawPrizeButton.Click += (o, e) =>
			{
				this.RunPrizeDraw();
			};

			this.DrawResultsText = new TextBox()
			{
				ReadOnly = true,
				Dock = DockStyle.Fill,
			};

			this.RootPanel.Controls.Add(this.PrizeForm, 0, 0);
			this.RootPanel.SetColumnSpan(this.PrizeForm, 2);
			this.RootPanel.Controls.Add(this.DrawPrizeButton, 0, 1);
			this.RootPanel.Controls.Add(this.DrawResultsText, 1, 1);

			this.SetPanel(this.RootPanel);
			this.PrizeForm.Binding.AddAssociatedControl(this.DrawPrizeButton);
			this.AddForm(this.PrizeForm.Binding);
		}

		private void RunPrizeDraw()
		{
			if (this.PrizeForm.Id != null)
			{
				this.DrawPrizeButton.Enabled = false;

				PrizeAssignContext context = this.Context.DeferredPrizeAssign(this.PrizeForm.Id ?? 0);

				context.Completed += (response) =>
				{
					this.DrawPrizeButton.InvokeEx(() => this.DrawPrizeButton.Enabled = true);

					JObject result = JObject.Parse(response);

					this.PrizeForm.Binding.LoadSingleField("winner", result["winner"].ToString());

					this.DrawResultsText.InvokeEx(() => this.DrawResultsText.Text = response);
				};

				context.OnError += (type, msg) =>
				{
					this.DrawPrizeButton.InvokeEx(() => this.DrawPrizeButton.Enabled = true);
					this.DrawResultsText.InvokeEx(() => this.DrawResultsText.Text = msg);
				};

				context.Begin();
			}
		}
	}
}
