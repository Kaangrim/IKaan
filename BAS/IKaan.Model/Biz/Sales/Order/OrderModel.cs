using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Biz.Sales.Address;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Biz.Sales.Order
{
	[DataContract]
	public class OrderModel: ModelBase
	{
		[DataMember]
		[Display(Name = "상점ID")]
		public int StoreID { get; set; }

		[DataMember]
		[Display(Name = "주문일자")]
		public DateTime OrderDate { get; set; }

		[DataMember]
		[Display(Name = "주문시간")]
		public string OrderTime { get; set; }

		[DataMember]
		[Display(Name = "주문번호")]
		public string OrderNo { get; set; }

		[DataMember]
		[Display(Name = "채널ID")]
		public int? ChannelID { get; set; }

		[DataMember]
		[Display(Name = "채널ID")]
		public int? MemberID { get; set; }

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

		[DataMember]
		[Display(Name = "채널명")]
		public string ChannelName { get; set; }

		[DataMember]
		[Display(Name = "회원명")]
		public string MemberName { get; set; }

		[DataMember]
		[Display(Name = "주문자정보")]
		public BillingAddressModel BillingAddress { get; set; }

		[DataMember]
		[Display(Name = "수취인정보")]
		public ShippingAddressModel ShippingAddress { get; set; }

		[DataMember]
		[Display(Name = "상품상세")]
		public IList<OrderItemModel> Items { get; set; }

		[DataMember]
		[Display(Name = "비고")]
		public IList<OrderNoteModel> Notes { get; set; }

		public OrderModel()
		{
			BillingAddress = new BillingAddressModel();
			ShippingAddress = new ShippingAddressModel();
			Items = new List<OrderItemModel>();
			Notes = new List<OrderNoteModel>();
		}
	}
}
