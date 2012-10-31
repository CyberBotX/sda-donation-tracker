using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace SDA_DonationTracker
{
    public class TableBinding : BindingContext
    {
        private DataGridView DataGrid;
        private string[] Columns;

        private DataTable Table;

        private JArray LoadedData;

        public TableBinding(DataGridView dataGrid, params string[] columns)
        {
            DataGrid = dataGrid;
            AddAssociatedControl(dataGrid);
            Columns = columns.Select(s => s.ToLower()).ToArray();

            LoadArray(new JArray());
        }

        public void LoadArray(JArray data)
        {
            LoadedData = data;

            Table = new DataTable();

            DataColumn column = Table.Columns.Add("Key", typeof(int));

            column.ReadOnly = true;

            foreach (var s in Columns)
            {
                DataColumn fieldColumn = Table.Columns.Add(s.ToLower(), typeof(string));

                fieldColumn.Caption = s.SymbolToNatural();
            }

            foreach (var toks in data.Values<JObject>())
            {
                DataRow row = Table.Rows.Add(toks.Value<int>("pk"));

                JObject fields = toks.Value<JObject>("fields");

                foreach (var col in Columns)
                {
                    row[col] = fields.Value<string>(col);
                }
            }

            if (DataGrid.InvokeRequired)
            {
                DataGrid.Invoke(new SetTableDataCallback(SetTableData));
            }
            else
            {
                SetTableData();
            }
        }

        private delegate void SetTableDataCallback();

        private void SetTableData()
        {
            DataGrid.DataSource = Table;
        }
    }
}
