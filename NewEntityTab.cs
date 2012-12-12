using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SDA_DonationTracker
{
	public partial class NewEntityTab : UserControl, EntityTab
	{
		public int? Id
		{
			get
			{
				return this.Access.RootId;
			}
		}
		public MainForm Owner { get; private set; }
		public TrackerContext Context
		{
			get
			{
				return this.Access.Context;
			}
		}

		public string ModelName 
		{ 
			get
			{
				return this.Access.ModelName;
			}
		}

		public EntityModel Model
		{
			get
			{
				return this.Access.Model;
			}
		}

		private EntityAccessContext Access;

		public NewEntityTab(MainForm owner, TrackerContext context, string rootModel)
		{
			InitializeComponent();

			this.Owner = owner;

			this.Access = new EntityAccessContext(rootModel, context);

			this.Access.RefreshComplete += this.OnRefreshComplete;
			this.Access.SaveComplete += this.OnSaveComplete;
			this.Access.DeleteComplete += this.OnDeleteComplete;
			this.Access.Error += this.OnError;
		}

		// TODO: hook up the tab ctl ex thing to ask the panel for close confirmation on close
		public bool ConfirmClose()
		{
			return !this.Access.HasUnsavedChanges() || MessageBox.Show(this, "This form has unsaved changes, close anyways?", "Confirm Close...", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.Yes;
		}

		private void ResetName()
		{
			if (this.Id == null)
				this.Owner.SetTabName(this, "New " + this.ModelName);
			else
				this.Owner.SetTabName(this, this.Access.CachedData.GetDisplayName());
		}

		public void SetInstanceId(int? id)
		{
			if (id == null)
			{
				this.Access.ClearForms();
				this.OnRefreshComplete();
			}
			else
			{
				this.RunRefresh(id);
			}
		}

		// This is to allow the derived panels to set their client area controls
		// Its a bit of a hack, but its the only way I can think of to get around it
		protected void SetPanel(Control toAdd)
		{
			toAdd.Dock = DockStyle.Fill;
			this.RootTableLayout.Controls.Add(toAdd, 0, 1);
		}

		public void AddForm(FormBinding form)
		{
			this.Access.AddForm(form);
		}

		public void AddTable(TableBinding table, EntitySetModel fieldModel)
		{
			this.Access.AddTable(table, fieldModel);
		}

		private void OnRefreshComplete()
		{
			this.SetButtonStates();
			this.ResetName();
		}

		private void OnSaveComplete()
		{
			this.SetButtonStates();
			this.ResetName();
		}

		private void OnError(TrackerErrorType error, string message)
		{
			this.InvokeEx(() => MessageBox.Show(message));

			if (error == TrackerErrorType.InstanceDoesNotExist)
			{
				this.Owner.RemoveTab(this);
			}
			else
			{
				Console.WriteLine(message);
				this.SetButtonStates();
			}
		}

		private void OnDeleteComplete()
		{
			this.Owner.RemoveTab(this);
		}

		private void DisableButtons()
		{
			this.RefreshButton.InvokeEx(() => this.RefreshButton.Enabled = false);
			this.SaveButton.InvokeEx(() => this.SaveButton.Enabled = false);
			this.DeleteButton.InvokeEx(() => this.DeleteButton.Enabled = false);
		}

		private void SetButtonStates()
		{
			this.RefreshButton.InvokeEx(() => this.RefreshButton.Enabled = this.Access.RootId != null);
			this.SaveButton.InvokeEx(() => this.SaveButton.Enabled = true);
			this.DeleteButton.InvokeEx(() => this.DeleteButton.Enabled = this.Access.RootId != null);
		}

		public void RunSave()
		{
			this.DisableButtons();
			this.Access.Save();
		}

		private void SaveButton_Click(object sender, EventArgs e)
		{
			this.RunSave();
		}

		public void RunRefresh(int? newId = null)
		{
			this.DisableButtons();
			this.Access.Refresh(newId);
		}

		private void RefreshButton_Click(object sender, EventArgs e)
		{
			this.RunRefresh();
		}

		public void RunDelete()
		{
			if (MessageBox.Show(this, "Are you sure you want to delete this object?", "Confirm Delete...", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
			{
				this.DisableButtons();
				this.Access.Delete();
			}
		}

		private void DeleteButton_Click(object sender, EventArgs e)
		{
			this.RunDelete();
		}
	}
}
