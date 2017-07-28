using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Base;

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
		public string PersonID { get; set; }
	}
}
