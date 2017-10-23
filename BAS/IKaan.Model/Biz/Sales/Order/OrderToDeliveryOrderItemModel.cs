using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Biz.Sales.Order
{
	[DataContract]
	public class OrderToDeliveryOrderItemModel: ModelBase
	{
		[DataMember]
		[Display(Name = "주문ID")]
		public int OrderID { get; set; }

		[DataMember]
		[Display(Name = "주문상세ID")]
		public int OrderItemID { get; set; }

		[DataMember]
		[Display(Name = "요청수량")]
		public int RequestQty { get; set; }
	}
}
