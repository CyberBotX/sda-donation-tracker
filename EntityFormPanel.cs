using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace SDA_DonationTracker
{

	public abstract class EntityFormPanel : UserControl
	{
		public int? Id
		{
			get
			{
				return this.Binding.GetBoundId();
			}
		}

		public string ModelName { get; private set; }
		public EntityModel Model { get; private set; }
		public FormBinding Binding { get; private set; }

		public EntityFormPanel(string modelName)
		{
			this.ModelName = modelName;
			this.Model = DonationModels.GetModel(this.ModelName);
			this.Binding = new FormBinding(modelName);
		}
	}
}
