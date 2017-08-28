using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;
using IKaan.Model.Biz;

namespace IKaan.Model.Biz
{
	[DataContract]
	public class EmployeeModel : ModelBase
	{
		[DataMember]
		[Display(Name = "부서명")]
		public string EmployeeNo { get; set; }

		[DataMember]
		[Display(Name = "부서명")]
		public string EmployeeName { get; set; }

		[DataMember]
		[Display(Name = "사용여부")]
		public string UseYn { get; set; }

		[DataMember]
		[Display(Name = "사람ID")]
		public int? PersonID { get; set; }

		[DataMember]
		[Display(Name = "부서명")]
		public string DepartmentName { get; set; }

		[DataMember]
		[Display(Name = "포지션")]
		public string Position { get; set; }

		[DataMember]
		[Display(Name = "사람")]
		public PersonModel Person { get; set; }

		[DataMember]
		[Display(Name = "발령사항")]
		public IList<AppointmentModel> Appointments { get; set; }

		public EmployeeModel()
		{
			Person = new PersonModel();
			Appointments = new List<AppointmentModel>();
		}
	}
}
