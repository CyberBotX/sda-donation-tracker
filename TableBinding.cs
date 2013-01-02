using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using System.Threading;

namespace SDA_DonationTracker
{
	class BiModelMapping
	{
		public Dictionary<string, string> TableToModel = new Dictionary<string,string>();
		public Dictionary<string, string> ModelToTable = new Dictionary<string,string>();
	}

	public class TableBinding : BindingContext
	{
		public TrackerContext Context
		{
			get;
			set;
		}

		public static readonly string KeyColumn = "Key";
		public static readonly string ModelColumn = "Model";

		private static readonly string FieldsField = "fields";

		private DataGridView DataGrid;
		private string[] Columns;

		private DataTable Table;

		private JArray CachedData;
		private Dictionary<Tuple<string, int?>, JObject> CachedObjectTable;

		private Dictionary<string, BiModelMapping> ModelMappings;

		public TableBinding(DataGridView dataGrid, params string[] columns)
		{
			this.DataGrid = dataGrid;
			this.AddAssociatedControl(dataGrid);
			this.Columns = columns.Select(s => s.ToLower()).ToArray();
			this.ModelMappings =  new Dictionary<string,BiModelMapping>();

			this.DataGrid.EditingControlShowing += OnControlBegin;
			this.DataGrid.CellBeginEdit += OnBeginEdit;
			this.DataGrid.CellEndEdit += OnControlEnd;
			this.DataGrid.UserDeletingRow += OnRowDelete;

			this.LoadArray(new JArray());
		}

		public IEnumerable<string> GetModelNames()
		{
			return this.ModelMappings.Keys;
		}

		public IEnumerable<string> GetColumnNames()
		{
			return this.Columns;
		}

		private void OnBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
		{
			int currentCol = e.ColumnIndex;
			int currentRow = e.RowIndex;

			DataRowView remappedRow = this.GetRowView(currentRow);
			EntityModel model = this.GetRowModel(remappedRow);
			string columnModelName = this.DataGrid.Columns[currentCol].DataPropertyName;
			FieldModel field = model.GetField(this.ModelMappings[model.ModelName].TableToModel[columnModelName]);

			if (field.ReadOnly)
			{
				e.Cancel = true;
			}
		}

