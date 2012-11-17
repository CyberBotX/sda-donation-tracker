using System.Linq;
using System.Windows.Forms;
using System;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace SDA_DonationTracker
{
	// TODO:
	// - Figure out how to react to error responses, and forward them to the
	// ui as appropriate (possibly using the response data to fill the invalid fields)
	// - figure out a way to abstract the common refresh/save/delete buttons for
	// different entity tabs
	// - Figure out how to deal with the donations/prizes on a given donor
	//   -> i.e. load them on refresh, and navigate-to/add buttons for those tables
	public partial class DonorTab : UserControl, EntityTab
	{
		public string Model { get { return "donor"; } }
		public int? Id { get; set; }

		public TrackerContext TrackerContext { get; set; }
		public MainForm Owner { get; set; }

		private FormBinding FormBinding;

		public DonorTab()
		{
			this.InitializeComponent();

			this.FormBinding = new FormBinding();

			this.FormBinding.AddBinding("firstname", this.FirstNameText);
			this.FormBinding.AddBinding("lastname", this.LastNameText);
			this.FormBinding.AddBinding("alias", this.AliasText);
			this.FormBinding.AddBinding("email", this.EmailText);

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
				this.Owner.SetTabName(this, "New Donor");
			else
				this.Owner.SetTabName(this, "Donor#" + this.Id);
		}

		public void RefreshData()
		{
			if (!this.EnableRefresh())
				return;

			if (this.TrackerContext == null)
				throw new Exception("Error, TrackerContext not set.");

			SearchContext donorSearch = this.TrackerContext.DeferredSearch("donor", Util.CreateSearchParams("id", this.Id.ToString()));

			donorSearch.OnComplete += results =>
			{
				this.FormBinding.LoadObject(results.First());
				this.FormBinding.EnableControls();
				this.ResetControlButtonStates();
				this.ResetName();
			};

			donorSearch.OnError += () =>
			{
				this.FormBinding.EnableControls();
				this.ResetControlButtonStates();

				// TODO: put up some kind of message indicating an error
			};

			this.FormBinding.DisableControls();
			donorSearch.Begin();
		}

		public void SaveData()
		{
			if (!this.EnableSave())
				return;

			if (this.TrackerContext == null)
				throw new Exception("Error, TrackerContext not set.");

			SaveContext saveContext = this.TrackerContext.DeferredSave("donor", this.GetSaveParams(this.FormBinding));

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

		public void DeleteData()
		{
			if (!this.EnableDelete())
				return;

			if (this.TrackerContext == null)
				throw new Exception("Error, TrackerContext not set.");

			DeleteContext deleteContext = this.TrackerContext.DeferredDelete("donor", Id ?? 0);

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

		private void SaveButton_Click(object sender, EventArgs e)
		{
			SaveData();
		}

		private void RefreshButton_Click(object sender, EventArgs e)
		{
			RefreshData();
		}

		private void DeleteButton_Click(object sender, EventArgs e)
		{
			DeleteData();
		}
	}
}
