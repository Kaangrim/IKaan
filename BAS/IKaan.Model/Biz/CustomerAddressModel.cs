using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Biz
{
	[DataContract]
	public class CustomerAddressModel : ModelBase
	{
		[DataMember]
		[Display(Name = "거래처ID")]
		public int? CustomerID { get; set; }

		[DataMember]
		[Display(Name = "주소ID")]
		public int? AddressID { get; set; }

		[DataMember]
		[Display(Name = "주소유형")]
		public string AddressType { get; set; }

		[DataMember]
		[Display(Name = "설명")]
		public string Description { get; set; }

		[DataMember]
		[Display(Name = "우편코드")]
		public string PostalCode { get; set; }

		[DataMember]
		[Display(Name = "국가")]
		public string Country { get; set; }

		[DataMember]
		[Display(Name = "시도")]
		public string City { get; set; }

		[DataMember]
		[Display(Name = "시구군주")]
		public string StateProvince { get; set; }

		[DataMember]
		[Display(Name = "주소1")]
		public string AddressLine1 { get; set; }

		[DataMember]
		[Display(Name = "주소2")]
		public string AddressLine2 { get; set; }

		[DataMember]
		[Display(Name = "주소유형명")]
		public string AddressTypeName { get; set; }
	}
}
