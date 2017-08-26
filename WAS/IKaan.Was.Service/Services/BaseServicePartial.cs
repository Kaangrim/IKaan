using System;
using System.Collections.Generic;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Model.Common.Was;
using IKaan.Model.IKBase;
using IKaan.Was.Core.Mappers;
using IKaan.Was.Service.Utils;
using Newtonsoft.Json.Linq;

namespace IKaan.Was.Service.Services
{
	public static class BaseServicePartial
	{
		public static void SaveMenuView(this WasRequest req, IList<MenuViewModel> list)
		{
			try
			{
				foreach (var data in list)
				{
					if (data.MenuID == null)
					{
						data.MenuID = req.Result.ReturnValue.ToIntegerNullToNull();
					}

					if (data.ID == null)
					{
						if (data.ViewID != null)
							req.SaveSubData<MenuViewModel>(data);
					}
					else
					{
						if (data.ViewID != null)
							req.SaveSubData<MenuViewModel>(data);
						else
							req.DeleteSubData<MenuViewModel>(data);
					}
				}
			}
			catch
			{
				throw;
			}
		}

		public static void SaveViewButton(this WasRequest req, IList<ViewButtonModel> list)
		{
			try
			{
				foreach (var data in list)
				{
					if (data.ViewID == null)
					{
						data.ViewID = req.Result.ReturnValue.ToIntegerNullToNull();
					}

					bool isSkip = false;
					if (data.Checked == "Y" && data.UseYn == "Y")
						isSkip = true;

					if ((data.Checked == "Y" && data.UseYn == "N") ||
						(data.Checked == "N" && data.UseYn == "Y"))
					{
						data.UseYn = data.Checked;
					}

					if (!isSkip)
						req.SaveSubData<ViewButtonModel>(data);
				}
			}
			catch
			{
				throw;
			}
		}

		public static void SaveUserGroup(this WasRequest req, IList<UserGroupModel> list)
		{
			try
			{
				foreach (var data in list)
				{
					if (data.UserID == null)
					{
						data.UserID = req.Result.ReturnValue.ToIntegerNullToNull();
					}

					bool isSkip = false;
					if (data.Checked == "Y" && data.UseYn == "Y")
						isSkip = true;

					if ((data.Checked == "Y" && data.UseYn == "N") ||
						(data.Checked == "N" && data.UseYn == "Y"))
					{
						data.UseYn = data.Checked;
					}

					if (!isSkip)
						req.SaveSubData<UserGroupModel>(data);
				}
			}
			catch
			{
				throw;
			}
		}

		public static void SaveUserRole(this WasRequest req, IList<UserRoleModel> list)
		{
			try
			{
				foreach (var data in list)
				{
					if (data.UserID == null)
					{
						data.UserID = req.Result.ReturnValue.ToIntegerNullToNull();
					}

					bool isSkip = false;
					if (data.Checked == "Y" && data.UseYn == "Y")
						isSkip = true;

					if ((data.Checked == "Y" && data.UseYn == "N") ||
						(data.Checked == "N" && data.UseYn == "Y"))
					{
						data.UseYn = data.Checked;
					}

					if (!isSkip)
						req.SaveSubData<UserGroupModel>(data);
					req.SaveSubData<UserRoleModel>(data);
				}
			}
			catch
			{
				throw;
			}
		}

		public static void SaveGroupRole(this WasRequest req, IList<GroupRoleModel> list)
		{
			try
			{
				foreach (var data in list)
				{
					if (data.GroupID == null)
					{
						data.GroupID = req.Result.ReturnValue.ToIntegerNullToNull();
					}

					bool isSkip = false;
					if (data.Checked == "Y" && data.UseYn == "Y")
						isSkip = true;

					if ((data.Checked == "Y" && data.UseYn == "N") ||
						(data.Checked == "N" && data.UseYn == "Y"))
					{
						data.UseYn = data.Checked;
					}

					if (!isSkip)
						req.SaveSubData<UserGroupModel>(data);
					req.SaveSubData<GroupRoleModel>(data);
				}
			}
			catch
			{
				throw;
			}
		}

