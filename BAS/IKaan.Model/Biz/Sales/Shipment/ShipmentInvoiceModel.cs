using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Biz.Sales.Shipment
{
	[DataContract]
	public class ShipmentInvoiceModel : ModelBase
	{
		[DataMember]
		[Display(Name = "출하ID")]
		public int? ShipmentID { get; set; }

		[DataMember]
		[Display(Name = "송장번호")]
		public string InvoiceNo { get; set; }

		[DataMember]
		[Display(Name = "택배사코드")]
		public string DeliveryCode { get; set; }

		[DataMember]
		[Display(Name = "설명")]
		public string Description { get; set; }
	}
}
