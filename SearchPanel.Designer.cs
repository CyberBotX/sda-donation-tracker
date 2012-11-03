using System.Windows.Forms;
namespace SDA_DonationTracker
{
	partial class SearchPanel
	{
		private SplitContainer splitContainer1;
		private TableLayoutPanel SearchParamsTable;
		private TextBox BasicSearchText;
		private Button BasicSearchButton;
		private Button SearchButton;
		private ListBox ResultsList;

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
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.SearchParamsTable = new System.Windows.Forms.TableLayoutPanel();
			this.BasicSearchText = new System.Windows.Forms.TextBox();
			this.BasicSearchButton = new System.Windows.Forms.Button();
			this.ResultsList = new System.Windows.Forms.ListBox();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.SearchParamsTable.SuspendLayout();
			this.SuspendLayout();
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
			this.splitContainer1.Panel2.Controls.Add(this.ResultsList);
			this.splitContainer1.Size = new System.Drawing.Size(612, 325);
			this.splitContainer1.SplitterDistance = 432;
			this.splitContainer1.TabIndex = 0;
			// 
			// SearchParamsTable
			// 
			this.SearchParamsTable.AutoSize = true;
			this.SearchParamsTable.ColumnCount = 2;
			this.SearchParamsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.SearchParamsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.SearchParamsTable.Controls.Add(this.BasicSearchText, 0, 0);
			this.SearchParamsTable.Controls.Add(this.BasicSearchButton, 1, 1);
			this.SearchParamsTable.Dock = System.Windows.Forms.DockStyle.Top;
			this.SearchParamsTable.Location = new System.Drawing.Point(0, 0);
			this.SearchParamsTable.Name = "SearchParamsTable";
			this.SearchParamsTable.RowCount = 2;
			this.SearchParamsTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.SearchParamsTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.SearchParamsTable.Size = new System.Drawing.Size(432, 55);
			this.SearchParamsTable.TabIndex = 0;
			// 
			// BasicSearchText
			// 
			this.SearchParamsTable.SetColumnSpan(this.BasicSearchText, 2);
			this.BasicSearchText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.BasicSearchText.Location = new System.Drawing.Point(3, 3);
			this.BasicSearchText.Name = "BasicSearchText";
			this.BasicSearchText.Size = new System.Drawing.Size(426, 20);
			this.BasicSearchText.TabIndex = 0;
			// 
			// BasicSearchButton
			// 
			this.BasicSearchButton.Dock = System.Windows.Forms.DockStyle.Right;
			this.BasicSearchButton.Location = new System.Drawing.Point(334, 29);
			this.BasicSearchButton.Name = "BasicSearchButton";
			this.BasicSearchButton.Size = new System.Drawing.Size(95, 23);
			this.BasicSearchButton.TabIndex = 1;
			this.BasicSearchButton.Text = "Basic Search";
			this.BasicSearchButton.UseVisualStyleBackColor = true;
			// 
			// ResultsList
			// 
			this.ResultsList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ResultsList.FormattingEnabled = true;
			this.ResultsList.Location = new System.Drawing.Point(0, 0);
			this.ResultsList.Name = "ResultsList";
			this.ResultsList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.ResultsList.Size = new System.Drawing.Size(176, 325);
			this.ResultsList.TabIndex = 0;
			// 
			// SearchPanel
			// 
			this.Controls.Add(this.splitContainer1);
			this.Name = "SearchPanel";
			this.Size = new System.Drawing.Size(612, 325);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.SearchParamsTable.ResumeLayout(false);
			this.SearchParamsTable.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion
	}
}
