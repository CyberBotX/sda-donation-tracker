using System.Linq;
using System.Windows.Forms;
using System;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Data;

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
		private TableBinding TableBinding;
		private JObject CachedObject;

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

			this.TableBinding = new TableBinding(this.DonationTable, "domain", "timereceived", "amount", "comment");
			this.TableBinding.AddDefaultModelMapping("donation");
			this.TableBinding.AddAssociatedControl(this.OpenDonationButton);

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
			if (this.CachedObject == null)
				this.Owner.SetTabName(this, "New Donor");
			else
				this.Owner.SetTabName(this, this.CachedObject.GetDonorDisplayName());
		}

		public void RefreshData()
		{
			if (!this.EnableRefresh())
				return;

			if (this.TrackerContext == null)
				throw new Exception("Error, TrackerContext not set.");

			SearchContext donorSearch = this.TrackerContext.DeferredSearch(this.Model, Util.CreateSearchParams("id", this.Id.ToString()));

			donorSearch.OnComplete += (results) =>
			{
				this.CachedObject = results.First() as JObject;
				this.FormBinding.LoadObject(this.CachedObject);
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

			SearchContext donationSearch = this.TrackerContext.DeferredSearch("donation", Util.CreateSearchParams("donor", this.Id.ToString()));

			donationSearch.OnComplete += (results) =>
			{
				this.TableBinding.LoadArray(results);
				this.TableBinding.EnableControls();
			};

			donationSearch.OnError += () =>
			{
				this.TableBinding.EnableControls();
			};

			// TODO read in the donations and table them

			this.FormBinding.DisableControls();
			donorSearch.Begin();
			this.TableBinding.DisableControls();
			donationSearch.Begin();
		}

		public void SaveData()
		{
			if (!this.EnableSave())
				return;

			if (this.TrackerContext == null)
				throw new Exception("Error, TrackerContext not set.");

			SaveContext saveContext = this.TrackerContext.DeferredSave(this.Model, this.GetSaveParams(this.FormBinding));

			saveContext.OnComplete += (result) =>
			{
				this.Id = result.Value<int>("pk");
				this.CachedObject = result;
				this.FormBinding.LoadObject(this.CachedObject);
				this.FormBinding.EnableControls();
				this.TableBinding.EnableControls();
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
			this.TableBinding.DisableControls();
			saveContext.Begin();
		}

		public void DeleteData()
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

		private void OpenDonationButton_Click(object sender, EventArgs e)
		{
			foreach (DataGridViewRow row in this.DonationTable.SelectedRows)
			{
				DataRowView result = row.DataBoundItem as DataRowView;
				int key = result[TableBinding.KeyColumn] as int? ?? 0;
				string model = result[TableBinding.ModelColumn] as string;

				this.Owner.NavigateTo(model, key);
			}
		}
	}
}
