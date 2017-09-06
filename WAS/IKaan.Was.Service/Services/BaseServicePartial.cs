using System;
using System.Collections.Generic;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Model.Base;
using IKaan.Model.Common.Was;
using IKaan.Was.Core.Mappers;
using IKaan.Was.Service.Utils;

namespace IKaan.Was.Service.Services
{
	public static class BaseServicePartial
	{
		public static void SaveMenu(this WasRequest req)
		{
			try
			{
				var model = req.Data.JsonToAnyType<MenuModel>();
				if (model.ID == null)
				{
					model.CreatedBy = req.User.UserId;
					model.CreatedByName = req.User.UserName;
					object id = DaoFactory.Instance.Insert("InsertMenu", model);
					model.ID = id.ToIntegerNullToNull();
				}
				else
				{
					model.UpdatedBy = req.User.UserId;
					model.UpdatedByName = req.User.UserName;
					DaoFactory.Instance.Update("UpdateMenu", model);
				}

				if (model.MenuView != null && model.MenuView.Count > 0)
				{
					foreach (var data in model.MenuView)
					{
						data.MenuID = model.ID;

						var exists = DaoFactory.Instance.QueryForObject<MenuViewModel>("SelectMenuViewExists", new DataMap() { { "MenuID", model.ID } });
						if (exists == null)
						{
							if (data.ViewID != null)
							{
								data.CreatedBy = req.User.UserId;
								data.CreatedByName = req.User.UserName;
								object menuviewid = DaoFactory.Instance.Insert("InsertMenuView", data);
								data.ID = menuviewid.ToIntegerNullToNull();
							}
						}
						else
						{
							if (data.ViewID != null)
							{
								exists.ViewID = data.ViewID;
								exists.UpdatedBy = req.User.UserId;
								exists.UpdatedByName = req.User.UserName;
								DaoFactory.Instance.Update("UpdateMenuView", exists);
							}
							else
							{
								DaoFactory.Instance.Delete("DeleteMenuView", new DataMap() { { "ID", data.ID } });
							}
						}						
					}
				}

				req.Result.Count = 1;
				req.Result.ReturnValue = model.ID;
				req.Error.Number = 0;
			}
			catch
			{
				throw;
			}
		}

