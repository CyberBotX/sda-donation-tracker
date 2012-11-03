using System.Linq;
using System.Windows.Forms;
using System;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace SDA_DonationTracker
{
	// TODO:
	// - figure out a way to have the refresh/delete buttons disable if 
	// id is null
	// - Have this maintain a reference to the main form, and figure 
	// out how to remove itself on delete
	// - Figure out how to react to error responses, and forward them to the
	// ui as appropriate (possibly using the response data to fill the invalid fields)
	// - figure out a way to abstract the common refresh/save/delete buttons for
	// different entity tabs
	// - Figure out how to deal with the donations/prizes on a given donor
	//   -> i.e. load them on refresh, and navigate-to/add buttons for those tables
	public partial class DonorTab : UserControl
	{
		public TrackerContext TrackerContext { get; set; }
		public int? Id { get; set; }

		private FormBinding FormBinding;
		private SearchContext CurrentDonorSearch;

		public DonorTab()
		{
			this.InitializeComponent();

			this.FormBinding = new FormBinding();

			this.FormBinding.AddBinding("firstname", this.FirstNameText);
			this.FormBinding.AddBinding("lastname", this.LastNameText);
			this.FormBinding.AddBinding("alias", this.AliasText);
			this.FormBinding.AddBinding("email", this.EmailText);
		}

		public void RefreshData()
		{
			if (this.TrackerContext == null)
			{
				throw new Exception("Error, TrackerContext not set.");
			}

			if (this.Id == null)
			{
				throw new Exception("Error, Id not set.");
			}

			this.CurrentDonorSearch = this.TrackerContext.DeferredSearch("donor", Util.CreateSearchParams("id", this.Id.ToString()));

			this.CurrentDonorSearch.OnComplete += results =>
			{
				this.FormBinding.LoadObject(results.First());
				this.FormBinding.EnableControls();
			};

			this.FormBinding.DisableControls();
			this.CurrentDonorSearch.Begin();
		}

		private Dictionary<string, string> GetSaveParams()
		{
			Dictionary<string, string> result = new Dictionary<string, string>();

			JObject data = this.FormBinding.SaveObject();

			JObject fields = data.Value<JObject>("fields");

			foreach (var field in this.FormBinding.GetBindingKeys())
			{
				result.Add(field, fields.Value<string>(field));
			}

			if (this.Id != null)
			{
				result.Add("id", this.Id.ToString());
			}

			return result;
		}

		public void SaveData()
		{
			SaveContext saveContext = this.TrackerContext.DeferredSave("donor", GetSaveParams());

			saveContext.OnComplete += (result) =>
			{
				this.Id = result.Value<int>("pk");

				this.FormBinding.LoadObject(result);
				this.FormBinding.EnableControls();
			};

			this.FormBinding.DisableControls();
			saveContext.Begin();
		}

		public void DeleteData()
		{
			DeleteContext deleteContext = this.TrackerContext.DeferredDelete("donor", Id ?? 0);

			deleteContext.OnComplete += (result) =>
			{

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
