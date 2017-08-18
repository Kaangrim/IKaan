﻿using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Base;

namespace IKaan.Model.BIZ.BG
{
	[DataContract]
	public class BGGoodsDetail : ModelBase
	{
		[DataMember]
		[Display(Name = "상품ID")]
		public int? GoodsID { get; set; }

		[DataMember]
		[Display(Name = "상세설명")]
		public string Description { get; set; }

		[DataMember]
		[Display(Name = "상세설명(RTF)")]
		public string DescriptionRTF { get; set; }
	}
}
