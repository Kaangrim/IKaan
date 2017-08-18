﻿using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Base;

namespace IKaan.Model.BIZ.BG
{
	[DataContract]
	public class BGGoodsInfoNotice : ModelBase
	{
		[DataMember]
		[Display(Name = "상품ID")]
		public int? GoodsID { get; set; }

		[DataMember]
		[Display(Name = "정보고시ID")]
		public int InfoNoticeItemID { get; set; }

		[DataMember]
		[Display(Name = "정보고시값")]
		public string InfoNoticeValue { get; set; }

		[DataMember]
		[Display(Name = "정보고시항목명")]
		public string InfoNoticeItemName { get; set; }
	}
}
