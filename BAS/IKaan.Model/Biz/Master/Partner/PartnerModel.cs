using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Biz.Master.Common;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Biz.Master.Partner
{
	[DataContract]
	public class PartnerModel : ModelBase
	{
		[DataMember]
		[Display(Name = "파트너명")]
		public string Name { get; set; }

		[DataMember]
		[Display(Name = "파트너유형")]
		public string PartnerType { get; set; }

		[DataMember]
		[Display(Name = "설명")]
		public string Description { get; set; }

		[DataMember]
		[Display(Name = "사용여부")]
		public string UseYn { get; set; }

		[DataMember]
		[Display(Name = "파트너유형명")]
		public string PartnerTypeName { get; set; }

		[DataMember]
		[Display(Name = "사업자번호")]
		public string BizNo { get; set; }

		[DataMember]
		[Display(Name = "대표자명")]
		public string RepName { get; set; }

		[DataMember]
		[Display(Name = "사원명")]
		public string EmployeeName { get; set; }

		[DataMember]
		[Display(Name = "부서명")]
		public string DepartmentName { get; set; }

		[DataMember]
		[Display(Name = "현재사업자정보")]
		public BusinessModel CurrentBusiness { get; set; }

		[DataMember]
		[Display(Name = "주소")]
		public IList<PartnerAddressModel> Addresses { get; set; }

		[DataMember]
		[Display(Name = "은행계좌")]
		public IList<PartnerBankAccountModel> BankAccounts { get; set; }

		[DataMember]
		[Display(Name = "브랜드")]
		public IList<PartnerBrandModel> Brands { get; set; }

		[DataMember]
		[Display(Name = "사업자")]
		public IList<PartnerBusinessModel> Businesses { get; set; }

		[DataMember]
		[Display(Name = "채널")]
		public IList<PartnerChannelModel> Channels { get; set; }

		[DataMember]
		[Display(Name = "담당자")]
		public IList<PartnerContactModel> Contacts { get; set; }

		[DataMember]
		[Display(Name = "매니저")]
		public IList<PartnerManagerModel> Managers { get; set; }

		[DataMember]
		[Display(Name = "상점")]
		public IList<PartnerStoreModel> Stores { get; set; }

		public PartnerModel()
		{
			CurrentBusiness = new BusinessModel();
			Addresses = new List<PartnerAddressModel>();
			BankAccounts = new List<PartnerBankAccountModel>();
			Brands = new List<PartnerBrandModel>();
			Businesses = new List<PartnerBusinessModel>();
			Channels = new List<PartnerChannelModel>();
			Contacts = new List<PartnerContactModel>();
			Managers = new List<PartnerManagerModel>();
			Stores = new List<PartnerStoreModel>();
		}
	}
}
