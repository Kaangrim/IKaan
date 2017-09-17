using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Scrap.Mapping
{
	[DataContract]
	public class ScrapColorToSmapsModel : ModelBase
	{
		[DataMember]
		[Display(Name = "사이트ID")]
		public int? SiteID { get; set; }

		[DataMember]
		[Display(Name = "스크랩색상ID")]
		public int? ScrapColorID { get; set; }

		[DataMember]
		[Display(Name = "Smaps색상ID")]
		public int? SmapsColorID { get; set; }

		[DataMember]
		[Display(Name = "스크랩색상명")]
		public string ScrapColorName { get; set; }

		[DataMember]
		[Display(Name = "Smaps색상명")]
		public string SmapsColorName { get; set; }
	}
}
