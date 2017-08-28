using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Live
{
	[DataContract]
	public class ChannelOrderReturnModel: ModelBase
	{
		[DataMember]
		[Display(Name = "채널ID")]
		public int ChannelID { get; set; }

		[DataMember]
		[Display(Name = "반품일자")]
		public DateTime ReturnDate { get; set; }

		[DataMember]
		[Display(Name = "채널주문ID")]
		public int ChannelOrderID { get; set; }
	}
}
