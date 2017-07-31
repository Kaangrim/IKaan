using System;
using System.Collections.Generic;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Model.BIZ.BC;
using IKaan.Model.BIZ.BM;
using IKaan.Model.Was;
using IKaan.Was.Core.Mappers;
using IKaan.Was.Service.Utils;
using Newtonsoft.Json.Linq;

namespace IKaan.Was.Service.BIZ
{
	public static class BCService
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
						case "BCAppointment":
							req.SetList<BCAppointment>();
							break;
						case "BCDepartment":
							req.SetList<BCDepartment>();
							break;
						case "BCEmployee":
							req.SetList<BCEmployee>();
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
						case "BCAppointment":
							req.SetData<BCAppointment>();
							break;
						case "BCDepartment":
							req.GetDepartment();
							break;
						case "BCEmployee":
							req.GetEmployee();
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
					DaoFactory.InstanceBiz.BeginTransaction();
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
								case "BCAppointment":
									req.SaveAppointment();
									break;
								case "BCDepartment":
									req.SaveDepartment();
									break;
								case "BCEmployee":
									req.SaveEmployee();
									break;
							}
						}
					}

					if (isTran)
						DaoFactory.InstanceBiz.CommitTransaction();
				}
				catch (Exception ex)
				{
					if (isTran)
						DaoFactory.InstanceBiz.RollBackTransaction();

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

				if (request.IsTransaction)
				{
					DaoFactory.InstanceBiz.BeginTransaction();
					isTran = true;
				}

				try
				{
					foreach (WasRequest req in list)
					{
						DataMap map = req.Data.JsonToAnyType<DataMap>();
						DaoFactory.InstanceBiz.Delete(req.SqlId, map);
					}

					if (isTran)
						DaoFactory.InstanceBiz.CommitTransaction();
				}
				catch (Exception ex)
				{
					if (isTran)
						DaoFactory.InstanceBiz.RollBackTransaction();

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

		private static BCDepartment GetDepartment(this WasRequest req)
		{
			try
			{
				DataMap parameter = req.Parameter.JsonToAnyType<DataMap>();
				BCDepartment department = DaoFactory.InstanceBiz.QueryForObject<BCDepartment>("SelectBCDepartment", parameter);
				if (department != null)
				{
					//부서이력
					parameter = new DataMap() { { "DepartmentID", department.ID } };
					IList<BCDepartmentHist> history = DaoFactory.InstanceBiz.QueryForList<BCDepartmentHist>("SelectBCDepartmentHistList", parameter);
					department.History = history;

					//발령정보
					parameter = new DataMap() { { "DepartmentID", department.ID } };
					IList<BCAppointment> appointments = DaoFactory.InstanceBiz.QueryForList<BCAppointment>("SelectBCAppointmentList", parameter);
					department.Appointments = appointments;
				}
				req.Data = department;
				req.Result.Count = 1;
				return department;
			}
			catch
			{
				throw;
			}
		}

		private static BCEmployee GetEmployee(this WasRequest req)
		{
			try
			{
				DataMap parameter = req.Parameter.JsonToAnyType<DataMap>();
				BCEmployee employee = DaoFactory.InstanceBiz.QueryForObject<BCEmployee>("SelectBCEmployee", parameter);
				if (employee != null)
				{
					//사람정보 가져오기
					parameter = new DataMap() { { "ID", employee.PersonID } };
					BMPerson person = DaoFactory.InstanceBiz.QueryForObject<BMPerson>("SelectBMPerson", parameter);
					employee.Person = person;

					//발령정보 가져오기
					parameter = new DataMap() { { "EmployeeID", employee.ID } };
					IList<BCAppointment> appointments = DaoFactory.InstanceBiz.QueryForList<BCAppointment>("SelectBCAppointmentList", parameter);
					employee.Appointments = appointments;
				}
				req.Data = employee;
				req.Result.Count = 1;
				return employee;
			}
			catch
			{
				throw;
			}
		}

		private static void SaveDepartment(this WasRequest req)
		{
			try
			{
				BCDepartment department = req.Data.JsonToAnyType<BCDepartment>();
				department = req.SaveData<BCDepartment>(department);
				if (department != null)
				{
					DataMap parameter = new DataMap()
					{
						{ "DepartmentID", department.ID },
						{ "StartDate", department.StartDate }
					};

					BCDepartmentHist equal = DaoFactory.InstanceBiz.QueryForObject<BCDepartmentHist>("SelectBCDepartmentHistEqual", parameter);
					if (equal != null)
					{
						//시작일이 동일한 경우 업데이트한다.
						equal.DepartmentName = department.DepartmentName;
						equal.ParentID = department.ParentID;
						equal.ManagerID = department.ManagerID;
						equal.UpdateBy = req.User.UserId;
						equal.UpdateByName = req.User.UserName;

						DaoFactory.InstanceBiz.Update("UpdateBCDepartmentHist", equal);
					}
					else
					{
						//동일 시작일의 데이터가 없는 경우
						//직전 이력을 찾아서 종료일을 변경한 후 새로운 이력을 저장한다.
						BCDepartmentHist before = DaoFactory.InstanceBiz.QueryForObject<BCDepartmentHist>("SelectBCDepartmentHistBefore", parameter);
						if (before != null)
						{
							before.EndDate = department.StartDate.Value.AddDays(-1);
							before.UpdateBy = req.User.UserId;
							before.UpdateByName = req.User.UserName;

							DaoFactory.InstanceBiz.Update("UpdateBCDepartmentHistBefore", before);
						}
						
						//새로운 이력을 저장한다.
						BCDepartmentHist history = new BCDepartmentHist()
						{
							DepartmentID = department.ID,
							DepartmentName = department.DepartmentName,
							ParentID = department.ParentID,
							ManagerID = department.ManagerID,
							StartDate = department.StartDate,
							EndDate = null,
							CreateBy = req.User.UserId,
							CreateByName = req.User.UserName
						};
						DaoFactory.InstanceBiz.Insert("InsertBCDepartmentHist", history);
					}

					req.Result.Count = 1;
					req.Result.ReturnValue = department.ID;
					req.Error.Number = 0;
				}
			}
			catch
			{
				throw;
			}
		}

		private static void SaveEmployee(this WasRequest req)
		{
			try
			{
				object personID = null;
				BCEmployee employee = req.Data.JsonToAnyType<BCEmployee>();

				if (employee != null)
				{
					if (employee.Person != null)
					{
						if (employee.PersonID != null)
						{
							employee.Person.ID = employee.PersonID;
							employee.Person.UpdateBy = req.User.UserId;
							employee.Person.UpdateByName = req.User.UserName;

							DaoFactory.InstanceBiz.Update("UpdateBMPerson", employee.Person);
							personID = employee.PersonID;
						}
						else
						{
							employee.Person.CreateBy = req.User.UserId;
							employee.Person.CreateByName = req.User.UserName;

							personID = DaoFactory.InstanceBiz.Insert("InsertBMPerson", employee.Person);
						}
					}

					employee.PersonID = personID.ToIntegerNullToNull();
					employee = req.SaveData<BCEmployee>(employee);

					req.Result.Count = 1;
					req.Result.ReturnValue = employee.ID;
					req.Error.Number = 0;
				}
			}
			catch
			{
				throw;
			}
		}

		private static void SaveAppointment(this WasRequest req)
		{
			try
			{
				object id = null;
				BCAppointment appointment = req.Data.JsonToAnyType<BCAppointment>();
				if (appointment != null)
				{
					DataMap parameter = new DataMap()
					{
						{ "EmployeeID", appointment.EmployeeID },
						{ "StartDate", appointment.StartDate }
					};

					BCAppointment dup = DaoFactory.InstanceBiz.QueryForObject<BCAppointment>("SelectBCAppointmentDuplicate", parameter);
					if (dup != null)
					{
						if (appointment.ID == null)
						{
							throw new Exception("동일한 일자에 등록된 내역이 존재합니다.");
						}
						else
						{
							if (appointment.ID != dup.ID)
								throw new Exception("동일한 일자에 등록된 내역이 존재합니다.");

							appointment.UpdateBy = req.User.UserId;
							appointment.UpdateByName = req.User.UserName;

							DaoFactory.InstanceBiz.Update("UpdateBCAppointment", appointment);
							id = appointment.ID;
						}						
					}
					else
					{
						//동일 시작일의 데이터가 없는 경우
						//직전 이력을 찾아서 종료일을 변경한 후 새로운 이력을 저장한다.
						BCAppointment before = DaoFactory.InstanceBiz.QueryForObject<BCAppointment>("SelectBCAppointmentBefore", parameter);
						if (before != null)
						{
							before.EndDate = appointment.StartDate.Value.AddDays(-1);
							before.UpdateBy = req.User.UserId;
							before.UpdateByName = req.User.UserName;

							DaoFactory.InstanceBiz.Update("UpdateBCAppointmentBefore", before);
						}

						//이후에 등록된 이력이 존재하는 경우 종료일을 이후 등록된 내역의 시작일 (-1)일로 설정한다.
						BCAppointment after = DaoFactory.InstanceBiz.QueryForObject<BCAppointment>("SelectBCAppointmentAfter", parameter);
						if (after != null)
						{
							appointment.EndDate = after.StartDate.Value.AddDays(-1);
						}

						if (appointment.ID == null)
						{
							appointment.CreateBy = req.User.UserId;
							appointment.CreateByName = req.User.UserName;

							id = DaoFactory.InstanceBiz.Insert("InsertBCAppointment", appointment);
						}
						else
						{
							appointment.UpdateBy = req.User.UserId;
							appointment.UpdateByName = req.User.UserName;

							DaoFactory.InstanceBiz.Update("UpdateBCAppointment", appointment);
							id = appointment.ID;
						}
					}

					req.Result.Count = 1;
					req.Result.ReturnValue = id;
					req.Error.Number = 0;
				}
			}
			catch
			{
				throw;
			}
		}

	}
}
