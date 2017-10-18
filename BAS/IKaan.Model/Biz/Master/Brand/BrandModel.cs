using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Biz.Master.Channel;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Biz.Master.Brand
{
	[DataContract]
	public class BrandModel : ModelBase
	{
		[DataMember]
		[Display(Name = "브랜드명")]
		public string Name { get; set; }

		[DataMember]
		[Display(Name = "코드")]
		public string Code { get; set; }

		[DataMember]
		[Display(Name = "영문명")]
		public string EngName { get; set; }

		[DataMember]
		[Display(Name = "URL")]
		public string Url { get; set; }

		[DataMember]
		[Display(Name = "카테고리")]
		public string Category { get; set; }

		[DataMember]
		[Display(Name = "스타일")]
		public string Style { get; set; }

		[DataMember]
		[Display(Name = "사용여부")]
		public string UseYn { get; set; }

		[DataMember]
		[Display(Name = "설명")]
		public string Description { get; set; }

		[DataMember]
		[Display(Name = "설명(RTF)")]
		public string DescriptionRTF { get; set; }

		[DataMember]
		[Display(Name = "브랜드카테고리명")]
		public string CategoryName { get; set; }

		[DataMember]
		[Display(Name = "브랜드스타일명")]
		public string StyleName { get; set; }

		[DataMember]
		[Display(Name = "대표이미지")]
		public string ImageUrl { get; set; }

		[DataMember]
		[Display(Name = "브랜드속성")]
		public IList<BrandAttributeModel> Attributes { get; set; }

		[DataMember]
		[Display(Name = "브랜드 이미지")]
		public IList<BrandImageModel> Images { get; set; }

		[DataMember]
		[Display(Name = "채널, 브랜드")]
		public IList<ChannelBrandModel> Channels { get; set; }

		public BrandModel()
		{
			Attributes = new List<BrandAttributeModel>();
			Images = new List<BrandImageModel>();
			Channels = new List<ChannelBrandModel>();
		}
	}
}
