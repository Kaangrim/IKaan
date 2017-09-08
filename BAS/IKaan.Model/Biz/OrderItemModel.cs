using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Biz
{
	[DataContract]
	public class OrderItemModel : ModelBase
	{
		[DataMember]
		[Display(Name = "주문ID")]
		public int OrderID { get; set; }

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
		[Display(Name = "주문수량")]
		public int OrderQty { get; set; }

		[DataMember]
		[Display(Name = "판매가")]
		public decimal SalePrice { get; set; }

		[DataMember]
		[Display(Name = "주문액")]
		public decimal OrderAmt { get; set; }

		[DataMember]
		[Display(Name = "할인액")]
		public decimal DiscountAmt { get; set; }

		[DataMember]
		[Display(Name = "쿠폰액")]
		public decimal CouponAmt { get; set; }

		[DataMember]
		[Display(Name = "배송료")]
		public decimal DeliveryFee { get; set; }

		[DataMember]
		[Display(Name = "공급단가")]
		public decimal SupplyPrice { get; set; }

		[DataMember]
		[Display(Name = "공급액")]
		public decimal SupplyAmt { get; set; }

		[DataMember]
		[Display(Name = "취소여부")]
		public string CancelYn { get; set; }

		[DataMember]
		[Display(Name = "취소일자")]
		public DateTime? CancelDate { get; set; }

		[DataMember]
		[Display(Name = "채널주문순번")]
		public string ChannelOrderSeq { get; set; }
	}
}
