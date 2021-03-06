﻿using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Scrap.Common
{
	[DataContract]
	public class ScrapCategoryModel : ModelBase
	{
		[DataMember]
		[Display(Name = "사이트ID")]
		public int SiteID { get; set; }

		[DataMember]
		[Display(Name = "카테고리명")]
		public string Name { get; set; }

		[DataMember]
		[Display(Name = "설명")]
		public string Description { get; set; }
	}
}
