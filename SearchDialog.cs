using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace SDA_DonationTracker
{
	public class SearchDialog : Form
	{
		public JObject Result
		{
			get;
			private set;
		}

		private SearchPanel InnerPanel;
		private TableLayoutPanel RootPanel;
		private Button OpenButton;
		private Button CloseButton;

		public SearchDialog(SearchPanel panel)
		{
			this.Result = null;
			this.InnerPanel = panel;
			this.InnerPanel.AllowMultiSelect = false;
			this.InnerPanel.Dock = DockStyle.Fill;

			this.InnerPanel.OnSelect += this.OnSelection;

			this.RootPanel = new TableLayoutPanel()
			{
				RowCount = 2,
				ColumnCount = 3,
				RowStyles = 
				{
					new RowStyle(SizeType.Percent, 100.0f),
					new RowStyle(SizeType.AutoSize),
				},
				ColumnStyles =
				{
					new ColumnStyle(SizeType.Percent, 100.0f),
					new ColumnStyle(SizeType.AutoSize),
					new ColumnStyle(SizeType.AutoSize),
				},
				Dock = DockStyle.Fill,
			};

			this.CloseButton = new Button()
			{
				Text = "Cancel",
				Dock = DockStyle.Fill,
			};

			this.CloseButton.Click += (o, e) =>
			{
				this.OnCancel();
			};

			this.OpenButton = new Button()
			{
				Text = "Open",
				Dock = DockStyle.Fill,
			};

			this.OpenButton.Click += (o, e) =>
			{
				this.OnOpen();
			};

			this.RootPanel.Controls.Add(this.InnerPanel, 0, 0);
			this.RootPanel.SetColumnSpan(this.InnerPanel, 3);
			this.RootPanel.Controls.Add(this.OpenButton, 1, 1);
			this.RootPanel.Controls.Add(this.CloseButton, 2, 1);

			this.Controls.Add(this.RootPanel);
		}

		private void OnCancel()
		{
			this.Result = null;
			this.Close();
		}

		private void OnOpen()
		{
			this.Result = this.InnerPanel.GetSelectionObjects().FirstOrDefault();
			this.Close();
		}

		private void OnSelection(IEnumerable<int> selections)
		{
			this.OpenButton.Enabled = selections.Any();
		}
	}
}
