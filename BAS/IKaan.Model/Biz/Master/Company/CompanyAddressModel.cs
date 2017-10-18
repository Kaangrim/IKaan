using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Biz.Master.Company
{
	[DataContract]
	public class CompanyAddressModel : ModelBase
	{
		[DataMember]
		[Display(Name = "회사ID")]
		public int? CompanyID { get; set; }

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
		[Display(Name = "주소유형명")]
		public string AddressTypeName { get; set; }

		[DataMember]
		[Display(Name = "우편번호")]
		public string PostalCode { get; set; }

		[DataMember]
		[Display(Name = "국가코드")]
		public string Country { get; set; }

		[DataMember]
		[Display(Name = "시/도")]
		public string City { get; set; }

		[DataMember]
		[Display(Name = "시/구/군")]
		public string StateProvince { get; set; }

		[DataMember]
		[Display(Name = "주소1")]
		public string AddressLine1 { get; set; }

		[DataMember]
		[Display(Name = "주소2")]
		public string AddressLine2 { get; set; }

		[DataMember]
		[Display(Name = "국가명")]
		public string CountryName { get; set; }
	}
}
