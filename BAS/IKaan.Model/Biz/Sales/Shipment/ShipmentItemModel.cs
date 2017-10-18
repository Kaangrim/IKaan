using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Biz.Sales.Shipment
{
	[DataContract]
	public class ShipmentItemModel: ModelBase
	{
		[DataMember]
		[Display(Name = "출하ID")]
		public int? ShipmentID { get; set; }

		[DataMember]
		[Display(Name = "주문상세ID")]
		public int OrderItemID { get; set; }

		[DataMember]
		[Display(Name = "출고수량")]
		public int ShippedQty { get; set; }
	}
}
