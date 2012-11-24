namespace SDA_DonationTracker
{
	public partial class SearchRunPanel : SearchPanel
	{
		public SearchRunPanel()
			: base(DonationModels.RunModel,
			new string[]
			{
				"name",
				"runner",
				"description",
			})
		{
			this.InitializeComponent();
		}
	}
}
