using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SDA_DonationTracker
{
	public class TrackerError : Exception
	{
		public TrackerErrorType ErrorType
		{
			get;
			private set;
		}

		public TrackerError(TrackerErrorType type, string message)
			: base(message)
		{
			this.ErrorType = type;
		}

		public static TrackerError ParseErrorResponse(string response)
		{
			return new TrackerError(TrackerErrorType.Unknown, "Unknown Error");
		}
	}
}
