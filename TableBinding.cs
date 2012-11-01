using System.Data;
using System.Linq;
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
			this.DataGrid = dataGrid;
			this.AddAssociatedControl(dataGrid);
			this.Columns = columns.Select(s => s.ToLower()).ToArray();

			this.LoadArray(new JArray());
		}

		public void LoadArray(JArray data)
		{
			this.LoadedData = data;

			this.Table = new DataTable();

			this.Table.Columns.Add("Key", typeof(int)).ReadOnly = true;

			foreach (string s in this.Columns)
				this.Table.Columns.Add(s.ToLower(), typeof(string)).Caption = s.SymbolToNatural();

			foreach (JObject toks in data.Values<JObject>())
			{
				DataRow row = this.Table.Rows.Add(toks.Value<int>("pk"));

				JObject fields = toks.Value<JObject>("fields");

				foreach (string col in this.Columns)
					row[col] = fields.Value<string>(col);
			}

			if (this.DataGrid.InvokeRequired)
				this.DataGrid.Invoke(new SetTableDataCallback(this.SetTableData));
			else
				this.SetTableData();
		}

		private delegate void SetTableDataCallback();

		private void SetTableData()
		{
			this.DataGrid.DataSource = Table;
		}
	}
}
