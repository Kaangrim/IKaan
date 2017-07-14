using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Base;

namespace IKaan.Model.LIB.LM
{
	public class LMCustomerBrand : ModelBase
	{
		[DataMember]
		[Display(Name = "브랜드ID")]
		public int BrandID { get; set; }
	}
}
