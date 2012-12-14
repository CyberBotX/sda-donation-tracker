using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using Newtonsoft.Json.Linq;

namespace SDA_DonationTracker
{
	public static class Util
	{
		/**
		 * I normally dislike using variadics like this, but it helps cut down on code a lot, 
		 * so I'm breaking my own rule here.
		 */
		public static IEnumerable<KeyValuePair<string, string>> CreateSearchParams(params string[] stuff)
		{
			Dictionary<string, string> list = new Dictionary<string, string>(stuff.Length / 2);

			for (int i = 0; i < stuff.Length; i += 2)
				list[stuff[i / 2]] = stuff[i / 2 + 1];

			return list;
		}

		public static IEnumerable<KeyValuePair<string, string>> CreateIdSearch(int id)
		{
			return CreateSearchParams("id", id.ToString());
		}

		public static Dictionary<string, string> BuildSaveParams(JObject obj)
		{
			var result = new Dictionary<string, string>();

			foreach (var field in obj.GetFields())
			{
				result[field.Key] = field.Value;
			}

			int? id = obj.GetId();

			if (id != null)
			{
				result["id"] = id.ToString();
			}

			return result;
		}

		public static IEnumerable<T> Concat1<T>(this IEnumerable<T> self, T toAdd)
		{
			return self.Concat(new T[] { toAdd });
		}

		public static bool IEquals(this string self, string other)
		{
			return self.Equals(other, StringComparison.OrdinalIgnoreCase);
		}

		public static string SymbolToNatural(this string self)
		{
			StringBuilder builder = new StringBuilder();

			if (self.Length > 0)
			{
				builder.Append(char.ToUpper(self[0]));

				if (self.Length > 1)
				{
					foreach (char c in self.Skip(1))
					{
						if (char.IsUpper(c))
							builder.Append(' ');

						builder.Append(c);
					}
				}
			}

			return builder.ToString();
		}

		public static bool EqualsEx(object left, object right)
		{
			if (left == null || right == null)
			{
				return left == right;
			}
			else
			{
				return left.Equals(right);
			}
		}
	}
}
