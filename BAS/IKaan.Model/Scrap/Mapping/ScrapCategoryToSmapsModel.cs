using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Scrap.Mapping
{
	[DataContract]
	public class ScrapCategoryToSmapsModel : ModelBase
	{
		[DataMember]
		[Display(Name = "사이트ID")]
		public int? SiteID { get; set; }

		[DataMember]
		[Display(Name = "스크랩카테고리명")]
		public string ScrapCategoryName { get; set; }

		[DataMember]
		[Display(Name = "Smaps카테고리ID")]
		public int? SmapsCategoryID { get; set; }

		[DataMember]
		[Display(Name = "Smaps카테고리명")]
		public string SmapsCategoryName { get; set; }
	}
}
