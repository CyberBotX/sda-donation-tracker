using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SDA_DonationTracker
{
	public class ComboBoxBinding : FieldBinding 
	{
		public ComboBox ComboBox { get; private set; }
		public Type EnumType { get; private set; }
		public Control BoundControl
		{
			get { return ComboBox; }
		}

		public ComboBoxBinding(ComboBox comboBox, Type enumType)
		{
			ComboBox = comboBox;
			EnumType = enumType;
			ComboBox.DataSource = Enum.GetValues(EnumType);
			ComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			//ComboBox.SelectedIndex = 0;
		}

		public void LoadField(string data)
		{
			if (ComboBox.InvokeRequired)
				ComboBox.Invoke(new SetSelectedValueDelegate(SetSelectedValue), data);
			else
				SetSelectedValue(data);
		}

		public string RetreiveField()
		{
			return ComboBox.SelectedValue.ToString();
		}

		private delegate void SetSelectedValueDelegate(string data);

		private void SetSelectedValue(string data)
		{
			ComboBox.SelectedValue = Enum.Parse(EnumType, data);
		}
	}
}
