using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SDA_DonationTracker
{
	public abstract class EntityEditPanel : UserControl
	{
		public TrackerContext Context
		{
			get;
			private set;
		}

		public MainForm Owner
		{
			get;
			private set;
		}

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

		public abstract IEnumerable<FormBinding> Forms
		{
			get;
		}

		public abstract IEnumerable<TableBinding> Tables
		{
			get;
		}

		public EntityEditPanel(string modelName, TrackerContext context, MainForm owner = null)
		{
			this.ModelName = modelName;
			this.Model = DonationModels.GetModel(this.ModelName);
			this.Context = context;
			this.Owner = owner;
		}
	}
}
