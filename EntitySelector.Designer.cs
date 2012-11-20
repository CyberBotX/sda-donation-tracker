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
			this.SplitContainer = new System.Windows.Forms.SplitContainer();
			this.NameText = new System.Windows.Forms.TextBox();
			this.ButtonsPanel = new System.Windows.Forms.FlowLayoutPanel();
			this.OpenButton = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.SplitContainer)).BeginInit();
			this.SplitContainer.Panel1.SuspendLayout();
			this.SplitContainer.Panel2.SuspendLayout();
			this.SplitContainer.SuspendLayout();
			this.ButtonsPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// SplitContainer
			// 
			this.SplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.SplitContainer.Location = new System.Drawing.Point(0, 0);
			this.SplitContainer.Name = "SplitContainer";
			// 
			// SplitContainer.Panel1
			// 
			this.SplitContainer.Panel1.Controls.Add(this.NameText);
			// 
			// SplitContainer.Panel2
			// 
			this.SplitContainer.Panel2.Controls.Add(this.ButtonsPanel);
			this.SplitContainer.Size = new System.Drawing.Size(265, 38);
			this.SplitContainer.SplitterDistance = 165;
			this.SplitContainer.TabIndex = 0;
			// 
			// NameText
			// 
			this.NameText.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.NameText.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.NameText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.NameText.Location = new System.Drawing.Point(0, 0);
			this.NameText.Name = "NameText";
			this.NameText.Size = new System.Drawing.Size(165, 20);
			this.NameText.TabIndex = 0;
			// 
			// ButtonsPanel
			// 
			this.ButtonsPanel.AutoSize = true;
			this.ButtonsPanel.Controls.Add(this.OpenButton);
			this.ButtonsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ButtonsPanel.Location = new System.Drawing.Point(0, 0);
			this.ButtonsPanel.Name = "ButtonsPanel";
			this.ButtonsPanel.Size = new System.Drawing.Size(96, 38);
			this.ButtonsPanel.TabIndex = 0;
			// 
			// OpenButton
			// 
			this.OpenButton.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.OpenButton.Location = new System.Drawing.Point(3, 3);
			this.OpenButton.Name = "OpenButton";
			this.OpenButton.Size = new System.Drawing.Size(75, 23);
			this.OpenButton.TabIndex = 0;
			this.OpenButton.Text = "Open";
			this.OpenButton.UseVisualStyleBackColor = true;
			this.OpenButton.Click += new System.EventHandler(this.OpenButton_Click);
			// 
			// EntitySelector
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.Controls.Add(this.SplitContainer);
			this.Name = "EntitySelector";
			this.Size = new System.Drawing.Size(265, 38);
			this.SplitContainer.Panel1.ResumeLayout(false);
			this.SplitContainer.Panel1.PerformLayout();
			this.SplitContainer.Panel2.ResumeLayout(false);
			this.SplitContainer.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.SplitContainer)).EndInit();
			this.SplitContainer.ResumeLayout(false);
			this.ButtonsPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer SplitContainer;
		private System.Windows.Forms.TextBox NameText;
		private System.Windows.Forms.FlowLayoutPanel ButtonsPanel;
		private System.Windows.Forms.Button OpenButton;
	}
}
