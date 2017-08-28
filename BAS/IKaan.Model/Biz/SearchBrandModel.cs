using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Biz
{
	[DataContract]
	public class SearchBrandModel : ModelBase
	{
		[DataMember]
		[Display(Name = "브랜드명")]
		public string BrandName { get; set; }

		[DataMember]
		[Display(Name = "채널적합도")]
		public string ChannelFitness { get; set; }

		[DataMember]
		[Display(Name = "홈페이지")]
		public string HomePage { get; set; }

		[DataMember]
		[Display(Name = "Style Or SKU")]
		public string StyleOrSku { get; set; }

		[DataMember]
		[Display(Name = "이메일")]
		public string Email { get; set; }

		[DataMember]
		[Display(Name = "연락처")]
		public string Phone { get; set; }

		[DataMember]
		[Display(Name = "주요제품")]
		public string MainGoods { get; set; }

		[DataMember]
		[Display(Name = "카테고리")]
		public string Category { get; set; }

		[DataMember]
		[Display(Name = "스타일")]
		public string Style { get; set; }

		[DataMember]
		[Display(Name = "가격대")]
		public string Price { get; set; }

		[DataMember]
		[Display(Name = "설명")]
		public string Description { get; set; }

		[DataMember]
		[Display(Name = "카테고리분류")]
		public string TopCategory { get; set; }

		[DataMember]
		[Display(Name = "브랜드대표이미지")]
		public string BrandMainUrl { get; set; }

		[DataMember]
		[Display(Name = "브랜드로고이미지")]
		public string BrandLogoUrl { get; set; }

		[DataMember]
		[Display(Name = "영업활동")]
		public IList<SearchBrandActivityModel> Activities { get; set; }

		public SearchBrandModel()
		{
			Activities = new List<SearchBrandActivityModel>();
		}
	}
}
