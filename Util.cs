using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SDA_DonationTracker
{
	public static class Util
	{
		public static IEnumerable<KeyValuePair<string, string>> CreateSearchParams(params string[] stuff)
		{
			Dictionary<string, string> list = new Dictionary<string, string>(stuff.Length / 2);

			for (int i = 0; i < stuff.Length; i += 2)
				list[stuff[i / 2]] = stuff[i / 2 + 1];

			return list;
		}

		public static IEnumerable<T> Concat1<T>(this IEnumerable<T> self, T toAdd)
		{
			return self.Concat(new T[] { toAdd });
		}

		/*public static string JoinSeperated(this IEnumerable<string> self, string join)
		{
			if (self.Any())
			{
				return self.Aggregate((x, y) => x + join + y);
			}
			else
			{
				return "";
			}
		}*/

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
	}
}
