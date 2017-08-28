using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Biz
{
	[DataContract]
	public class PersonModel : ModelBase
	{
		[DataMember]
		[Display(Name = "구분")]
		public string PersonType { get; set; }

		[DataMember]
		[Display(Name = "성명")]
		public string PersonName { get; set; }

		[DataMember]
		[Display(Name = "영문명")]
		public string EngName { get; set; }

		[DataMember]
		[Display(Name = "이메일")]
		public string Email { get; set; }

		[DataMember]
		[Display(Name = "연락처1")]
		public string PhoneNo1 { get; set; }

		[DataMember]
		[Display(Name = "연락처2")]
		public string PhoneNo2 { get; set; }

		[DataMember]
		[Display(Name = "팩스번호")]
		public string FaxNo { get; set; }

		[DataMember]
		[Display(Name = "이미지URL")]
		public string ImageUrl { get; set; }
	}
}
