﻿using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Biz.Master.Common;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Biz.Master.Company
{
	[DataContract]
	public class CompanyContactModel : ModelBase
	{
		[DataMember]
		[Display(Name = "회사ID")]
		public int? CompanyID { get; set; }

		[DataMember]
		[Display(Name = "담당자ID")]
		public int? ContactID { get; set; }

		[DataMember]
		[Display(Name = "포지션")]
		public string Position { get; set; }

		[DataMember]
		[Display(Name = "직무")]
		public string AssignedTask { get; set; }

		[DataMember]
		[Display(Name = "설명")]
		public string Description { get; set; }

		[DataMember]
		[Display(Name = "담당자명")]
		public string ContactName { get; set; }

		[DataMember]
		[Display(Name = "이메일")]
		public string Email { get; set; }

		[DataMember]
		[Display(Name = "전화번호")]
		public string PhoneNo { get; set; }

		[DataMember]
		[Display(Name = "휴대전화")]
		public string MobileNo { get; set; }

		[DataMember]
		[Display(Name = "팩스번호")]
		public string FaxNo { get; set; }

		[DataMember]
		[Display(Name = "담당자")]
		public ContactModel Contact { get; set; }
	}
}
