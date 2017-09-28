using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace IKaan.Model.Scrap.Smaps
{
	[DataContract]
	public class SmapsOptionModel
	{
		[DataMember]
		[Display(Name = "카테고리ID")]
		public int category_uid { get; set; }

		[DataMember]
		[Display(Name = "성별")]
		public string sex { get; set; }

		[DataMember]
		[Display(Name = "옵션유형")]
		public string type { get; set; }

		[DataMember]
		[Display(Name = "옵션명")]
		public string name { get; set; }

		[DataMember]
		[Display(Name = "옵션코드")]
		public string code { get; set; }
	}
}
