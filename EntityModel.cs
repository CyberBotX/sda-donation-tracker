using System;
using System.Linq;
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
		public bool IsAbstract
		{
			get
			{
				return this.GetChildEntities().Any();
			}
		}

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

		public EntityModel Parent
		{
			get;
			private set;
		}

		private Dictionary<string, FieldModel> TypeMapping;
		private Dictionary<string, SearchFieldModel> SearchFields;
		

		public EntityModel(string modelName, Dictionary<string, FieldModel> typeMapping, Dictionary<string, SearchFieldModel> searchFields, Func<JObject, string> defaultDisplayConverter, EntityModel parent = null)
		{
			this.ModelName = modelName;
			this.TypeMapping = typeMapping;
			this.SearchFields = searchFields;
			this.DisplayConverter = defaultDisplayConverter;
			this.Parent = parent;

			if (this.Parent != null)
			{
				foreach (var type in this.Parent.TypeMapping)
				{
					if (!this.TypeMapping.ContainsKey(type.Key))
						this.TypeMapping[type.Key] = type.Value;
				}

				foreach (var type in this.Parent.SearchFields)
				{
					if (!this.SearchFields.ContainsKey(type.Key))
						this.SearchFields[type.Key] = type.Value;
				}
			}
		}

		public FieldModel GetField(string name)
		{
			return this.TypeMapping[name];
		}

		public bool HasField(string name)
		{
			return this.TypeMapping.ContainsKey(name);
		}

		public SearchFieldModel GetSearchField(string name)
		{
			return this.SearchFields[name];
		}

		public IEnumerable<KeyValuePair<string, FieldModel>> GetNamedFields()
		{
			return this.TypeMapping;
		}

		public IEnumerable<FieldModel> GetFields()
		{
			return this.TypeMapping.Values;
		}

		public IEnumerable<EntityModel> GetChildEntities()
		{
			IEnumerable<EntityModel> filtered = DonationModels.GetModels();
			filtered = filtered.Where(m => m.Parent == this).ToArray();

			return filtered;
		}
	}
}
