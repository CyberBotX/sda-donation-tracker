using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Windows.Forms;
using System.Threading;

namespace SDA_DonationTracker
{
	/**
	 * This is a relatively complex class that is meant to manage aggregate db interactions, such that
	 * calling refresh will refresh all elements in a given panel (forms, tables, etc), and only reactivate
	 * when all tasks are completed.
	 */
	public class EntityAccessContext
	{
		public int? RootId
		{
			get
			{
				return this.CachedData != null ? this.CachedData.GetId() : null;
			}
		}

		bool AllowRefresh 
		{ 
			get 
			{
				return this.RootId != null && !this.Busy; 
			} 
		}

		bool AllowSave
		{
			get
			{
				return !this.Busy;
			}
		}

		bool AllowDelete
		{
			get
			{
				return this.RootId != null && !this.Busy;
			}
		}

		public bool Busy { get; private set; }

		public TrackerContext Context { get; private set; }
		public string ModelName { get; private set; }
		public EntityModel Model { get; private set; }
		public JObject CachedData { get; private set; }

		private List<FormBinding> FormBindings = new List<FormBinding>();
		private List<Tuple<TableBinding, EntitySetModel>> TableBindings = new List<Tuple<TableBinding,EntitySetModel>>();

		public EntityAccessContext(string modelName, TrackerContext context)
		{
			this.ModelName = modelName;
			this.Model = DonationModels.GetModel(this.ModelName);
			this.Context = context;
			this.Busy = false;
		}

		public bool HasUnsavedChanges()
		{
			return this.FormBindings.Aggregate(false, (x, y) => x || y.HasUnsavedChanges()) || this.TableBindings.Aggregate(false, (x, y) => x || y.Item1.HasUnsavedChanges());
		}

		public void ClearForms()
		{
			this.CachedData = null;

			foreach (var form in this.FormBindings)
			{
				form.ClearFields();
			}

			foreach (var tablePair in this.TableBindings)
			{
				var table = tablePair.Item1;
				table.LoadArray(new JArray());
			}
		}

		public void Refresh(int? newId = null)
		{
			JoinWaiter waiter = new JoinWaiter(OnRefreshComplete);

			if (newId == null && this.RootId == null)
			{
				this.OnError(TrackerErrorType.NullKey, "There is no active instance to refresh.");
				return;
			}

			int id = newId ?? this.RootId ?? 0;

			foreach (var form in this.FormBindings)
			{
				form.DisableControls();
			}

			SearchContext searcher = this.Context.DeferredSearch(this.ModelName, Util.CreateIdSearch(id));
			waiter.AddProcess();

			searcher.OnComplete += (results) =>
			{
				this.CachedData = results.First() as JObject;
				foreach (var form in this.FormBindings)
				{
					form.LoadObject(this.CachedData);
					form.EnableControls();
				}

				waiter.ProcessComplete();
			};

			searcher.OnError += (error, message) =>
			{
				this.OnError(error, message);
				waiter.ProcessComplete();

				foreach (var form in this.FormBindings)
				{
					form.EnableControls();
				}
			};

			searcher.Begin();

			this.RunTablesRefresh(id, waiter);

			waiter.Start();
		}

		private void RunTablesRefresh(int id, JoinWaiter waiter)
		{
			foreach (var tablePair in this.TableBindings)
			{
				var table = tablePair.Item1;
				var mapping = tablePair.Item2;
				table.DisableControls();
				waiter.AddProcess();

				IEnumerable<string> models;

				if (mapping.GetModel.IsAbstract)
				{
					models = mapping.GetModel.GetChildEntities().Select(e => e.ModelName);
				}
				else
				{
					models = new string[]{ mapping.ModelName };
				}

				AggregateSearchContext searcher = new AggregateSearchContext(models.Select(m => new SearchContext(this.Context, m, Util.CreateSearchParams(mapping.SearchKeyField, id.ToString()))));

				searcher.Completed += (results) =>
				{
					table.LoadArray(results);
					waiter.ProcessComplete();
					table.EnableControls();
				};

				searcher.Error += (errorList) =>
				{
					foreach (var error in errorList)
						this.OnError(error.ErrorType, error.Message);
					waiter.ProcessComplete();
					table.EnableControls();
				};

				searcher.Begin();
			}
		}

		private void OnRefreshComplete()
		{
			if (this.RefreshComplete != null)
				this.RefreshComplete();
		}

