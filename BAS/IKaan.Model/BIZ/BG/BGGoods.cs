﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Base;

namespace IKaan.Model.BIZ.BG
{
	[DataContract]
	public class BGGoods : ModelBase
	{
		[DataMember]
		[Display(Name = "상품코드")]
		public string GoodsCode { get; set; }

		[DataMember]
		[Display(Name = "상품명")]
		public string GoodsName { get; set; }

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
		[Display(Name = "상품상세")]
		public BGGoodsDetail Detail { get; set; }

		[DataMember]
		[Display(Name = "상품이미지")]
		public IList<BGGoodsImage> Image { get; set; }

		[DataMember]
		[Display(Name = "상품옵션")]
		public IList<BGGoodsItem> Item { get; set; }

		[DataMember]
		[Display(Name = "정보고시")]
		public IList<BGGoodsInfoNotice> InfoNotice { get; set; }

		[DataMember]
		[Display(Name = "상품속성")]
		public IList<BGGoodsAttribute> Attribute { get; set; }

		public BGGoods()
		{
			Detail = new BGGoodsDetail();
			Image = new List<BGGoodsImage>();
			Item = new List<BGGoodsItem>();
			InfoNotice = new List<BGGoodsInfoNotice>();
			Attribute = new List<BGGoodsAttribute>();
		}
	}
}
