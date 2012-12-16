using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SDA_DonationTracker
{
	/*
	public class ChipinMergeResults
	{
		public int Total { get; private set; }
		public int Added { get; private set; }
		public int Updated { get; private set; }

		public ChipinMergeResults(int total, int added, int updated)
		{
			this.Total = total;
			this.Added = added;
			this.Updated = updated;
		}

		public static ChipinMergeResults ParseResponse(string response)
		{
			string[] toks = response.Trim().Split();

			int total = 0;
			int added = 0;
			int updated = 0;

			for (int i = 0; i < toks.Length; i += 2)
			{
				string name = toks[i].Replace(":", "").Trim();
				string value = toks[i + 1].Trim();
				int iVal = int.Parse(value);

				if (name.IEquals("total"))
				{
					total = iVal;
				}
				else if (name.IEquals("new"))
				{
					added = iVal;
				}
				else if (name.IEquals("updated"))
				{
					updated = iVal;
				}
			}

			return new ChipinMergeResults(total: total, added: added, updated: updated);
		}
	}
	*/

	public class ChipinMergeContext : ExternalProcessContext
	{
		public ChipinMergeContext(TrackerContext context)
			: base(context)
		{
		}

		protected override string ExecuteProcess()
		{
			return this.Context.RunChipinMerge();
		}
	}
}
