using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Biz
{
	[DataContract]
	public class CustomerBankAccountModel : ModelBase
	{
		[DataMember]
		[Display(Name = "거래처ID")]
		public int? CustomerID { get; set; }

		[DataMember]
		[Display(Name = "은행계좌ID")]
		public int? BankAccountID { get; set; }

		[DataMember]
		[Display(Name = "은행계좌유형")]
		public string BankAccountType { get; set; }

		[DataMember]
		[Display(Name = "설명")]
		public string Description { get; set; }

		[DataMember]
		[Display(Name = "은행계좌")]
		public BankAccountModel BankAccount { get; set; }

		public CustomerBankAccountModel()
		{
			BankAccount = new BankAccountModel();
		}
	}
}
