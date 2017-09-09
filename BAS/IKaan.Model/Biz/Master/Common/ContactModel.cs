using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Biz.Common
{
	[DataContract]
	public class ContactModel : ModelBase
	{
		[DataMember]
		[Display(Name = "담당자명")]
		public string Name { get; set; }

		[DataMember]
		[Display(Name = "구분")]
		public string ContactType { get; set; }

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
	}
}
