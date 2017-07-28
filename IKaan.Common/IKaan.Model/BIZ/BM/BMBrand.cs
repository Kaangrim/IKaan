using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Base;

namespace IKaan.Model.BIZ.BM
{
	[DataContract]
	public class BMBrand : ModelBase
	{
		[DataMember]
		[Display(Name = "브랜드명")]
		public string BrandName { get; set; }

		[DataMember]
		[Display(Name = "영문명")]
		public string EngName { get; set; }

		[DataMember]
		[Display(Name = "약어명")]
		public string ShortName { get; set; }

		[DataMember]
		[Display(Name = "홈페이지주소")]
		public string HomePage { get; set; }

		[DataMember]
		[Display(Name = "브랜드카테고리")]
		public string BrandCategory { get; set; }

		[DataMember]
		[Display(Name = "브랜드스타일")]
		public string BrandStyle { get; set; }

		[DataMember]
		[Display(Name = "설명")]
		public string Description { get; set; }

		[DataMember]
		[Display(Name = "사용여부")]
		public string UseYn { get; set; }

		[DataMember]
		[Display(Name = "로고이미지경로")]
		public string ImageUrl { get; set; }

		[DataMember]
		[Display(Name = "브랜드카테고리명")]
		public string BrandCategoryName { get; set; }

		[DataMember]
		[Display(Name = "브랜드스타일명")]
		public string BrandStyleName { get; set; }

		[DataMember]
		[Display(Name = "브랜드 이미지")]
		public IList<BMBrandImage> BrandImage { get; set; }

		[DataMember]
		[Display(Name = "거래처, 브랜드")]
		public IList<BMCustomerBrand> BrandCustomer { get; set; }

		[DataMember]
		[Display(Name = "채널, 브랜드")]
		public IList<BMChannelBrand> BrandChannel { get; set; }

		public BMBrand()
		{
			BrandImage = new List<BMBrandImage>();
			BrandCustomer = new List<BMCustomerBrand>();
			BrandChannel = new List<BMChannelBrand>();
		}
	}
}
