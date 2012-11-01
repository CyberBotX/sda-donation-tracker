using System.Linq;
using System.Windows.Forms;

namespace SDA_DonationTracker
{
	public partial class DonorTab : UserControl
	{
		private FormBinding FormBinding;
		private TrackerContext Context;
		private SearchContext CurrentDonorSearch;
		private int Id;

		public DonorTab(TrackerContext context, int id)
		{
			this.Id = id;
			this.InitializeComponent();

			this.Context = context;

			this.FormBinding = new FormBinding();

			this.FormBinding.AddBinding("firstname", this.FirstNameText);
			this.FormBinding.AddBinding("lastname", this.LastNameText);
			this.FormBinding.AddBinding("alias", this.AliasText);
			this.FormBinding.AddBinding("email", this.EmailText);

			this.RefreshData();
		}

		private void RefreshData()
		{
			this.CurrentDonorSearch = this.Context.DeferredSearch("donor", Util.CreateSearchParams("id", this.Id.ToString()));

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
