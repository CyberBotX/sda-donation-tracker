using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace SDA_DonationTracker
{
    public class ListBinding<T> : BindingContext
    {
        private List<Control> SelectionControls = new List<Control>();
        private ListBox List;
        private Func<JToken, T> Builder;
        public string DisplayProperty { get { return List.DisplayMember; } }

        public bool AllowMultiSelect
        {
            get
            {
                return List.SelectionMode == SelectionMode.MultiExtended;
            }

            set
            {
                List.SelectionMode = value ? SelectionMode.MultiExtended : SelectionMode.One;
            }
        }

        public ListBinding(ListBox list, Func<JToken, T> builder, string displayProperty)
        {
            Builder = builder;
            List = list;

            AddAssociatedControl(List);
            List.SelectionMode = SelectionMode.One;
            List.DisplayMember = displayProperty;

            List.SelectedValueChanged += (e, o) =>
            {
                if (OnSelection != null)
                {
                    OnSelection.Invoke(GetSelections());
                }
            };

            OnSelection += (v) =>
            {
                if (v.Count() > 0)
                {
                    EnableSelectionControls();
                }
                else
                {
                    DisableSelectionControls();
                }
            };

            LoadArray(new JArray());
        }

        public void AddSelectionControl(Control c)
        {
            SelectionControls.Add(c);
        }

        public override void DisableControls()
        {
            List.ClearSelected();
            DisableSelectionControls();
            base.DisableControls();
        }

        public void LoadArray(JArray results)
        {
            T[] newContent = results.Select(Builder).ToArray();

            if (List.InvokeRequired)
            {
                List.Invoke(new SetListContentCallback(SetListContent), List, newContent);
            }
            else
            {
                SetListContent(List, newContent);
            }
        }

        public event Action<IEnumerable<T>> OnSelection;

        public IEnumerable<T> GetSelections()
        {
            return List.SelectedItems.Cast<T>();
        }

        private delegate void SetListContentCallback(ListBox list, T[] data);

        private void SetListContent(ListBox list, T[] data)
        {
            list.DataSource = data;
        }

        private void DisableSelectionControls()
        {
            foreach (var control in SelectionControls)
            {
                if (control.InvokeRequired)
                {
                    control.Invoke(new ControlCallback(DisableControl), control);
                }
                else
                {
                    DisableControl(control);
                }
            }
        }

        private void EnableSelectionControls()
        {
            foreach (var control in SelectionControls)
            {
                if (control.InvokeRequired)
                {
                    control.Invoke(new ControlCallback(EnableControl), control);
                }
                else
                {
                    EnableControl(control);
                }
            }
        }
    }
}
