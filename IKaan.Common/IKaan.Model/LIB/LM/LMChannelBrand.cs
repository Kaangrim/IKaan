﻿using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Base;

namespace IKaan.Model.LIB.LM
{
	public class LMChannelBrand : ModelBase
	{
		[DataMember]
		[Display(Name = "채널ID")]
		public int? ChannelID { get; set; }

		[DataMember]
		[Display(Name = "브랜드ID")]
		public int? BrandID { get; set; }

		[DataMember]
		[Display(Name = "시작일")]
		public string StartDate { get; set; }

		[DataMember]
		[Display(Name = "종료일")]
		public string EndDate { get; set; }

		[DataMember]
		[Display(Name = "채널마진")]
		public decimal ChannelMargin { get; set; }

		[DataMember]
		[Display(Name = "브랜드마진")]
		public decimal BrandMargin { get; set; }

		[DataMember]
		[Display(Name = "채널명")]
		public string ChannelName { get; set; }

		[DataMember]
		[Display(Name = "브랜드명")]
		public string BrandName { get; set; }
	}
}
