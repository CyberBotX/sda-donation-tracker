using System;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace SDA_DonationTracker
{
	public static class JObjectEntityHelpers
	{
		public static int CompareDonationsByTime(this JObject self, JObject other)
		{
			DateTime left = DateTimeFieldModel.ParseDate(self.GetField("timereceived"));
			DateTime right = DateTimeFieldModel.ParseDate(other.GetField("timereceived"));
			return left.CompareTo(right);
		}

		public static JObject CreateEntityObject(string model, int? id = null)
		{
			JObject result = new JObject();
			result.SetModel(model);
			if (id != null)
				result.SetId(id ?? 0);
			result.Add("fields", new JObject());
			return result;
		}

		/**
		 * prioritizeSelf will prevent overwriting the field in self with the value in other
		 */
		public static void MergeFrom(this JObject self, JObject other, bool prioritizeSelf = false)
		{
			foreach (var field in other.GetFields())
			{
				if (!prioritizeSelf || !self.HasField(field.Key))
					self.SetField(field.Key, field.Value);
			}
		}

		public static int? GetId(this JObject self)
		{
			return self.Value<int?>("pk");
		}

		public static void SetId(this JObject self, int id)
		{
			self["pk"] = id;
		}

		public static string GetModel(this JObject self)
		{
			string model = self.Value<string>("model");

			if (string.IsNullOrEmpty(model))
				return null;

			string result = model.Split('.')[1];

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

		public static bool HasField(this JObject self, string name)
		{
			JObject fields = self.GetFieldsObject();
			return fields.Properties().Any(p => p.Name.Equals(name));
		}

		public static string GetField(this JObject self, string name)
		{
			if (self.HasField(name))
			{
				JObject fields = self.GetFieldsObject();

				string result = fields.Value<string>(name);

				// This is a hack to ensure that the output time values are in a consistent format
				if (result != null && !result.Equals("None") && result.Length > 0 && self.GetModel() != null)
				{
					EntityModel model = DonationModels.GetModel(self.GetModel());

					if (model.HasField(name) && model.GetField(name) is DateTimeFieldModel)
					{
						DateTime timeResult = fields.Value<DateTime>(name);
						result = timeResult.ToString(DateTimeFieldModel.DateFormatFromPicker) + "Z";
					}
				}
				
				return (result == null || result.Equals("None")) ? null : result;
			}
			else
			{
				return null;
			}
		}

		public static void SetField(this JObject self, string name, string value)
		{
			JObject fields = self.GetFieldsObject();

			// Unfortunately, 
			if (value == null)
				value = "None";

			fields[name] = value;
		}

		public static IEnumerable<KeyValuePair<string,string> > GetFields(this JObject self)
		{
			JObject fields = self.GetFieldsObject();
			//return fields.Properties().Select(p => new KeyValuePair<string, string>(p.Name, p.Value.ToString()));

			return fields.Properties().Select(p => new KeyValuePair<string, string>(p.Name, self.GetField(p.Name)));
		}

		public static IEnumerable<KeyValuePair<string, string>> GetErrorFields(this JObject self)
		{
			JToken firstResult;

			Dictionary<string, string> results = new Dictionary<string, string>();

			if (self.TryGetValue("error", out firstResult))
			{
        results["error"] = firstResult.Value<string>();
			}

      if (self.TryGetValue("exception", out firstResult))
      {
        results["exception"] = firstResult.Value<string>();
      }

			JObject fields = self.GetFieldsObject();

			if (fields != null)
			{
				foreach (JProperty p in fields.Properties())
				{
          results[p.Name] = p.Value.ToString();
				}
			}
			
			if (results.Count == 0)
			{
				results["error"] = "unknown";
			}

			return results;
		}

		public static string GetDisplayName(this JObject self, bool publicFacing = false)
		{
			string model = self.GetModel();

			if (model.IEquals("event"))
				return self.GetEventDisplayName();
			else if (model.IEquals("donor"))
				return self.GetDonorDisplayName(publicFacing);
			else if (model.IEquals("donation"))
				return self.GetDonationDisplayName(publicFacing);
			else if (model.IEquals("prize"))
				return self.GetPrizeDisplayName();
			else if (model.IEquals("run"))
				return self.GetRunDisplayName();
			else if (model.IEquals("challenge"))
				return self.GetChallengeDisplayName();
			else if (model.IEquals("choice"))
				return self.GetChoiceDisplayName();
			else if (model.IEquals("choiceoption"))
				return self.GetOptionDisplayName();
			else if (model.IEquals("choicebid"))
				return self.GetChoiceBidDisplayName();
			else if (model.IEquals("challengebid"))
				return self.GetChallengeBidDisplayName();
			else if (model.IEquals("prizecategory"))
				return self.GetPrizeCategoryDisplayName();
			else
				return "Unknown Entity";
		}

		// This probably belongs at another level of abstraction, but w/e
		public static string GetEventDisplayName(this JObject self)
		{
			return self.GetField("name");
		}

		// This probably belongs at another level of abstraction, but w/e
		public static string GetDonorDisplayName(this JObject self, bool publicFacing = false)
		{
			string alias = self.GetField("alias");
			string email = self.GetField("email");
			string firstName = self.GetField("firstname");
			string lastName = self.GetField("lastname");
			bool anonymous = publicFacing ? bool.Parse(self.GetField("anonymous")) : false;
			int? id = self.GetId();

			return RawDonorDisplayName(id, email, firstName, lastName, alias, anonymous);
		}

		// This probably belongs at another level of abstraction, but w/e
		public static string GetDonationDonorDisplayName(this JObject self, bool publicFacing = false)
		{
			string alias = self.GetField("donor__alias");
			string firstName = self.GetField("donor__firstname");
			string lastName = self.GetField("donor__lastname");
			string email = self.GetField("donor__email");
			bool anonymous = publicFacing ? bool.Parse(self.GetField("donor__anonymous")) : false;
			int? donorId = self.GetId();

			return RawDonorDisplayName(donorId, email, firstName, lastName, alias, anonymous);
		}

		public static string RawDonorDisplayName(int? id, string email, string firstName, string lastName, string alias, bool anonymous = false)
		{
			if (anonymous)
				return "*Anonymous*";
			else if (!string.IsNullOrEmpty(alias))
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

		public static string GetDonationDisplayName(this JObject self, bool publicFacing = false)
		{
			int? id = self.GetId();
			string amount = self.GetField("amount");
			string domain = self.GetField("domain");

			if (string.IsNullOrEmpty(domain))
				return "New Donation";
			else
				return domain + ":" + amount + ":" + self.GetDonationDonorDisplayName(publicFacing);
		}

		public static string GetBidDisplayName(this JObject self)
		{
			string name = self.GetField("name");
			string runName = self.GetField("speedrun__name");

			if (string.IsNullOrEmpty(name))
				return "New Bid";
			else
				return runName + ":" + name;
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

		public static string GetPrizeCategoryDisplayName(this JObject self)
		{
			string name = self.GetField("name");

			if (string.IsNullOrEmpty(name))
				return "New Prize Category";
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
