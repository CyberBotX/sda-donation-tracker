using System;
using System.Collections.Generic;

namespace SDA_DonationTracker
{
	// TODO: 
	// - finish adding the other models, and linking them up appropriately
	public static class DonationModels
	{
		public static readonly EntityModel EventModel = new EntityModel("event",
			new Dictionary<string, FieldModel>()
			{
				{ "short", new StringFieldModel() },
				{ "name", new StringFieldModel() },
				{ "date", new DateTimeFieldModel() },
			},
			new Dictionary<string, SearchFieldModel>()
			{
				{ "short", new SearchFieldModel(new StringFieldModel(), "short") },
				{ "name", new SearchFieldModel(new StringFieldModel(), "name") },
				{ "date", new SearchFieldModel(new DateTimeFieldModel(), "date") },
			},
			JObjectEntityHelpers.GetEventDisplayName);

		public static readonly EntityModel DonorModel = new EntityModel("donor",
			new Dictionary<string, FieldModel>()
			{
				{ "firstname", new StringFieldModel() },
				{ "lastname", new StringFieldModel() },
				{ "alias", new StringFieldModel() },
				{ "email", new StringFieldModel() },
				{ "donations", new EntitySetModel("donation") },
			},
			new Dictionary<string, SearchFieldModel>()
			{
				{ "firstname", new SearchFieldModel(new StringFieldModel(), "firstname") },
				{ "lastname", new SearchFieldModel(new StringFieldModel(), "lastname") },
				{ "alias", new SearchFieldModel(new StringFieldModel(), "alias") },
				{ "email", new SearchFieldModel(new StringFieldModel(), "email") },
			},
			JObjectEntityHelpers.GetDonorDisplayName);

		public static readonly EntityModel DonationModel = new EntityModel("donation",
			new Dictionary<string, FieldModel>()
			{
				{ "domain", new EnumFieldModel(typeof(DonationDomain)) },
				{ "domainId", new StringFieldModel() },
				{ "bidstate", new EnumFieldModel(typeof(DonationBidState)) },
				{ "readstate", new EnumFieldModel(typeof(DonationReadState)) },
				{ "commentstate", new EnumFieldModel(typeof(DonationCommentState)) }, 
				{ "amount", new MoneyFieldModel() },
				{ "timereceived", new DateTimeFieldModel() },
				{ "donor", new EntityFieldModel("donor") },
				{ "modcomment", new StringFieldModel() },
				{ "comment", new StringFieldModel() },
				{ "event", new EntityFieldModel("event") },
			},
			new Dictionary<string, SearchFieldModel>()
			{
				{ "time_lte", new SearchFieldModel(new DateTimeFieldModel(), "timereceived") },
				{ "time_gte", new SearchFieldModel(new DateTimeFieldModel(), "timereceived") },
				{ "domain", new SearchFieldModel(new EnumFieldModel(typeof(DonationDomain)), null) },
				{ "domainId", new SearchFieldModel(new StringFieldModel(), null) },
				{ "amount_lte", new SearchFieldModel(new MoneyFieldModel(), "amount") },
				{ "amount_gte", new SearchFieldModel(new MoneyFieldModel(), "amount") },
				{ "comment", new SearchFieldModel(new StringFieldModel(), "comment") },
				{ "modcomment", new SearchFieldModel(new StringFieldModel(), "modcomment") },
				{ "bidstate", new SearchFieldModel(new EnumFieldModel(typeof(DonationBidState)), "bidstate") },
				{ "readstate", new SearchFieldModel(new EnumFieldModel(typeof(DonationReadState)), "readstate") },
				{ "commentstate", new SearchFieldModel(new EnumFieldModel(typeof(DonationCommentState)), "commentstate") },
			},
			JObjectEntityHelpers.GetDonationDisplayName);

		public static readonly EntityModel RunModel = new EntityModel("run",
			new Dictionary<string, FieldModel>()
			{
				{ "event", new EntityFieldModel("event") },
				{ "name", new StringFieldModel() },
				{ "runner", new StringFieldModel() },
				{ "description", new StringFieldModel() },
				{ "starttime", new DateTimeFieldModel() },
				{ "endtime", new DateTimeFieldModel() },
			},
			new Dictionary<string, SearchFieldModel>()
			{
				{ "name", new SearchFieldModel(new StringFieldModel(), "name") },
				{ "runner", new SearchFieldModel(new StringFieldModel(), "runner") },
				{ "description", new SearchFieldModel(new StringFieldModel(), "description") },
			},
			JObjectEntityHelpers.GetRunDisplayName);

