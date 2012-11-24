using System;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

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
				return this._TrackerContext;
			}
			set
			{
				this._TrackerContext = value;
				this.WinnerSelector.Initialize(value, "donor");
				this.StartGameSelector.Initialize(value, "run");
				this.EndGameSelector.Initialize(value, "run");
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
				this._Owner = value;
				this.WinnerSelector.Owner = value;
				this.StartGameSelector.Owner = value;
				this.EndGameSelector.Owner = value;
			}
		}

		private TrackerContext _TrackerContext;
		private MainForm _Owner;

		private FormBinding FormBinding;
		private JObject CachedObject;

		public PrizeTab()
		{
			this.InitializeComponent();

			this.FormBinding = new FormBinding();
			this.FormBinding.AddBinding("name", this.NameText);
			this.FormBinding.AddBinding("provided", this.ProvidedByText);
			this.FormBinding.AddBinding("image", this.ImageURLText);
			this.FormBinding.AddBinding("description", this.DescriptionText);
			this.FormBinding.AddBinding("winner", this.WinnerSelector);
			this.FormBinding.AddBinding("startgame", this.StartGameSelector);
			this.FormBinding.AddBinding("endgame", this.EndGameSelector);

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
				this.Owner.SetTabName(this, "New Prize");
			else
				this.Owner.SetTabName(this, this.CachedObject.GetPrizeDisplayName());
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
				this.CachedObject = results.First() as JObject;
				this.FormBinding.LoadObject(this.CachedObject);
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
