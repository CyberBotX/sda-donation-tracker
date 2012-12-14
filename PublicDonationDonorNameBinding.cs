using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace SDA_DonationTracker
{
	class PublicDonorNameBinding : InstanceBinding
	{
		public Control BoundControl
		{
			get { return this.BoundText; }
		}

		private TextBox BoundText;
		private bool PublicFacing;

		public PublicDonorNameBinding(TextBox text, bool publicFacing)
		{
			this.PublicFacing = publicFacing;
			this.BoundText = text;
			this.BoundText.ReadOnly = true;
		}

		public void LoadInstance(JObject instance)
		{
			if (instance.GetModel().IEquals("donation"))
				this.LoadText(instance.GetDonationDonorDisplayName(this.PublicFacing));
			else if (instance.GetModel().IEquals("donor"))
				this.LoadText(instance.GetDonorDisplayName(this.PublicFacing));
			else
				throw new Exception("Error, this only works with donation or donor entities");
		}

		private void LoadText(string text)
		{
			this.BoundText.InvokeEx(() => this.BoundText.Text = text);
		}
	}
}
