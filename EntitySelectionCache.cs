using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Newtonsoft.Json.Linq;

namespace SDA_DonationTracker
{
	public enum EntitySelectionCacheRefreshType
	{
		Light,
		Strong,
		Force,
	}

	public class EntitySelectionCache
	{
		private static readonly TimeSpan LightRefreshOffset = new TimeSpan(0, 5, 0);
		private static readonly TimeSpan StrongRefreshOffset = new TimeSpan(0, 0, 10);
		private static readonly TimeSpan ForceRefreshOffset = new TimeSpan(0, 0, 0);

		public string ModelName
		{
			get;
			private set;
		}

		public EntityModel Model
		{
			get;
			private set;
		}

		public TrackerContext Context
		{
			get;
			private set;
		}

		public event Action<BiMap<int, string>> DataRefreshed;

		private Mutex AccessControl;

		private BiMap<int, string> PublicCache;
		private DateTime LastRefreshTime;
		private SearchContext Searcher;
		private bool BlockRequests;

		public EntitySelectionCache(TrackerContext context, string model)
		{
			this.ModelName = model;
			this.Model = DonationModels.GetModel(this.ModelName);
			this.Context = context;
			this.AccessControl = new Mutex();
			this.LastRefreshTime = DateTime.MinValue;
			this.PublicCache = new BiMap<int,string>(null, StringComparer.OrdinalIgnoreCase);
			this.BlockRequests = false;
		}

		private void RefreshCache(JArray results)
		{
			try
			{
				this.AccessControl.WaitOne();
				this.BlockRequests = true;
				this.LastRefreshTime = DateTime.Now;

				BiMap<int, string> newCache = new BiMap<int, string>(null, StringComparer.OrdinalIgnoreCase);

				foreach (JObject obj in results.Values<JObject>())
				{
					int id = obj.GetId() ?? 0;
					string label = this.Model.DisplayConverter(obj);

					newCache.AddPair(id, label);
				}

				// I'm going to pray that assignment is atomic
				this.PublicCache = newCache;

				if (DataRefreshed != null)
					DataRefreshed(this.PublicCache);
			}
			finally
			{
				this.BlockRequests = false;
				this.AccessControl.ReleaseMutex();
			}
		}

		private TimeSpan GetSuggesstionOffset(EntitySelectionCacheRefreshType type)
		{
			switch (type)
			{
				case EntitySelectionCacheRefreshType.Light:
					return LightRefreshOffset;
				case EntitySelectionCacheRefreshType.Strong:
					return StrongRefreshOffset;
				case EntitySelectionCacheRefreshType.Force:
					return ForceRefreshOffset;
			}

			return LightRefreshOffset;
		}

		public void RequestRefresh(EntitySelectionCacheRefreshType refreshType = EntitySelectionCacheRefreshType.Light)
		{
			if (!this.BlockRequests)
			{
				try
				{
					this.AccessControl.WaitOne();

					TimeSpan offset = this.GetSuggesstionOffset(refreshType);

					if (!this.BlockRequests && this.LastRefreshTime.Add(offset) < DateTime.Now && (this.Searcher == null || !this.Searcher.Busy))
					{
						this.Searcher = new SearchContext(this.Context, this.ModelName, new Dictionary<string, string>());
						this.Searcher.OnComplete += this.RefreshCache;
						this.Searcher.Begin();
					}
				}
				finally
				{
					this.AccessControl.ReleaseMutex();
				}
			}
		}

		public IBiMap<int, string> GetLatestCache()
		{
			return this.PublicCache;
		}
	}
}
