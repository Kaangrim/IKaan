﻿using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Biz.Master.Common;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Biz.Master.Company
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
		[Display(Name = "은행계좌명")]
		public string BankAccountName { get; set; }

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
		[Display(Name = "은행계좌이미지ID")]
		public int? ImageID { get; set; }

		[DataMember]
		[Display(Name = "이미지")]
		public ImageModel Image { get; set; }

		public CompanyBankAccountModel()
		{
			Image = new ImageModel();
		}
	}
}
