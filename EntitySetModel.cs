using System;

namespace SDA_DonationTracker
{
	public enum OrphanResolution
	{
		Delete,
		Null,
	}

	public class EntitySetModel : FieldModel
	{
		public Type FieldType
		{
			get
			{
				return typeof(EntityModel);
			}
		}
		public bool ReadOnly
		{
			get
			{
				return false;
			}
		}
		public string ModelName
		{
			get;
			private set;
		}
		public string KeyField
		{
			get;
			private set;
		}
		public string SearchKeyField
		{
			get;
			private set;
		}
		public OrphanResolution Resolution
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

		public EntitySetModel(string modelName, string keyField, string searchKeyField, OrphanResolution resolution = OrphanResolution.Null)
		{
			this.ModelName = modelName;
			this.KeyField = keyField;
			this.SearchKeyField = searchKeyField;
			this.Resolution = resolution;
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
