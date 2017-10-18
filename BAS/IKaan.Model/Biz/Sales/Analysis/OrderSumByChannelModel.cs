using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Biz.Sales.Analysis
{
	[DataContract]
	public class OrderSumByChannelModel : ModelBase
	{
		[DataMember]
		[Display(Name = "채널ID")]
		public int? ChannelID { get; set; }

		[DataMember]
		[Display(Name = "주문일자")]
		public DateTime? OrderDate { get; set; }

		[DataMember]
		[Display(Name = "수량")]
		public IList<OrderSumModel> OrderSumList { get; set; }

		public OrderSumByChannelModel()
		{
			OrderSumList = new List<OrderSumModel>();
		}
	}
}