		public static readonly EntityModel PrizeModel = new EntityModel("prize",
			new Dictionary<string, FieldModel>()
			{
				{ "event", new EntityFieldModel("event") },
				{ "name", new StringFieldModel() },
				{ "description", new StringFieldModel() },
				{ "provided", new StringFieldModel() },
				{ "pin", new BooleanFieldModel() },
			},
			new Dictionary<string, SearchFieldModel>()
			{
				{ "name", new SearchFieldModel(new StringFieldModel(), "name") },
				{ "description", new SearchFieldModel(new StringFieldModel(), "description") },
				{ "provided", new SearchFieldModel(new StringFieldModel(), "provided") },
			},
			JObjectEntityHelpers.GetPrizeDisplayName);

		public static readonly EntityModel ChoiceModel = new EntityModel("choice",
			new Dictionary<string, FieldModel>()
			{
				{ "speedrun", new EntityFieldModel("run") },
				{ "name", new StringFieldModel() },
				{ "description", new StringFieldModel() },
				{ "state", new EnumFieldModel(typeof(BidState)) },
				{ "pin", new BooleanFieldModel() },
			},
			new Dictionary<string, SearchFieldModel>()
			{
				{ "runname", new SearchFieldModel(new StringFieldModel(), null) },
				{ "name", new SearchFieldModel(new StringFieldModel(), "name") },
				{ "description", new SearchFieldModel(new StringFieldModel(), "description") },
			},
			JObjectEntityHelpers.GetChoiceDisplayName);

		public static readonly EntityModel ChallengeModel = new EntityModel("choice",
			new Dictionary<string, FieldModel>()
			{
				{ "speedrun", new EntityFieldModel("run") },
				{ "name", new StringFieldModel() },
				{ "description", new StringFieldModel() },
				{ "goal", new MoneyFieldModel() },
				{ "state", new EnumFieldModel(typeof(BidState)) },
				{ "pin", new BooleanFieldModel() },
			},
			new Dictionary<string, SearchFieldModel>()
			{
				{ "runname", new SearchFieldModel(new StringFieldModel(), null) },
				{ "name", new SearchFieldModel(new StringFieldModel(), "name") },
				{ "description", new SearchFieldModel(new StringFieldModel(), "description") },
			},
			JObjectEntityHelpers.GetChallengeDisplayName);

		public static readonly EntityModel ChoiceOptionModel = new EntityModel("choiceoption",
			new Dictionary<string, FieldModel>()
			{
				{ "choice", new EntityFieldModel("choice") },
				{ "name", new StringFieldModel() },
				{ "description", new StringFieldModel() },
				{ "state", new EnumFieldModel(typeof(BidState)) },
				{ "pin", new BooleanFieldModel() },
			},
			new Dictionary<string, SearchFieldModel>()
			{
				{ "runname", new SearchFieldModel(new StringFieldModel(), null) },
				{ "choicename", new SearchFieldModel(new StringFieldModel(), null) },
				{ "name", new SearchFieldModel(new StringFieldModel(), "name") },
			},
			JObjectEntityHelpers.GetOptionDisplayName);

		public static readonly EntityModel ChoiceBidModel = new EntityModel("choicebid",
			new Dictionary<string, FieldModel>()
			{
				{ "option", new EntityFieldModel("choiceoption") },
				{ "amount", new MoneyFieldModel() },
				{ "donation", new EntityFieldModel("donation") },
			},
			new Dictionary<string, SearchFieldModel>() { },
			JObjectEntityHelpers.GetChoiceBidDisplayName);

		public static readonly EntityModel ChallengeBidModel = new EntityModel("challengebid",
			new Dictionary<string, FieldModel>()
			{
				{ "challenge", new EntityFieldModel("challenge") },
				{ "amount", new MoneyFieldModel() },
				{ "donation", new EntityFieldModel("donation") },
			},
			new Dictionary<string, SearchFieldModel>() { },
			JObjectEntityHelpers.GetChallengeBidDisplayName);

		private static Dictionary<string, EntityModel> ModelMap = new Dictionary<string, EntityModel>(StringComparer.OrdinalIgnoreCase)
		{
			{ "donor", DonorModel },
			{ "donation", DonationModel },
			{ "run", RunModel },
			{ "choice", ChoiceModel },
			{ "challenge", ChallengeModel },
			{ "choiceoption", ChoiceOptionModel },
			{ "prize", PrizeModel },
			{ "challengebid", ChallengeBidModel },
			{ "choicebid", ChoiceBidModel },
		};

		public static EntityModel GetModel(string name)
		{
			EntityModel result;
			if (DonationModels.ModelMap.TryGetValue(name, out result))
				return result;
			else
				return null;
		}
	}
}
