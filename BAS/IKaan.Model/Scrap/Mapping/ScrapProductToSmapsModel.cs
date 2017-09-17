using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Scrap.Mapping
{
	[DataContract]
	public class ScrapProductToSmapsModel : ModelBase
	{
		[DataMember]
		[Display(Name = "사이트ID")]
		public int? SiteID { get; set; }

		[DataMember]
		[Display(Name = "브랜드코드")]
		public string BrandCode { get; set; }

		[DataMember]
		[Display(Name = "카테고리ID")]
		public int? CategoryID { get; set; }

		[DataMember]
		[Display(Name = "스크랩상품ID")]
		public int? ScrapProductID { get; set; }

		[DataMember]
		[Display(Name = "Smaps상품ID")]
		public int? SmapsProductID { get; set; }

		[DataMember]
		[Display(Name = "브랜드명")]
		public string BrandName { get; set; }

		[DataMember]
		[Display(Name = "카테고리명")]
		public string CategoryName { get; set; }

		[DataMember]
		[Display(Name = "스크랩상품명")]
		public string ScrapProductName { get; set; }

		[DataMember]
		[Display(Name = "Smaps상품명")]
		public string SmapsProductName { get; set; }
	}
}
