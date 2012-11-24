using System;
using Newtonsoft.Json.Linq;

namespace SDA_DonationTracker
{
	public static class JObjectEntityHelpers
	{
		public static int? GetId(this JObject self)
		{
			return self.Value<int?>("pk");
		}

		public static void SetId(this JObject self, int id)
		{
			self["id"] = id;
		}

		public static string GetModel(this JObject self)
		{
			string result = self.Value<string>("model").Split('.')[1];

			if (result == "speedrun")
				return "run";
			else
				return result;
		}

		public static void SetModel(this JObject self, string model)
		{
			if (string.Equals(model, "run", StringComparison.OrdinalIgnoreCase))
				self["model"] = "tracker.speedrun";
			else
				self["model"] = "tracker." + model;
		}

		public static JObject GetFieldsObject(this JObject self)
		{
			return self.Value<JObject>("fields");
		}

		public static string GetField(this JObject self, string name)
		{
			JObject fields = self.GetFieldsObject();
			string result = fields.Value<string>(name);
			return result == "None" ? null : result;
		}

		public static void SetField(this JObject self, string name, string value)
		{
			JObject fields = self.GetFieldsObject();
			fields[name] = value;
		}

		// This probably belongs at another level of abstraction, but w/e
		public static string GetEventDisplayName(this JObject self)
		{
			return self.GetField("name");
		}

		// This probably belongs at another level of abstraction, but w/e
		public static string GetDonorDisplayName(this JObject self)
		{
			string alias = self.GetField("alias");
			string email = self.GetField("email");
			string firstName = self.GetField("firstname");
			string lastName = self.GetField("lastname");
			int? id = self.GetId();

			return RawDonorDisplayName(id, email, firstName, lastName, alias);
		}

		public static string RawDonorDisplayName(int? id, string email, string firstName, string lastName, string alias)
		{
			if (!string.IsNullOrEmpty(alias))
				return alias;
			else if (!string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName))
				return firstName + " " + lastName;
			else if (!string.IsNullOrEmpty(email))
				return email;
			else if (id != null)
				return "Donor#" + id;
			else
				return "New Donor";
		}

		public static string GetDonationDisplayName(this JObject self)
		{
			int? donorId = self.GetId();
			string donorAlias = self.GetField("donor__alias");
			string donorFirst = self.GetField("donor__firstname");
			string donorLast = self.GetField("donor__lastname");
			string donorEmail = self.GetField("donor__email");
			string amount = self.GetField("amount");
			string domain = self.GetField("domain");

			if (string.IsNullOrEmpty(domain))
				return "New Donation";
			else
				return domain + ":" + amount + ":" + RawDonorDisplayName(donorId, donorEmail, donorFirst, donorLast, donorAlias);
		}

		public static string GetChallengeDisplayName(this JObject self)
		{
			string name = self.GetField("name");
			string runName = self.GetField("speedrun__name");

			if (string.IsNullOrEmpty(name))
				return "New Challenge";
			else
				return runName + ":" + name;
		}

		public static string GetChoiceDisplayName(this JObject self)
		{
			string name = self.GetField("name");
			string runName = self.GetField("speedrun__name");

			if (string.IsNullOrEmpty(name))
				return "New Choice";
			else
				return runName + ":" + name;
		}

		public static string GetRunDisplayName(this JObject self)
		{
			string name = self.GetField("name");

			if (string.IsNullOrEmpty(name))
				return "New Run";
			else
				return name;
		}

		public static string GetPrizeDisplayName(this JObject self)
		{
			string name = self.GetField("name");

			if (string.IsNullOrEmpty(name))
				return "New Prize";
			else
				return name;
		}

		public static string GetOptionDisplayName(this JObject self)
		{
			string runName = self.GetField("choice__speedrun__name");
			string choiceName = self.GetField("choice__name");
			string name = self.GetField("name");

			if (string.IsNullOrEmpty(name))
				return "New Choice Option";
			else
				return runName + ":" + choiceName + ":" + name;
		}

		public static string GetChoiceBidDisplayName(this JObject self)
		{
			string amount = self.GetField("amount");
			string donation = self.GetField("donation");
			string option = self.GetField("option");
			// this gives basically no information, just for consistency for now
			return option + ":" + donation + ":" + amount;
		}

		public static string GetChallengeBidDisplayName(this JObject self)
		{
			string amount = self.GetField("amount");
			string donation = self.GetField("donation");
			string challenge = self.GetField("challenge");
			// this gives basically no information, just for consistency for now
			return challenge + ":" + donation + ":" + amount;
		}
	}
}
