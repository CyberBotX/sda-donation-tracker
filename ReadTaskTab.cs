using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace SDA_DonationTracker
{
	public enum ReadTaskVolumeMode
	{
		LOW,
		HIGH,
	}

	public partial class ReadTaskTab : UserControl
	{
		private static readonly int DefaultMinimumMinuteOffset = 5;
		private static readonly decimal DefaultMinimumAmount = 1.00m;
		private static readonly ReadTaskVolumeMode DefaultVolumeMode = ReadTaskVolumeMode.LOW;

		public TrackerContext Context
		{
			get;
			set;
		}

		public MainForm Owner
		{
			get;
			set;
		}

		public bool IsBound
		{
			get
			{
				return this.BoundId != null;
			}
		}

		public int? BoundId
		{
			get
			{
				return this.DonationBinding.GetBoundId();
			}
		}

		private FormBinding DonationBinding;
		private ListBinding<JObjectEntityDisplay> SearchBinding;
		private MoneyFieldBinding MinimumAmountBinding;
		private IntFieldBinding MinimumMinutesBinding;
		private ComboBoxBinding ModeBinding;
		private JObject CurrentObject;

		public ReadTaskTab()
		{
			InitializeComponent();

			this.DonationBinding = new FormBinding("donation");
			this.DonationBinding.AddInstanceBinding(new PublicDonorNameBinding(this.DonorNameText, true));
			this.DonationBinding.AddBinding("amount", new MoneyFieldBinding(this.AmountText, readOnly: true, allowNull: false));
			this.DonationBinding.AddBinding("comment", new TextBoxBinding(this.CommentText, readOnly: true, nullable: false, longText: true));
			this.DonationBinding.AddBinding("modcomment", new TextBoxBinding(this.ModCommentText, readOnly: true, nullable: false, longText: true));
			this.DonationBinding.AddBinding("readstate", this.ReadStateBox, typeof(DonationReadState));
			this.DonationBinding.AddBinding("commentstate", this.CommentStateBox, typeof(DonationCommentState));
			this.DonationBinding.AddBinding("bidstate", this.BidStateBox, typeof(DonationBidState));

			this.DonationBinding.AddAssociatedControl(this.OpenDonorButton);
			this.DonationBinding.AddAssociatedControl(this.OpenDonationButton);
			this.DonationBinding.AddAssociatedControl(this.NextButton);

			this.MinimumAmountBinding = new MoneyFieldBinding(this.MinimumAmountText);
			this.MinimumMinutesBinding = new IntFieldBinding(this.MinimumMinutesText);
			this.ModeBinding = new ComboBoxBinding(this.ModeBox, typeof(ReadTaskVolumeMode));

			this.SearchBinding = new ListBinding<JObjectEntityDisplay>(this.TaskList, x => new JObjectFuncDisplay(x, DonationModels.DonationModel.DisplayConverter), "Display");
			this.SearchBinding.AddAssociatedControl(this.RefreshButton);
			this.SearchBinding.AddAssociatedControl(this.MinimumAmountText);
			this.SearchBinding.AddAssociatedControl(this.MinimumMinutesText);
			this.SearchBinding.AddAssociatedControl(this.ModeBox);

			this.MinimumAmountBinding.LoadField(DefaultMinimumAmount.ToString());
			this.MinimumMinutesBinding.LoadField(DefaultMinimumMinuteOffset.ToString());
			this.ModeBinding.LoadField(DefaultVolumeMode.ToString());

			this.SearchBinding.OnSelection += this.OnSelection;

			this.CurrentObject = null;
		}

		private void OnSelection(IEnumerable<JObjectEntityDisplay> selections)
		{
			if (selections.Any())
			{
				this.CurrentObject = selections.Single().Source;
				this.DonationBinding.LoadObject(this.CurrentObject);
				this.DonationBinding.EnableControls();
			}
			else
			{
				this.CurrentObject = null;
				this.DonationBinding.DisableControls();
			}
		}

		private DateTime GetSearchOffsetTime()
		{
			int result;

			if (int.TryParse(this.MinimumMinutesBinding.RetreiveField(), out result))
				return DateTime.Now.AddMinutes(-result);
			else
				return DateTime.Now;
		}

		private ReadTaskVolumeMode GetVolumeMode()
		{
			return (ReadTaskVolumeMode) Enum.Parse(typeof(ReadTaskVolumeMode), this.ModeBinding.RetreiveField());
		}

		private Dictionary<string, string> GetSearchParams()
		{
			Dictionary<string, string> result = new Dictionary<string, string>();

			result["time_lte"] = DateTimeFieldModel.SerializeDate(this.GetSearchOffsetTime());
			result["readstate"] = DonationBidState.PENDING.ToString();

			string amountString = this.MinimumAmountBinding.RetreiveField();
			
			if (amountString != null)
				result["amount_gte"] = amountString;

			if (this.GetVolumeMode() == ReadTaskVolumeMode.HIGH)
			{
				result["commentstate"] = DonationCommentState.APPROVED.ToString();
			}

			return result;
		}

		public void RefreshData()
		{
			if (this.Context == null)
				throw new Exception("Error, no context set for this task.");

			SearchContext searcher = this.Context.DeferredSearch("donation", this.GetSearchParams());

			searcher.OnComplete += this.OnSearchComplete;
			searcher.OnError += this.OnSearchError;

			this.DonationBinding.DisableControls();
			this.SearchBinding.DisableControls();

			searcher.Begin();
		}

		private void OnSearchError(TrackerErrorType error, string message)
		{
			this.InvokeEx(() => MessageBox.Show("Error, could not refresh task list: " + message, "Refresh Error"));
			if (this.Owner != null)
				this.Owner.SetStatusMessage(message);
			this.SearchBinding.EnableControls();
		}

		private void OnSearchComplete(JArray results)
		{
			JArray reversed = new JArray();

			// Donations are returned in reverse chronological order, but we 
			// want to read them in chronological order
			foreach (var tok in results.Reverse())
			{
				reversed.Add(tok);
			}

			this.SearchBinding.LoadArray(reversed);
			this.SearchBinding.EnableControls();
		}

		private void OpenDonationButton_Click(object sender, EventArgs e)
		{
			if (this.IsBound && this.Owner != null)
				this.Owner.NavigateToDonation(this.BoundId);
		}

		private void OpenDonorButton_Click(object sender, EventArgs e)
		{
			if (this.IsBound && this.Owner != null)
			{
				int result;
				if (int.TryParse(this.CurrentObject.GetField("donor"), out result))
					this.Owner.NavigateToDonor(int.Parse(this.CurrentObject.GetField("donor")));
			}
		}

		private void RefreshButton_Click(object sender, EventArgs e)
		{
			this.RefreshData();
		}

		private void MarkCurrentAsDone()
		{
			if (this.CurrentObject != null)
			{
				JObject savingObject = this.DonationBinding.SaveObject();
				JObject diffedObject = this.DonationBinding.SaveObject(diffOnly: true);

				if (!diffedObject.HasField("readstate") && savingObject.GetField("readstate").IEquals(DonationReadState.PENDING.ToString()))
				{
					diffedObject.SetField("readstate", DonationReadState.READ.ToString());
				}

				if (diffedObject.GetFields().Any())
				{
					SaveContext saver = this.Context.DeferredSave("donation", Util.BuildSaveParams(diffedObject));

					saver.OnComplete += (obj) =>
					{
						savingObject.MergeFrom(obj);
					};

					saver.Begin();
				}
			}
		}

		private void NextButton_Click(object sender, EventArgs e)
		{
			if (this.CurrentObject != null)
			{
				this.MarkCurrentAsDone();

				if (this.TaskList.SelectedIndex < this.TaskList.Items.Count - 1)
				{
					this.TaskList.SelectedIndex += 1;
				}
			}
		}


	}
}
