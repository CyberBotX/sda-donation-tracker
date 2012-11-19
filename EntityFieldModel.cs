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
		public EntityModel Model
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


		public string Serialize(object t)
		{
			throw new NotImplementedException();
		}

		public object Parse(string s)
		{
			throw new NotImplementedException();
		}
	}
}
