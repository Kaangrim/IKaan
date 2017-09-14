using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Scrap.Smaps
{
	[DataContract]
	public class SmapsLookbookModel : ModelBase
	{
		[DataMember]
		[Display(Name = "요청ID")]
		public int? RequestID { get; set; }

		[DataMember]
		[Display(Name = "UID")]
		public int? uid { get; set; }

		[DataMember]
		[Display(Name = "대행사UID")]
		public int agency_uid { get; set; }

		[DataMember]
		[Display(Name = "브랜드UID")]
		public int brand_uid { get; set; }

		[DataMember]
		[Display(Name = "룩북제목")]
		public string title { get; set; }

		[DataMember]
		[Display(Name = "촬영구분")]
		public string marketing { get; set; }

		[DataMember]
		[Display(Name = "활성화기간 시작일")]
		public DateTime active_date_start { get; set; }

		[DataMember]
		[Display(Name = "활성화기간 종료일")]
		public DateTime active_date_end { get; set; }

		[DataMember]
		[Display(Name = "공지")]
		public string notice { get; set; }
	}
}
