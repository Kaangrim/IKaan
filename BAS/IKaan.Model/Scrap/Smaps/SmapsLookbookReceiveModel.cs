using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace IKaan.Model.Scrap.Smaps
{
	[DataContract]
	public class SmapsLookbookReceiveModel
	{
		[DataMember]
		[Display(Name = "UID")]
		public int? uid { get; set; }

		[DataMember]
		[Display(Name = "룩북제목")]
		public string title { get; set; }

		[DataMember]
		[Display(Name = "대행사UID")]
		public int agency_uid { get; set; }

		[DataMember]
		[Display(Name = "브랜드UID")]
		public int brand_uid { get; set; }
	}
}
