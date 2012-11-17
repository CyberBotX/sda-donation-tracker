using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SDA_DonationTracker
{
	public class TextBoxBinding : FieldBinding
	{
		public TextBoxBase TextBox
		{
			get;
			private set;
		}

		public Control BoundControl { get { return TextBox; } }

		public TextBoxBinding(TextBoxBase textBox)
		{
			this.TextBox = textBox;
		}

		public void LoadField(string data)
		{
			this.TextBox.InvokeEx(() => this.TextBox.Text = data);
		}

		public string RetreiveField()
		{
			return this.TextBox.Text;
		}
	}
}
