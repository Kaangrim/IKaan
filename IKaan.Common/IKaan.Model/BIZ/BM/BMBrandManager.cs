using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Base;

namespace IKaan.Model.BIZ.BM
{
	[DataContract]
	public class BMBrandManager : ModelBase
	{
		[DataMember]
		[Display(Name = "브랜드ID")]
		public int? BrandID { get; set; }

		[DataMember]
		[Display(Name = "사원ID")]
		public int? EmployeeID { get; set; }

		[DataMember]
		[Display(Name = "시작일")]
		public DateTime? StartDate { get; set; }

		[DataMember]
		[Display(Name = "종료일")]
		public DateTime? EndDate { get; set; }

		[DataMember]
		[Display(Name = "사원명")]
		public string EmployeeName { get; set; }

		[DataMember]
		[Display(Name = "부서명")]
		public string DepartmentName { get; set; }
	}
}
