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
		[Display(Name = "설명")]
		public string Description { get; set; }

		[DataMember]
		[Display(Name = "사용여부")]
		public string UseYn { get; set; }

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
