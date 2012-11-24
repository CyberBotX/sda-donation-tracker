using System;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace SDA_DonationTracker
{
	public partial class RunTab : UserControl, EntityTab
	{
		public string Model
		{
			get { return "run"; }
		}

		public int? Id { get; set; }

		public TrackerContext TrackerContext { get; set; }
		public MainForm Owner { get; set; }

		private FormBinding FormBinding;
		private JObject CachedObject;

		public RunTab()
		{
			this.InitializeComponent();

			this.FormBinding = new FormBinding();
			this.FormBinding.AddBinding("name", this.NameText);
			this.FormBinding.AddBinding("runners", this.RunnersText);
			this.FormBinding.AddBinding("description", this.DescriptionText);
			this.FormBinding.AddBinding("starttime", this.StartTimePicker);
			this.FormBinding.AddBinding("endtime", this.EndTimePicker);

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
			if (this.CachedObject == null)
				this.Owner.SetTabName(this, "New Run");
			else
				this.Owner.SetTabName(this, this.CachedObject.GetRunDisplayName());
		}

		public void RefreshData()
		{
			if (!this.EnableRefresh())
				return;

			if (this.TrackerContext == null)
				throw new Exception("Error, TrackerContext not set.");

			SearchContext runSearch = this.TrackerContext.DeferredSearch(this.Model, Util.CreateSearchParams("id", this.Id.ToString()));

			runSearch.OnComplete += (results) =>
			{
				this.CachedObject = results.First() as JObject;
				this.FormBinding.LoadObject(this.CachedObject);
				this.FormBinding.EnableControls();
				this.ResetControlButtonStates();
				this.ResetName();
			};

			runSearch.OnError += () =>
			{
				this.FormBinding.EnableControls();
				this.ResetControlButtonStates();

				// TODO: put up some kind of message indicating an error
			};

			// TODO read in the donations and table them

			this.FormBinding.DisableControls();
			runSearch.Begin();
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
