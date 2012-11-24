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

		public Control BoundControl { get { return this.TextBox; } }

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
