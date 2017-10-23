using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace IKaan.Model.Biz.Sales.Order
{
	[DataContract]
	public class OrderWorkModel
	{
		[DataMember]
		[Display(Name = "작업번호")]
		public int WorkNo { get; set; }

		[DataMember]
		[Display(Name = "작업명")]
		public string WorkName { get; set; }

		[DataMember]
		[Display(Name = "작업내용&결과")]
		public string WorkDescription { get; set; }
	}
}
