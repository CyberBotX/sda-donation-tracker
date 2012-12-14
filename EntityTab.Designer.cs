namespace SDA_DonationTracker
{
	partial class EntityTab
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
			this.RootTableLayout = new System.Windows.Forms.TableLayoutPanel();
			this.ButtonsTableLayout = new System.Windows.Forms.TableLayoutPanel();
			this.SaveButton = new System.Windows.Forms.Button();
			this.RefreshButton = new System.Windows.Forms.Button();
			this.DeleteButton = new System.Windows.Forms.Button();
			this.RootTableLayout.SuspendLayout();
			this.ButtonsTableLayout.SuspendLayout();
			this.SuspendLayout();
			// 
			// RootTableLayout
			// 
			this.RootTableLayout.ColumnCount = 1;
			this.RootTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.RootTableLayout.Controls.Add(this.ButtonsTableLayout, 0, 0);
			this.RootTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
			this.RootTableLayout.Location = new System.Drawing.Point(0, 0);
			this.RootTableLayout.Name = "RootTableLayout";
			this.RootTableLayout.RowCount = 2;
			this.RootTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.RootTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.RootTableLayout.Size = new System.Drawing.Size(544, 325);
			this.RootTableLayout.TabIndex = 0;
			// 
			// ButtonsTableLayout
			// 
			this.ButtonsTableLayout.AutoSize = true;
			this.ButtonsTableLayout.ColumnCount = 4;
			this.ButtonsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.ButtonsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.ButtonsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.ButtonsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.ButtonsTableLayout.Controls.Add(this.SaveButton, 0, 0);
			this.ButtonsTableLayout.Controls.Add(this.RefreshButton, 1, 0);
			this.ButtonsTableLayout.Controls.Add(this.DeleteButton, 3, 0);
			this.ButtonsTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ButtonsTableLayout.Location = new System.Drawing.Point(3, 3);
			this.ButtonsTableLayout.Name = "ButtonsTableLayout";
			this.ButtonsTableLayout.RowCount = 1;
			this.ButtonsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.ButtonsTableLayout.Size = new System.Drawing.Size(538, 29);
			this.ButtonsTableLayout.TabIndex = 0;
			// 
			// SaveButton
			// 
			this.SaveButton.Location = new System.Drawing.Point(3, 3);
			this.SaveButton.Name = "SaveButton";
			this.SaveButton.Size = new System.Drawing.Size(75, 23);
			this.SaveButton.TabIndex = 0;
			this.SaveButton.Text = "Save";
			this.SaveButton.UseVisualStyleBackColor = true;
			this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
			// 
			// RefreshButton
			// 
			this.RefreshButton.Location = new System.Drawing.Point(84, 3);
			this.RefreshButton.Name = "RefreshButton";
			this.RefreshButton.Size = new System.Drawing.Size(75, 23);
			this.RefreshButton.TabIndex = 1;
			this.RefreshButton.Text = "Refresh";
			this.RefreshButton.UseVisualStyleBackColor = true;
			this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
			// 
			// DeleteButton
			// 
			this.DeleteButton.Location = new System.Drawing.Point(460, 3);
			this.DeleteButton.Name = "DeleteButton";
			this.DeleteButton.Size = new System.Drawing.Size(75, 23);
			this.DeleteButton.TabIndex = 2;
			this.DeleteButton.Text = "Delete";
			this.DeleteButton.UseVisualStyleBackColor = true;
			this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
			// 
			// NewEntityTab
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.RootTableLayout);
			this.Name = "NewEntityTab";
			this.Size = new System.Drawing.Size(544, 325);
			this.RootTableLayout.ResumeLayout(false);
			this.RootTableLayout.PerformLayout();
			this.ButtonsTableLayout.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel RootTableLayout;
		private System.Windows.Forms.TableLayoutPanel ButtonsTableLayout;
		private System.Windows.Forms.Button SaveButton;
		private System.Windows.Forms.Button RefreshButton;
		private System.Windows.Forms.Button DeleteButton;
	}
}
