using System;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Model.Common.UserModels;
using IKaan.Model.Common.Was;
using IKaan.Model.Base;
using IKaan.Was.Core.Mappers;

namespace IKaan.Was.Service.Common
{
	public static class AUTHService
	{
		/// <summary>
		/// CheckLoginUser
		/// 로그인 체크
		/// </summary>
		/// <param name="req">WasRequest</param>
		/// <returns>WasRequest</returns>
		public static WasRequest CheckLoginUser(WasRequest request)
		{
			try
			{
				DataMap parameter = new DataMap();
				if(request.Parameter!=null)
					parameter = ConvertUtils.JsonToAnyType<DataMap>(request.Parameter);
				parameter.SetValue("UserId", null);
				var data = DaoFactory.Instance.QueryForObject<ULoginUser>("GetLoginUser", parameter);

				if (data == null)
				{
					request.Error.Number = -1;
					request.Error.Message = "해당 아이디로 사용자를 찾을 수 없습니다.";
					return request;
				}

				if (data.UseYn != "Y")
				{
					request.Error.Number = -2;
					request.Error.Message = "사용 가능한 아이디가 아닙니다. 확인 후 다시 시도하세요!!!";
					return request;
				}

				if (data.IsPwCheck != 1)
				{
					request.Error.Number = -3;
					request.Error.Message = "비밀번호가 정확하지 않습니다. 확인 후 다시 시도하세요!!!";
					return request;
				}

				parameter.SetValue("UserId", data.UserId);
				request.Result.ReturnValue = data.UserId;

				//로그인 로그 저장
				try
				{
					DaoFactory.Instance.Insert("InserLoginLog", parameter);
				}
				catch (Exception ex)
				{
					throw new Exception("로그인로그 저장 중 오류가 발생하였습니다.\r\n" + ErrorUtils.GetMessage(ex));
				}

				//공통코드 받아오기
				var codes = DaoFactory.Instance.QueryForList<UCodeLookup>("SelectCodeLookup", parameter);
				data.Codes = codes;
				request.Data = data;
				request.Result.Count = 1;
				return request;
			}
			catch (Exception ex)
			{
				request.Error.Number = ex.HResult;
				request.Error.Message = ex.Message;
				return request;
			}
		}

