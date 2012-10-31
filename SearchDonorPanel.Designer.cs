namespace SDA_DonationTracker
{
    partial class SearchDonorPanel
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
            this.SearchButton = new System.Windows.Forms.Button();
            this.FirstNameLabel = new System.Windows.Forms.Label();
            this.FirstNameText = new System.Windows.Forms.TextBox();
            this.SearchParamsTable = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.BasicSearchButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.EmailLabel = new System.Windows.Forms.Label();
            this.LastNameText = new System.Windows.Forms.TextBox();
            this.EmailText = new System.Windows.Forms.TextBox();
            this.AliasText = new System.Windows.Forms.TextBox();
            this.BasicSearchText = new System.Windows.Forms.TextBox();
            this.ResultsView = new System.Windows.Forms.DataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.SearchParamsTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ResultsView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SearchButton
            // 
            this.SearchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchButton.AutoSize = true;
            this.SearchButton.Location = new System.Drawing.Point(286, 162);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(108, 23);
            this.SearchButton.TabIndex = 6;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // FirstNameLabel
            // 
            this.FirstNameLabel.AutoSize = true;
            this.FirstNameLabel.Location = new System.Drawing.Point(3, 81);
            this.FirstNameLabel.Name = "FirstNameLabel";
            this.FirstNameLabel.Size = new System.Drawing.Size(57, 13);
            this.FirstNameLabel.TabIndex = 1;
            this.FirstNameLabel.Text = "First Name";
            // 
            // FirstNameText
            // 
            this.FirstNameText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FirstNameText.Location = new System.Drawing.Point(67, 84);
            this.FirstNameText.Name = "FirstNameText";
            this.FirstNameText.Size = new System.Drawing.Size(327, 20);
            this.FirstNameText.TabIndex = 3;
            // 
            // SearchParamsTable
            // 
            this.SearchParamsTable.AutoSize = true;
            this.SearchParamsTable.ColumnCount = 2;
            this.SearchParamsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.SearchParamsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.SearchParamsTable.Controls.Add(this.label1, 0, 4);
            this.SearchParamsTable.Controls.Add(this.BasicSearchButton, 1, 1);
            this.SearchParamsTable.Controls.Add(this.SearchButton, 1, 6);
            this.SearchParamsTable.Controls.Add(this.label2, 0, 5);
            this.SearchParamsTable.Controls.Add(this.FirstNameLabel, 0, 3);
            this.SearchParamsTable.Controls.Add(this.EmailLabel, 0, 2);
            this.SearchParamsTable.Controls.Add(this.LastNameText, 1, 4);
            this.SearchParamsTable.Controls.Add(this.FirstNameText, 1, 3);
            this.SearchParamsTable.Controls.Add(this.EmailText, 1, 2);
            this.SearchParamsTable.Controls.Add(this.AliasText, 1, 5);
            this.SearchParamsTable.Controls.Add(this.BasicSearchText, 0, 0);
            this.SearchParamsTable.Dock = System.Windows.Forms.DockStyle.Top;
            this.SearchParamsTable.Location = new System.Drawing.Point(0, 0);
            this.SearchParamsTable.Name = "SearchParamsTable";
            this.SearchParamsTable.RowCount = 7;
            this.SearchParamsTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.SearchParamsTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.SearchParamsTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.SearchParamsTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.SearchParamsTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.SearchParamsTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.SearchParamsTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.SearchParamsTable.Size = new System.Drawing.Size(397, 188);
            this.SearchParamsTable.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Last Name";
            // 
            // BasicSearchButton
            // 
            this.BasicSearchButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.BasicSearchButton.AutoSize = true;
            this.BasicSearchButton.Location = new System.Drawing.Point(286, 29);
            this.BasicSearchButton.Name = "BasicSearchButton";
            this.BasicSearchButton.Size = new System.Drawing.Size(108, 23);
            this.BasicSearchButton.TabIndex = 1;
            this.BasicSearchButton.Text = "Basic Search";
            this.BasicSearchButton.UseVisualStyleBackColor = true;
            this.BasicSearchButton.Click += new System.EventHandler(this.BasicSearchButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Alias";
            // 
            // EmailLabel
            // 
            this.EmailLabel.AutoSize = true;
            this.EmailLabel.Location = new System.Drawing.Point(3, 55);
            this.EmailLabel.Name = "EmailLabel";
            this.EmailLabel.Size = new System.Drawing.Size(32, 13);
            this.EmailLabel.TabIndex = 5;
            this.EmailLabel.Text = "Email";
            // 
            // LastNameText
            // 
            this.LastNameText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LastNameText.Location = new System.Drawing.Point(67, 110);
            this.LastNameText.Name = "LastNameText";
            this.LastNameText.Size = new System.Drawing.Size(327, 20);
            this.LastNameText.TabIndex = 4;
            // 
            // EmailText
            // 
            this.EmailText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EmailText.Location = new System.Drawing.Point(67, 58);
            this.EmailText.Name = "EmailText";
            this.EmailText.Size = new System.Drawing.Size(327, 20);
            this.EmailText.TabIndex = 2;
            // 
            // AliasText
            // 
            this.AliasText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AliasText.Location = new System.Drawing.Point(67, 136);
            this.AliasText.Name = "AliasText";
            this.AliasText.Size = new System.Drawing.Size(327, 20);
            this.AliasText.TabIndex = 5;
            // 
            // BasicSearchText
            // 
            this.SearchParamsTable.SetColumnSpan(this.BasicSearchText, 2);
            this.BasicSearchText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BasicSearchText.Location = new System.Drawing.Point(3, 3);
            this.BasicSearchText.Name = "BasicSearchText";
            this.BasicSearchText.Size = new System.Drawing.Size(391, 20);
            this.BasicSearchText.TabIndex = 0;
            // 
            // ResultsView
            // 
            this.ResultsView.AllowUserToAddRows = false;
            this.ResultsView.AllowUserToDeleteRows = false;
            this.ResultsView.AllowUserToResizeRows = false;
            this.ResultsView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ResultsView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ResultsView.Location = new System.Drawing.Point(0, 0);
            this.ResultsView.Name = "ResultsView";
            this.ResultsView.Size = new System.Drawing.Size(530, 425);
            this.ResultsView.TabIndex = 7;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.SearchParamsTable);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ResultsView);
            this.splitContainer1.Size = new System.Drawing.Size(931, 425);
            this.splitContainer1.SplitterDistance = 397;
            this.splitContainer1.TabIndex = 8;
            // 
            // SearchDonorPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "SearchDonorPanel";
            this.Size = new System.Drawing.Size(931, 425);
            this.SearchParamsTable.ResumeLayout(false);
            this.SearchParamsTable.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ResultsView)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.Label FirstNameLabel;
        private System.Windows.Forms.TextBox FirstNameText;
        private System.Windows.Forms.TableLayoutPanel SearchParamsTable;
        private System.Windows.Forms.DataGridView ResultsView;
        private System.Windows.Forms.TextBox AliasText;
        private System.Windows.Forms.TextBox LastNameText;
        private System.Windows.Forms.TextBox EmailText;
        private System.Windows.Forms.Label EmailLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BasicSearchButton;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox BasicSearchText;

    }
}
