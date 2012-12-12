namespace SDA_DonationTracker
{
	// TODO: 
	// - do this for all of the other entities
	// - The searching for enum values is pretty unreasonable
	// - Searching for date values doesn't work
	public partial class SearchDonationPanel : SearchPanel
	{
		public SearchDonationPanel()
			: base(DonationModels.DonationModel,
			new string[]
			{
				"time_lte",
				"time_gte",
				"amount_lte",
				"amount_gte",
				"comment",
			})
		{
			this.InitializeComponent();
		}
	}
}
