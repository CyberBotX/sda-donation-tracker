using System.Windows.Forms;

namespace SDA_DonationTracker
{
	public class CheckBoxBinding : FieldBinding
	{
		public CheckBox CheckBox { get; private set; }
		public Control BoundControl { get { return this.CheckBox; } }

		public CheckBoxBinding(CheckBox checkBox)
		{
			this.CheckBox = checkBox;
		}

		public void LoadField(string data)
		{
			this.CheckBox.InvokeEx(() => this.CheckBox.Checked = bool.Parse(data));
		}

		public string RetreiveField()
		{
			return this.CheckBox.Checked.ToString();
		}
	}
}
