using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Biz
{
	[DataContract]
	public class CompanyBankAccountModel : ModelBase
	{
		[DataMember]
		[Display(Name = "회사ID")]
		public int? CompanyID { get; set; }

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

		public CompanyBankAccountModel()
		{
			BankAccount = new BankAccountModel();
		}
	}
}
