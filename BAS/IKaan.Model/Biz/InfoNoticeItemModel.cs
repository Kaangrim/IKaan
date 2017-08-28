using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Biz
{
	[DataContract]
	public class InfoNoticeItemModel : ModelBase
	{
		[DataMember]
		[Display(Name = "정보고시항목명")]
		public string ItemName { get; set; }

		[DataMember]
		[Display(Name = "정보고시ID")]
		public int? InfoNoticeID { get; set; }

		[DataMember]
		[Display(Name = "사용여부")]
		public string UseYn { get; set; }

		[DataMember]
		[Display(Name = "정렬순서")]
		public int SortOrder { get; set; }
	}
}
