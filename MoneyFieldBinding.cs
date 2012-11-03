using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
				if (!this.IsDecimal(this.TextBox.Text))
				{
					e.Cancel = true;
					this.LoadField(LastKnownGoodValue == null ? "" : LastKnownGoodValue.ToString());
				}
			};

			this.LoadField("");
		}

		public void LoadField(string data)
		{
			if (this.TextBox.InvokeRequired)
				this.TextBox.Invoke(new SetTextCallback(SetText), data);
			else
				this.SetText(data);
		}

		public string RetreiveField()
		{
			return this.TextBox.Text.ToString();
		}

		private delegate void SetTextCallback(string data);

		private void SetText(string data)
		{
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
				{
					this.TextBox.Text = this.LastKnownGoodValue.ToString();
				}
			}
		}

		private bool IsDecimal(string data)
		{
			decimal result;
			return decimal.TryParse(data, out result);
		}
	}
}
