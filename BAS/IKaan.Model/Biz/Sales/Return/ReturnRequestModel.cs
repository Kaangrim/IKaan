using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Biz.Sales.Return
{
	[DataContract]
	public class ReturnRequestModel : ModelBase
	{
		[DataMember]
		[Display(Name = "상점ID")]
		public int StoreID { get; set; }

		[DataMember]
		[Display(Name = "거래처ID")]
		public int CustomerID { get; set; }

		[DataMember]
		[Display(Name = "주문상세ID")]
		public int OrderItemID { get; set; }

		[DataMember]
		[Display(Name = "반품수량")]
		public int ReturnQty { get; set; }

		[DataMember]
		[Display(Name = "반품사유")]
		public string ReasonForReturn { get; set; }

		[DataMember]
		[Display(Name = "요청액션")]
		public string RequestedAction { get; set; }

		[DataMember]
		[Display(Name = "거래처설명")]
		public string CustomerComments { get; set; }

		[DataMember]
		[Display(Name = "스탭비고")]
		public string StaffNotes { get; set; }

		[DataMember]
		[Display(Name = "관리자비고")]
		public string AdminComments { get; set; }

		[DataMember]
		[Display(Name = "처리상태")]
		public string Status { get; set; }
	}
}
