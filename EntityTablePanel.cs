using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SDA_DonationTracker
{
	public abstract class EntityTablePanel : UserControl
	{
		public string ModelName { get; private set; }
		public EntityModel Model { get; private set; }
		public TableBinding Binding { get; private set; }

		public EntityTablePanel(string modelName)
		{
			this.ModelName = modelName;
			this.Model = DonationModels.GetModel(this.ModelName);
		}

		protected void SetTableBinding(TableBinding binding)
		{
			this.Binding = binding;
		}
	}
}
