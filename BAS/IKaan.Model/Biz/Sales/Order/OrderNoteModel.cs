using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Biz.Sales.Order
{
	[DataContract]
	public class OrderNoteModel : ModelBase
	{
		[DataMember]
		[Display(Name = "주문ID")]
		public int OrderID { get; set; }

		[DataMember]
		[Display(Name = "내용")]
		public string Note { get; set; }

		[DataMember]
		[Display(Name = "거래처표시여부")]
		public string DisplayToCustomerYn { get; set; }
	}
}
