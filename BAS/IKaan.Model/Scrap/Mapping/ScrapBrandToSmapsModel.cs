using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Scrap.Mapping
{
	[DataContract]
	public class ScrapBrandToSmapsModel : ModelBase
	{
		[DataMember]
		[Display(Name = "사이트ID")]
		public int? SiteID { get; set; }

		[DataMember]
		[Display(Name = "스크랩브랜드ID")]
		public int? ScrapBrandID { get; set; }

		[DataMember]
		[Display(Name = "Smaps브랜드ID")]
		public int? SmapsBrandID { get; set; }

		[DataMember]
		[Display(Name = "스크랩브랜드명")]
		public string ScrapBrandName { get; set; }

		[DataMember]
		[Display(Name = "Smaps브랜드명")]
		public string SmapsBrandName { get; set; }
	}
}
