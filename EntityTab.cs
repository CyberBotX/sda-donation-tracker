using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace SDA_DonationTracker
{
	public interface EntityTab
	{
		string Model { get; }
		int? Id { get; }
	}

	public static class EntityTabMethods
	{
		public static Dictionary<string, string> GetSaveParams(this EntityTab self, FormBinding formBinding)
		{
			Dictionary<string, string> result = new Dictionary<string, string>();

			JObject data = formBinding.SaveObject();

			JObject fields = data.Value<JObject>("fields");

			foreach (string field in formBinding.GetBindingKeys())
				result.Add(field, fields.Value<string>(field));

			if (self.Id != null)
				result.Add("id", self.Id.ToString());

			return result;
		}

		public static bool EnableRefresh(this EntityTab self)
		{
			return self.Id != null;
		}

		public static bool EnableSave(this EntityTab self)
		{
			return true;
		}

		public static bool EnableDelete(this EntityTab self)
		{
			return self.Id != null;
		}
	}
}
