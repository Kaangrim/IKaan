﻿using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Scrap.Common
{
	[DataContract]
	public class ScrapOptionModel
	{
		[DataMember]
		[Display(Name = "사이트ID")]
		public int SiteID { get; set; }

		[DataMember]
		[Display(Name = "카테고리ID")]
		public int CategoryID { get; set; }

		[DataMember]
		[Display(Name = "성별")]
		public string Gender { get; set; }

		[DataMember]
		[Display(Name = "옵션유형")]
		public string Type { get; set; }

		[DataMember]
		[Display(Name = "옵션명")]
		public string Name { get; set; }
	}
}
