﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Biz.Master.Partner
{
	[DataContract]
	public class PartnerBrandModel : ModelBase
	{
		[DataMember]
		[Display(Name = "파트너ID")]
		public int? PartnerID { get; set; }

		[DataMember]
		[Display(Name = "브랜드ID")]
		public int? BrandID { get; set; }

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
		[Display(Name = "브랜드명")]
		public string BrandName { get; set; }
	}
}
