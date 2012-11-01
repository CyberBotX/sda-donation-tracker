using System.Collections.Generic;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace SDA_DonationTracker
{
	public class TextBoxBinding : FieldBinding
	{
		public TextBoxBase TextBox
		{
			get;
			private set;
		}
		public string Field
		{
			get;
			private set;
		}

		public TextBoxBinding(string field, TextBoxBase textBox)
		{
			this.Field = field;
			this.TextBox = textBox;
		}

		public void LoadField(string data)
		{
			this.TextBox.Invoke(new SetTextDelegate(this.ImplSetText), data);
		}

		public string RetreiveField()
		{
			return this.TextBox.Text;
		}

		private delegate void SetTextDelegate(string data);

		private void ImplSetText(string data)
		{
			this.TextBox.Text = data;
		}
	}

	public interface FieldBinding
	{
		string Field
		{
			get;
		}
		void LoadField(string data);
		string RetreiveField();
	}

	public class FormBinding : BindingContext
	{
		private readonly string FieldsField = "fields";

		private Dictionary<string, FieldBinding> Bindings = new Dictionary<string, FieldBinding>();
		private JToken LoadedData;

		public void AddBinding(string fieldName, TextBoxBase textBox)
		{
			this.AddAssociatedControl(textBox);
			this.Bindings.Add(fieldName, new TextBoxBinding(fieldName, textBox));
		}

		public void LoadObject(JToken data)
		{
			this.LoadedData = data;

			JObject fields = data.Value<JObject>(FieldsField);

			foreach (FieldBinding entry in this.Bindings.Values)
				entry.LoadField(fields.Value<string>(entry.Field));
		}
	}
}
