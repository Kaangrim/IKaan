using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Scrap.Mapping
{
	[DataContract]
	public class ScrapSizeToSmapsModel : ModelBase
	{
		[DataMember]
		[Display(Name = "사이트ID")]
		public int? SiteID { get; set; }

		[DataMember]
		[Display(Name = "카테고리ID")]
		public int? CategoryID { get; set; }

		[DataMember]
		[Display(Name = "성별")]
		public string Gender { get; set; }

		[DataMember]
		[Display(Name = "스크랩사이즈ID")]
		public int? ScrapSizeID { get; set; }

		[DataMember]
		[Display(Name = "Smaps사이즈ID")]
		public int? SmapsSizeID { get; set; }

		[DataMember]
		[Display(Name = "카테고리명")]
		public string CategoryName { get; set; }

		[DataMember]
		[Display(Name = "성별명")]
		public string GenderName { get; set; }

		[DataMember]
		[Display(Name = "스크랩사이즈명")]
		public string ScrapSizeName { get; set; }

		[DataMember]
		[Display(Name = "Smaps사이즈명")]
		public string SmapsSizeName { get; set; }
	}
}
