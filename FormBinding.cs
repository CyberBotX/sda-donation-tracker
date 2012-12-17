using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace SDA_DonationTracker
{
	public class FormBinding : BindingContext
	{
		public bool SearchForm
		{
			get;
			private set;
		}

		public FormBinding(string modelName, bool searchForm = false)
		{
			this.ModelName = modelName;
			this.Model = DonationModels.GetModel(modelName);
			this.SearchForm = searchForm;
		}

		public string ModelName
		{
			get;
			private set;
		}

		public EntityModel Model
		{
			get;
			private set;
		}

		private readonly string FieldsField = "fields";

		private Dictionary<string, FieldBinding> Bindings = new Dictionary<string, FieldBinding>();
		private List<InstanceBinding> InstanceBindings = new List<InstanceBinding>();
		private JObject CachedData;

		public int? GetBoundId()
		{
			return (this.CachedData != null) ? this.CachedData.GetId() : null;
		}

		public void AddInstanceBinding(InstanceBinding binding)
		{
			this.InstanceBindings.Add(binding);
		}

		public void AddBinding(string fieldName, TextBoxBase textBox)
		{
			this.AddBinding(fieldName, new TextBoxBinding(textBox));
		}

		public void AddMoneyBinding(string fieldName, TextBoxBase textBox)
		{
			this.AddBinding(fieldName, new MoneyFieldBinding(textBox));
		}

		public void AddBinding(string fieldName, DateTimePicker picker)
		{
			this.AddBinding(fieldName, new DateTimePickerBinding(picker));
		}

		public void AddBinding(string fieldName, CheckBox box)
		{
			this.AddBinding(fieldName, new CheckBoxBinding(box));
		}

		public void AddBinding(string fieldName, ComboBox box, Type enumType)
		{
			this.AddBinding(fieldName, new ComboBoxBinding(box, enumType));
		}

		public void AddBinding(string fieldName, EntitySelector selector)
		{
			this.AddBinding(fieldName, new EntitySelectorBinding(selector));
		}

		public void AddBinding(string fieldName, FieldBinding binding)
		{
			this.AddAssociatedControl(binding.BoundControl);
			this.Bindings.Add(fieldName, binding);
		}

		public void LoadObject(JObject data)
		{
			this.CachedData = data;

			foreach (InstanceBinding binding in this.InstanceBindings)
			{
				binding.LoadInstance(data);
			}

			foreach (KeyValuePair<string, FieldBinding> entry in this.Bindings)
			{
				string value = this.CachedData.GetField(entry.Key);
				entry.Value.LoadField(value);
			}
		}

		/**
		 * Calling this with diffOnly=true will, if there is already a cached object, return
		 * only those fields whose values have changed.
		 */
		public JObject SaveObject(bool diffOnly = false)
		{
			JObject obj = new JObject();
			obj.Add(FieldsField, new JObject());

			if (this.CachedData != null)
			{
				if (this.CachedData.GetId() != null)
					obj.SetId(this.CachedData.GetId() ?? 0);

				obj.SetModel(this.CachedData.GetModel());
			}

			foreach (KeyValuePair<string, FieldBinding> entry in this.Bindings)
			{
				FieldModel field = this.SearchForm ? this.Model.GetSearchField(entry.Key).FieldType : this.Model.GetField(entry.Key);

				string fieldValue = entry.Value.RetreiveField();
				if (!field.ReadOnly && (!diffOnly || this.CachedData == null || !Util.EqualsEx(fieldValue, this.CachedData.GetField(entry.Key))))
					obj.SetField(entry.Key, fieldValue);
			}

			Console.WriteLine(obj.ToString());

			return obj;
		}

		public bool HasUnsavedChanges()
		{
			return this.SaveObject(true).GetFields().Any();
		}

		public IEnumerable<string> GetBindingKeys()
		{
			return this.Bindings.Keys;
		}

		public void LoadSingleField(string field, string value)
		{
			this.Bindings[field].LoadField(value);
		}

		public void ClearFields()
		{
			this.CachedData = null;
			foreach (KeyValuePair<string, FieldBinding> entry in this.Bindings)
			{
				entry.Value.LoadField(null);
			}
		}
	}
}
