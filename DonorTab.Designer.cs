namespace SDA_DonationTracker
{
    partial class DonorTab
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.FirstNameLabel = new System.Windows.Forms.Label();
			this.LastNameLabel = new System.Windows.Forms.Label();
			this.AliasLabel = new System.Windows.Forms.Label();
			this.FirstNameText = new System.Windows.Forms.TextBox();
			this.LastNameText = new System.Windows.Forms.TextBox();
			this.AliasText = new System.Windows.Forms.TextBox();
			this.EmailText = new System.Windows.Forms.TextBox();
			this.EmailLabel = new System.Windows.Forms.Label();
			this.OpenDonationButton = new System.Windows.Forms.Button();
			this.DonationTable = new System.Windows.Forms.DataGridView();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.SaveButton = new System.Windows.Forms.Button();
			this.RefreshButton = new System.Windows.Forms.Button();
			this.DeleteButton = new System.Windows.Forms.Button();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DonationTable)).BeginInit();
			this.tableLayoutPanel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(200, 100);
			this.panel1.TabIndex = 0;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.DonationTable, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size = new System.Drawing.Size(685, 375);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.ColumnCount = 2;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.Controls.Add(this.FirstNameLabel, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.LastNameLabel, 0, 1);
			this.tableLayoutPanel2.Controls.Add(this.AliasLabel, 0, 2);
			this.tableLayoutPanel2.Controls.Add(this.FirstNameText, 1, 0);
			this.tableLayoutPanel2.Controls.Add(this.LastNameText, 1, 1);
			this.tableLayoutPanel2.Controls.Add(this.AliasText, 1, 2);
			this.tableLayoutPanel2.Controls.Add(this.EmailText, 1, 3);
			this.tableLayoutPanel2.Controls.Add(this.EmailLabel, 0, 3);
			this.tableLayoutPanel2.Controls.Add(this.OpenDonationButton, 1, 5);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 6;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.Size = new System.Drawing.Size(322, 169);
			this.tableLayoutPanel2.TabIndex = 0;
			// 
			// FirstNameLabel
			// 
			this.FirstNameLabel.AutoSize = true;
			this.FirstNameLabel.Dock = System.Windows.Forms.DockStyle.Right;
			this.FirstNameLabel.Location = new System.Drawing.Point(4, 0);
			this.FirstNameLabel.Name = "FirstNameLabel";
			this.FirstNameLabel.Size = new System.Drawing.Size(60, 26);
			this.FirstNameLabel.TabIndex = 0;
			this.FirstNameLabel.Text = "First Name:";
			// 
			// LastNameLabel
			// 
			this.LastNameLabel.AutoSize = true;
			this.LastNameLabel.Dock = System.Windows.Forms.DockStyle.Right;
			this.LastNameLabel.Location = new System.Drawing.Point(3, 26);
			this.LastNameLabel.Name = "LastNameLabel";
			this.LastNameLabel.Size = new System.Drawing.Size(61, 26);
			this.LastNameLabel.TabIndex = 1;
			this.LastNameLabel.Text = "Last Name:";
			// 
			// AliasLabel
			// 
			this.AliasLabel.AutoSize = true;
			this.AliasLabel.Dock = System.Windows.Forms.DockStyle.Right;
			this.AliasLabel.Location = new System.Drawing.Point(32, 52);
			this.AliasLabel.Name = "AliasLabel";
			this.AliasLabel.Size = new System.Drawing.Size(32, 26);
			this.AliasLabel.TabIndex = 2;
			this.AliasLabel.Text = "Alias:";
			// 
			// FirstNameText
			// 
			this.FirstNameText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.FirstNameText.Location = new System.Drawing.Point(70, 3);
			this.FirstNameText.Name = "FirstNameText";
			this.FirstNameText.Size = new System.Drawing.Size(249, 20);
			this.FirstNameText.TabIndex = 3;
			// 
			// LastNameText
			// 
			this.LastNameText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.LastNameText.Location = new System.Drawing.Point(70, 29);
			this.LastNameText.Name = "LastNameText";
			this.LastNameText.Size = new System.Drawing.Size(249, 20);
			this.LastNameText.TabIndex = 4;
			// 
			// AliasText
			// 
			this.AliasText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.AliasText.Location = new System.Drawing.Point(70, 55);
			this.AliasText.Name = "AliasText";
			this.AliasText.Size = new System.Drawing.Size(249, 20);
			this.AliasText.TabIndex = 5;
			// 
			// EmailText
			// 
			this.EmailText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.EmailText.Location = new System.Drawing.Point(70, 81);
			this.EmailText.Name = "EmailText";
			this.EmailText.Size = new System.Drawing.Size(249, 20);
			this.EmailText.TabIndex = 6;
			// 
			// EmailLabel
			// 
			this.EmailLabel.AutoSize = true;
			this.EmailLabel.Dock = System.Windows.Forms.DockStyle.Right;
			this.EmailLabel.Location = new System.Drawing.Point(29, 78);
			this.EmailLabel.Name = "EmailLabel";
			this.EmailLabel.Size = new System.Drawing.Size(35, 26);
			this.EmailLabel.TabIndex = 7;
			this.EmailLabel.Text = "Email:";
			// 
			// OpenDonationButton
			// 
			this.OpenDonationButton.Location = new System.Drawing.Point(70, 143);
			this.OpenDonationButton.Name = "OpenDonationButton";
			this.OpenDonationButton.Size = new System.Drawing.Size(109, 23);
			this.OpenDonationButton.TabIndex = 8;
			this.OpenDonationButton.Text = "Open Donation";
			this.OpenDonationButton.UseVisualStyleBackColor = true;
			this.OpenDonationButton.Click += new System.EventHandler(this.OpenDonationButton_Click);
			// 
			// DonationTable
			// 
			this.DonationTable.AllowUserToAddRows = false;
			this.DonationTable.AllowUserToDeleteRows = false;
			this.DonationTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.DonationTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.tableLayoutPanel1.SetColumnSpan(this.DonationTable, 2);
			this.DonationTable.Dock = System.Windows.Forms.DockStyle.Fill;
			this.DonationTable.Location = new System.Drawing.Point(3, 178);
			this.DonationTable.Name = "DonationTable";
			this.DonationTable.ReadOnly = true;
			this.DonationTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.DonationTable.Size = new System.Drawing.Size(679, 194);
			this.DonationTable.TabIndex = 1;
			// 
			// tableLayoutPanel3
			// 
			this.tableLayoutPanel3.ColumnCount = 1;
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel3.Controls.Add(this.SaveButton, 0, 0);
			this.tableLayoutPanel3.Controls.Add(this.RefreshButton, 0, 1);
			this.tableLayoutPanel3.Controls.Add(this.DeleteButton, 0, 2);
			this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel3.Location = new System.Drawing.Point(331, 3);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 4;
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel3.Size = new System.Drawing.Size(351, 169);
			this.tableLayoutPanel3.TabIndex = 3;
			// 
			// SaveButton
			// 
			this.SaveButton.Dock = System.Windows.Forms.DockStyle.Right;
			this.SaveButton.Location = new System.Drawing.Point(273, 3);
			this.SaveButton.Name = "SaveButton";
			this.SaveButton.Size = new System.Drawing.Size(75, 23);
			this.SaveButton.TabIndex = 2;
			this.SaveButton.Text = "Save";
			this.SaveButton.UseVisualStyleBackColor = true;
			this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
			// 
			// RefreshButton
			// 
			this.RefreshButton.Dock = System.Windows.Forms.DockStyle.Right;
			this.RefreshButton.Location = new System.Drawing.Point(273, 32);
			this.RefreshButton.Name = "RefreshButton";
			this.RefreshButton.Size = new System.Drawing.Size(75, 23);
			this.RefreshButton.TabIndex = 3;
			this.RefreshButton.Text = "Refresh";
			this.RefreshButton.UseVisualStyleBackColor = true;
			this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
			// 
			// DeleteButton
			// 
			this.DeleteButton.Dock = System.Windows.Forms.DockStyle.Right;
			this.DeleteButton.Location = new System.Drawing.Point(273, 61);
			this.DeleteButton.Name = "DeleteButton";
			this.DeleteButton.Size = new System.Drawing.Size(75, 36);
			this.DeleteButton.TabIndex = 4;
			this.DeleteButton.Text = "Delete";
			this.DeleteButton.UseVisualStyleBackColor = true;
			this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
			// 
			// DonorTab
			// 
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "DonorTab";
			this.Size = new System.Drawing.Size(685, 375);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.DonationTable)).EndInit();
			this.tableLayoutPanel3.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label FirstNameLabel;
        private System.Windows.Forms.Label LastNameLabel;
        private System.Windows.Forms.Label AliasLabel;
        private System.Windows.Forms.TextBox FirstNameText;
        private System.Windows.Forms.TextBox LastNameText;
        private System.Windows.Forms.TextBox AliasText;
        private System.Windows.Forms.DataGridView DonationTable;
        private System.Windows.Forms.TextBox EmailText;
        private System.Windows.Forms.Label EmailLabel;
		private System.Windows.Forms.Button SaveButton;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
		private System.Windows.Forms.Button RefreshButton;
		private System.Windows.Forms.Button DeleteButton;
		private System.Windows.Forms.Button OpenDonationButton;
    }
}
