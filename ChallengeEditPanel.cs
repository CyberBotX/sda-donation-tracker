using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SDA_DonationTracker
{
	public class ChallengeEditPanel : EntityEditPanel
	{
		private EntityFormPanelConstruct ChallengeForm;

		public ChallengeEditPanel(MainForm owner, TrackerContext context)
			: base("choice", context, owner)
		{
			this.ChallengeForm = new EntityFormPanelConstruct("challenge",
				new string[]
				{
					"total",
					"name",
					"description",
					"goal",
					"state",
					"speedrun",
				},
				this.Context,
				this.Owner
			)
			{
				Dock = DockStyle.Fill,
			};

			this.Controls.Add(this.ChallengeForm);
		}

		public override IEnumerable<FormBinding> Forms
		{
			get { return new FormBinding[] { this.ChallengeForm.Binding }; }
		}

		public override IEnumerable<TableBinding> Tables
		{
			get
			{
				return new TableBinding[] { }; 
			}
		}
	}
}
