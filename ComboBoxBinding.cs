using System;
using System.Windows.Forms;

namespace SDA_DonationTracker
{
	public class ComboBoxBinding : FieldBinding 
	{
		public ComboBox ComboBox { get; private set; }
		public Type EnumType { get; private set; }
		public Control BoundControl { get { return this.ComboBox; } }

		public ComboBoxBinding(ComboBox comboBox, Type enumType)
		{
			this.ComboBox = comboBox;
			this.EnumType = enumType;
			this.ComboBox.DataSource = Enum.GetValues(this.EnumType);
			this.ComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			//this.ComboBox.SelectedIndex = 0;
		}

		public void LoadField(string data)
		{
			this.ComboBox.InvokeEx(() => this.SetSelectedValue(data));
		}

		public string RetreiveField()
		{
			return this.ComboBox.SelectedValue.ToString();
		}

		private void SetSelectedValue(string data)
		{
			object o = Enum.Parse(this.EnumType, data);
			this.ComboBox.SelectedItem = o;
		}
	}
}