		public static void SaveGroupMenu(this WasRequest req, IList<GroupMenuModel> list)
		{
			try
			{
				foreach (var data in list)
				{
					if (data.GroupID == null)
					{
						data.GroupID = req.Result.ReturnValue.ToIntegerNullToNull();
					}

					bool isSkip = false;
					if (data.Checked == "Y" && data.UseYn == "Y")
						isSkip = true;

					if ((data.Checked == "Y" && data.UseYn == "N") ||
						(data.Checked == "N" && data.UseYn == "Y"))
					{
						data.UseYn = data.Checked;
					}

					if (!isSkip)
						req.SaveSubData<UserGroupModel>(data);
					req.SaveSubData<GroupMenuModel>(data);
				}
			}
			catch
			{
				throw;
			}
		}

		public static void SaveDictionaryLanguage(this WasRequest req, DictionaryModel model)
		{
			try
			{
				foreach (var data in model.LanguageList)
				{
					data.Checked = "Y";
					if (data.PhysicalName == null)
					{
						data.PhysicalName = model.PhysicalName;
					}

					if (data.ID == null)
					{
						if (data.LogicalName.IsNullOrEmpty() == false)
							req.SaveSubData<DictionaryModel>(data);
					}
					else
					{
						if (data.LogicalName.IsNullOrEmpty() == false)
							req.SaveSubData<DictionaryModel>(data);
						else
							req.DeleteSubData<DictionaryModel>(data);
					}
				}
			}
			catch
			{
				throw;
			}
		}

		public static void GetTableList(this WasRequest req)
		{
			try
			{
				DataMap parameter = req.Parameter.JsonToAnyType<DataMap>();
				int? serverID = parameter.GetValue("ServerID").ToIntegerNullToNull();
				int? databaseID = parameter.GetValue("DatabaseID").ToIntegerNullToNull();

				DatabaseModel db = DaoFactory.Instance.QueryForObject<DatabaseModel>("SelectDatabase", new DataMap() { { "ID", databaseID } });

				if (db != null)
				{
					DataMap map = new DataMap()
					{
						{ "DatabaseID", db.ID },
						{ "DatabaseName", db.DatabaseName }
					};
					string sqlId = string.Format("SelectTableBy{0}", db.DbmsType);

					IList<TableModel> tableList = new List<TableModel>();
					IList<TableStatisticsModel> list = new List<TableStatisticsModel>();
					switch (db.DatabaseName)
					{
						case "IKBase":
							list = DaoFactory.Instance.QueryForList<TableStatisticsModel>(sqlId, map);
							break;
						case "IKBiz":
							list = DaoFactory.InstanceBiz.QueryForList<TableStatisticsModel>(sqlId, map);
							break;
						case "IKScrap":
							list = DaoFactory.InstanceScrap.QueryForList<TableStatisticsModel>(sqlId, map);
							break;
					}

					if (list != null && list.Count > 0)
					{
						foreach (var data in list)
						{
							tableList.Add(new TableModel()
							{
								RowNo = data.RowNo,
								ID = data.ID,
								CreateDate = data.CreateDate,
								CreateBy = data.CreateBy,
								CreateByName = data.CreateByName,
								UpdateDate = data.UpdateDate,
								UpdateBy = data.UpdateBy,
								UpdateByName = data.UpdateByName,
								DatabaseID = db.ID.ToIntegerNullToZero(),
								DatabaseName = db.DatabaseName,
								SchemaName = data.SchemaName,
								TableName = data.TableName,
								Description = data.Description,
								UseYn = "Y"
							});
						}
						req.Data = tableList;
						req.Result.Count = tableList.Count;
					}
				}
			}
			catch
			{
				throw;
			}
		}

