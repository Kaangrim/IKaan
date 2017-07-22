using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Base;

namespace IKaan.Model.LIB.LM
{
	public class LMBrand : ModelBase
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
		public IList<LMBrandImage> BrandImage { get; set; }

		[DataMember]
		[Display(Name = "거래처, 브랜드")]
		public IList<LMCustomerBrand> BrandCustomer { get; set; }

		[DataMember]
		[Display(Name = "채널, 브랜드")]
		public IList<LMChannelBrand> BrandChannel { get; set; }

		public LMBrand()
		{
			BrandImage = new List<LMBrandImage>();
			BrandCustomer = new List<LMCustomerBrand>();
			BrandChannel = new List<LMChannelBrand>();
		}
	}
}
