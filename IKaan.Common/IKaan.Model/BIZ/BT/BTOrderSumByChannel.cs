using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Base;

namespace IKaan.Model.BIZ.BT
{
	[DataContract]
	public class BTOrderSumByChannel : ModelBase
	{
		[DataMember]
		[Display(Name = "채널ID")]
		public int? ChannelID { get; set; }

		[DataMember]
		[Display(Name = "주문일자")]
		public DateTime? OrderDate { get; set; }

		[DataMember]
		[Display(Name = "수량")]
		public IList<BTOrderSum> OrderSumList { get; set; }

		public BTOrderSumByChannel()
		{
			OrderSumList = new List<BTOrderSum>();
		}
	}
}
