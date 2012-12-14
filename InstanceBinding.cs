using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace SDA_DonationTracker
{
	public interface InstanceBinding
	{
		Control BoundControl { get; }
		void LoadInstance(JObject instance);
	}
}
