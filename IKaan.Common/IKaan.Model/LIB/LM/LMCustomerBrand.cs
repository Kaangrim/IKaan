using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Base;

namespace IKaan.Model.LIB.LM
{
	public class LMCustomerBrand : ModelBase
	{
		[DataMember]
		[Display(Name = "거래처ID")]
		public int? CustomerID { get; set; }

		[DataMember]
		[Display(Name = "브랜드ID")]
		public int? BrandID { get; set; }

		[DataMember]
		[Display(Name = "담당자ID")]
		public int? PersonID { get; set; }

		[DataMember]
		[Display(Name = "시작일")]
		public string StartDate { get; set; }

		[DataMember]
		[Display(Name = "종료일")]
		public string EndDate { get; set; }

		[DataMember]
		[Display(Name = "거래처명")]
		public string CustomerName { get; set; }

		[DataMember]
		[Display(Name = "브랜드명")]
		public string BrandName { get; set; }

		[DataMember]
		[Display(Name = "담당자명")]
		public string PersonName { get; set; }
	}
}
