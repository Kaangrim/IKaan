using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Scrap.Common
{
	[DataContract]
	public class ScrapSizeModel : ModelBase
	{
		[DataMember]
		[Display(Name = "사이트ID")]
		public int SiteID { get; set; }

		[DataMember]
		[Display(Name = "카테고리ID")]
		public int CategoryID { get; set; }

		[DataMember]
		[Display(Name = "성별")]
		public string Gender { get; set; }

		[DataMember]
		[Display(Name = "사이즈명")]
		public string Name { get; set; }

		[DataMember]
		[Display(Name = "설명")]
		public string Description { get; set; }

		[DataMember]
		[Display(Name = "카테고리명")]
		public string CategoryName { get; set; }

		[DataMember]
		[Display(Name = "성별명")]
		public string GenderName { get; set; }
	}
}
