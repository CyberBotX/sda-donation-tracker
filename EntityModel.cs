using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace SDA_DonationTracker
{
	public class SearchFieldModel
	{
		public SearchFieldModel(FieldModel fieldType, string baseField)
		{
			this.BaseField = baseField;
			this.FieldType = fieldType;
		}

		public string BaseField { get; private set; }
		public FieldModel FieldType { get; private set; }
	}

	public class EntityModel
	{
		public string ModelName
		{
			get;
			private set;
		}

		public Func<JObject, string> DisplayConverter
		{
			get;
			private set;
		}

		private Dictionary<string, FieldModel> TypeMapping;
		private Dictionary<string, SearchFieldModel> SearchFields;

		public EntityModel(string modelName, Dictionary<string, FieldModel> typeMapping, Dictionary<string, SearchFieldModel> searchFields, Func<JObject, string> defaultDisplayConverter)
		{
			this.ModelName = modelName;
			this.TypeMapping = typeMapping;
			this.SearchFields = searchFields;
			this.DisplayConverter = defaultDisplayConverter;
		}

		public FieldModel GetField(string name)
		{
			return this.TypeMapping[name];
		}

		public SearchFieldModel GetSearchField(string name)
		{
			return this.SearchFields[name];
		}

		public IEnumerable<FieldModel> GetFields()
		{
			return this.TypeMapping.Values;
		}
	}
}
