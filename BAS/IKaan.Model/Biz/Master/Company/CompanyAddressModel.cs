using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Biz.Common;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Biz.Company
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
		[Display(Name = "주소")]
		public AddressModel Address { get; set; }
	}
}
