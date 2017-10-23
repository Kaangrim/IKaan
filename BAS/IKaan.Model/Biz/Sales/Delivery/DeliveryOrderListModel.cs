using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Biz.Sales.Delivery
{
	[DataContract]
	public class DeliveryOrderListModel: ModelBase
	{
		[DataMember]
		[Display(Name = "배송요청일자")]
		public DateTime DeliveryOrderDate { get; set; }

		[DataMember]
		[Display(Name = "주문일자")]
		public DateTime OrderDate { get; set; }

		[DataMember]
		[Display(Name = "주문ID")]
		public int OrderID { get; set; }

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
		[Display(Name = "상태")]
		public string Status { get; set; }

		[DataMember]
		[Display(Name = "상태명")]
		public string StatusName { get; set; }

		[DataMember]
		[Display(Name = "설명")]
		public string Description { get; set; }

		[DataMember]
		[Display(Name = "주문자명")]
		public string BillingAddressName { get; set; }

		[DataMember]
		[Display(Name = "주문자이메일")]
		public string BillingAddressEmail { get; set; }

		[DataMember]
		[Display(Name = "주문자전화번호")]
		public string BillingAddressPhoneNo { get; set; }

		[DataMember]
		[Display(Name = "주문자핸드폰")]
		public string BillingAddressMobileNo { get; set; }

		[DataMember]
		[Display(Name = "주문자팩스번호")]
		public string BillingAddressFaxNo { get; set; }

		[DataMember]
		[Display(Name = "수취인명")]
		public string ShippingAddressName { get; set; }

		[DataMember]
		[Display(Name = "수취인이메일")]
		public string ShippingAddressEmail { get; set; }

		[DataMember]
		[Display(Name = "수취인전화번호")]
		public string ShippingAddressPhoneNo { get; set; }

		[DataMember]
		[Display(Name = "수취인핸드폰")]
		public string ShippingAddressMobileNo { get; set; }

		[DataMember]
		[Display(Name = "수취인팩스번호")]
		public string ShippingAddressFaxNo { get; set; }

		[DataMember]
		[Display(Name = "수취인 주소 우편번호")]
		public string ShippingAddressPostalCode { get; set; }

		[DataMember]
		[Display(Name = "수취인 주소 국가코드")]
		public string ShippingAddressCountry { get; set; }

		[DataMember]
		[Display(Name = "수취인 주소 시도")]
		public string ShippingAddressCity { get; set; }

		[DataMember]
		[Display(Name = "수취인 주소 시구군")]
		public string ShippingAddressStateProvince { get; set; }

		[DataMember]
		[Display(Name = "수취인 주소 주소1")]
		public string ShippingAddressAddressLine1 { get; set; }

		[DataMember]
		[Display(Name = "수취인 주소 주소2")]
		public string ShippingAddressAddressLine2 { get; set; }

		[DataMember]
		[Display(Name = "배송오더상세ID")]
		public int DeliveryOrderItemID { get; set; }

		[DataMember]
		[Display(Name = "배송오더상세번호")]
		public int DeliveryOrderItemNo { get; set; }

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
		[Display(Name = "아이템ID")]
		public int? ProductItemID { get; set; }

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
		[Display(Name = "배송오더시간")]
		public DateTime? DeliveryOrderTime { get; set; }

		[DataMember]
		[Display(Name = "배송오더상세상태")]
		public string DeliveryItemStatus { get; set; }

		[DataMember]
		[Display(Name = "브랜드ID")]
		public int BrandID { get; set; }

		[DataMember]
		[Display(Name = "브랜드명")]
		public string BrandName { get; set; }

		[DataMember]
		[Display(Name = "출고수량")]
		public int ShippedQty { get; set; }

		[DataMember]
		[Display(Name = "잔여수량")]
		public int RemainQty { get; set; }
	}
}
