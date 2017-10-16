using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Biz.Catalog.Product
{
	[DataContract]
	public class ProductModel : ModelBase
	{
		[DataMember]
		[Display(Name = "상품명")]
		public string Name { get; set; }

		[DataMember]
		[Display(Name = "상품코드")]
		public string Code { get; set; }

		[DataMember]
		[Display(Name = "상품유형")]
		public string ProductType { get; set; }

		[DataMember]
		[Display(Name = "브랜드ID")]
		public int BrandID { get; set; }

		[DataMember]
		[Display(Name = "카테고리ID")]
		public int CategoryID { get; set; }

		[DataMember]
		[Display(Name = "소비자가")]
		public decimal ListPrice { get; set; }

		[DataMember]
		[Display(Name = "판매가")]
		public decimal SalePrice { get; set; }

		[DataMember]
		[Display(Name = "사용여부")]
		public string UseYn { get; set; }

		[DataMember]
		[Display(Name = "브랜드명")]
		public string BrandName { get; set; }

		[DataMember]
		[Display(Name = "카테고리명")]
		public string CategoryName { get; set; }

		[DataMember]
		[Display(Name = "대표이미지URL")]
		public string ImageUrl { get; set; }

		[DataMember]
		[Display(Name = "상품유형명")]
		public string ProductTypeName { get; set; }

		[DataMember]
		[Display(Name = "카테고리(1)")]
		public int Category1 { get; set; }

		[DataMember]
		[Display(Name = "카테고리(1)명")]
		public string Category1Name { get; set; }

		[DataMember]
		[Display(Name = "카테고리(2)")]
		public int Category2 { get; set; }

		[DataMember]
		[Display(Name = "카테고리(2)명")]
		public string Category2Name { get; set; }

		[DataMember]
		[Display(Name = "카테고리(3)")]
		public int Category3 { get; set; }

		[DataMember]
		[Display(Name = "카테고리(3)명")]
		public string Category3Name { get; set; }

		[DataMember]
		[Display(Name = "카테고리(4)")]
		public int Category4 { get; set; }

		[DataMember]
		[Display(Name = "카테고리(4)명")]
		public string Category4Name { get; set; }

		[DataMember]
		[Display(Name = "카테고리(5)")]
		public int Category5 { get; set; }

		[DataMember]
		[Display(Name = "카테고리(5)명")]
		public string Category5Name { get; set; }

		[DataMember]
		[Display(Name = "상품상세")]
		public ProductDescriptionModel Description { get; set; }

		[DataMember]
		[Display(Name = "상품속성")]
		public IList<ProductAttributeModel> Attributes { get; set; }

		[DataMember]
		[Display(Name = "상품이미지")]
		public IList<ProductImageModel> Images { get; set; }

		[DataMember]
		[Display(Name = "정보고시")]
		public IList<ProductInfoNoticeModel> InfoNotices { get; set; }

		[DataMember]
		[Display(Name = "상품아이템")]
		public IList<ProductItemModel> Items { get; set; }

		public ProductModel()
		{
			Description = new ProductDescriptionModel();
			Images = new List<ProductImageModel>();
			Items = new List<ProductItemModel>();
			InfoNotices = new List<ProductInfoNoticeModel>();
			Attributes = new List<ProductAttributeModel>();
		}
	}
}
