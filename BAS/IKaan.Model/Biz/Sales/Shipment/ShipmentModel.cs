using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Biz.Sales.Shipment
{
	[DataContract]
	public class ShipmentModel: ModelBase
	{
		[DataMember]
		[Display(Name = "주문ID")]
		public int OrderID { get; set; }

		[DataMember]
		[Display(Name = "트래킹번호")]
		public string TrackingNo { get; set; }

		[DataMember]
		[Display(Name = "총중량")]
		public decimal TotalWeight { get; set; }

		[DataMember]
		[Display(Name = "출고일")]
		public DateTime? ShippedDate { get; set; }

		[DataMember]
		[Display(Name = "배송일")]
		public DateTime? DeliveryDate { get; set; }

		[DataMember]
		[Display(Name = "상태")]
		public string Status { get; set; }

		[DataMember]
		[Display(Name = "설명")]
		public string Description { get; set; }

		[DataMember]
		[Display(Name = "상품상세")]
		public IList<ShipmentItemModel> Items { get; set; }

		[DataMember]
		[Display(Name = "송장내역")]
		public IList<ShipmentInvoiceModel> Invoices { get; set; }

		public ShipmentModel()
		{
			Items = new List<ShipmentItemModel>();
			Invoices = new List<ShipmentInvoiceModel>();
		}
	}
}
