using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Scrap.Smaps
{
	[DataContract]
	public class SmapsUserModel : ModelBase
	{
		[DataMember]
		[Display(Name = "요청ID")]
		public int? ApiRequestID { get; set; }

		[DataMember]
		[Display(Name = "API유형")]
		public string ApiType { get; set; }

		[DataMember]
		[Display(Name = "상태")]
		public string Status { get; set; }

		[DataMember]
		[Display(Name = "유형")]
		public DateTime? RequestDate { get; set; }

		[DataMember]
		[Display(Name = "UID")]
		public int? uid { get; set; }

		[DataMember]
		[Display(Name = "이메일")]
		public string email { get; set; }

		[DataMember]
		[Display(Name = "사용자명")]
		public string name { get; set; }

		[DataMember]
		[Display(Name = "사용자유형")]
		public string utype { get; set; }

		[DataMember]
		[Display(Name = "대행사UID")]
		public int agency_uid { get; set; }

		[DataMember]
		[Display(Name = "비밀번호")]
		public string passwd { get; set; }

		[DataMember]
		[Display(Name = "연락처1")]
		public string phone1 { get; set; }

		[DataMember]
		[Display(Name = "연락처2")]
		public string phone2 { get; set; }

		[DataMember]
		[Display(Name = "연락처3")]
		public string phone3 { get; set; }

		[DataMember]
		[Display(Name = "소개")]
		public string introduce { get; set; }

		[DataMember]
		[Display(Name = "직급")]
		public string rank { get; set; }

		[DataMember]
		[Display(Name = "이미지경로")]
		public string image { get; set; }

		[DataMember]
		[Display(Name = "이미지Width")]
		public string image_width { get; set; }

		[DataMember]
		[Display(Name = "이미지Height")]
		public string image_height { get; set; }

		[DataMember]
		[Display(Name = "대행사명")]
		public string agency_name { get; set; }
	}
}
