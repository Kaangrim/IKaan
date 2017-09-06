using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Scrap
{
	[DataContract]
	public class GoodsInfoModel : ModelBase
	{
		[DataMember]
		[Display(Name = "사이트코드")]
		public string SiteCode { get; set; }

		[DataMember]
		[Display(Name = "브랜드코드")]
		public string BrandCode { get; set; }

		[DataMember]
		[Display(Name = "상품코드")]
		public string GoodsCode { get; set; }

		[DataMember]
		[Display(Name = "상품명")]
		public string GoodsName { get; set; }

		[DataMember]
		[Display(Name = "상품URL")]
		public string GoodsURL { get; set; }

		[DataMember]
		[Display(Name = "소비자가")]
		public decimal ListPrice { get; set; }

		[DataMember]
		[Display(Name = "판매가")]
		public decimal SalePrice { get; set; }

		[DataMember]
		[Display(Name = "상품이미지URL")]
		public string ImageURL { get; set; }

		[DataMember]
		[Display(Name = "옵션1유형")]
		public string Option1Type { get; set; }

		[DataMember]
		[Display(Name = "옵션1명")]
		public string Option1Name { get; set; }

		[DataMember]
		[Display(Name = "옵션2유형")]
		public string Option2Type { get; set; }
		
		[DataMember]
		[Display(Name = "옵션2명")]
		public string Option2Name { get; set; }

		[DataMember]
		[Display(Name = "카테고리명")]
		public string CategoryName { get; set; }

		[DataMember]
		[Display(Name = "설명")]
		public string Description { get; set; }
	}
}
