using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Base;

namespace IKaan.Model.BIZ.BM
{
	public class BMCustomerBank : ModelBase
	{
		[DataMember]
		[Display(Name = "거래처ID")]
		public int? CustomerID { get; set; }

		[DataMember]
		[Display(Name = "은행명")]
		public string BankName { get; set; }

		[DataMember]
		[Display(Name = "계좌번호")]
		public string AccountNo { get; set; }

		[DataMember]
		[Display(Name = "예금주명")]
		public string Depositor { get; set; }

		[DataMember]
		[Display(Name = "거래처명")]
		public string CustomerName { get; set; }
	}
}