		private void OnRowDelete(object sender, DataGridViewRowCancelEventArgs e)
		{
			if (MessageBox.Show("Are you sure you want to delete this item?", "Confirm delete...", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
				e.Cancel = false;
			else
				e.Cancel = true;
		}

		private void OnControlEnd(object sender, DataGridViewCellEventArgs a)
		{
			int currentCol = a.ColumnIndex;
			int currentRow = a.RowIndex;

			DataRowView remappedRow = this.GetRowView(currentRow);

			EntityModel model = this.GetRowModel(remappedRow);

			string columnModelName = this.DataGrid.Columns[currentCol].DataPropertyName;
			FieldModel field = model.GetField(this.ModelMappings[model.ModelName].TableToModel[columnModelName]);

			string immediateValue = remappedRow[columnModelName].ToString();
			string trueValue = remappedRow[this.TrueColumnName(columnModelName)].ToString();

			if (field is EntityFieldModel)
			{
				EntityFieldModel entityField = field as EntityFieldModel;

				var cache = this.Context.GetEntitySelectionCache(entityField.ModelName);
				cache.DataRefreshed -= this.ResetControlCache;
				var cacheTable = cache.GetLatestCache();

				int fk;

				if (cacheTable.TryGetRightToLeft(immediateValue, out fk))
					trueValue = fk.ToString();
			}
			else
			{
				trueValue = immediateValue;
			}

			remappedRow[this.TrueColumnName(columnModelName)] = trueValue;
		}

		private void ResetControlCache(IBiMap<int, string> cacheTable)
		{
			this.ResetControlCache(cacheTable, null);
		}

		private void ResetControlCache(IBiMap<int, string> cacheTable, string trueValue = null)
		{
			TextBox control = this.DataGrid.EditingControl as TextBox;
			AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
			foreach (var entry in cacheTable.EnumerateLeftToRight().Select(p => p.Value))
			{
				collection.Add(entry);
			}

			int? fk = null;

			if (!string.IsNullOrEmpty(trueValue))
				fk = int.Parse(trueValue);

			control.InvokeEx(() =>
			{
				if (fk != null)
					control.Text = cacheTable.GetLeftToRight(fk ?? 0);
				control.AutoCompleteCustomSource = collection;
				control.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
				control.AutoCompleteSource = AutoCompleteSource.CustomSource;
			});
		}

		private void OnControlBegin(object sender, DataGridViewEditingControlShowingEventArgs eventArgs)
		{
			int currentCol = this.DataGrid.CurrentCell.ColumnIndex;
			int currentRow = this.DataGrid.CurrentCell.RowIndex;

			DataRowView remappedRow = this.GetRowView(currentRow);

			EntityModel model = this.GetRowModel(remappedRow);

			string columnModelName = this.DataGrid.Columns[currentCol].DataPropertyName;
			FieldModel field = model.GetField(this.ModelMappings[model.ModelName].TableToModel[columnModelName]);

			string immediateValue = remappedRow[columnModelName].ToString();
			string trueValue = remappedRow[this.TrueColumnName(columnModelName)].ToString();

			if (field is EntityFieldModel)
			{
				EntityFieldModel entityField = field as EntityFieldModel;

				var cache = this.Context.GetEntitySelectionCache(entityField.ModelName);

				cache.RequestRefresh();
				cache.DataRefreshed += this.ResetControlCache;
				var cacheTable = cache.GetLatestCache();

				if (cacheTable.Count > 0)
					this.DataGrid.Columns[currentCol].Width = cacheTable.EnumerateLeftToRight().Select(p => p.Value.Length).Max() * 10;
				else
					this.DataGrid.Columns[currentCol].Width= 80;

				this.ResetControlCache(cacheTable, trueValue);

				TextBoxBase selector = this.DataGrid.EditingControl as TextBoxBase;

				MenuItem searchMenuItem = new MenuItem()
				{
					Text = "Search...",
				};

				searchMenuItem.Click += (o, e) =>
				{
					SearchPanel panel = SearchPanelHelpers.CreatePanelForModel(entityField.ModelName);
					panel.Context = this.Context;
					SearchDialog dialog = new SearchDialog(panel);
					dialog.ShowDialog();

					if (dialog.Result != null)
					{
						remappedRow[columnModelName] = dialog.Result.GetDisplayName();
						selector.Text = dialog.Result.GetDisplayName();
						remappedRow[this.TrueColumnName(columnModelName)] = dialog.Result.GetId().ToString();
					}
				};

				MenuItem refreshMenuItem = new MenuItem()
				{
					Text = "Force Refresh",
				};

				refreshMenuItem.Click += (o, e) =>
				{
					cache.RequestRefresh(EntitySelectionCacheRefreshType.Force);
				};

				selector.ContextMenu = new ContextMenu()
				{
					MenuItems = 
					{
						searchMenuItem,
						refreshMenuItem,
					}
				};
			}
		}

		private EntityModel GetRowModel(DataRowView row)
		{
			return DonationModels.GetModel(row[ModelColumn].ToString());
		}

		private DataRowView GetRowView(int row)
		{
			return this.DataGrid.Rows[row].DataBoundItem as DataRowView;
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

		private Dictionary<Tuple<string, int?>, JObject> BuildCachedObjectTable()
		{
			var result = new Dictionary<Tuple<string, int?>, JObject>();

			if (this.CachedData != null)
			{
				foreach (JObject obj in CachedData)
				{
					result[new Tuple<string, int?>(obj.GetModel(), obj.GetId())] = obj;
				}
			}

			return result;
		}

		private string TrueColumnName(string columnName)
		{
			return "true__" + columnName.ToLower();
		}

		public void LoadArray(JArray data)
		{
			this.CachedData = data;
			this.CachedObjectTable = this.BuildCachedObjectTable();

			this.Table = new DataTable();

			// create hidden 'key' and 'model' fields so that each row can be re-attributed
			// to a persistent instance later
			var keyColumn = this.Table.Columns.Add(KeyColumn, typeof(int));
			keyColumn.ReadOnly = true;
			keyColumn.ColumnMapping = MappingType.Hidden;

			var modelColumn = this.Table.Columns.Add(ModelColumn, typeof(string));
			bool hideModel = this.ModelMappings.Count <= 1;
			modelColumn.ReadOnly = true;
			modelColumn.ColumnMapping = hideModel ? MappingType.Hidden : MappingType.Attribute;

			foreach (string s in this.Columns)
			{
				DataColumn column = this.Table.Columns.Add(s, typeof(string));
				column.Caption = s.SymbolToNatural();

				DataColumn trueColumn = this.Table.Columns.Add(this.TrueColumnName(s), typeof(string));
				trueColumn.ColumnMapping = MappingType.Hidden;
				trueColumn.DefaultValue = null;
			}

			foreach (JObject dataObj in data.Values<JObject>())
			{
				this.AddRow(dataObj);
			}

			this.DataGrid.InvokeEx(() =>
			{
				this.DataGrid.DataSource = this.Table;
			});
		}

		public JArray DeletionArray()
		{
			var cachedObjectTable = BuildCachedObjectTable();
			JArray result = new JArray();

			// So very, very inefficient
			JArray knownValues = this.SaveArray();

			// Find all values listed in the save listing which have Ids, and remove them from
			// the dictionary
			foreach (JObject obj in knownValues)
			{
				if (obj.GetId() != null)
				{
					cachedObjectTable.Remove(new Tuple<string, int?>(obj.GetModel(), obj.GetId()));
				}
			}

			// Any values remaining in the dictionary are not in the table, and thus have been removed
			foreach (JObject obj in cachedObjectTable.Values)
			{
				result.Add(obj);
			}

			return result;
		}

		public JArray SaveArray(bool diffOnly = false)
		{
			var cachedObjectTable = BuildCachedObjectTable();

			JArray result = new JArray();

			foreach (DataRow row in this.Table.Rows)
			{
				JObject data = this.RetreiveObjectFromRow(row, diffOnly);

				if (!diffOnly || data.GetFields().Any())
					result.Add(data);
			}

			return result;
		}

		public bool HasUnsavedChanges()
		{
			return this.SaveArray(true).Any();
		}

		private void FillObjectToRow(DataRow row, JObject dataObj)
		{
			int? primaryKey = dataObj.GetId();
			string modelName = dataObj.GetModel();
			EntityModel model = DonationModels.GetModel(modelName);

			if (this.ModelMappings.ContainsKey(modelName))
			{
				Dictionary<string,string> tableToModel = this.ModelMappings[modelName].TableToModel;

				foreach (string col in this.Columns)
				{
					string trueColumn = this.TrueColumnName(col);
					FieldModel field = model.GetField(tableToModel[col]);

					string trueValue = dataObj.GetField(tableToModel[col]);
					row[trueColumn] = trueValue;

					if (field is EntityFieldModel)
					{
						EntityFieldModel entityField = field as EntityFieldModel;
						EntitySelectionCache cache = this.Context.GetEntitySelectionCache(entityField.ModelName);

						cache.RequestRefresh(EntitySelectionCacheRefreshType.Strong);
							
						var mapping = cache.GetLatestCache();

						if (trueValue != null)
						{
							int fk = int.Parse(trueValue);

							string name;
							if (mapping.TryGetLeftToRight(fk, out name))
								row[col] = name;
							else
								row[col] = row[trueColumn];
						}
						else
						{
							row[col] = "";
						}
					}
					else
					{
						row[col] = trueValue;
					}

				}
			}
			else
				throw new Exception("Model mapping for " + modelName + " unregistered");
		}

		private JObject RetreiveObjectFromRow(DataRow row, bool diffOnly = false)
		{
			int? pk = row.Field<int?>(this.Table.Columns[KeyColumn]);
			string modelName = row.Field<string>(this.Table.Columns[ModelColumn]);

			JObject obj = new JObject();
			obj.Add(FieldsField, new JObject());

			if (pk != null)
				obj.SetId(pk ?? 0);

			if (modelName == null)
				throw new Exception("Error, model must be set for data field");

			obj.SetModel(modelName);

			if (this.ModelMappings.ContainsKey(modelName))
			{
				Dictionary<string, string> tableToModel = this.ModelMappings[modelName].TableToModel;
				EntityModel model = DonationModels.GetModel(modelName);

				foreach (string col in this.Columns)
				{
					JObject found = null;

					if (obj.GetId() != null)
						this.CachedObjectTable.TryGetValue(new Tuple<string, int?>(obj.GetModel(), obj.GetId()), out found);

					string fieldName = tableToModel[col];
					string value = row[this.TrueColumnName(col)] == null ? null : row[this.TrueColumnName(col)].ToString();

					if (!model.GetField(fieldName).ReadOnly && (!diffOnly || found == null || !Util.EqualsEx(found.GetField(fieldName), value)))
						obj.SetField(fieldName, value);
				}

				return obj;
			}
			else
				throw new Exception("Model mapping for " + modelName + " unregistered");
		}

		public void AddRow(JObject dataObj)
		{
			int? primaryKey = dataObj.GetId();
			string modelName = dataObj.GetModel();

			if (primaryKey != null)
			{
				foreach (DataRow row in this.Table.Rows)
				{
					if (row[ModelColumn].ToString().IEquals(modelName) && row[KeyColumn].ToString().Equals(primaryKey.ToString()))
					{
						this.FillObjectToRow(row, dataObj);
						return;
					}
				}
			}

			DataRow newRow = this.Table.Rows.Add(primaryKey, modelName);

			this.FillObjectToRow(newRow, dataObj);
		}

		public JObject GetRowData(int rowIndex)
		{
			return this.RetreiveObjectFromRow(this.Table.Rows[rowIndex]);
		}

		public void RemoveRow(int rowIndex)
		{
			this.Table.Rows.RemoveAt(rowIndex);
		}
	}
}
