using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SDA_DonationTracker
{
    public static class Util
    {
        public static string JoinSeperated(this IEnumerable<string> self, string join)
        {
            return self.Aggregate("", (x, y) => x + join + y);
        }

        public static string SymbolToNatural(this string self)
        {
            StringBuilder builder = new StringBuilder();

            if (self.Length > 0)
            {
                builder.Append(Char.ToUpper(self[0]));

                if (self.Length > 1)
                {
                    foreach (char c in self.Skip(1))
                    {
                        if (char.IsUpper(c))
                        {
                            builder.Append(' ');
                        }

                        builder.Append(c);
                    }
                }
            }

            return builder.ToString();
        }
    }
}
