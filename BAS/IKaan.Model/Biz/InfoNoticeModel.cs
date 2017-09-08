using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Biz
{
	[DataContract]
	public class InfoNoticeModel : ModelBase
	{
		[DataMember]
		[Display(Name = "정보고시명")]
		public string Name { get; set; }

		[DataMember]
		[Display(Name = "사용여부")]
		public string UseYn { get; set; }

		[DataMember]
		[Display(Name = "정보고시항목")]
		public IList<InfoNoticeItemModel> Items { get; set; }

		public InfoNoticeModel()
		{
			Items = new List<InfoNoticeItemModel>();
		}
	}
}
