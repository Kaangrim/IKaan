using System;
using System.Collections.Generic;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Model.Common.Was;
using IKaan.Model.Base;
using IKaan.Was.Core.Mappers;
using IKaan.Was.Service.Utils;
using Newtonsoft.Json.Linq;

namespace IKaan.Was.Service.Services
{
	public static class BaseService
	{
		public static WasRequest GetList(WasRequest request)
		{
			try
			{
				if (request == null || request.SqlId.IsNullOrEmpty())
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

				foreach (WasRequest req in list)
				{
					switch (req.ModelName.Replace("Model", ""))
					{
						case "Group":
							req.SetList<GroupModel>();
							break;
						case "Help":
							req.SetList<HelpModel>();
							break;
						case "Module":
							req.SetList<ModuleModel>();
							break;
						case "Menu":
							req.SetList<MenuModel>();
							break;
						case "Role":
							req.SetList<RoleModel>();
							break;
						case "User":
							req.SetList<UserModel>();
							break;
						case "View":
							req.SetList<ViewModel>();
							break;
						case "Button":
							req.SetList<ButtonModel>();
							break;
						case "LoginLog":
							req.SetList<LoginLogModel>();
							break;
						case "LoginLogUser":
							req.SetList<LoginLogUserModel>();
							break;
						case "Dictionary":
							req.SetList<DictionaryModel>();
							break;
						case "Message":
							req.SetList<MessageModel>();
							break;
						case "Code":
							req.SetList<CodeModel>();
							break;
						case "System":
							req.SetList<SystemModel>();
							break;
						case "Server":
							req.SetList<ServerModel>();
							break;
						case "Database":
							req.SetList<DatabaseModel>();
							break;
						case "Table":
							req.GetTableList();
							break;
						case "Column":
							req.SetList<ColumnModel>();
							break;
						case "TableStatistics":
							req.GetTableStatistics();
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

				foreach (WasRequest req in list)
				{
					switch (req.ModelName.Replace("Model", ""))
					{
						case "Group":
							req.SetData<GroupModel>();
							(req.Data as GroupModel).GroupRole = req.GetList<GroupRoleModel>();
							(req.Data as GroupModel).GroupMenu = req.GetList<GroupMenuModel>();
							break;
						case "Help":
							req.SetData<HelpModel>();
							break;
						case "Module":
							req.SetData<ModuleModel>();
							break;
						case "Menu":
							req.SetData<MenuModel>();
							break;
						case "Role":
							req.SetData<RoleModel>();
							break;
						case "User":
							req.SetData<UserModel>();
							(req.Data as UserModel).UserGroup = req.GetList<UserGroupModel>();
							(req.Data as UserModel).UserRole = req.GetList<UserRoleModel>();
							(req.Data as UserModel).UserPasswordHist = req.GetList<UserPasswordHistModel>();
							break;
						case "View":
							req.SetData<ViewModel>();
							(req.Data as ViewModel).ViewButton = req.GetList<ViewButtonModel>();
							break;
						case "Button":
							req.SetData<ButtonModel>();
							break;
						case "Dictionary":
							req.SetData<DictionaryModel>();
							(req.Data as DictionaryModel).LanguageList = req.GetList<DictionaryModel>("SelectDictionaryLanguageList");
							break;
						case "Message":
							req.SetData<MessageModel>();
							break;
						case "Code":
							req.SetData<CodeModel>();
							break;
						case "System":
							req.SetData<SystemModel>();
							break;
						case "Server":
							req.SetData<ServerModel>();
							break;
						case "Database":
							req.SetData<DatabaseModel>();
							break;
						case "Table":
							req.GetTableData();
							break;
						case "Column":
							req.SetData<ColumnModel>();
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

							switch (req.ModelName.Replace("Model", ""))
							{
								case "Menu":
									req.SaveMenu();
									break;
								case "Group":
									req.SaveGroup();
									break;
								case "Help":
									req.SaveData<HelpModel>();
									break;
								case "Module":
									req.SaveData<ModuleModel>();
									break;
								case "Role":
									req.SaveData<RoleModel>();
									break;
								case "User":
									req.SaveUser();
									break;
								case "View":
									req.SaveView();
									break;
								case "Button":
									req.SaveData<ButtonModel>();
									break;
								case "Dictionary":
									req.SaveDictionary();
									break;
								case "Message":
									req.SaveData<MessageModel>();
									break;
								case "Code":
									req.SaveData<CodeModel>();
									break;
								case "System":
									req.SaveData<SystemModel>();
									break;
								case "Server":
									req.SaveData<ServerModel>();
									break;
								case "Database":
									req.SaveData<DatabaseModel>();
									break;
								case "Table":
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

		public static WasRequest ClearPassword(WasRequest request)
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
						DaoFactory.Instance.Update("ClearPassword", map);
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
	}
}
