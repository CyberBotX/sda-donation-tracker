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
			});

		public static readonly EntityModel DonorModel = new EntityModel("donor",
			new Dictionary<string, FieldModel>()
			{
				{ "firstname", new StringFieldModel() },
				{ "lastname", new StringFieldModel() },
				{ "alias", new StringFieldModel() },
				{ "email", new StringFieldModel() },
				{ "donations", new EntitySetModel("donation") },
			});

		public static readonly EntityModel DonationModel = new EntityModel("donation",
			new Dictionary<string, FieldModel>()
			{
				{ "event", new StringFieldModel() },
				{ "time_lte", new DateTimeFieldModel() },
				{ "time_gte", new DateTimeFieldModel() },
				{ "domain", new EnumFieldModel(typeof(DonationDomain)) },
				{ "domainId", new StringFieldModel() },
				{ "amount_lte", new MoneyFieldModel() },
				{ "amount_gte", new MoneyFieldModel() },
				{ "comment", new StringFieldModel() },
				{ "bidstate", new EnumFieldModel(typeof(DonationBidState)) },
				{ "readstate", new EnumFieldModel(typeof(DonationReadState)) },
				{ "commentstate", new EnumFieldModel(typeof(DonationCommentState)) },
			});

		public static readonly EntityModel RunModel = new EntityModel("run",
			new Dictionary<string, FieldModel>()
			{
				{ "event", new StringFieldModel() },
				{ "name", new StringFieldModel() },
				{ "runner", new StringFieldModel() },
				{ "description", new StringFieldModel() },
			});

		public static readonly EntityModel PrizeModel = new EntityModel("prize",
			new Dictionary<string, FieldModel>()
			{
				{ "event", new StringFieldModel() },
				{ "name", new StringFieldModel() },
				{ "description", new StringFieldModel() },
				{ "provided", new StringFieldModel() },
			});

		private static Dictionary<string, EntityModel> ModelMap = new Dictionary<string, EntityModel>(StringComparer.OrdinalIgnoreCase)
		{
			{ "donor", DonorModel },
			{ "donation", DonationModel },
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
