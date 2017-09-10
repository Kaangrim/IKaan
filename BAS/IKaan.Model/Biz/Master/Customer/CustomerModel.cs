using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Biz.Master.Customer
{
	[DataContract]
	public class CustomerModel : ModelBase
	{
		[DataMember]
		[Display(Name = "거래처명")]
		public string Name { get; set; }

		[DataMember]
		[Display(Name = "거래처유형")]
		public string CustomerType { get; set; }

		[DataMember]
		[Display(Name = "설명")]
		public string Description { get; set; }

		[DataMember]
		[Display(Name = "사용여부")]
		public string UseYn { get; set; }

		[DataMember]
		[Display(Name = "거래처주소")]
		public IList<CustomerAddressModel> Addresses { get; set; }

		[DataMember]
		[Display(Name = "거래처은행계좌")]
		public IList<CustomerBankAccountModel> BankAccounts { get; set; }

		[DataMember]
		[Display(Name = "거래처브랜드")]
		public IList<CustomerBrandModel> Brands { get; set; }

		[DataMember]
		[Display(Name = "거래처사업자")]
		public IList<CustomerBusinessModel> Businesses { get; set; }

		[DataMember]
		[Display(Name = "거래처채널")]
		public IList<CustomerChannelModel> Channels { get; set; }

		[DataMember]
		[Display(Name = "거래처담당자")]
		public IList<CustomerContactModel> Contacts { get; set; }

		[DataMember]
		[Display(Name = "거래처매니저")]
		public IList<CustomerManagerModel> Managers { get; set; }

		[DataMember]
		[Display(Name = "거래처상점")]
		public IList<CustomerStoreModel> Stores { get; set; }

		public CustomerModel()
		{
			Addresses = new List<CustomerAddressModel>();
			BankAccounts = new List<CustomerBankAccountModel>();
			Brands = new List<CustomerBrandModel>();
			Businesses = new List<CustomerBusinessModel>();
			Channels = new List<CustomerChannelModel>();
			Contacts = new List<CustomerContactModel>();
			Managers = new List<CustomerManagerModel>();
			Stores = new List<CustomerStoreModel>();
		}
	}
}
