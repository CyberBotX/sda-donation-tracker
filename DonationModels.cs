using System;
using System.Linq;
using System.Collections.Generic;

namespace SDA_DonationTracker
{
	// TODO: 
	// - Add nullability and read-only constraints to fields as appropriate
	public static class DonationModels
	{
		private static readonly string[] CachingSelectionEntities = new string[]
		{
			"choiceoption",
			"challenge",
			"prize",
			"run",
			"prizecategory",
		};

		public static bool IsCachingEntity(string modelName)
		{
			return CachingSelectionEntities.Contains(modelName);
		}

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
				{ "donations", new EntitySetModel("donation", "donor", "donor", OrphanResolution.Delete) },
				{ "prizes", new EntitySetModel("prize", "winner", "winner", OrphanResolution.Null) },
				{ "anonymous", new BooleanFieldModel() },
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
				{ "domain", new EnumFieldModel(typeof(DonationDomain), readOnly: true) },
				{ "domainId", new StringFieldModel(readOnly: true) },
				{ "bidstate", new EnumFieldModel(typeof(DonationBidState)) },
				{ "readstate", new EnumFieldModel(typeof(DonationReadState)) },
				{ "commentstate", new EnumFieldModel(typeof(DonationCommentState)) }, 
				{ "amount", new MoneyFieldModel() },
				{ "timereceived", new DateTimeFieldModel() },
				{ "donor", new EntityFieldModel("donor") },
				{ "modcomment", new StringFieldModel(longText: true) },
				{ "comment", new StringFieldModel(longText: true) },
				{ "event", new EntityFieldModel("event") },
				{ "bids", new EntitySetModel("donationbid", "donation", "donation", OrphanResolution.Delete) },
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
				{ "runners", new StringFieldModel() },
				{ "description", new StringFieldModel(longText: true) },
				{ "starttime", new DateTimeFieldModel() },
				{ "endtime", new DateTimeFieldModel() },
				{ "bids", new EntitySetModel("bid", "speedrun", "run", OrphanResolution.Null) },
				//{ "drawPrizes", new EntitySetModel("prize", "endgame", OrphanResolution.Null) },
			},
			new Dictionary<string, SearchFieldModel>()
			{
				{ "name", new SearchFieldModel(new StringFieldModel(), "name") },
				{ "runner", new SearchFieldModel(new StringFieldModel(), "runner") },
				{ "description", new SearchFieldModel(new StringFieldModel(), "description") },
			},
			JObjectEntityHelpers.GetRunDisplayName);

		public static readonly EntityModel PrizeCategoryModel = new EntityModel("prizecategory",
			new Dictionary<string, FieldModel>()
			{
				{ "name", new StringFieldModel() },
			},
			new Dictionary<string, SearchFieldModel>()
			{
				{ "name", new SearchFieldModel(new StringFieldModel(), "name") },
			},
			JObjectEntityHelpers.GetPrizeCategoryDisplayName);

		public static readonly EntityModel PrizeModel = new EntityModel("prize",
			new Dictionary<string, FieldModel>()
			{
				{ "event", new EntityFieldModel("event") },
				{ "name", new StringFieldModel() },
				{ "image", new StringFieldModel() },
				{ "category", new EntityFieldModel("prizecategory") },
				{ "description", new StringFieldModel(longText: true) },
				{ "minimumbid", new MoneyFieldModel() },
				{ "maximumbid", new MoneyFieldModel() },
				{ "sumdonations", new BooleanFieldModel() },
				{ "randomdraw", new BooleanFieldModel() },
				{ "provided", new StringFieldModel() },
				{ "pin", new BooleanFieldModel() },
				{ "winner", new EntityFieldModel("donor") },
				{ "startrun", new EntityFieldModel("run") },
				{ "endrun", new EntityFieldModel("run") },
				{ "starttime", new DateTimeFieldModel() },
				{ "endtime", new DateTimeFieldModel() },
			},
			new Dictionary<string, SearchFieldModel>()
			{
				{ "category", new SearchFieldModel(new StringFieldModel(), null) },
				{ "name", new SearchFieldModel(new StringFieldModel(), "name") },
				{ "description", new SearchFieldModel(new StringFieldModel(), "description") },
				{ "provided", new SearchFieldModel(new StringFieldModel(), "provided") },
			},
			JObjectEntityHelpers.GetPrizeDisplayName);

		public static readonly EntityModel BidModel = new EntityModel("bid",
			new Dictionary<string, FieldModel>()
			{
				{ "speedrun", new EntityFieldModel("run") },
				{ "name", new StringFieldModel() },
				{ "description", new StringFieldModel(longText: true) },
				{ "state", new EnumFieldModel(typeof(BidState)) },
				{ "pin", new BooleanFieldModel() },
				{ "total", new MoneyFieldModel(readOnly: true) },
			},
			new Dictionary<string, SearchFieldModel>()
			{
				{ "run", new SearchFieldModel(new EntityFieldModel("run"), "speedrun") },
				{ "runname", new SearchFieldModel(new StringFieldModel(), null) },
				{ "name", new SearchFieldModel(new StringFieldModel(), "name") },
				{ "description", new SearchFieldModel(new StringFieldModel(), "description") },
			},
			JObjectEntityHelpers.GetBidDisplayName);

		public static readonly EntityModel ChoiceModel = new EntityModel("choice",
			new Dictionary<string, FieldModel>()
			{
				{ "options", new EntitySetModel("choiceoption", "choice", "choice", OrphanResolution.Delete) },
			},
			new Dictionary<string, SearchFieldModel>()
			{
			},
			JObjectEntityHelpers.GetChoiceDisplayName,
			BidModel);

		public static readonly EntityModel ChallengeModel = new EntityModel("challenge",
			new Dictionary<string, FieldModel>()
			{
				{ "goal", new MoneyFieldModel() },
				{ "total", new MoneyFieldModel(readOnly: true) },
			},
			new Dictionary<string, SearchFieldModel>()
			{
			},
			JObjectEntityHelpers.GetChallengeDisplayName,
			BidModel);

		public static readonly EntityModel ChoiceOptionModel = new EntityModel("choiceoption",
			new Dictionary<string, FieldModel>()
			{
				{ "choice", new EntityFieldModel("choice") },
				{ "name", new StringFieldModel() },
				{ "total", new MoneyFieldModel(readOnly: true) },
			},
			new Dictionary<string, SearchFieldModel>()
			{
				{ "run", new SearchFieldModel(new EntityFieldModel("run"), null) },
				{ "runname", new SearchFieldModel(new StringFieldModel(), null) },
				{ "choicename", new SearchFieldModel(new StringFieldModel(), null) },
				{ "name", new SearchFieldModel(new StringFieldModel(), "name") },
			},
			JObjectEntityHelpers.GetOptionDisplayName);

		public static readonly EntityModel DonationBidModel = new EntityModel("donationbid",
			new Dictionary<string, FieldModel>()
			{
				{ "amount", new MoneyFieldModel() },
				{ "donation", new EntityFieldModel("donation") },
			},
			new Dictionary<string, SearchFieldModel>()
			{
			},
			null);

		public static readonly EntityModel ChoiceBidModel = new EntityModel("choicebid",
			new Dictionary<string, FieldModel>()
			{
				{ "option", new EntityFieldModel("choiceoption") },
			},
			new Dictionary<string, SearchFieldModel>() { },
			JObjectEntityHelpers.GetChoiceBidDisplayName,
			DonationBidModel);

		public static readonly EntityModel ChallengeBidModel = new EntityModel("challengebid",
			new Dictionary<string, FieldModel>()
			{
				{ "challenge", new EntityFieldModel("challenge") },
			},
			new Dictionary<string, SearchFieldModel>() { },
			JObjectEntityHelpers.GetChallengeBidDisplayName,
			DonationBidModel);

		private static Dictionary<string, EntityModel> ModelMap = new Dictionary<string, EntityModel>(StringComparer.OrdinalIgnoreCase)
		{
			{ "event", EventModel },
			{ "donor", DonorModel },
			{ "donation", DonationModel },
			{ "run", RunModel },
			{ "bid", BidModel },
			{ "choice", ChoiceModel },
			{ "challenge", ChallengeModel },
			{ "choiceoption", ChoiceOptionModel },
			{ "prize", PrizeModel },
			{ "donationbid", DonationBidModel },
			{ "challengebid", ChallengeBidModel },
			{ "choicebid", ChoiceBidModel },
			{ "prizecategory", PrizeCategoryModel },
		};

		public static IEnumerable<EntityModel> GetModels()
		{
			return ModelMap.Values;
		}

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
