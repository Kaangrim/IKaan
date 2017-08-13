using System;
using System.Collections.Generic;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Model.SYS.AD;
using IKaan.Model.Was;
using IKaan.Was.Core.Mappers;
using IKaan.Was.Service.Utils;
using Newtonsoft.Json.Linq;

namespace IKaan.Was.Service.SYS
{
	public static class ADService
	{
		public static WasRequest GetList(WasRequest request)
		{
			try
			{
				if (request == null || (request.Data == null && request.SqlId.IsNullOrEmpty()))
				{
					throw new Exception("처리요청이 없습니다.");
				}

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

				foreach (WasRequest req in list)
				{
					switch (req.ModelName)
					{
						case "ADSystem":
							req.SetList<ADSystem>();
							break;
						case "ADServer":
							req.SetList<ADServer>();
							break;
						case "ADDatabase":
							req.SetList<ADDatabase>();
							break;
						case "ADTable":
							//req.SetList<ADTable>();
							req.GetTableList();
							break;
						case "ADColumn":
							req.SetList<ADColumn>();
							break;
						case "ADTableStatistics":
							req.SetList<ADTableStatistics>();
							break;
					}
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

		public static WasRequest GetData(WasRequest request)
		{
			try
			{
				if (request == null || (request.Data == null && request.SqlId.IsNullOrEmpty()))
				{
					throw new Exception("처리요청이 없습니다.");
				}

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

				var parameter = request.Parameter.JsonToAnyType<DataMap>();

				foreach (WasRequest req in list)
				{
					switch (req.ModelName)
					{
						case "ADSystem":
							req.SetData<ADSystem>();
							break;
						case "ADServer":
							req.SetData<ADServer>();
							break;
						case "ADDatabase":
							req.SetData<ADDatabase>();
							break;
						case "ADTable":
							req.GetTableData();
							break;
						case "ADColumn":
							req.SetData<ADColumn>();
							break;
					}
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

		public static WasRequest Save(WasRequest request)
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
								throw new Exception("저장할 데이터가 존재하지 않습니다.");

							switch (req.ModelName)
							{
								case "ADSystem":
									req.SaveData<ADSystem>();
									break;
								case "ADServer":
									req.SaveData<ADServer>();
									break;
								case "ADDatabase":
									req.SaveData<ADDatabase>();
									break;
								case "ADTable":
									req.SaveTableAndColumn();
									break;
							}
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

		public static WasRequest Delete(WasRequest request)
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

				DaoFactory.Instance.BeginTransaction();
				isTran = true;

				try
				{
					foreach (WasRequest req in list)
					{
						DataMap map = req.Data.JsonToAnyType<DataMap>();
						DaoFactory.Instance.Delete(req.SqlId, map);
					}

					if (isTran)
						DaoFactory.Instance.CommitTransaction();
				}
				catch (Exception ex)
				{
					if (isTran)
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

		private static void GetTableList(this WasRequest req)
		{
			try
			{
				DataMap parameter = req.Parameter.JsonToAnyType<DataMap>();
				int? serverID = parameter.GetValue("ServerID").ToIntegerNullToNull();
				int? databaseID = parameter.GetValue("DatabaseID").ToIntegerNullToNull();

				ADDatabase db = DaoFactory.Instance.QueryForObject<ADDatabase>("SelectADDatabase", new DataMap() { { "ID", databaseID } });
				
				if (db != null)
				{
					DataMap map = new DataMap()
					{
						{ "DatabaseName", db.DatabaseName }
					};
					string sqlId = string.Format("SelectADTableBy{0}", db.DbmsType);

					IList<ADTable> tableList = new List<ADTable>();
					IList<ADTableStatistics> list = new List<ADTableStatistics>();
					switch (db.DatabaseName)
					{
						case "IKBAS":
							list = DaoFactory.Instance.QueryForList<ADTableStatistics>(sqlId, map);
							break;
						case "IKBIZ":
							list = DaoFactory.InstanceBiz.QueryForList<ADTableStatistics>(sqlId, map);
							break;
						case "IKLIB":
							list = DaoFactory.InstanceLib.QueryForList<ADTableStatistics>(sqlId, map);
							break;
						case "IKSMP":
							list = DaoFactory.InstanceSmp.QueryForList<ADTableStatistics>(sqlId, map);
							break;
					}

					if (list != null && list.Count > 0)
					{
						foreach (var data in list)
						{
							tableList.Add(new ADTable()
							{
								RowNo = data.RowNo,
								ID = data.TableID,
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

		private static void GetTableData(this WasRequest req)
		{
			try
			{
				DataMap parameter = req.Parameter.JsonToAnyType<DataMap>();

				int databaseID = parameter.GetValue("DatabaseID").ToIntegerNullToZero();
				string tableName = parameter.GetValue("TableName").ToStringNullToEmpty();

				ADDatabase db = DaoFactory.Instance.QueryForObject<ADDatabase>("SelectADDatabase", new DataMap() { { "ID", databaseID } });

				if (db != null)
				{
					DataMap map = new DataMap()
					{
						{ "DatabaseID", db.ID },
						{ "DatabaseName", db.DatabaseName },
						{ "TableName", tableName }
					};
					string sqlId = string.Format("SelectADTableBy{0}", db.DbmsType);

					ADTable table = new ADTable();
					ADTableStatistics tableDB = new ADTableStatistics();
					switch (db.DatabaseName)
					{
						case "IKBAS":
							tableDB = DaoFactory.Instance.QueryForObject<ADTableStatistics>(sqlId, map);
							break;
						case "IKBIZ":
							tableDB = DaoFactory.InstanceBiz.QueryForObject<ADTableStatistics>(sqlId, map);
							break;
						case "IKLIB":
							tableDB = DaoFactory.InstanceLib.QueryForObject<ADTableStatistics>(sqlId, map);
							break;
						case "IKSMP":
							tableDB = DaoFactory.InstanceSmp.QueryForObject<ADTableStatistics>(sqlId, map);
							break;
					}

					if (tableDB != null)
					{
						table = new ADTable()
						{
							RowNo = tableDB.RowNo,
							ID = tableDB.TableID,
							DatabaseID = db.ID.ToIntegerNullToZero(),
							DatabaseName = db.DatabaseName,
							SchemaName = tableDB.SchemaName,
							TableName = tableDB.TableName,
							Description = tableDB.Description,
							UseYn = "Y"
						};

						//Column List
						sqlId = string.Format("SelectADColumnBy{0}", db.DbmsType);
						IList<ADColumn> columns = new List<ADColumn>();
						switch (db.DatabaseName)
						{
							case "IKBAS":
								columns = DaoFactory.Instance.QueryForList<ADColumn>(sqlId, map);
								break;
							case "IKBIZ":
								columns = DaoFactory.InstanceBiz.QueryForList<ADColumn>(sqlId, map);
								break;
							case "IKLIB":
								columns = DaoFactory.InstanceLib.QueryForList<ADColumn>(sqlId, map);
								break;
							case "IKSMP":
								columns = DaoFactory.InstanceSmp.QueryForList<ADColumn>(sqlId, map);
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

		private static void SaveTableAndColumn(this WasRequest req)
		{
			try
			{
				ADTable table = req.Data.JsonToAnyType<ADTable>();
				ADDatabase db = DaoFactory.Instance.QueryForObject<ADDatabase>("SelectADDatabase", new DataMap() { { "ID", table.DatabaseID } });

				if (table != null)
				{
					DataMap map = new DataMap()
					{
						{ "DatabaseID", table.DatabaseID },
						{ "TableName", table.TableName }
					};
					ADTable exists = DaoFactory.Instance.QueryForObject<ADTable>("SelectADTableExists", map);
					if (exists == null)
					{
						table.CreateBy = req.User.UserId;
						table.CreateByName = req.User.UserName;

						object id = DaoFactory.Instance.Insert("InsertADTable", table);
						table.ID = id.ToIntegerNullToNull();
					}
					else
					{
						table.UpdateBy = req.User.UserId;
						table.UpdateByName = req.User.UserName;

						DaoFactory.Instance.Update("UpdateADTable", table);
					}

					//MS_Description
					switch (db.DatabaseName)
					{
						case "IKBAS":
							DaoFactory.Instance.Insert("AddOrUpdateTableDescription", table);
							break;
						case "IKBIZ":
							DaoFactory.InstanceBiz.Insert("AddOrUpdateTableDescription", table);
							break;
						case "IKLIB":
							DaoFactory.InstanceLib.Insert("AddOrUpdateTableDescription", table);
							break;
						case "IKSMP":
							DaoFactory.InstanceSmp.Insert("AddOrUpdateTableDescription", table);
							break;
					}
					
					if (table.Columns != null)
					{
						foreach (ADColumn column in table.Columns)
						{
							column.TableID = table.ID;
							column.TableName = table.TableName;
							column.SchemaName = table.SchemaName;

							map = new DataMap()
							{
								{ "TableID", table.ID },
								{ "PhysicalName", column.PhysicalName }
							};

							ADColumn columnExists = DaoFactory.Instance.QueryForObject<ADColumn>("SelectADColumnExists", map);
							if (columnExists == null)
							{
								column.CreateBy = req.User.UserId;
								column.CreateByName = req.User.UserName;
								object columnID = DaoFactory.Instance.Insert("InsertADColumn", column);
								column.ID = columnID.ToIntegerNullToNull();
							}
							else
							{
								column.UpdateBy = req.User.UserId;
								column.UpdateByName = req.User.UserName;

								DaoFactory.Instance.Update("UpdateADColumn", column);
							}

							//MS_Description
							switch (db.DatabaseName)
							{
								case "IKBAS":
									DaoFactory.Instance.Insert("AddOrUpdateColumnDescription", column);
									break;
								case "IKBIZ":
									DaoFactory.InstanceBiz.Insert("AddOrUpdateColumnDescription", column);
									break;
								case "IKLIB":
									DaoFactory.InstanceLib.Insert("AddOrUpdateColumnDescription", column);
									break;
								case "IKSMP":
									DaoFactory.InstanceSmp.Insert("AddOrUpdateColumnDescription", column);
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
							var table_list = DaoFactory.Instance.QueryForList<ADTableStatistics>("SelectADTableByMSSQL", parameters);

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
	}
}
