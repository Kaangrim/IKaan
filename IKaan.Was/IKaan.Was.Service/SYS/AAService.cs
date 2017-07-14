using System;
using System.Collections.Generic;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Model.SYS.AA;
using IKaan.Model.Was;
using IKaan.Was.Core.Mappers;
using IKaan.Was.Service.Utils;
using Newtonsoft.Json.Linq;

namespace IKaan.Was.Service.SYS
{
	public static class AAService
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
					switch (req.ModelName)
					{
						case "AAGroup":
							req.SetList<AAGroup>();
							break;
						case "AAHelp":
							req.SetList<AAHelp>();
							break;
						case "AAModule":
							req.SetList<AAModule>();
							break;
						case "AAMenu":
							req.SetList<AAMenu>();
							break;
						case "AARole":
							req.SetList<AARole>();
							break;
						case "AAUser":
							req.SetList<AAUser>();
							break;
						case "AAView":
							req.SetList<AAView>();
							break;
						case "AAButton":
							req.SetList<AAButton>();
							break;
						case "AALoginLog":
							req.SetList<AALoginLog>();
							break;
						case "AALoginLogUser":
							req.SetList<AALoginLogUser>();
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
					switch (req.ModelName)
					{
						case "AAGroup":
							req.SetData<AAGroup>();
							(req.Data as AAGroup).GroupRole = req.GetList<AAGroupRole>();
							(req.Data as AAGroup).GroupMenu = req.GetList<AAGroupMenu>();
							break;
						case "AAHelp":
							req.SetData<AAHelp>();
							break;
						case "AAModule":
							req.SetData<AAModule>();
							break;
						case "AAMenu":
							req.SetData<AAMenu>();
							break;
						case "AARole":
							req.SetData<AARole>();
							break;
						case "AAUser":
							req.SetData<AAUser>();
							(req.Data as AAUser).UserGroup = req.GetList<AAUserGroup>();
							(req.Data as AAUser).UserRole = req.GetList<AAUserRole>();
							(req.Data as AAUser).UserPasswordHist = req.GetList<AAUserPasswordHist>();
							break;
						case "AAView":
							req.SetData<AAView>();
							(req.Data as AAView).ViewButton = req.GetList<AAViewButton>();
							break;
						case "AAButton":
							req.SetData<AAButton>();
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
								case "AAMenu":
									var menu = req.SaveData<AAMenu>();
									if (menu.MenuView != null && menu.MenuView.Count > 0)
										req.SaveMenuView(menu.MenuView);
									break;
								case "AAGroup":
									var group = req.SaveData<AAGroup>();
									if (group.GroupRole != null && group.GroupRole.Count > 0)
										req.SaveGroupRole(group.GroupRole);
									if (group.GroupMenu != null && group.GroupMenu.Count > 0)
										req.SaveGroupMenu(group.GroupMenu);
									break;
								case "AAHelp":
									req.SaveData<AAHelp>();
									break;
								case "AAModule":
									req.SaveData<AAModule>();
									break;
								case "AARole":
									req.SaveData<AARole>();
									break;
								case "AAUser":
									var user = req.SaveData<AAUser>();
									if (user.UserGroup != null && user.UserGroup.Count > 0)
										req.SaveUserGroup(user.UserGroup);
									if (user.UserRole != null && user.UserRole.Count > 0)
										req.SaveUserRole(user.UserRole);
									break;
								case "AAView":
									var view = req.SaveData<AAView>();
									if (view.ViewButton != null && view.ViewButton.Count > 0)
										req.SaveViewButton(view.ViewButton);
									break;
								case "AAButton":
									req.SaveData<AAButton>();
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
						DaoFactory.Instance.Delete(string.Concat(req.SqlId, req.ModelName), map);
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
				
		private static void SaveMenuView(this WasRequest req, IList<AAMenuView> list)
		{
			try
			{
				foreach (var data in list)
				{
					if (data.MenuID == null)
					{
						data.MenuID = req.Result.ReturnValue.ToIntegerNullToNull();
					}

					if (data.Checked == "Y")
						req.SaveSubData<AAMenuView>(data);
					else
						req.DeleteSubData<AAMenuView>(data);

				}
			}
			catch
			{
				throw;
			}
		}

		private static void SaveViewButton(this WasRequest req, IList<AAViewButton> list)
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
						req.SaveSubData<AAViewButton>(data);
				}
			}
			catch
			{
				throw;
			}
		}

		private static void SaveUserGroup(this WasRequest req, IList<AAUserGroup> list)
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
						req.SaveSubData<AAUserGroup>(data);
				}
			}
			catch
			{
				throw;
			}
		}

		private static void SaveUserRole(this WasRequest req, IList<AAUserRole> list)
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
						req.SaveSubData<AAUserGroup>(data);
					req.SaveSubData<AAUserRole>(data);
				}
			}
			catch
			{
				throw;
			}
		}

		private static void SaveGroupRole(this WasRequest req, IList<AAGroupRole> list)
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
						req.SaveSubData<AAUserGroup>(data);
					req.SaveSubData<AAGroupRole>(data);
				}
			}
			catch
			{
				throw;
			}
		}

		private static void SaveGroupMenu(this WasRequest req, IList<AAGroupMenu> list)
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
						req.SaveSubData<AAUserGroup>(data);
					req.SaveSubData<AAGroupMenu>(data);
				}
			}
			catch
			{
				throw;
			}
		}
	}
}
