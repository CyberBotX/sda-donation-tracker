using System.Collections.Generic;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using System;

namespace SDA_DonationTracker
{
	public class FormBinding : BindingContext
	{
		private readonly string FieldsField = "fields";

		private Dictionary<string, FieldBinding> Bindings = new Dictionary<string, FieldBinding>();
		private JToken LoadedData;

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

		public void LoadObject(JToken data)
		{
			this.LoadedData = data;

			JObject fields = data.Value<JObject>(FieldsField);

			foreach (KeyValuePair<string, FieldBinding> entry in this.Bindings)
			{
				string value = fields.Value<string>(entry.Key);
				entry.Value.LoadField(value);
			}
		}

		public JObject SaveObject()
		{
			JObject obj = new JObject();

			if (LoadedData != null)
			{
				obj.Add("pk", LoadedData.Value<string>("pk"));
				obj.Add("model", LoadedData.Value<string>("model"));
			}

			JObject fields = new JObject();

			foreach (KeyValuePair<string, FieldBinding> entry in this.Bindings)
				fields.Add(entry.Key, entry.Value.RetreiveField());

			obj.Add("fields", fields);

			Console.WriteLine(obj.ToString());

			return obj;
		}

		public IEnumerable<string> GetBindingKeys()
		{
			return this.Bindings.Keys;
		}
	}
}
