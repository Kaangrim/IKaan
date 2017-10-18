using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Biz.Sales.Order
{
	[DataContract]
	public class OrderListModel: ModelBase
	{
		[DataMember]
		[Display(Name = "주문일자")]
		public DateTime OrderDate { get; set; }

		[DataMember]
		[Display(Name = "주문번호")]
		public string OrderNo { get; set; }

		[DataMember]
		[Display(Name = "상점ID")]
		public int StoreID { get; set; }

		[DataMember]
		[Display(Name = "상점명")]
		public string StoreName { get; set; }

		[DataMember]
		[Display(Name = "채널ID")]
		public int? ChannelID { get; set; }

		[DataMember]
		[Display(Name = "채널명")]
		public string ChannelName { get; set; }

		[DataMember]
		[Display(Name = "고객ID")]
		public int? MemberID { get; set; }

		[DataMember]
		[Display(Name = "고객명")]
		public string MemberName { get; set; }

		[DataMember]
		[Display(Name = "주문자ID")]
		public int? BillingAddressID { get; set; }

		[DataMember]
		[Display(Name = "배송지ID")]
		public int? ShippingAddressID { get; set; }

		[DataMember]
		[Display(Name = "설명")]
		public string Description { get; set; }

		[DataMember]
		[Display(Name = "상태")]
		public string Status { get; set; }

		[DataMember]
		[Display(Name = "상태명")]
		public string StatusName { get; set; }

		[DataMember]
		[Display(Name = "주문상세ID")]
		public int OrderItemID { get; set; }

		[DataMember]
		[Display(Name = "상품ID")]
		public int ProductID { get; set; }

		[DataMember]
		[Display(Name = "상품명")]
		public string ProductName { get; set; }

		[DataMember]
		[Display(Name = "상품코드")]
		public string ProductCode { get; set; }

		[DataMember]
		[Display(Name = "옵션1")]
		public string Option1 { get; set; }

		[DataMember]
		[Display(Name = "옵션2")]
		public string Option2 { get; set; }

		[DataMember]
		[Display(Name = "번들")]
		public string Bundle { get; set; }

		[DataMember]
		[Display(Name = "판매가")]
		public decimal SalePrice { get; set; }

		[DataMember]
		[Display(Name = "주문수량")]
		public int OrderQty { get; set; }

		[DataMember]
		[Display(Name = "주문금액")]
		public decimal OrderAmt { get; set; }

		[DataMember]
		[Display(Name = "할인액")]
		public decimal DiscountAmt { get; set; }

		[DataMember]
		[Display(Name = "쿠폰액")]
		public decimal CouponAmt { get; set; }

		[DataMember]
		[Display(Name = "배송비")]
		public decimal DeliveryFee { get; set; }

		[DataMember]
		[Display(Name = "공급가")]
		public decimal SupplyPrice { get; set; }

		[DataMember]
		[Display(Name = "공급금액")]
		public decimal SupplyAmt { get; set; }

		[DataMember]
		[Display(Name = "취소여부")]
		public string CancelYn { get; set; }

		[DataMember]
		[Display(Name = "취소일자")]
		public DateTime? CancelDate { get; set; }

		[DataMember]
		[Display(Name = "통화구분")]
		public string Currency { get; set; }

		[DataMember]
		[Display(Name = "로컬판매가")]
		public decimal LocalSalePrice { get; set; }

		[DataMember]
		[Display(Name = "브랜드ID")]
		public int BrandID { get; set; }

		[DataMember]
		[Display(Name = "브랜드명")]
		public string BrandName { get; set; }

		[DataMember]
		[Display(Name = "출고수량")]
		public int ShippedQty { get; set; }
	}
}
