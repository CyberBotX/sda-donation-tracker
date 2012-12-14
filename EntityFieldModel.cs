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
		public bool Nullable
		{
			get;
			private set;
		}
		public bool ReadOnly
		{
			get 
			{ 
				return false; 
			}
		}

		public EntityFieldModel(string modelName, bool nullable = true)
		{
			this.ModelName = modelName;
			this.Nullable = nullable;
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
