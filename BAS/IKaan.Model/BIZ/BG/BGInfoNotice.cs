using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Base;

namespace IKaan.Model.BIZ.BG
{
	[DataContract]
	public class BGInfoNotice : ModelBase
	{
		[DataMember]
		[Display(Name = "정보고시명")]
		public string InfoNoticeName { get; set; }

		[DataMember]
		[Display(Name = "사용여부")]
		public string UseYn { get; set; }

		[DataMember]
		[Display(Name = "정보고시항목")]
		public IList<BGInfoNoticeItem> Items { get; set; }

		public BGInfoNotice()
		{
			Items = new List<BGInfoNoticeItem>();
		}
	}
}
