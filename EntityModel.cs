using System.Collections.Generic;

namespace SDA_DonationTracker
{
	public class EntityModel
	{
		public string ModelName
		{
			get;
			private set;
		}

		private Dictionary<string, FieldModel> TypeMapping;

		public EntityModel(string modelName, Dictionary<string, FieldModel> typeMapping)
		{
			this.ModelName = modelName;
			this.TypeMapping = typeMapping;
		}

		public FieldModel GetField(string name)
		{
			return this.TypeMapping[name];
		}

		public IEnumerable<FieldModel> GetFields()
		{
			return this.TypeMapping.Values;
		}
	}
}
