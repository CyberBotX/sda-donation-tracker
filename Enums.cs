namespace SDA_DonationTracker
{
	public enum DonationDomain
	{
		LOCAL,
		CHIPIN,
	}

	public enum DonationBidState
	{
		PENDING,
		IGNORED,
		PROCESSED,
		FLAGGED,
	}

	public enum DonationReadState
	{
		PENDING,
		IGNORED,
		READ,
		FLAGGED,
	}

	public enum DonationCommentState
	{
		PENDING,
		DENIED,
		APPROVED,
		FLAGGED,
	}

	public enum BidState
	{
		HIDDEN,
		OPENED,
		CLOSED,
	}
}
