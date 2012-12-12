using System.Windows.Forms;
using System;

namespace SDA_DonationTracker
{
	public class MoneyFieldBinding : FieldBinding
	{
		public TextBoxBase TextBox
		{
			get;
			private set;
		}
		public Control BoundControl { get { return TextBox; } }
		private decimal? LastKnownGoodValue;

		public MoneyFieldBinding(TextBoxBase textBox)
		{
			this.TextBox = textBox;

			this.TextBox.Validating += (o, e) =>
			{
				if (this.TextBox.Text.Trim().Length > 0 && !this.IsDecimal(this.TextBox.Text))
				{
					e.Cancel = true;
					this.LoadField(LastKnownGoodValue == null ? "" : LastKnownGoodValue.ToString());
				}
			};

			this.LoadField("");
		}

		public void LoadField(string data)
		{
			this.TextBox.InvokeEx(() => this.SetText(data));
		}

		public string RetreiveField()
		{
			return this.TextBox.Text.ToString();
		}

		private delegate void SetTextCallback(string data);

		private void SetText(string data)
		{
			data = data ?? "0.00";

			if (data.Trim().Length == 0)
			{
				this.LastKnownGoodValue = null;
				this.TextBox.Text = "";
			}
			else
			{
				decimal result;
				if (decimal.TryParse(data, out result))
				{
					this.LastKnownGoodValue = result;
					this.TextBox.Text = data;
				}
				else
					this.TextBox.Text = this.LastKnownGoodValue.ToString();
			}
		}

		private bool IsDecimal(string data)
		{
			decimal result;
			return decimal.TryParse(data, out result);
		}
	}
}
