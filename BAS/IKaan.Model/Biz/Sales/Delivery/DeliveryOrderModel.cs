using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Biz.Sales.Delivery
{
	[DataContract]
	public class DeliveryOrderModel : ModelBase
	{
		[DataMember]
		[Display(Name = "상점ID")]
		public int StoreID { get; set; }

		[DataMember]
		[Display(Name = "채널ID")]
		public int? ChannelID { get; set; }

		[DataMember]
		[Display(Name = "회원ID")]
		public int? MemberID { get; set; }

		[DataMember]
		[Display(Name = "배송일자")]
		public DateTime DeliveryOrderDate { get; set; }

		[DataMember]
		[Display(Name = "주문일자")]
		public DateTime OrderDate { get; set; }

		[DataMember]
		[Display(Name = "오더ID")]
		public int OrderID { get; set; }

		[DataMember]
		[Display(Name = "주문수량")]
		public int TotalOrderQty { get; set; }

		[DataMember]
		[Display(Name = "주문액")]
		public decimal TotalOrderAmt { get; set; }

		[DataMember]
		[Display(Name = "할인액")]
		public decimal TotalDiscountAmt { get; set; }

		[DataMember]
		[Display(Name = "쿠폰액")]
		public decimal TotalCouponAmt { get; set; }

		[DataMember]
		[Display(Name = "배송비")]
		public decimal TotalDeliveryFee { get; set; }

		[DataMember]
		[Display(Name = "공급금액")]
		public decimal TotalSupplyAmt { get; set; }

		[DataMember]
		[Display(Name = "설명")]
		public string Description { get; set; }

		[DataMember]
		[Display(Name = "상태")]
		public string Status { get; set; }

		[DataMember]
		[Display(Name = "채널명")]
		public string ChannelName { get; set; }

		[DataMember]
		[Display(Name = "회원명")]
		public string MemberName { get; set; }

		[DataMember]
		[Display(Name = "상품상세")]
		public IList<DeliveryOrderItemModel> Items { get; set; }

		public DeliveryOrderModel()
		{
			Items = new List<DeliveryOrderItemModel>();
		}
	}
}
