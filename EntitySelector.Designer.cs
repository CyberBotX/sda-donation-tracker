namespace SDA_DonationTracker
{
	partial class EntitySelector
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
			if (this.Cache != null)
			{
				this.Cache.DataRefreshed -= this.RebuildMappingInfo;
			}

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
			this.NameText = new System.Windows.Forms.TextBox();
			this.OpenButton = new System.Windows.Forms.Button();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.SearchButton = new System.Windows.Forms.Button();
			this.ClearButton = new System.Windows.Forms.Button();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// NameText
			// 
			this.NameText.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.NameText.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.NameText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.NameText.Location = new System.Drawing.Point(3, 3);
			this.NameText.Name = "NameText";
			this.NameText.Size = new System.Drawing.Size(233, 20);
			this.NameText.TabIndex = 0;
			// 
			// OpenButton
			// 
			this.OpenButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.OpenButton.Location = new System.Drawing.Point(404, 3);
			this.OpenButton.Name = "OpenButton";
			this.OpenButton.Size = new System.Drawing.Size(75, 24);
			this.OpenButton.TabIndex = 3;
			this.OpenButton.Text = "Open";
			this.OpenButton.UseVisualStyleBackColor = true;
			this.OpenButton.Click += new System.EventHandler(this.OpenButton_Click);
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 4;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.Controls.Add(this.NameText, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.SearchButton, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.OpenButton, 3, 0);
			this.tableLayoutPanel1.Controls.Add(this.ClearButton, 2, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size = new System.Drawing.Size(482, 30);
			this.tableLayoutPanel1.TabIndex = 1;
			// 
			// SearchButton
			// 
			this.SearchButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.SearchButton.Location = new System.Drawing.Point(242, 3);
			this.SearchButton.Name = "SearchButton";
			this.SearchButton.Size = new System.Drawing.Size(75, 24);
			this.SearchButton.TabIndex = 1;
			this.SearchButton.Text = "Search";
			this.SearchButton.UseVisualStyleBackColor = true;
			this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
			// 
			// ClearButton
			// 
			this.ClearButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ClearButton.Location = new System.Drawing.Point(323, 3);
			this.ClearButton.Name = "ClearButton";
			this.ClearButton.Size = new System.Drawing.Size(75, 24);
			this.ClearButton.TabIndex = 2;
			this.ClearButton.Text = "Clear";
			this.ClearButton.UseVisualStyleBackColor = true;
			this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
			// 
			// EntitySelector
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "EntitySelector";
			this.Size = new System.Drawing.Size(482, 30);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TextBox NameText;
		private System.Windows.Forms.Button OpenButton;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Button SearchButton;
		private System.Windows.Forms.Button ClearButton;
	}
}
