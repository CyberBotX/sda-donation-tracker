namespace SDA_DonationTracker
{
	partial class ExternalProcessTab
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.StatusLabel = new System.Windows.Forms.Label();
			this.ProgressBar = new System.Windows.Forms.ProgressBar();
			this.ResultsText = new System.Windows.Forms.TextBox();
			this.ControlButton = new System.Windows.Forms.Button();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 4;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.Controls.Add(this.StatusLabel, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.ProgressBar, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.ResultsText, 1, 3);
			this.tableLayoutPanel1.Controls.Add(this.ControlButton, 2, 1);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 5;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(613, 353);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// StatusLabel
			// 
			this.StatusLabel.AutoSize = true;
			this.StatusLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.StatusLabel.Location = new System.Drawing.Point(23, 20);
			this.StatusLabel.Name = "StatusLabel";
			this.StatusLabel.Size = new System.Drawing.Size(486, 29);
			this.StatusLabel.TabIndex = 0;
			this.StatusLabel.Text = "Ilde";
			// 
			// ProgressBar
			// 
			this.tableLayoutPanel1.SetColumnSpan(this.ProgressBar, 2);
			this.ProgressBar.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ProgressBar.Location = new System.Drawing.Point(23, 52);
			this.ProgressBar.Name = "ProgressBar";
			this.ProgressBar.Size = new System.Drawing.Size(567, 14);
			this.ProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
			this.ProgressBar.TabIndex = 1;
			// 
			// ResultsText
			// 
			this.tableLayoutPanel1.SetColumnSpan(this.ResultsText, 2);
			this.ResultsText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ResultsText.Location = new System.Drawing.Point(23, 72);
			this.ResultsText.Multiline = true;
			this.ResultsText.Name = "ResultsText";
			this.ResultsText.Size = new System.Drawing.Size(567, 258);
			this.ResultsText.TabIndex = 2;
			// 
			// ControlButton
			// 
			this.ControlButton.Location = new System.Drawing.Point(515, 23);
			this.ControlButton.Name = "ControlButton";
			this.ControlButton.Size = new System.Drawing.Size(75, 23);
			this.ControlButton.TabIndex = 3;
			this.ControlButton.Text = "Begin";
			this.ControlButton.UseVisualStyleBackColor = true;
			// 
			// ExternalProcessTab
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "ExternalProcessTab";
			this.Size = new System.Drawing.Size(613, 353);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label StatusLabel;
		private System.Windows.Forms.ProgressBar ProgressBar;
		private System.Windows.Forms.TextBox ResultsText;
		private System.Windows.Forms.Button ControlButton;
	}
}
