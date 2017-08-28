using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Live
{
	[DataContract]
	public class ChannelOrderCancelModel: ModelBase
	{
		[DataMember]
		[Display(Name = "채널ID")]
		public int ChannelID { get; set; }

		[DataMember]
		[Display(Name = "취소일자")]
		public DateTime CancelDate { get; set; }

		[DataMember]
		[Display(Name = "주문번호")]
		public string OrderNo { get; set; }

		[DataMember]
		[Display(Name = "주문순번")]
		public string OrderSeq { get; set; }

		[DataMember]
		[Display(Name = "채널주문ID")]
		public int ChannelOrderID { get; set; }
	}
}
