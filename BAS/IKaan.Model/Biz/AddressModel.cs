using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Biz
{
	[DataContract]
	public class AddressModel : ModelBase
	{
		[DataMember]
		[Display(Name = "우편코드")]
		public string PostalCode { get; set; }

		[DataMember]
		[Display(Name = "시/도")]
		public string City { get; set; }

		[DataMember]
		[Display(Name = "시/구/군/주/지역")]
		public string StateProvince { get; set; }

		[DataMember]
		[Display(Name = "국가")]
		public string Country { get; set; }

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
