using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SDA_DonationTracker
{
	public partial class DonationTab : UserControl
	{
		public TrackerContext TrackerContext { get; set; }
		public int Id { get; set; }

		private FormBinding FormBinding;
		private SearchContext CurrentDonationSearch;

		public DonationTab()
		{
			InitializeComponent();

			this.FormBinding = new FormBinding();

			this.FormBinding.AddBinding("domain", this.DomainText);
			this.FormBinding.AddBinding("timereceived", this.TimePicker);
			this.FormBinding.AddMoneyBinding("amount", this.AmountText);
			this.FormBinding.AddBinding("bidstate", this.BidStateBox, typeof(DonationBidState));
			this.FormBinding.AddBinding("readstate", this.ReadStateBox, typeof(DonationReadState));
			this.FormBinding.AddBinding("commentstate", this.CommentStateBox, typeof(DonationCommentState));
			this.FormBinding.AddBinding("comment", this.CommentText);
		}

		public void RefreshData()
		{
			if (this.TrackerContext == null)
			{
				throw new Exception("Error, TrackerContext not set.");
			}

			this.CurrentDonationSearch = this.TrackerContext.DeferredSearch("donation", Util.CreateSearchParams("id", this.Id.ToString()));

			this.CurrentDonationSearch.OnComplete += results =>
			{
				this.FormBinding.LoadObject(results.First());
				this.FormBinding.EnableControls();
			};

			this.FormBinding.DisableControls();
			this.CurrentDonationSearch.Begin();
		}
	}
}
