using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Base;

namespace IKaan.Model.BIZ.BC
{
	[DataContract]
	public class BCAppointment : ModelBase
	{
		[DataMember]
		[Display(Name = "부서명")]
		public int? EmployeeID { get; set; }

		[DataMember]
		[Display(Name = "상위ID")]
		public int? DepartmentID { get; set; }

		[DataMember]
		[Display(Name = "메인부서여부")]
		public string MainYn { get; set; }

		[DataMember]
		[Display(Name = "포지션")]
		public string Position { get; set; }

		[DataMember]
		[Display(Name = "시작일")]
		public DateTime StartDate { get; set; }

		[DataMember]
		[Display(Name = "종료일")]
		public DateTime EndDate { get; set; }
	}
}
