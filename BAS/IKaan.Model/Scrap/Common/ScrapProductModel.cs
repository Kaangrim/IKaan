﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Scrap.Common
{
	[DataContract]
	public class ScrapProductModel : ModelBase
	{
		[DataMember]
		[Display(Name = "사이트ID")]
		public int SiteID { get; set; }

		[DataMember]
		[Display(Name = "브랜드코드")]
		public string BrandCode { get; set; }

		[DataMember]
		[Display(Name = "상품코드")]
		public string Code { get; set; }

		[DataMember]
		[Display(Name = "상품명")]
		public string Name { get; set; }

		[DataMember]
		[Display(Name = "상품URL")]
		public string Url { get; set; }

		[DataMember]
		[Display(Name = "소비자가")]
		public decimal ListPrice { get; set; }

		[DataMember]
		[Display(Name = "판매가")]
		public decimal SalePrice { get; set; }

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
		[Display(Name = "카테고리ID")]
		public int? CategoryID { get; set; }

		[DataMember]
		[Display(Name = "성별")]
		public string Gender { get; set; }

		[DataMember]
		[Display(Name = "시즌")]
		public string Season { get; set; }

		[DataMember]
		[Display(Name = "설명")]
		public string Description { get; set; }

		[DataMember]
		[Display(Name = "이미지")]
		public IList<ScrapProductImageModel> Images { get; set; }

		[DataMember]
		[Display(Name = "브랜드명")]
		public string BrandName { get; set; }

		public ScrapProductModel()
		{
			Images = new List<ScrapProductImageModel>();
		}
	}
}
