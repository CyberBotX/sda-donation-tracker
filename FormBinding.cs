using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Windows.Forms;

namespace SDA_DonationTracker
{
    public class TextBoxBinding : FieldBinding
    {
        public TextBoxBase TextBox { get; private set; }
        public string Field { get; private set; }

        public TextBoxBinding(string field, TextBoxBase textBox)
        {
            Field = field;
            TextBox = textBox;
        }

        public void LoadField(string data)
        {
            TextBox.Invoke(new SetTextDelegate(ImplSetText), data);
        }

        public string RetreiveField()
        {
            return TextBox.Text;
        }

        private delegate void SetTextDelegate(string data);

        private void ImplSetText(string data)
        {
            TextBox.Text = data;
        }
    }

    public interface FieldBinding
    {
        string Field { get; }
        void LoadField(string data);
        string RetreiveField();
    }

    public class FormBinding
    {
        private readonly string FieldsField = "fields";

        private Dictionary<string, FieldBinding> Bindings;
        private JToken LoadedData;

        public FormBinding()
        {
            Bindings = new Dictionary<string, FieldBinding>(StringComparer.OrdinalIgnoreCase);
        }

        public void AddBinding(string fieldName, TextBoxBase textBox)
        {
            Bindings.Add(fieldName, new TextBoxBinding(fieldName, textBox));
        }

        public void LoadObject(JToken data)
        {
            LoadedData = data;

            JObject fields = data.Value<JObject>("fields");

            foreach (var entry in Bindings.Values)
            {
                string value = fields.Value<string>(entry.Field);
                entry.LoadField(value);
            }
        }
    }
}
