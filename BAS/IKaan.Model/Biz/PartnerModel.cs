﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Biz
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
