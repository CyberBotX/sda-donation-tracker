using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SDA_DonationTracker
{
	// TODO: 
	// - This copies a lot (, that is, almost all of its) code with MoneyFieldBinding,
	//   so there is probably an oppourtunity to refactor the implementations to share code
	public class IntFieldBinding : FieldBinding
	{
		public TextBoxBase TextBox
		{
			get;
			private set;
		}
		public Control BoundControl { get { return TextBox; } }
		private int? LastKnownGoodValue;
		private bool AllowNull;

		public IntFieldBinding(TextBoxBase textBox, bool readOnly = false, bool allowNull = true)
		{
			this.TextBox = textBox;
			this.TextBox.ReadOnly = readOnly;
			this.AllowNull = allowNull;

			this.TextBox.Validating += (o, e) =>
			{
				if (this.TextBox.Text.Trim().Length == 0)
				{
					if (!this.AllowNull)
						this.LoadField("0");
				}
				else if (!this.IsInt(this.TextBox.Text))
				{
					e.Cancel = true;
					this.LoadField(this.LastKnownGoodValue == null ? (this.AllowNull ? "" : "0") : LastKnownGoodValue.ToString());
				}
			};

			this.LastKnownGoodValue = this.AllowNull ? null : (int?)0;

			this.LoadField(this.AllowNull ? "" : "0");
		}

		public void LoadField(string data)
		{
			this.TextBox.InvokeEx(() => this.SetText(data));
		}

		public string RetreiveField()
		{
			if (TextBox.Text.Length == 0)
				return this.AllowNull ? null : "0";
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
					this.LastKnownGoodValue = 0;
					this.TextBox.Text = "0";
				}
			}
			else
			{
				int result;
				if (int.TryParse(data, out result))
				{
					this.LastKnownGoodValue = result;
					this.TextBox.Text = data;
				}
				else
					this.TextBox.Text = this.LastKnownGoodValue.ToString();
			}
		}

		private bool IsInt(string data)
		{
			int result;
			return int.TryParse(data, out result);
		}
	}
}
