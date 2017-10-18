using System;
using System.Collections.Generic;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Model.Biz.Organization;
using IKaan.Model.Common.Was;
using IKaan.Was.Core.Mappers;
using IKaan.Was.Service.Utils;

namespace IKaan.Was.Service.Services
{
	public static class BizServiceOrganization
	{
		public static DepartmentModel GetDepartment(this WasRequest req)
		{
			try
			{
				var parameter = req.Parameter.JsonToAnyType<DataMap>();
				var department = DaoFactory.InstanceBiz.QueryForObject<DepartmentModel>("SelectDepartment", parameter);
				if (department != null)
				{
					//부서이력
					parameter = new DataMap() { { "DepartmentID", department.ID } };
					var history = DaoFactory.InstanceBiz.QueryForList<DepartmentHistoryModel>("SelectDepartmentHistoryList", parameter);
					department.Histories = history;

					//발령정보
					parameter = new DataMap() { { "DepartmentID", department.ID } };
					var appointments = DaoFactory.InstanceBiz.QueryForList<AppointmentModel>("SelectAppointmentList", parameter);
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

		public static EmployeeModel GetEmployee(this WasRequest req)
		{
			try
			{
				var parameter = req.Parameter.JsonToAnyType<DataMap>();
				var employee = DaoFactory.InstanceBiz.QueryForObject<EmployeeModel>("SelectEmployee", parameter);
				if (employee != null)
				{
					//발령정보 가져오기
					parameter = new DataMap() { { "EmployeeID", employee.ID } };
					var appointments = DaoFactory.InstanceBiz.QueryForList<AppointmentModel>("SelectAppointmentList", parameter);
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

		public static void SaveDepartment(this WasRequest req)
		{
			try
			{
				var department = req.Data.JsonToAnyType<DepartmentModel>();
				department = req.SaveData<DepartmentModel>(department);
				if (department != null)
				{
					var parameter = new DataMap()
					{
						{ "DepartmentID", department.ID },
						{ "StartDate", department.StartDate }
					};

					var equal = DaoFactory.InstanceBiz.QueryForObject<DepartmentHistoryModel>("SelectDepartmentHistoryEqual", parameter);
					if (equal != null)
					{
						//시작일이 동일한 경우 업데이트한다.
						equal.Name = department.Name;
						equal.ParentID = department.ParentID;
						equal.ManagerID = department.ManagerID;
						equal.UpdatedBy = req.User.UserId;
						equal.UpdatedByName = req.User.UserName;

						DaoFactory.InstanceBiz.Update("UpdateDepartmentHistory", equal);
					}
					else
					{
						//동일 시작일의 데이터가 없는 경우
						//직전 이력을 찾아서 종료일을 변경한 후 새로운 이력을 저장한다.
						var before = DaoFactory.InstanceBiz.QueryForObject<DepartmentHistoryModel>("SelectDepartmentHistoryBefore", parameter);
						if (before != null)
						{
							before.EndDate = department.StartDate.Value.AddDays(-1);
							before.UpdatedBy = req.User.UserId;
							before.UpdatedByName = req.User.UserName;

							DaoFactory.InstanceBiz.Update("UpdateDepartmentHistoryBefore", before);
						}

						//새로운 이력을 저장한다.
						var history = new DepartmentHistoryModel()
						{
							DepartmentID = department.ID,
							Name = department.Name,
							ParentID = department.ParentID,
							ManagerID = department.ManagerID,
							StartDate = department.StartDate,
							EndDate = null,
							CreatedBy = req.User.UserId,
							CreatedByName = req.User.UserName
						};
						DaoFactory.InstanceBiz.Insert("InsertDepartmentHistory", history);
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

		public static void SaveEmployee(this WasRequest req)
		{
			try
			{
				var employee = req.Data.JsonToAnyType<EmployeeModel>();
				if (employee != null)
				{
					employee = req.SaveData<EmployeeModel>(employee);

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

		public static void SaveAppointment(this WasRequest req)
		{
			try
			{
				object id = null;
				var appointment = req.Data.JsonToAnyType<AppointmentModel>();
				if (appointment != null)
				{
					var parameter = new DataMap()
					{
						{ "EmployeeID", appointment.EmployeeID },
						{ "StartDate", appointment.StartDate }
					};

					var dup = DaoFactory.InstanceBiz.QueryForObject<AppointmentModel>("SelectAppointmentDuplicate", parameter);
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

							appointment.UpdatedBy = req.User.UserId;
							appointment.UpdatedByName = req.User.UserName;

							DaoFactory.InstanceBiz.Update("UpdateAppointment", appointment);
							id = appointment.ID;
						}
					}
					else
					{
						//동일 시작일의 데이터가 없는 경우
						//직전 이력을 찾아서 종료일을 변경한 후 새로운 이력을 저장한다.
						var before = DaoFactory.InstanceBiz.QueryForObject<AppointmentModel>("SelectAppointmentBefore", parameter);
						if (before != null)
						{
							before.EndDate = appointment.StartDate.Value.AddDays(-1);
							before.UpdatedBy = req.User.UserId;
							before.UpdatedByName = req.User.UserName;

							DaoFactory.InstanceBiz.Update("UpdateAppointmentBefore", before);
						}

						//이후에 등록된 이력이 존재하는 경우 종료일을 이후 등록된 내역의 시작일 (-1)일로 설정한다.
						var after = DaoFactory.InstanceBiz.QueryForObject<AppointmentModel>("SelectAppointmentAfter", parameter);
						if (after != null)
						{
							appointment.EndDate = after.StartDate.Value.AddDays(-1);
						}

						if (appointment.ID == null)
						{
							appointment.CreatedBy = req.User.UserId;
							appointment.CreatedByName = req.User.UserName;
							id = DaoFactory.InstanceBiz.Insert("InsertAppointment", appointment);
							appointment.ID = id.ToIntegerNullToNull();
						}
						else
						{
							appointment.UpdatedBy = req.User.UserId;
							appointment.UpdatedByName = req.User.UserName;
							DaoFactory.InstanceBiz.Update("UpdateAppointment", appointment);
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
