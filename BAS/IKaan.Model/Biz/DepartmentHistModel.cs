using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Biz
{
	[DataContract]
	public class DepartmentHistModel : ModelBase
	{
		[DataMember]
		[Display(Name = "부서ID")]
		public int? DepartmentID { get; set; }

		[DataMember]
		[Display(Name = "부서명")]
		public string DepartmentName { get; set; }

		[DataMember]
		[Display(Name = "상위ID")]
		public int? ParentID { get; set; }

		[DataMember]
		[Display(Name = "부서장ID")]
		public int? ManagerID { get; set; }

		[DataMember]
		[Display(Name = "시작일")]
		public DateTime? StartDate { get; set; }

		[DataMember]
		[Display(Name = "종료일")]
		public DateTime? EndDate { get; set; }

		[DataMember]
		[Display(Name = "매니저명")]
		public string ManagerName { get; set; }
	}
}
