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
	public partial class PrizeTab : UserControl, EntityTab
	{
		public string Model { get { return "prize"; } }
		public int? Id { get; set; }

		public TrackerContext TrackerContext
		{
			get
			{
				return _TrackerContext;
			}
			set
			{
				_TrackerContext = value;
				this.WinnerSelector.Initialize(value, "donor", new string[] { "lastname", "firstname" });
			}
		}

		public MainForm Owner
		{
			get
			{
				return this._Owner;
			}
			set
			{
				_Owner = value;
				this.WinnerSelector.Owner = value;
			}
		}

		private TrackerContext _TrackerContext;
		private MainForm _Owner;

		private FormBinding FormBinding;
		private string PrizeName;

		public PrizeTab()
		{
			InitializeComponent();

			this.FormBinding = new FormBinding();
			this.FormBinding.AddBinding("name", this.NameText);
			this.FormBinding.AddBinding("provided", this.ProvidedByText);
			this.FormBinding.AddBinding("image", this.ImageURLText);
			this.FormBinding.AddBinding("description", this.DescriptionText);
			this.FormBinding.AddBinding("winner", this.WinnerSelector);

			this.FormBinding.AddAssociatedControl(this.RefreshButton);
			this.FormBinding.AddAssociatedControl(this.SaveButton);
			this.FormBinding.AddAssociatedControl(this.DeleteButton);

			this.ResetControlButtonStates();
		}

		private void ResetControlButtonStates()
		{
			this.RefreshButton.InvokeEx(() => this.RefreshButton.Enabled = this.EnableRefresh());
			this.SaveButton.InvokeEx(() => this.SaveButton.Enabled = this.EnableSave());
			this.DeleteButton.InvokeEx(() => this.DeleteButton.Enabled = this.EnableDelete());
		}

		private void ResetName()
		{
			if (this.Id == null)
				this.Owner.SetTabName(this, "New Prize");
			else
				this.Owner.SetTabName(this, this.PrizeName);
		}

		public void RefreshData()
		{
			if (!this.EnableRefresh())
				return;

			if (this.TrackerContext == null)
				throw new Exception("Error, TrackerContext not set.");

			SearchContext prizeSearch = this.TrackerContext.DeferredSearch(this.Model, Util.CreateSearchParams("id", this.Id.ToString()));

			prizeSearch.OnComplete += (results) =>
			{
				this.FormBinding.LoadObject(results.First());
				this.PrizeName = this.NameText.Text;
				this.FormBinding.EnableControls();
				this.ResetControlButtonStates();
				this.ResetName();
			};

			prizeSearch.OnError += () =>
			{
				this.FormBinding.EnableControls();
				this.ResetControlButtonStates();

				// TODO: put up some kind of message indicating an error
			};

			this.FormBinding.DisableControls();
			prizeSearch.Begin();
		}

		private void SaveData()
		{
			if (!this.EnableSave())
				return;

			if (this.TrackerContext == null)
				throw new Exception("Error, TrackerContext not set.");

			SaveContext saveContext = this.TrackerContext.DeferredSave(this.Model, this.GetSaveParams(this.FormBinding));

			saveContext.OnComplete += (result) =>
			{
				this.Id = result.Value<int>("pk");

				this.FormBinding.LoadObject(result);
				this.FormBinding.EnableControls();
				this.ResetControlButtonStates();
				this.ResetName();
			};

			saveContext.OnError += () =>
			{
				this.FormBinding.EnableControls();
				this.ResetControlButtonStates();

				// TODO: put up some kind of message indicating an error
			};

			this.FormBinding.DisableControls();
			saveContext.Begin();
		}

		private void DeleteData()
		{
			if (!this.EnableDelete())
				return;

			if (this.TrackerContext == null)
				throw new Exception("Error, TrackerContext not set.");

			DeleteContext deleteContext = this.TrackerContext.DeferredDelete(this.Model, Id ?? 0);

			deleteContext.OnComplete += (result) =>
			{
				Owner.RemoveTab(this);
			};

			deleteContext.OnError += () =>
			{
				this.FormBinding.EnableControls();
				this.ResetControlButtonStates();

				// TODO: put up some kind of message indicating an error
			};

			this.FormBinding.DisableControls();
			deleteContext.Begin();
		}

		private void RefreshButton_Click(object sender, EventArgs e)
		{
			this.RefreshData();
		}

		private void SaveButton_Click(object sender, EventArgs e)
		{
			this.SaveData();
		}

		private void DeleteButton_Click(object sender, EventArgs e)
		{
			this.DeleteData();
		}
	}
}
