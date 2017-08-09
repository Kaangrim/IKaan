﻿using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Base;

namespace IKaan.Model.SMP.WC
{
	[DataContract]
	public class WCBrandInfo : ModelBase
	{
		[DataMember]
		[Display(Name = "사이트코드")]
		public string SiteCode { get; set; }

		[DataMember]
		[Display(Name = "브랜드코드")]
		public string BrandCode { get; set; }

		[DataMember]
		[Display(Name = "브랜드명")]
		public string BrandName { get; set; }

		[DataMember]
		[Display(Name = "브랜드URL")]
		public string BrandURL { get; set; }

		[DataMember]
		[Display(Name = "상품수")]
		public int GoodsCnt { get; set; }
	}
}