		/// <summary>
		/// Logout
		/// 로그아웃
		/// </summary>
		/// <param name="request">WasRequest</param>
		/// <returns>WasRequest</returns>
		public static WasRequest Logout(WasRequest request)
		{
			try
			{
				DataMap parameter = new DataMap();
				if (request.Parameter != null)
					parameter = request.Parameter.JsonToAnyType<DataMap>();

				try
				{
					DaoFactory.Instance.Update("UpdateLogout", parameter);
				}
				catch (Exception ex)
				{
					throw new Exception("로그아웃 정보 저장 중 오류가 발생하였습니다.\r\n" + ErrorUtils.GetMessage(ex));
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

		/// <summary>
		/// GetUserMenus
		/// 사용자별 메뉴구성
		/// </summary>
		/// <param name="req">WasRequest</param>
		/// <returns>WasRequest</returns>
		public static WasRequest GetMainMenu(WasRequest request)
		{
			try
			{
				DataMap parameter = new DataMap();
				if (request.Parameter != null)
					parameter = request.Parameter.JsonToAnyType<DataMap>();
				var result = DaoFactory.Instance.QueryForList<UMainMenu>("GetMainMenu", parameter);
				request.Data = result;
				request.Result.Count = result.Count;
				return request;
			}
			catch (Exception ex)
			{
				request.Error.Number = ex.HResult;
				request.Error.Message = ex.Message;
				return request;
			}
		}

		/// <summary>
		/// GetFormData
		/// 화면정보 가져오기
		/// </summary>
		/// <param name="req">WasRequest</param>
		/// <returns>WasRequest</returns>
		public static WasRequest GetMenuView(WasRequest request)
		{
			try
			{
				DataMap parameter = new DataMap();
				if (request.Parameter != null)
					parameter = request.Parameter.JsonToAnyType<DataMap>();

				var menuView = DaoFactory.Instance.QueryForObject<UMenuView>("GetMenuView", parameter);
				var menuViewButton = DaoFactory.Instance.QueryForList<UMenuViewButton>("GetMenuViewButton", parameter);

				if (menuView != null && menuViewButton != null)
					menuView.ViewButtons = menuViewButton;

				request.Data = menuView;
				request.Result.Count = 1;
				return request;
			}
			catch (Exception ex)
			{
				request.Error.Number = ex.HResult;
				request.Error.Message = ex.Message;
				return request;
			}
		}

		/// <summary>
		/// SaveBookmark
		/// 북마크 저장
		/// </summary>
		/// <param name="req">WasRequest</param>
		/// <returns>WasRequest</returns>
		public static WasRequest SaveBookmark(WasRequest request)
		{
			try
			{
				DataMap parameter = new DataMap();
				if (request.Parameter != null)
					parameter = request.Parameter.JsonToAnyType<DataMap>();

				var data = DaoFactory.Instance.QueryForObject<BookmarkModel>("SelectBookmark", parameter);
				if (data == null || data.ID == default(int))
				{
					DaoFactory.Instance.Insert("InsertBookmark", parameter);
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

		/// <summary>
		/// GetDictionary
		/// 용어사전 가져오기
		/// </summary>
		/// <param name="req">WasRequest</param>
		/// <returns>WasRequest</returns>
		public static WasRequest GetDictionary(WasRequest request)
		{
			try
			{
				DataMap parameter = new DataMap();
				if (request.Parameter != null)
					parameter = request.Parameter.JsonToAnyType<DataMap>();

				var list = DaoFactory.Instance.QueryForList<UCodeValue>("GetDictionary", parameter);
				request.Data = list;
				request.Result.Count = list.Count;
				return request;
			}
			catch (Exception ex)
			{
				request.Error.Number = ex.HResult;
				request.Error.Message = ex.Message;
				return request;
			}
		}

		public static WasRequest GetMessage(WasRequest request)
		{
			try
			{
				DataMap parameter = new DataMap();
				if (request.Parameter != null)
					parameter = request.Parameter.JsonToAnyType<DataMap>();

				var list = DaoFactory.Instance.QueryForList<UCodeValue>("GetMessage", parameter);
				request.Data = list;
				request.Result.Count = list.Count;
				return request;
			}
			catch (Exception ex)
			{
				request.Error.Number = ex.HResult;
				request.Error.Message = ex.Message;
				return request;
			}
		}

		public static WasRequest GetCodes(WasRequest request)
		{
			try
			{
				DataMap parameter = new DataMap();
				if (request.Parameter != null)
					parameter = request.Parameter.JsonToAnyType<DataMap>();
				
				//시스템공통코드
				var codes = DaoFactory.Instance.QueryForList<UCodeLookup>("SelectCodeLookup", parameter);
				request.Data = codes;
				request.Result.Count = codes.Count;
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
			try
			{
				DataMap parameter = new DataMap();
				if (request.Parameter != null)
					parameter = request.Parameter.JsonToAnyType<DataMap>();
				parameter.SetValue("UserId", request.User.UserId);
				parameter.SetValue("UpdatedBy", request.User.UserId);
				parameter.SetValue("UpdatedByName", request.User.UserName);

				DaoFactory.Instance.Update("ClearPassword", parameter);
				return request;
			}
			catch (Exception ex)
			{
				request.Error.Number = ex.HResult;
				request.Error.Message = ex.Message;
				return request;
			}
		}

		public static WasRequest ChangePassword(WasRequest request)
		{
			try
			{
				DataMap parameter = new DataMap();
				if (request.Parameter != null)
					parameter = request.Parameter.JsonToAnyType<DataMap>();
				parameter.SetValue("UserId", request.User.UserId);
				parameter.SetValue("UpdatedBy", request.User.UserId);
				parameter.SetValue("UpdatedByName", request.User.UserName);

				var data = DaoFactory.Instance.QueryForObject<ULoginUser>("GetLoginUser", parameter);

				if (data == null)
				{
					request.Error.Number = -1;
					request.Error.Message = "해당 아이디로 사용자를 찾을 수 없습니다.";
					return request;
				}

				if (data.UseYn != "Y")
				{
					request.Error.Number = -2;
					request.Error.Message = "사용 가능한 아이디가 아닙니다. 확인 후 다시 시도하세요!!!";
					return request;
				}

				if (data.IsPwCheck != 1)
				{
					request.Error.Number = -3;
					request.Error.Message = "비밀번호가 정확하지 않습니다. 확인 후 다시 시도하세요!!!";
					return request;
				}

				parameter.SetValue("UserId", data.UserId);
				parameter.SetValue("Password", parameter.GetValue("ChangePassword"));

				DaoFactory.Instance.Update("ChangePassword", parameter);
				request.Error.Number = 0;
				request.Error.Message = "SUCCESS";
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
