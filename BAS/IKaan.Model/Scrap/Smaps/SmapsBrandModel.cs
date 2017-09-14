﻿using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Scrap.Smaps
{
	[DataContract]
	public class SmapsBrandModel : ModelBase
	{
		[DataMember]
		[Display(Name = "요청ID")]
		public int? RequestID { get; set; }

		[DataMember]
		[Display(Name = "UID")]
		public int? uid { get; set; }

		[DataMember]
		[Display(Name = "브랜드명")]
		public string name { get; set; }

		[DataMember]
		[Display(Name = "매니저")]
		public string manager { get; set; }

		[DataMember]
		[Display(Name = "쇼룸담당자")]
		public string showroom { get; set; }

		[DataMember]
		[Display(Name = "대행사UID")]
		public int agency_uid { get; set; }

		[DataMember]
		[Display(Name = "캡션")]
		public string caption { get; set; }

		[DataMember]
		[Display(Name = "이미지경로")]
		public string image { get; set; }

		[DataMember]
		[Display(Name = "이미지Width")]
		public string image_width { get; set; }

		[DataMember]
		[Display(Name = "이미지Height")]
		public string image_height { get; set; }
	}
}