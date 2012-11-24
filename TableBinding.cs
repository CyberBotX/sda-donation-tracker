using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace SDA_DonationTracker
{
	class BiModelMapping
	{
		public Dictionary<string, string> TableToModel = new Dictionary<string,string>();
		public Dictionary<string, string> ModelToTable = new Dictionary<string,string>();
	}

	public class TableBinding : BindingContext
	{
		public static readonly string KeyColumn = "Key";
		public static readonly string ModelColumn = "Model";

		private static readonly string pkField = "pk";
		private static readonly string modelField = "model";
		private static readonly string fieldsField = "fields";

		private DataGridView DataGrid;
		private string[] Columns;

		private DataTable Table;

		private JArray LoadedData;

		private Dictionary<string, BiModelMapping> ModelMappings;

		public TableBinding(DataGridView dataGrid, params string[] columns)
		{
			this.DataGrid = dataGrid;
			this.AddAssociatedControl(dataGrid);
			this.Columns = columns.Select(s => s.ToLower()).ToArray();
			this.ModelMappings =  new Dictionary<string,BiModelMapping>();

			this.LoadArray(new JArray());
		}

		private string CanonicalModelName(string simpleModelName)
		{
			return "tracker." + simpleModelName;
		}

		private string CoreModelName(string fullModelName)
		{
			return fullModelName.Split('.')[1];
		}

		// TODO: add a way to generate pseudo-columns that are functions on the JObject instead of strings
		public void AddModelMapping(string modelName, IEnumerable<KeyValuePair<string, string> > modelToColumnMapping)
		{
			BiModelMapping mapping = new BiModelMapping();

			foreach (KeyValuePair<string, string> pair in modelToColumnMapping)
			{
				mapping.TableToModel[pair.Value] = pair.Key;
				mapping.ModelToTable[pair.Key] = pair.Value;
			}

			this.ModelMappings[modelName] = mapping;
		}

		public void AddDefaultModelMapping(string modelName)
		{
			BiModelMapping mapping = new BiModelMapping();

			foreach (string column in this.Columns)
				mapping.TableToModel[column] = mapping.ModelToTable[column] = column;

			this.ModelMappings[modelName] = mapping;
		}

		public void LoadArray(JArray data)
		{
			this.LoadedData = data;

			this.Table = new DataTable();

			// create hidden 'key' and 'model' fields so that each row can be re-attributed
			// to a persistent instance later
			this.Table.Columns.Add(KeyColumn, typeof(int)).ReadOnly = true;
			this.Table.Columns[KeyColumn].ColumnMapping = MappingType.Hidden;

			this.Table.Columns.Add(ModelColumn, typeof(string)).ReadOnly = true;
			this.Table.Columns[ModelColumn].ColumnMapping = MappingType.Hidden;

			foreach (string s in this.Columns)
				this.Table.Columns.Add(s.ToLower(), typeof(string)).Caption = s.SymbolToNatural();

			foreach (JObject toks in data.Values<JObject>())
			{
				int primaryKey = toks.Value<int>(pkField);
				string modelName = this.CoreModelName(toks.Value<string>(modelField));

				DataRow row = this.Table.Rows.Add(primaryKey, modelName);

				JObject fields = toks.Value<JObject>(fieldsField);

				if (this.ModelMappings.ContainsKey(modelName))
				{
					Dictionary<string,string> tableToModel = this.ModelMappings[modelName].TableToModel;

					foreach (string col in this.Columns)
						row[col] = fields.Value<string>(tableToModel[col]);
				}
				else
					throw new Exception("Model mapping for " + modelName + " unregistered");
			}

			this.DataGrid.InvokeEx(() => this.DataGrid.DataSource = Table);
		}

		public JArray SaveArray()
		{
			JArray result = new JArray();

			foreach (DataRow row in this.Table.Rows)
			{
				int? pk = row.Field<int?>(this.Table.Columns[KeyColumn]);
				string model = row.Field<string>(this.Table.Columns[ModelColumn]);

				JObject obj = new JObject();

				if (pk != null)
					obj.Add(pkField, pk ?? 0);

				if (model == null)
					throw new Exception("Error, model must be set for data field");

				obj.Add(modelField, this.CanonicalModelName(model));

				if (this.ModelMappings.ContainsKey(model))
				{
					Dictionary<string, string> tableToModel = this.ModelMappings[model].TableToModel;

					JObject fields = new JObject();
					obj.Add(fieldsField, fields);

					foreach (string col in this.Columns)
						fields.Add(tableToModel[col], row[col].ToString());
				}
				else
					throw new Exception("Model mapping for " + model + " unregistered");
			}

			return result;
		}
	}
}
