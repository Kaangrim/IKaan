using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Biz.Sales.Order
{
	[DataContract]
	public class OrderToDeliveryOrderModel: ModelBase
	{
		[DataMember]
		[Display(Name = "배송요청일")]
		public DateTime DeliveryOrderDate { get; set; }

		[DataMember]
		[Display(Name = "배송요청상세내역")]
		public List<OrderToDeliveryOrderItemModel> Items { get; set; }

		public OrderToDeliveryOrderModel()
		{
			Items = new List<OrderToDeliveryOrderItemModel>();
		}
	}
}