		public void Save()
		{
			JoinWaiter waiter = new JoinWaiter(() =>
			{
				JoinWaiter finalWaiter = new JoinWaiter(OnSaveComplete);

				if (this.RootId != null)
				{
					this.RunTablesRefresh(this.RootId ?? 0, finalWaiter);
				}

				finalWaiter.Start();
			});

			JObject rootObject = JObjectEntityHelpers.CreateEntityObject(this.ModelName);

			bool initialSave = false;

			if (this.RootId != null)
				rootObject.SetId(this.RootId ?? 0);
			else
				initialSave = true;

			rootObject.SetModel(this.ModelName);

			foreach (var form in this.FormBindings)
			{
				form.DisableControls();
				JObject savedObject = form.SaveObject(diffOnly: true);
				rootObject.MergeFrom(savedObject);
			}

			SaveContext rootSaver = this.Context.DeferredSave(this.ModelName, Util.BuildSaveParams(rootObject));
			waiter.AddProcess();

			rootSaver.OnComplete += (result) =>
			{
				this.CachedData = result;

				foreach (var form in this.FormBindings)
				{
					form.LoadObject(this.CachedData);
					form.EnableControls();
				}

				if (initialSave && this.RootId != null)
					this.RunTablesSave(this.RootId ?? 0, waiter);

				waiter.ProcessComplete();
			};

			rootSaver.OnError += (error, message) =>
			{
				this.OnError(error, message);

				foreach (var form in this.FormBindings)
				{
					form.EnableControls();
				}

				foreach (var tablePair in this.TableBindings)
				{
					tablePair.Item1.EnableControls();
				}

				waiter.ProcessComplete();
			};

			rootSaver.Begin();

			if (!initialSave)
			{
				this.RunTablesSave(this.RootId ?? 0, waiter);
			}

			waiter.Start();
		}

		private void RunTablesSave(int id, JoinWaiter waiter)
		{
			foreach (var tablePair in this.TableBindings)
			{
				TableBinding table = tablePair.Item1;
				EntitySetModel mapping = tablePair.Item2;
				waiter.AddProcess();

				var subWaiter = new JoinWaiter(() =>
				{
					table.EnableControls();
					waiter.ProcessComplete();
				});

				table.DisableControls();
				JArray tableData = table.SaveArray(diffOnly: true);

				foreach (JObject value in tableData)
				{
					subWaiter.AddProcess();

					if (value.GetFields().Any())
					{
						value.SetField(mapping.KeyField, id.ToString());
						SaveContext saver = this.Context.DeferredSave(value.GetModel(), Util.BuildSaveParams(value));

						saver.OnComplete += (result) =>
						{
							subWaiter.ProcessComplete();
						};

						saver.OnError += (error, message) =>
						{
							this.OnError(error, message);
							subWaiter.ProcessComplete();
						};

						saver.Begin();
					}
				}

				JArray removedValues = table.DeletionArray();

				foreach (JObject value in removedValues)
				{
					subWaiter.AddProcess();

					if (mapping.Resolution == OrphanResolution.Null)
					{
						SaveContext saver = this.Context.DeferredSave(value.GetModel(), Util.CreateSearchParams("id", value.GetId().ToString(), mapping.KeyField, null));

						saver.OnComplete += (result) =>
						{
							subWaiter.ProcessComplete();
						};

						saver.OnError += (error, message) =>
						{
							this.OnError(error, message);
							subWaiter.ProcessComplete();
						};

						saver.Begin();
					}
					else
					{
						DeleteContext deleter = this.Context.DeferredDelete(value.GetModel(), value.GetId() ?? 0);

						deleter.OnComplete += (result) =>
						{
							subWaiter.ProcessComplete();
						};

						deleter.OnError += (error, message) =>
						{
							this.OnError(error, message);
							subWaiter.ProcessComplete();
						};

						deleter.Begin();
					}
				}

				subWaiter.Start();
			}
		}

		private void OnSaveComplete()
		{
			if (this.SaveComplete != null)
				this.SaveComplete();
		}

		public void Delete()
		{
			if (this.RootId == null)
			{
				this.OnError(TrackerErrorType.NullKey, "There is no active instance to delete.");
				return;
			}

			int id = this.RootId ?? 0;

			foreach (var form in this.FormBindings)
			{
				form.DisableControls();
			}

			foreach (var table in this.TableBindings)
			{
				table.Item1.DisableControls();
			}

			DeleteContext deleter = this.Context.DeferredDelete(this.ModelName, id);

			deleter.OnComplete += (result) =>
			{
				foreach (var form in this.FormBindings)
				{
					form.DisableControls();
				}

				foreach (var table in this.TableBindings)
				{
					table.Item1.DisableControls();
				}

				this.OnDeleteComplete();
			};

			deleter.OnError += (error, message) =>
			{
				this.OnError(error, message);

				foreach (var form in this.FormBindings)
				{
					form.DisableControls();
				}

				foreach (var table in this.TableBindings)
				{
					table.Item1.DisableControls();
				}
			};

			deleter.Begin();
		}

		private void OnDeleteComplete()
		{
			if (this.DeleteComplete != null)
				this.DeleteComplete();
		}

		private void OnError(TrackerErrorType error, string message)
		{
			if (this.Error != null)
				this.Error(error, message);
		}

		public event Action RefreshComplete;
		public event Action SaveComplete;
		public event Action DeleteComplete;
		public event Action<TrackerErrorType, string> Error;

		public void AddForm(FormBinding formBinding)
		{
			FormBindings.Add(formBinding);
		}

		public void AddTable(TableBinding tableBinding, EntitySetModel fieldModel)
		{
			TableBindings.Add(new Tuple<TableBinding, EntitySetModel>(tableBinding, fieldModel));
		}
	}
}
