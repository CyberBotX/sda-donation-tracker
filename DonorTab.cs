using System.Linq;
using System.Windows.Forms;
using System;

namespace SDA_DonationTracker
{
	public partial class DonorTab : UserControl
	{
		public TrackerContext TrackerContext { get; set; }
		public int Id { get; set; }

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

			this.CurrentDonorSearch = this.TrackerContext.DeferredSearch("donor", Util.CreateSearchParams("id", this.Id.ToString()));

			this.CurrentDonorSearch.OnComplete += results =>
			{
				this.FormBinding.LoadObject(results.First());
				this.FormBinding.EnableControls();
			};

			this.FormBinding.DisableControls();
			this.CurrentDonorSearch.Begin();
		}
	}
}
