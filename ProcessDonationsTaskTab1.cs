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
	public enum ProcessDonationsMode
	{
		BOTH,
		BIDS,
		COMMMENTS,
	}

	public partial class ProcessDonationsTaskTab1: UserControl
	{
		public TrackerContext Context
		{
			get
			{
				return _Context;
			}
			set
			{
				_Context = value;
				this.DonorSelector.Initialize(value, "donor");
			}
		}

		public MainForm Owner
		{
			get
			{
				return _Owner;
			}
			set
			{
				_Owner = value;
				this.DonorSelector.Owner = value;
			}
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

		private MainForm _Owner;
		private TrackerContext _Context;
		private FormBinding DonationBinding;
		private ListBinding<JObjectEntityDisplay> SearchBinding;
		private ComboBoxBinding ModeBinding;
		private JObject CurrentObject;

		public ProcessDonationsTaskTab1()
		{
			InitializeComponent();

			this.DonationBinding = new FormBinding("donation");
			this.DonationBinding.AddBinding("donor", this.DonorSelector);
			this.DonationBinding.AddBinding("amount", new MoneyFieldBinding(this.AmountText, allowNull: false));
			this.DonationBinding.AddBinding("comment", new TextBoxBinding(this.CommentText, nullable: false, longText: true));
			this.DonationBinding.AddBinding("modcomment", new TextBoxBinding(this.ModCommentText, nullable: false, longText: true));
			this.DonationBinding.AddBinding("readstate", this.ReadStateBox, typeof(DonationReadState));
			this.DonationBinding.AddBinding("commentstate", this.CommentStateBox, typeof(DonationCommentState));
			this.DonationBinding.AddBinding("bidstate", this.BidStateBox, typeof(DonationBidState));
			
			this.DonationBinding.AddAssociatedControl(this.OpenDonorButton);
			this.DonationBinding.AddAssociatedControl(this.OpenDonationButton);
			this.DonationBinding.AddAssociatedControl(this.NextButton);

			this.ModeBinding = new ComboBoxBinding(this.ModeBox, typeof(ProcessDonationsMode));

			this.SearchBinding = new ListBinding<JObjectEntityDisplay>(this.TaskList, x => new JObjectFuncDisplay(x, DonationModels.DonationModel.DisplayConverter), "Display");
			this.SearchBinding.AddAssociatedControl(this.RefreshButton);
			this.SearchBinding.AddAssociatedControl(this.NextButton);
			this.SearchBinding.AddAssociatedControl(this.ModeBox);

			this.ModeBinding.LoadField(ProcessDonationsMode.COMMMENTS.ToString());

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

		private bool HasMode(ProcessDonationsMode mode)
		{
			return this.GetDonationsMode() == mode || this.GetDonationsMode() == ProcessDonationsMode.BOTH;
		}

		private ProcessDonationsMode GetDonationsMode()
		{
			return (ProcessDonationsMode)Enum.Parse(typeof(ProcessDonationsMode), this.ModeBinding.RetreiveField());
		}

		private Dictionary<string, string> GetCommentSearchParams()
		{
			Dictionary<string, string> result = new Dictionary<string, string>();

			result["commentstate"] = DonationCommentState.PENDING.ToString();
			
			// TODO: also check that comment is not null when that becomes possible

			return result;
		}

		private Dictionary<string, string> GetBidSearchParams()
		{
			Dictionary<string, string> result = new Dictionary<string, string>();

			result["bidstate"] = DonationBidState.PENDING.ToString();

			return result;
		}

		public void RefreshData()
		{
			if (this.Context == null)
				throw new Exception("Error, no context set for this task.");

			List<SearchContext> searches = new List<SearchContext>();

			ProcessDonationsMode mode = this.GetDonationsMode();

			if (this.HasMode(ProcessDonationsMode.BIDS))
				searches.Add(this.Context.DeferredSearch("donation", this.GetBidSearchParams()));

			if (this.HasMode(ProcessDonationsMode.COMMMENTS))
				searches.Add(this.Context.DeferredSearch("donation", this.GetCommentSearchParams()));

			AggregateSearchContext metaSearcher = new AggregateSearchContext(searches.ToArray());

			metaSearcher.Completed += this.OnSearchComplete;
			metaSearcher.Error += this.OnSearchError;

			this.DonationBinding.DisableControls();
			this.SearchBinding.DisableControls();

			metaSearcher.Begin();
		}

		private void OnSearchError(IEnumerable<TrackerError> errors)
		{
			string message = errors.First().Message;
			this.InvokeEx(() => MessageBox.Show("Error, could not refresh task list: " + message, "Refresh Error"));
			if (this.Owner != null)
				this.Owner.SetStatusMessage(message);
			this.SearchBinding.EnableControls();
		}

		private void OnSearchComplete(JArray results)
		{
			Dictionary<int, JObject> mapped = new Dictionary<int, JObject>();

			// Donations are returned in reverse chronological order, but we 
			// want to read them in chronological order
			foreach (JObject tok in results)
			{
				mapped[tok.GetId() ?? 0] = tok;
			}

			List<JObject> aggregatedResults = mapped.Values.ToList();

			aggregatedResults.Sort(JObjectEntityHelpers.CompareDonationsByTime);

			JArray reversed = new JArray();

			foreach (JObject tok in aggregatedResults)
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
				JObject currObject = this.CurrentObject;
				JObject savingObject = this.DonationBinding.SaveObject();
				JObject diffedObject = this.DonationBinding.SaveObject(diffOnly: true);

				if (this.HasMode(ProcessDonationsMode.COMMMENTS) && !diffedObject.HasField("commentstate") && savingObject.GetField("commentstate").IEquals(DonationCommentState.PENDING.ToString()))
				{
					diffedObject.SetField("commentstate", DonationCommentState.APPROVED.ToString());
				}

				if (this.HasMode(ProcessDonationsMode.BIDS) && !diffedObject.HasField("bidstate") && savingObject.GetField("bidstate").IEquals(DonationBidState.PENDING.ToString()))
				{
					diffedObject.SetField("bidstate", DonationBidState.PROCESSED.ToString());
				}

				if (diffedObject.GetFields().Any())
				{
					SaveContext saver = this.Context.DeferredSave("donation", Util.BuildSaveParams(diffedObject));

					saver.OnComplete += (obj) =>
					{
						currObject.MergeFrom(obj);
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
