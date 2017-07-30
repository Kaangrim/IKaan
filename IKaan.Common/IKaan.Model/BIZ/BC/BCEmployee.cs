using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Base;
using IKaan.Model.BIZ.BM;

namespace IKaan.Model.BIZ.BC
{
	[DataContract]
	public class BCEmployee : ModelBase
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
		[Display(Name = "사람")]
		public BMPerson Person { get; set; }

		[DataMember]
		[Display(Name = "발령사항")]
		public IList<BCAppointment> Appointments { get; set; }

		public BCEmployee()
		{
			Person = new BMPerson();
			Appointments = new List<BCAppointment>();
		}
	}
}
