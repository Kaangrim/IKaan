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
		[Display(Name = "거래처, 브랜드")]
		public IList<LMCustomerBrand> CustomerBrand { get; set; }

		public LMBrand()
		{
			CustomerBrand = new List<LMCustomerBrand>();
		}
	}
}
