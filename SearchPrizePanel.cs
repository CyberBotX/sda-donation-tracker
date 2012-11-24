namespace SDA_DonationTracker
{
	public partial class SearchPrizePanel : SearchPanel
	{
		public SearchPrizePanel()
			: base(DonationModels.PrizeModel,
			new string[]
			{
				"name",
				"description",
				"provided",
			})
		{
			this.InitializeComponent();
		}
	}
}
