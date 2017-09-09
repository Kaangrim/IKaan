using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Biz.Common;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Biz.Partner
{
	[DataContract]
	public class PartnerAddressModel : ModelBase
	{
		[DataMember]
		[Display(Name = "파트너ID")]
		public int? PartnerID { get; set; }

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
		[Display(Name = "주소")]
		public AddressModel Address { get; set; }
	}
}
