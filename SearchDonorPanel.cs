namespace SDA_DonationTracker
{
	public partial class SearchDonorPanel : SearchPanel
	{
		public SearchDonorPanel()
			: base(DonationModels.DonorModel,
			new string[]
			{
				"firstname", "lastname", "alias", "email"
			})
		{
			this.InitializeComponent();
		}
	}
}
