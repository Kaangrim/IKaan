﻿using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.IKBiz
{
	[DataContract]
	public class BrandImageModel : ModelBase
	{
		[DataMember]
		[Display(Name = "브랜드명")]
		public int? BrandID { get; set; }

		[DataMember]
		[Display(Name = "이미지구분")]
		public string ImageType { get; set; }

		[DataMember]
		[Display(Name = "이미지URL")]
		public string ImageUrl { get; set; }
	}
}