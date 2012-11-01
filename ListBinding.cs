using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace SDA_DonationTracker
{
	public class ListBinding<T> : BindingContext
	{
		private List<Control> SelectionControls = new List<Control>();
		private ListBox List;
		private Func<JToken, T> Builder;
		public string DisplayProperty
		{
			get
			{
				return this.List.DisplayMember;
			}
		}

		public bool AllowMultiSelect
		{
			get
			{
				return this.List.SelectionMode == SelectionMode.MultiExtended;
			}

			set
			{
				this.List.SelectionMode = value ? SelectionMode.MultiExtended : SelectionMode.One;
			}
		}

		public ListBinding(ListBox list, Func<JToken, T> builder, string displayProperty)
		{
			this.Builder = builder;
			this.List = list;

			this.AddAssociatedControl(this.List);
			this.List.SelectionMode = SelectionMode.One;
			this.List.DisplayMember = displayProperty;

			this.List.SelectedValueChanged += (e, o) =>
			{
				if (this.OnSelection != null)
					this.OnSelection.Invoke(this.GetSelections());
			};

			this.OnSelection += v =>
			{
				if (v.Count() > 0)
					this.EnableSelectionControls();
				else
					this.DisableSelectionControls();
			};

			this.LoadArray(new JArray());
		}

		public void AddSelectionControl(Control c)
		{
			this.SelectionControls.Add(c);
		}

		public override void DisableControls()
		{
			this.List.ClearSelected();
			this.DisableSelectionControls();
			base.DisableControls();
		}

		public void LoadArray(JArray results)
		{
			T[] newContent = results.Select(this.Builder).ToArray();

			if (this.List.InvokeRequired)
				this.List.Invoke(new SetListContentCallback(this.SetListContent), this.List, newContent);
			else
				this.SetListContent(this.List, newContent);
		}

		public event Action<IEnumerable<T>> OnSelection;

		public IEnumerable<T> GetSelections()
		{
			return this.List.SelectedItems.Cast<T>();
		}

		private delegate void SetListContentCallback(ListBox list, T[] data);

		private void SetListContent(ListBox list, T[] data)
		{
			list.DataSource = data;
		}

		private void DisableSelectionControls()
		{
			this.SelectionControls.ForEach(control =>
			{
				if (control.InvokeRequired)
					control.Invoke(new ControlCallback(this.DisableControl), control);
				else
					this.DisableControl(control);
			});
		}

		private void EnableSelectionControls()
		{
			this.SelectionControls.ForEach(control =>
			{
				if (control.InvokeRequired)
					control.Invoke(new ControlCallback(this.EnableControl), control);
				else
					this.EnableControl(control);
			});
		}
	}
}