		public static void GetTableData(this WasRequest req)
		{
			try
			{
				DataMap parameter = req.Parameter.JsonToAnyType<DataMap>();

				int databaseID = parameter.GetValue("DatabaseID").ToIntegerNullToZero();
				string tableName = parameter.GetValue("TableName").ToStringNullToEmpty();

				DatabaseModel db = DaoFactory.Instance.QueryForObject<DatabaseModel>("SelectDatabase", new DataMap() { { "ID", databaseID } });

				if (db != null)
				{
					DataMap map = new DataMap()
					{
						{ "DatabaseID", db.ID },
						{ "DatabaseName", db.DatabaseName },
						{ "TableName", tableName }
					};
					string sqlId = string.Format("SelectsTableBy{0}", db.DbmsType);

					TableModel table = new TableModel();
					TableStatisticsModel tableDB = new TableStatisticsModel();
					switch (db.DatabaseName)
					{
						case "IKBase":
							tableDB = DaoFactory.Instance.QueryForObject<TableStatisticsModel>(sqlId, map);
							break;
						case "IKBiz":
							tableDB = DaoFactory.InstanceBiz.QueryForObject<TableStatisticsModel>(sqlId, map);
							break;
						case "IKScrap":
							tableDB = DaoFactory.InstanceScrap.QueryForObject<TableStatisticsModel>(sqlId, map);
							break;
					}

					if (tableDB != null)
					{
						table = new TableModel()
						{
							RowNo = tableDB.RowNo,
							ID = tableDB.ID,
							CreateDate = tableDB.CreateDate,
							CreateBy = tableDB.CreateBy,
							CreateByName = tableDB.CreateByName,
							UpdateDate = tableDB.UpdateDate,
							UpdateBy = tableDB.UpdateBy,
							UpdateByName = tableDB.UpdateByName,
							DatabaseID = db.ID.ToIntegerNullToZero(),
							DatabaseName = db.DatabaseName,
							SchemaName = tableDB.SchemaName,
							TableName = tableDB.TableName,
							Description = tableDB.Description,
							UseYn = "Y"
						};

						//Column List
						sqlId = string.Format("SelectColumnBy{0}", db.DbmsType);
						IList<ColumnModel> columns = new List<ColumnModel>();
						switch (db.DatabaseName)
						{
							case "IKBase":
								columns = DaoFactory.Instance.QueryForList<ColumnModel>(sqlId, map);
								break;
							case "IKBiz":
								columns = DaoFactory.InstanceBiz.QueryForList<ColumnModel>(sqlId, map);
								break;
							case "IKScrap":
								columns = DaoFactory.InstanceScrap.QueryForList<ColumnModel>(sqlId, map);
								break;
						}
						table.Columns = columns;
						req.Data = table;
						req.Result.Count = 1;
					}
				}
			}
			catch
			{
				throw;
			}
		}

		public static void SaveTableAndColumn(this WasRequest req)
		{
			try
			{
				TableModel table = req.Data.JsonToAnyType<TableModel>();
				DatabaseModel db = DaoFactory.Instance.QueryForObject<DatabaseModel>("SelectDatabase", new DataMap() { { "ID", table.DatabaseID } });

				if (table != null)
				{
					DataMap map = new DataMap()
					{
						{ "DatabaseID", table.DatabaseID },
						{ "TableName", table.TableName }
					};
					TableModel exists = DaoFactory.Instance.QueryForObject<TableModel>("SelectTableExists", map);
					if (exists == null)
					{
						table.CreateBy = req.User.UserId;
						table.CreateByName = req.User.UserName;

						object id = DaoFactory.Instance.Insert("InsertTable", table);
						table.ID = id.ToIntegerNullToNull();
					}
					else
					{
						table.UpdateBy = req.User.UserId;
						table.UpdateByName = req.User.UserName;

						DaoFactory.Instance.Update("UpdateTable", table);
					}

					//MS_Description
					switch (db.DatabaseName)
					{
						case "IKBase":
							DaoFactory.Instance.Insert("AddOrUpdateTableDescription", table);
							break;
						case "IKBiz":
							DaoFactory.InstanceBiz.Insert("AddOrUpdateTableDescription", table);
							break;
						case "IKScrap":
							DaoFactory.InstanceScrap.Insert("AddOrUpdateTableDescription", table);
							break;
					}

					if (table.Columns != null)
					{
						foreach (ColumnModel column in table.Columns)
						{
							column.TableID = table.ID;
							column.TableName = table.TableName;
							column.SchemaName = table.SchemaName;

							map = new DataMap()
							{
								{ "TableID", table.ID },
								{ "PhysicalName", column.PhysicalName }
							};

							ColumnModel columnExists = DaoFactory.Instance.QueryForObject<ColumnModel>("SelectColumnExists", map);
							if (columnExists == null)
							{
								column.CreateBy = req.User.UserId;
								column.CreateByName = req.User.UserName;
								object columnID = DaoFactory.Instance.Insert("InsertColumn", column);
								column.ID = columnID.ToIntegerNullToNull();
							}
							else
							{
								column.UpdateBy = req.User.UserId;
								column.UpdateByName = req.User.UserName;

								DaoFactory.Instance.Update("UpdateColumn", column);
							}

							//MS_Description
							switch (db.DatabaseName)
							{
								case "IKBase":
									DaoFactory.Instance.Insert("AddOrUpdateColumnDescription", column);
									break;
								case "IKBiz":
									DaoFactory.InstanceBiz.Insert("AddOrUpdateColumnDescription", column);
									break;
								case "IKScrap":
									DaoFactory.InstanceScrap.Insert("AddOrUpdateColumnDescription", column);
									break;
							}
						}
					}

					req.Result.ReturnValue = table.TableName;
					req.Result.Count = 1;
				}
			}
			catch
			{
				throw;
			}
		}

