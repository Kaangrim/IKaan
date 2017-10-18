using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace IKaan.Model.Scrap.Smaps
{
	[DataContract]
	public class SmapsBrandReceiveModel
	{
		[DataMember]
		[Display(Name = "UID")]
		public int? uid { get; set; }

		[DataMember]
		[Display(Name = "브랜드명")]
		public string brand_name { get; set; }

		[DataMember]
		[Display(Name = "대행사UID")]
		public int agency_uid { get; set; }

		[DataMember]
		[Display(Name = "브랜드담당UID")]
		public int manager_uid { get; set; }
	}
}
