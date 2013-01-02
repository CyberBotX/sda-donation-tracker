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

		public bool Nullable
		{
			get;
			private set;
		}
		public Control BoundControl { get { return this.TextBox; } }

		public TextBoxBinding(TextBoxBase textBox, bool readOnly = false, bool nullable = true, bool longText = false)
		{
			this.TextBox = textBox;
			this.TextBox.Multiline = longText;
			this.TextBox.ReadOnly = readOnly;
      if (this.TextBox is TextBox && longText)
        (this.TextBox as TextBox).ScrollBars = ScrollBars.Vertical;
			this.Nullable = nullable;
		}

		public void LoadField(string data)
		{
			if (data == null)
				data = "";
			this.TextBox.InvokeEx(() => this.TextBox.Text = data);
		}

		public string RetreiveField()
		{
			string outData = this.TextBox.Text;
			return (this.Nullable && outData.Equals("")) ? null : outData;
		}
	}
}
