using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Biz.Master.Common;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Biz.Master.Company
{
	[DataContract]
	public class CompanyModel : ModelBase
	{
		[DataMember]
		[Display(Name = "회사명")]
		public string Name { get; set; }

		[DataMember]
		[Display(Name = "사용여부")]
		public string UseYn { get; set; }

		[DataMember]
		[Display(Name = "설명")]
		public string Description { get; set; }

		[DataMember]
		[Display(Name = "상호")]
		public string BizName { get; set; }

		[DataMember]
		[Display(Name = "사업자번호")]
		public string BizNo { get; set; }

		[DataMember]
		[Display(Name = "대표자명")]
		public string RepName { get; set; }

		[DataMember]
		[Display(Name = "현재사업자정보")]
		public BusinessModel CurrentBusiness { get; set; }

		[DataMember]
		[Display(Name = "주소정보")]
		public IList<CompanyAddressModel> Addresses { get; set; }

		[DataMember]
		[Display(Name = "계좌정보")]
		public IList<CompanyBankAccountModel> BankAccounts { get; set; }

		[DataMember]
		[Display(Name = "사업자정보")]
		public IList<CompanyBusinessModel> Businesses { get; set; }

		[DataMember]
		[Display(Name = "담당자정보")]
		public IList<CompanyContactModel> Contacts { get; set; }

		[DataMember]
		[Display(Name = "상점정보")]
		public IList<CompanyStoreModel> Stores { get; set; }

		public CompanyModel()
		{
			CurrentBusiness = new BusinessModel();
			Addresses = new List<CompanyAddressModel>();
			BankAccounts = new List<CompanyBankAccountModel>();
			Businesses = new List<CompanyBusinessModel>();
			Contacts = new List<CompanyContactModel>();
			Stores = new List<CompanyStoreModel>();
		}
	}
}