		public static WasRequest SaveDatabaseToTables(WasRequest request)
		{
			bool isTran = false;

			try
			{
				if (request == null || (request.Data == null && request.SqlId.IsNullOrEmpty()))
					throw new Exception("처리요청이 없습니다.");

				bool isOneRequest = true;
				List<WasRequest> list = new List<WasRequest>();
				if (request.Data != null && request.Data.GetType() == typeof(JArray))
				{
					list = request.Data.JsonToAnyType<List<WasRequest>>();
					isOneRequest = false;
				}
				else
				{
					list.Add(request);
				}

				if (request.IsTransaction)
				{
					DaoFactory.Instance.BeginTransaction();
					isTran = true;
				}

				try
				{
					//테이블
					if (list.Count > 0)
					{
						foreach (WasRequest req in list)
						{
							if (req.Data == null)
								throw new Exception("처리할 데이터가 존재하지 않습니다.");

							var parameters = req.Parameter.JsonToAnyType<DataMap>();
							var table_list = DaoFactory.Instance.QueryForList<TableStatisticsModel>("SelectTableByMSSQL", parameters);

						}
					}

					if (request.IsTransaction && isTran)
						DaoFactory.Instance.CommitTransaction();
				}
				catch (Exception ex)
				{
					if (request.IsTransaction && isTran)
						DaoFactory.Instance.RollBackTransaction();

					throw new Exception(ex.Message);
				}

				if (isOneRequest)
				{
					request = list[0];
				}
				else
				{
					request.Data = list;
				}

				return request;
			}
			catch (Exception ex)
			{
				request.Error.Number = ex.HResult;
				request.Error.Message = ex.Message;
				return request;
			}
		}

		public static void GetTableStatistics(this WasRequest req)
		{
			try
			{
				DataMap parameter = req.Parameter.JsonToAnyType<DataMap>();
				int? databaseID = parameter.GetValue("DatabaseID").ToIntegerNullToNull();

				DatabaseModel db = DaoFactory.Instance.QueryForObject<DatabaseModel>("SelectDatabase", new DataMap() { { "ID", databaseID } });

				if (db != null)
				{
					DataMap map = new DataMap()
					{
						{ "DatabaseID", db.ID },
						{ "DatabaseName", db.DatabaseName },
						{ "TableName", parameter.GetValue("TableName") }
					};
					string sqlId = string.Format("SelectTableBy{0}", db.DbmsType);

					IList<TableStatisticsModel> list = new List<TableStatisticsModel>();
					switch (db.DatabaseName)
					{
						case "IKBase":
							list = DaoFactory.Instance.QueryForList<TableStatisticsModel>(sqlId, map);
							break;
						case "IKBiz":
							list = DaoFactory.InstanceBiz.QueryForList<TableStatisticsModel>(sqlId, map);
							break;
						case "IKScrap":
							list = DaoFactory.InstanceScrap.QueryForList<TableStatisticsModel>(sqlId, map);
							break;
					}

					req.Data = list;
					req.Result.Count = list.Count;
				}
			}
			catch
			{
				throw;
			}
		}
	}
}
