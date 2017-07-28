using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Base;

namespace IKaan.Model.BIZ.BC
{
	[DataContract]
	public class BCDepartment : ModelBase
	{
		[DataMember]
		[Display(Name = "부서명")]
		public string DepartmentName { get; set; }

		[DataMember]
		[Display(Name = "상위ID")]
		public int? ParentID { get; set; }

		[DataMember]
		[Display(Name = "사용여부")]
		public string UseYn { get; set; }

		[DataMember]
		[Display(Name = "부서장ID")]
		public string EmployeeID { get; set; }
	}
}
