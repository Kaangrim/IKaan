using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Scrap.Common
{
	[DataContract]
	public class ScrapBrandModel : ModelBase
	{
		[DataMember]
		[Display(Name = "사이트ID")]
		public int SiteID { get; set; }

		[DataMember]
		[Display(Name = "브랜드코드")]
		public string Code { get; set; }

		[DataMember]
		[Display(Name = "브랜드명")]
		public string Name { get; set; }

		[DataMember]
		[Display(Name = "브랜드URL")]
		public string Url { get; set; }

		[DataMember]
		[Display(Name = "상품수")]
		public int ProductCount { get; set; }

		[DataMember]
		[Display(Name = "설명")]
		public string Description { get; set; }

		[DataMember]
		[Display(Name = "스크랩상품수")]
		public int ScrapProductCount { get; set; }

		[DataMember]
		[Display(Name = "스크랩이미지수")]
		public int ScrapImageCount { get; set; }

		[DataMember]
		[Display(Name = "성별(남)")]
		public int GenderMen { get; set; }

		[DataMember]
		[Display(Name = "성별(여)")]
		public int GenderFemale { get; set; }

		[DataMember]
		[Display(Name = "성별(공용)")]
		public int GenderUnisex { get; set; }
	}
}
