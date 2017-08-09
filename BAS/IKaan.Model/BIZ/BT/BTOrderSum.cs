using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Base;

namespace IKaan.Model.BIZ.BT
{
	[DataContract]
	public class BTOrderSum : ModelBase
	{
		[DataMember]
		[Display(Name = "채널ID")]
		public int? ChannelID { get; set; }

		[DataMember]
		[Display(Name = "브랜드ID")]
		public int? BrandID { get; set; }

		[DataMember]
		[Display(Name = "주문일자")]
		public DateTime? OrderDate { get; set; }

		[DataMember]
		[Display(Name = "수량")]
		public int OrderQty { get; set; }

		[DataMember]
		[Display(Name = "금액")]
		public decimal OrderAmt { get; set; }

		[DataMember]
		[Display(Name = "채널명")]
		public string ChannelName { get; set; }

		[DataMember]
		[Display(Name = "브랜드명")]
		public string BrandName { get; set; }
	}
}
