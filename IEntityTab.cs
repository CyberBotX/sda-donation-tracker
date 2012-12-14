using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace SDA_DonationTracker
{
	public interface IEntityTab : ITab
	{
		string ModelName { get; }
		int? Id { get; }
	}

	public static class EntityTabMethods
	{
		public static bool EnableRefresh(this IEntityTab self)
		{
			return self.Id != null;
		}

		public static bool EnableSave(this IEntityTab self)
		{
			return true;
		}

		public static bool EnableDelete(this IEntityTab self)
		{
			return self.Id != null;
		}
	}
}
