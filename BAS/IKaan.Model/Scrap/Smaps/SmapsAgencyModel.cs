using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Scrap.Smaps
{
	[DataContract]
	public class SmapsAgencyModel : SmapsBaseModel
	{
		[DataMember]
		[Display(Name = "유형")]
		public string type { get; set; }

		[DataMember]
		[Display(Name = "등급")]
		public string grade { get; set; }

		[DataMember]
		[Display(Name = "대행사명")]
		public string name { get; set; }

		[DataMember]
		[Display(Name = "추천여부")]
		public string recommend { get; set; }

		[DataMember]
		[Display(Name = "이용기간 시작일")]
		public DateTime? sv_start_date { get; set; }

		[DataMember]
		[Display(Name = "이용기간 종료일")]
		public DateTime? sv_end_date { get; set; }

		[DataMember]
		[Display(Name = "주소")]
		public string cp_address { get; set; }

		[DataMember]
		[Display(Name = "대표자명")]
		public string president_name { get; set; }

		[DataMember]
		[Display(Name = "사업자번호")]
		public string cp_crn { get; set; }

		[DataMember]
		[Display(Name = "이메일")]
		public string cp_email { get; set; }

		[DataMember]
		[Display(Name = "홈페이지")]
		public string cp_homepage { get; set; }

		[DataMember]
		[Display(Name = "소개")]
		public string cp_intro { get; set; }

		[DataMember]
		[Display(Name = "연락처")]
		public string cp_tel { get; set; }

		[DataMember]
		[Display(Name = "결제담당부서")]
		public string ct_department { get; set; }

		[DataMember]
		[Display(Name = "결제담당자이메일")]
		public string ct_email { get; set; }

		[DataMember]
		[Display(Name = "결제담당자팩스")]
		public string ct_fax { get; set; }

		[DataMember]
		[Display(Name = "결제담당자휴대폰")]
		public string ct_hphone { get; set; }

		[DataMember]
		[Display(Name = "결제담당자명")]
		public string ct_name { get; set; }

		[DataMember]
		[Display(Name = "결제담당자직위")]
		public string ct_position { get; set; }

		[DataMember]
		[Display(Name = "결제담당자전화번호")]
		public string ct_tel { get; set; }

		[DataMember]
		[Display(Name = "별도협의사항")]
		public string consultation { get; set; }

		[DataMember]
		[Display(Name = "이용요금")]
		public decimal using_price { get; set; }

		[DataMember]
		[Display(Name = "이미지경로")]
		public string image { get; set; }

		[DataMember]
		[Display(Name = "이미지넓이")]
		public string image_width { get; set; }

		[DataMember]
		[Display(Name = "이미지높이")]
		public string image_height { get; set; }

		[DataMember]
		[Display(Name = "등급명")]
		public string grade_name { get; set; }

		[DataMember]
		[Display(Name = "유형명")]
		public string type_name { get; set; }
	}
}
