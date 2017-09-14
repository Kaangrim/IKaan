﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Biz.Master.Company
{
	[DataContract]
	public class CompanyStoreModel : ModelBase
	{
		[DataMember]
		[Display(Name = "회사ID")]
		public int? CompanyID { get; set; }

		[DataMember]
		[Display(Name = "상점ID")]
		public int? StoreID { get; set; }

		[DataMember]
		[Display(Name = "시작일")]
		public DateTime? StartDate { get; set; }

		[DataMember]
		[Display(Name = "종료일")]
		public DateTime? EndDate { get; set; }

		[DataMember]
		[Display(Name = "설명")]
		public string Description { get; set; }

		[DataMember]
		[Display(Name = "회사명")]
		public string CompanyName { get; set; }

		[DataMember]
		[Display(Name = "상점명")]
		public string StoreName { get; set; }
	}
}