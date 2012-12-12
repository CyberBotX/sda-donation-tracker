using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace SDA_DonationTracker
{
	public interface EntityTab
	{
		string ModelName { get; }
		int? Id { get; }
	}

	public static class EntityTabMethods
	{
		/*
		public static IEnumerable<KeyValuePair<string, string>> GetSaveParams(this EntityTab self, FormBinding formBinding)
		{
			return Util.BuildSaveParams(formBinding, self.Id);
		}
		*/

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
