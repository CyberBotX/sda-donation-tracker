using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SDA_DonationTracker
{
	public interface ITab
	{
		// return true to allow this tab to be closed, false otherwise
		bool ConfirmClose();
	}
}
