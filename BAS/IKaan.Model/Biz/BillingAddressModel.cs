using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Biz
{
	[DataContract]
	public class BillingAddressModel : ModelBase
	{
		[DataMember]
		[Display(Name = "거래처ID")]
		public int? CustomerID { get; set; }

		[DataMember]
		[Display(Name = "First Name")]
		public string FirstName { get; set; }

		[DataMember]
		[Display(Name = "Last Name")]
		public string LastName { get; set; }

		[DataMember]
		[Display(Name = "이메일")]
		public string Email { get; set; }

		[DataMember]
		[Display(Name = "전화번호")]
		public string PhoneNo { get; set; }

		[DataMember]
		[Display(Name = "모바일번호")]
		public string MobileNo { get; set; }

		[DataMember]
		[Display(Name = "팩스번호")]
		public string FaxNo { get; set; }

		[DataMember]
		[Display(Name = "주소ID")]
		public int? AddressID { get; set; }

		[DataMember]
		[Display(Name = "이미지")]
		public AddressModel Address { get; set; }
	}
}
