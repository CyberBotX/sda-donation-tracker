using System;

namespace SDA_DonationTracker
{
	public class EntityFieldModel : FieldModel
	{
		public Type FieldType
		{
			get
			{
				return typeof(EntityModel);
			}
		}
		public string ModelName
		{
			get;
			private set;
		}
		public EntityModel GetModel
		{
			get
			{
				return DonationModels.GetModel(this.ModelName);
			}
		}

		public EntityFieldModel(string modelName)
		{
			this.ModelName = modelName;
		}
	}
}
