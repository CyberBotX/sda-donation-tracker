using System;

namespace SDA_DonationTracker
{
	public class EntitySetModel : FieldModel
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

		public EntitySetModel(string modelName)
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
