using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace SDA_DonationTracker
{
	public class EditEntityDialog : Form
	{
		public TrackerContext Context
		{
			get;
			private set;
		}

		public void BindData(JObject data)
		{
			this.OriginalData = data;
			this.EntityForm.Binding.LoadObject(data);
		}

		public JObject RetreiveData()
		{
			return this.EntityForm.Binding.SaveObject();
		}

		public bool Cancelled { get; private set; }
		public JObject OriginalData { get; private set; }

		private TableLayoutPanel RootPanel;
		private EntityFormPanel EntityForm;
		private Button SaveButton;
		private new Button CancelButton;

		public EditEntityDialog(TrackerContext context, string model, params string[] fields)
			: this(context, new EntityFormPanelConstruct(model, fields, context: context))
		{
		}

		public EditEntityDialog(TrackerContext context, EntityFormPanel editPanel)
		{
			this.Context = context;

			this.EntityForm = editPanel;

			this.RootPanel = new TableLayoutPanel()
			{
				RowCount = 2,
				ColumnCount = 3,
				RowStyles =
				{
					new RowStyle() { SizeType = SizeType.Percent, Height = 100.0f },
					new RowStyle() { SizeType = SizeType.AutoSize },
				},
				ColumnStyles = 
				{
					new ColumnStyle() { SizeType = SizeType.Percent, Width = 100.0f },
					new ColumnStyle() { SizeType = SizeType.AutoSize },
					new ColumnStyle() { SizeType = SizeType.AutoSize },
				},
				Dock = DockStyle.Fill
			};

			this.EntityForm.Dock = DockStyle.Fill;
			this.SaveButton = new Button()
			{
				Text = "Save",
				Dock = DockStyle.Fill
			};
			this.SaveButton.Click += this.SaveButton_Click;
			this.CancelButton = new Button()
			{
				Text = "Cancel",
				Dock = DockStyle.Fill
			};
			this.CancelButton.Click += this.CancelButton_Click;

			this.RootPanel.Controls.Add(this.EntityForm, 0, 0);
			this.RootPanel.SetColumnSpan(this.EntityForm, 3);
			this.RootPanel.Controls.Add(this.SaveButton, 1, 1);
			this.RootPanel.Controls.Add(this.CancelButton, 2, 1);

			this.OriginalData = this.EntityForm.Binding.SaveObject();
		}

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
		}

		private void SaveButton_Click(object o, EventArgs e)
		{
			this.Cancelled = false;
			this.Close();
		}

		private void CancelButton_Click(object o, EventArgs e)
		{
			this.Cancelled = true;
			this.Close();
		}
	}
}
