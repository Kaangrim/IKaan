using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace IKaan.Model.Biz.Sales.Order
{
	[DataContract]
	public class OrderStateModel
	{
		[DataMember]
		[Display(Name = "구분번호")]
		public int ItemNo { get; set; }

		[DataMember]
		[Display(Name = "구분명")]
		public string ItemName { get; set; }

		[DataMember]
		[Display(Name = "오늘")]
		public string ToDay { get; set; }

		[DataMember]
		[Display(Name = "이번달")]
		public string ToMonth { get; set; }
	}
}