		public static void SaveGroup(this WasRequest req)
		{
			try
			{
				var model = req.Data.JsonToAnyType<GroupModel>();
				if (model.ID == null)
				{
					model.CreatedBy = req.User.UserId;
					model.CreatedByName = req.User.UserName;
					object id = DaoFactory.Instance.Insert("InsertGroup", model);
					model.ID = id.ToIntegerNullToNull();
				}
				else
				{
					model.UpdatedBy = req.User.UserId;
					model.UpdatedByName = req.User.UserName;
					DaoFactory.Instance.Update("UpdateGroup", model);
				}

				if (model.GroupRole != null && model.GroupRole.Count > 0)
				{
					foreach (var data in model.GroupRole)
					{
						data.GroupID = model.ID;

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

				if (model.GroupMenu != null && model.GroupMenu.Count > 0)
				{
					foreach (var data in model.GroupMenu)
					{
						data.GroupID = model.ID;

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

				req.Result.Count = 1;
				req.Result.ReturnValue = model.ID;
				req.Error.Number = 0;
			}
			catch
			{
				throw;
			}
		}

		public static void SaveUser(this WasRequest req)
		{
			try
			{
				var model = req.Data.JsonToAnyType<UserModel>();
				if (model.ID == null)
				{
					model.CreatedBy = req.User.UserId;
					model.CreatedByName = req.User.UserName;
					object id = DaoFactory.Instance.Insert("InsertUser", model);
					model.ID = id.ToIntegerNullToNull();
				}
				else
				{
					model.UpdatedBy = req.User.UserId;
					model.UpdatedByName = req.User.UserName;
					DaoFactory.Instance.Update("UpdateUser", model);
				}

				if (model.UserGroup != null && model.UserGroup.Count > 0)
				{
					foreach (var data in model.UserGroup)
					{
						data.UserID = model.ID;

						if (data.Checked == "Y")
						{
							if (data.UseYn != "Y")
							{
								data.UseYn = data.Checked;

								if (data.ID == null)
								{
									data.CreatedBy = req.User.UserId;
									data.CreatedByName = req.User.UserName;
									object usergroupid = DaoFactory.Instance.Insert("InsertUserGroup", data);
									data.ID = usergroupid.ToIntegerNullToNull();
								}
								else
								{
									data.UpdatedBy = req.User.UserId;
									data.UpdatedByName = req.User.UserName;
									DaoFactory.Instance.Update("UpdateUserGroup", data);
								}
							}
						}
						else
						{
							if (data.ID != null)
							{
								DataMap map = new DataMap() { { "ID", data.ID } };
								DaoFactory.Instance.Delete("DeleteUserGroup", map);
							}
						}
					}
				}

				if (model.UserRole != null && model.UserRole.Count > 0)
				{
					foreach (var data in model.UserRole)
					{
						data.UserID = model.ID;

						if (data.Checked == "Y")
						{
							if (data.UseYn != "Y")
							{
								data.UseYn = data.Checked;

								if (data.ID == null)
								{
									data.CreatedBy = req.User.UserId;
									data.CreatedByName = req.User.UserName;
									object usergroupid = DaoFactory.Instance.Insert("InsertUserRole", data);
									data.ID = usergroupid.ToIntegerNullToNull();
								}
								else
								{
									data.UpdatedBy = req.User.UserId;
									data.UpdatedByName = req.User.UserName;
									DaoFactory.Instance.Update("UpdateUserRole", data);
								}
							}
						}
						else
						{
							if (data.ID != null)
							{
								DataMap map = new DataMap() { { "ID", data.ID } };
								DaoFactory.Instance.Delete("DeleteUserRole", map);
							}
						}
					}
				}

				req.Result.Count = 1;
				req.Result.ReturnValue = model.ID;
				req.Error.Number = 0;
			}
			catch
			{
				throw;
			}
		}

		public static void SaveView(this WasRequest req)
		{
			try
			{
				var model = req.Data.JsonToAnyType<ViewModel>();
				if (model.ID == null)
				{
					model.CreatedBy = req.User.UserId;
					model.CreatedByName = req.User.UserName;
					object id = DaoFactory.Instance.Insert("InsertView", model);
					model.ID = id.ToIntegerNullToNull();
				}
				else
				{
					model.UpdatedBy = req.User.UserId;
					model.UpdatedByName = req.User.UserName;
					DaoFactory.Instance.Update("UpdateView", model);
				}

				if (model.ViewButton != null && model.ViewButton.Count > 0)
				{
					foreach (var data in model.ViewButton)
					{
						data.ViewID = model.ID;

						if (data.Checked == "Y")
						{
							if (data.UseYn != "Y")
							{
								data.UseYn = data.Checked;

								if (data.ID == null)
								{
									data.CreatedBy = req.User.UserId;
									data.CreatedByName = req.User.UserName;
									object usergroupid = DaoFactory.Instance.Insert("InsertViewButton", data);
									data.ID = usergroupid.ToIntegerNullToNull();
								}
								else
								{
									data.UpdatedBy = req.User.UserId;
									data.UpdatedByName = req.User.UserName;
									DaoFactory.Instance.Update("UpdateViewButton", data);
								}
							}
						}
						else
						{
							if (data.ID != null)
							{
								DataMap map = new DataMap() { { "ID", data.ID } };
								DaoFactory.Instance.Delete("DeleteViewButton", map);
							}
						}
					}
				}
				
				req.Result.Count = 1;
				req.Result.ReturnValue = model.ID;
				req.Error.Number = 0;
			}
			catch
			{
				throw;
			}
		}

		public static void SaveDictionary(this WasRequest req)
		{
			try
			{
				var model = req.Data.JsonToAnyType<DictionaryModel>();
				if (model.ID == null)
				{
					model.CreatedBy = req.User.UserId;
					model.CreatedByName = req.User.UserName;
					object id = DaoFactory.Instance.Insert("InsertDictionary", model);
					model.ID = id.ToIntegerNullToNull();
				}
				else
				{
					model.UpdatedBy = req.User.UserId;
					model.UpdatedByName = req.User.UserName;
					DaoFactory.Instance.Update("UpdateDictionary", model);
				}

				if (model.ID != null && model.LanguageList.Count > 0)
				{
					foreach (var data in model.LanguageList)
					{
						if (data.ID == null)
						{
							if (data.LogicalName.IsNullOrEmpty() == false)
							{
								data.CreatedBy = req.User.UserId;
								data.CreatedByName = req.User.UserName;
								data.PhysicalName = model.PhysicalName;
								object usergroupid = DaoFactory.Instance.Insert("InsertDictionary", data);
								data.ID = usergroupid.ToIntegerNullToNull();
							}
						}
						else
						{
							if (data.LogicalName.IsNullOrEmpty())
							{
								DaoFactory.Instance.Delete("DeleteCalendar", new DataMap() { { "ID", data.ID } });
							}
							else
							{
								data.UpdatedBy = req.User.UserId;
								data.UpdatedByName = req.User.UserName;
								data.PhysicalName = model.PhysicalName;
								DaoFactory.Instance.Update("UpdateDictionary", data);
							}
						}
					}
				}

				req.Result.Count = 1;
				req.Result.ReturnValue = model.ID;
				req.Error.Number = 0;
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
								CreatedOn = data.CreatedOn,
								CreatedBy = data.CreatedBy,
								CreatedByName = data.CreatedByName,
								UpdatedOn = data.UpdatedOn,
								UpdatedBy = data.UpdatedBy,
								UpdatedByName = data.UpdatedByName,
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
					string sqlId = string.Format("SelectTableBy{0}", db.DbmsType);

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
							CreatedOn = tableDB.CreatedOn,
							CreatedBy = tableDB.CreatedBy,
							CreatedByName = tableDB.CreatedByName,
							UpdatedOn = tableDB.UpdatedOn,
							UpdatedBy = tableDB.UpdatedBy,
							UpdatedByName = tableDB.UpdatedByName,
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
						table.CreatedBy = req.User.UserId;
						table.CreatedByName = req.User.UserName;

						object id = DaoFactory.Instance.Insert("InsertTable", table);
						table.ID = id.ToIntegerNullToNull();
					}
					else
					{
						table.UpdatedBy = req.User.UserId;
						table.UpdatedByName = req.User.UserName;

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
								column.CreatedBy = req.User.UserId;
								column.CreatedByName = req.User.UserName;
								object columnID = DaoFactory.Instance.Insert("InsertColumn", column);
								column.ID = columnID.ToIntegerNullToNull();
							}
							else
							{
								column.UpdatedBy = req.User.UserId;
								column.UpdatedByName = req.User.UserName;

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

		public static void CreateCalendar(this WasRequest req)
		{
			try
			{
				var parameter = req.Data.JsonToAnyType<DataMap>();
				if (parameter == null || parameter.GetType() != typeof(DataMap) || parameter.GetValue("CalYear") == null)
					throw new Exception("전달 파라미터가 정확하지 않습니다.");

				int calYear = parameter.GetValue("CalYear").ToIntegerNullToZero();
				DateTime dt = new DateTime(calYear, 1, 1);
				DateTime endDate = new DateTime(calYear, 12, 31);
				int count = 0;
				string holidayYn = "N";
				string description = string.Empty;

				while (dt <= endDate)
				{
					holidayYn = "N";
					description = string.Empty;

					//기존에 등록된 건이 있으면 삭제한다.
					CalendarModel exists = DaoFactory.Instance.QueryForObject<CalendarModel>("SelectCalendarByCalDate", new DataMap() { { "CalDate", dt } });
					if (exists != null)
						DaoFactory.Instance.Delete("DeleteCalendar", new DataMap() { { "ID", exists.ID } });

					//휴일체크
					var holiday = DaoFactory.Instance.QueryForObject<HolidayModel>("SelectHolidayByDate", new DataMap() { { "HolidayDate", dt } });
					if (holiday != null)
					{
						holidayYn = "Y";
						description = holiday.Description;
					}
					else
					{
						if (dt.DayOfWeek == DayOfWeek.Sunday || dt.DayOfWeek == DayOfWeek.Saturday)
							holidayYn = "Y";
					}

					CalendarModel model = new CalendarModel()
					{
						CreatedBy = req.User.UserId,
						CreatedByName = req.User.UserName,
						CalDate = dt,
						CalYear = dt.Year,
						CalMonth = dt.Month,
						CalDay = dt.Day,
						Quarter = (dt.Month - 1) / 3 + 1,
						DayOfWeek = (int)dt.DayOfWeek + 1,
						DayOfYear = dt.DayOfYear,
						WeekOfMonth = dt.GetWeekOfMonth(),
						WeekOfYear = dt.GetWeekOfYear(),
						HolidayYn = holidayYn,
						Description = description
					};

					object id = DaoFactory.Instance.Insert("InsertCalendar", model);
					model.ID = id.ToIntegerNullToNull();
					count++;
					dt = dt.AddDays(1);
				}
				req.Result.Count = count;
				req.Result.ReturnValue = calYear;
				req.Error.Number = 0;
			}
			catch
			{
				throw;
			}
		}

		public static void SaveCalendar(this WasRequest req)
		{
			try
			{
				var model = req.Data.JsonToAnyType<CalendarModel>();
				if (model != null)
				{
					model.UpdatedBy = req.User.UserId;
					model.UpdatedByName = req.User.UserName;
					DaoFactory.Instance.Update("UpdateCalendar", model);

					var holiday = DaoFactory.Instance.QueryForObject<HolidayModel>("SelectHolidayByDate", new DataMap() { { "HolidayDate", model.CalDate } });
					if (holiday != null)
					{
						if (model.HolidayYn != "Y")
						{
							DaoFactory.Instance.Delete("DeleteHoliday", new DataMap() { { "ID", holiday.ID } });
						}
						else
						{
							holiday.UpdatedBy = req.User.UserId;
							holiday.UpdatedByName = req.User.UserName;
							holiday.HolidayDate = model.CalDate;
							holiday.Description = model.Description;
							DaoFactory.Instance.Update("UpdateHoliday", holiday);
						}
					}
					else
					{
						if (model.HolidayYn == "Y")
						{
							holiday = new HolidayModel()
							{
								HolidayDate = model.CalDate,
								Description = model.Description,
								CreatedBy = req.User.UserId,
								CreatedByName = req.User.UserName
							};
							object id = DaoFactory.Instance.Insert("InsertHoliday", holiday);
							holiday.ID = id.ToIntegerNullToNull();
						}
					}
				}
				
				req.Result.Count = 1;
				req.Result.ReturnValue = model.ID;
				req.Error.Number = 0;
			}
			catch
			{
				throw;
			}
		}
	}
}
