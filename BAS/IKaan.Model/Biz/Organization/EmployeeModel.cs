using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Biz.Common;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Biz.Organization
{
	[DataContract]
	public class EmployeeModel : ModelBase
	{
		[DataMember]
		[Display(Name = "사원명")]
		public string Name { get; set; }

		[DataMember]
		[Display(Name = "사원유형")]
		public string EmployeeType { get; set; }

		[DataMember]
		[Display(Name = "사원번호")]
		public string EmployeeNo { get; set; }

		[DataMember]
		[Display(Name = "이메일")]
		public string Email { get; set; }

		[DataMember]
		[Display(Name = "전화번호")]
		public string PhoneNo { get; set; }

		[DataMember]
		[Display(Name = "휴대전화")]
		public string MobileNo { get; set; }

		[DataMember]
		[Display(Name = "팩스번호")]
		public string FaxNo { get; set; }

		[DataMember]
		[Display(Name = "사용여부")]
		public string UseYn { get; set; }

		[DataMember]
		[Display(Name = "설명")]
		public string Description { get; set; }

		[DataMember]
		[Display(Name = "이미지ID")]
		public string ImageID { get; set; }

		[DataMember]
		[Display(Name = "이미지")]
		public ImageModel Image { get; set; }

		[DataMember]
		[Display(Name = "부서명")]
		public string DepartmentName { get; set; }

		[DataMember]
		[Display(Name = "포지션")]
		public string Position { get; set; }

		[DataMember]
		[Display(Name = "발령사항")]
		public IList<AppointmentModel> Appointments { get; set; }

		public EmployeeModel()
		{
			Appointments = new List<AppointmentModel>();
		}
	}
}
