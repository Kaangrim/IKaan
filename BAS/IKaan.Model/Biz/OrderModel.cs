using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Biz
{
	[DataContract]
	public class OrderModel: ModelBase
	{
		[DataMember]
		[Display(Name = "상점ID")]
		public int StoreID { get; set; }

		[DataMember]
		[Display(Name = "거래처ID")]
		public int CustomerID { get; set; }

		[DataMember]
		[Display(Name = "주문일자")]
		public DateTime OrderDate { get; set; }

		[DataMember]
		[Display(Name = "주문번호")]
		public string OrderNo { get; set; }

		[DataMember]
		[Display(Name = "주문자ID")]
		public int? BillingAddressID { get; set; }

		[DataMember]
		[Display(Name = "배송지ID")]
		public int? ShippingAddressID { get; set; }

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
	}
}
