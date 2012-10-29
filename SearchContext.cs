using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Newtonsoft.Json.Linq;

namespace SDA_DonationTracker
{


    public class SearchContext
    {
        public TrackerContext Context { get; private set; }
        private Thread Connection;
        public string Model { get; private set; }
        public IEnumerable<KeyValuePair<string, string>> SearchParams { get; private set; }
        public JArray Result { get; private set; }
        public bool Completed { get { return Status == ContextStatus.Completed; } }
        public bool Error { get { return Status == ContextStatus.Error; } }
        public bool Busy { get { return Status == ContextStatus.Pending || Status == ContextStatus.Started; } }
        public ContextStatus Status { get; private set; }
        public string ErrorString;
        public event Action<JArray> OnComplete;

        public SearchContext(TrackerContext context, string model, IEnumerable<KeyValuePair<string, string>> searchParams)
        {
            Context = context;
            Model = model;
            SearchParams = searchParams;
            Result = null;
            ErrorString = null;
            Status = ContextStatus.Idle;
            Connection = new Thread(this.Impl_RunSearch);
        }

        public void Begin()
        {
            Status = ContextStatus.Pending;
            Result = null;
            ErrorString = null;
            Connection.Start();
        }

        public void Abort()
        {
            Connection.Abort();
        }

        private void Impl_RunSearch()
        {
            try
            {
                Status = ContextStatus.Started;
                Result = Context.RunSearch(Model, SearchParams);
                Status = ContextStatus.Completed;

                if (OnComplete != null)
                {
                    OnComplete.Invoke(Result);
                }
            }
            catch (Exception e)
            {
                ErrorString = e.Message;
            }
        }
    }
}
