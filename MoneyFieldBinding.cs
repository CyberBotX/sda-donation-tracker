﻿using System.Windows.Forms;
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
		private bool AllowNull;

		public MoneyFieldBinding(TextBoxBase textBox, bool readOnly = false, bool allowNull = true)
		{
			this.TextBox = textBox;
			this.TextBox.ReadOnly = readOnly;
			this.AllowNull = allowNull;

			this.TextBox.Validating += (o, e) =>
			{
				if (this.TextBox.Text.Trim().Length == 0)
				{
					if (!this.AllowNull)
						this.LoadField("0.00");
				}
				else if (!this.IsDecimal(this.TextBox.Text))
				{
					e.Cancel = true;
					this.LoadField(this.LastKnownGoodValue == null ? (this.AllowNull ? "" : "0.00") : LastKnownGoodValue.ToString());
				}
			};

			this.LastKnownGoodValue = this.AllowNull ? null : (decimal?)0.00m;

			this.LoadField(this.AllowNull ? "" : "0.00");
		}

		public void LoadField(string data)
		{
			this.TextBox.InvokeEx(() => this.SetText(data));
		}

		public string RetreiveField()
		{
			if (TextBox.Text.Length == 0)
				return this.AllowNull ? null : "0.00";
			else
				return this.TextBox.Text.ToString();
		}

		private delegate void SetTextCallback(string data);

		private void SetText(string data)
		{
			data = data ?? "";

			if (data.Trim().Length == 0)
			{
				if (this.AllowNull)
				{
					this.LastKnownGoodValue = null;
					this.TextBox.Text = "";
				}
				else
				{
					this.LastKnownGoodValue = 0.00m;
					this.TextBox.Text = "0.00";
				}
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
