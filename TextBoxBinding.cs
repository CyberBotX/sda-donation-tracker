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
			if (this.TextBox.InvokeRequired)
				this.TextBox.Invoke(new SetTextDelegate(this.ImplSetText), data);
			else
				this.ImplSetText(data);
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
}
