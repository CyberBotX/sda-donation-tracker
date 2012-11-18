using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace SDA_DonationTracker
{
	public partial class DonationTab : UserControl, EntityTab
	{
		public int? Id { get; set; }
		public string Model { get { return "donation"; } }

		public TrackerContext TrackerContext 
		{
			get 
			{ 
				return _TrackerContext;
			}
			set
			{
				_TrackerContext = value;
				this.DonorSelector.Initialize(value, "donor", new string[] { "lastname", "firstname" });
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
				this.DonorSelector.Owner = value;
			}
		}

		private TrackerContext _TrackerContext;
		private MainForm _Owner;
		private FormBinding FormBinding;

		public DonationTab()
		{
			InitializeComponent();

			this.FormBinding = new FormBinding();

			this.FormBinding.AddBinding("domain", this.DomainText);
			this.FormBinding.AddBinding("timereceived", this.TimePicker);
			this.FormBinding.AddMoneyBinding("amount", this.AmountText);
			this.FormBinding.AddBinding("bidstate", this.BidStateBox, typeof(DonationBidState));
			this.FormBinding.AddBinding("readstate", this.ReadStateBox, typeof(DonationReadState));
			this.FormBinding.AddBinding("commentstate", this.CommentStateBox, typeof(DonationCommentState));
			this.FormBinding.AddBinding("comment", this.CommentText);

			this.FormBinding.AddBinding("donor", this.DonorSelector);

			this.FormBinding.AddAssociatedControl(this.RefreshButton);
			this.FormBinding.AddAssociatedControl(this.SaveButton);
			this.FormBinding.AddAssociatedControl(this.DeleteButton);

			this.ResetControlButtonStates();
		}

		private void ResetName()
		{
			if (this.Id == null)
				this.Owner.SetTabName(this, "New Donation");
			else
				this.Owner.SetTabName(this, "Donation#" + this.Id);
		}

		private void ResetControlButtonStates()
		{
			this.RefreshButton.InvokeEx(() => this.RefreshButton.Enabled = this.EnableRefresh());
			this.SaveButton.InvokeEx(() => this.SaveButton.Enabled = this.EnableSave());
			this.DeleteButton.InvokeEx(() => this.DeleteButton.Enabled = this.EnableDelete());
		}

		public void RefreshData()
		{
			if (!this.EnableRefresh())
				return;

			if (this.TrackerContext == null)
				throw new Exception("Error, TrackerContext not set.");

			SearchContext donationSearch = this.TrackerContext.DeferredSearch(this.Model, Util.CreateSearchParams("id", this.Id.ToString()));

			donationSearch.OnComplete += results =>
			{
				this.FormBinding.LoadObject(results.First());
				this.FormBinding.EnableControls();
				this.ResetControlButtonStates();
				this.ResetName();
			};

			donationSearch.OnError += () =>
			{
				this.FormBinding.EnableControls();
				this.ResetControlButtonStates();

				// TODO: put up some kind of message indicating an error
			};

			this.FormBinding.DisableControls();
			donationSearch.Begin();
		}

		public void SaveData()
		{
			if (!this.EnableSave())
				return;

			if (this.TrackerContext == null)
				throw new Exception("Error, TrackerContext not set.");

			Dictionary<string,string> saveParams = this.GetSaveParams(this.FormBinding);

			if (saveParams["domain"] == "")
			{
				saveParams["domain"] = DonationDomain.LOCAL.ToString();
				saveParams["domainId"] = saveParams["timereceived"] + DonationDomain.LOCAL.ToString();
			}

			SaveContext saveContext = this.TrackerContext.DeferredSave(this.Model, saveParams);

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

			DeleteContext deleteContext = this.TrackerContext.DeferredDelete(this.Model, this.Id ?? 0);

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
