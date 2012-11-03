﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SDA_DonationTracker
{
	public partial class SearchTab : UserControl
	{
		public MainForm Owner { get; set; }
		public TrackerContext TrackerContext
		{
			get
			{
				return this.SearchPanel.TrackerContext;
			}
			set
			{
				this.SearchPanel.TrackerContext = value;
			}
		}

		public SearchTab(SearchPanel searchPanel)
		{
			this.SearchPanel = searchPanel;
			InitializeComponent();
			this.SearchPanel.AddSelectionControl(this.OpenButton);
		}

		private void OpenButton_Click(object sender, EventArgs e)
		{
			//Console.WriteLine(string.Join("\n", this.SearchPanel.GetSelections()));

			foreach (var id in this.SearchPanel.GetSelections())
				Owner.NavigateTo(this.SearchPanel.Model.ModelName, id);
		}
	}
}