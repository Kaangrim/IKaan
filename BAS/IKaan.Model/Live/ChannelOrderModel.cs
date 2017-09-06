using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Live
{
	[DataContract]
	public class ChannelOrderModel: ModelBase
	{
		[DataMember]
		[Display(Name = "채널ID")]
		public int? ChannelID { get; set; }

		[DataMember]
		[Display(Name = "주문일자")]
		public DateTime? OrderDate { get; set; }

		[DataMember]
		[Display(Name = "주문번호")]
		public string OrderNo { get; set; }

		[DataMember]
		[Display(Name = "주문순번")]
		public string OrderSeq { get; set; }

		[DataMember]
		[Display(Name = "상품코드")]
		public string GoodsCode { get; set; }

		[DataMember]
		[Display(Name = "상품명")]
		public string GoodsName { get; set; }

		[DataMember]
		[Display(Name = "옵션1")]
		public string Option1 { get; set; }

		[DataMember]
		[Display(Name = "옵션2")]
		public string Option2 { get; set; }

		[DataMember]
		[Display(Name = "주문자")]
		public string Orderer { get; set; }

		[DataMember]
		[Display(Name = "주문자이메일")]
		public string OrdererEmail { get; set; }

		[DataMember]
		[Display(Name = "주문자모바일")]
		public string OrdererMobile { get; set; }

		[DataMember]
		[Display(Name = "주문자연락처")]
		public string OrdererTelNo { get; set; }

		[DataMember]
		[Display(Name = "수취인")]
		public string Recipient { get; set; }

		[DataMember]
		[Display(Name = "수취인모바일")]
		public string RecipientMobile { get; set; }

		[DataMember]
		[Display(Name = "수취인연락처")]
		public string RecipientTelNo { get; set; }

		[DataMember]
		[Display(Name = "우편번호")]
		public string PostalCode { get; set; }

		[DataMember]
		[Display(Name = "배송지주소")]
		public string RecipientAddress { get; set; }

		[DataMember]
		[Display(Name = "비고")]
		public string Description { get; set; }

		[DataMember]
		[Display(Name = "주문수량")]
		public int OrderQty { get; set; }
		
		[DataMember]
		[Display(Name = "공급단가")]
		public decimal SupplyPrice { get; set; }

		[DataMember]
		[Display(Name = "공급금액")]
		public decimal SupplyAmt { get; set; }

		[DataMember]
		[Display(Name = "판매단가")]
		public decimal SalePrice { get; set; }

		[DataMember]
		[Display(Name = "판매금액")]
		public decimal SaleAmt { get; set; }

		[DataMember]
		[Display(Name = "배송료")]
		public decimal DeliveryFee { get; set; }

		[DataMember]
		[Display(Name = "쿠폰금액")]
		public decimal CouponAmt { get; set; }

		[DataMember]
		[Display(Name = "딜번호")]
		public string DealNo { get; set; }

		[DataMember]
		[Display(Name = "브랜드ID")]
		public int? BrandID { get; set; }

		[DataMember]
		[Display(Name = "납기일")]
		public DateTime? DueDate { get; set; }

		[DataMember]
		[Display(Name = "사은품명")]
		public string GiftName { get; set; }

		[DataMember]
		[Display(Name = "파일업로드ID")]
		public int? FileUploadID { get; set; }

		[DataMember]
		[Display(Name = "채널명")]
		public string ChannelName { get; set; }

		[DataMember]
		[Display(Name = "브랜드명")]
		public string BrandName { get; set; }
	}
}
