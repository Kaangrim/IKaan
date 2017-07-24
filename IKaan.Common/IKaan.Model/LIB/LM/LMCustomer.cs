using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Base;

namespace IKaan.Model.LIB.LM
{
	public class LMCustomer : ModelBase
	{
		[DataMember]
		[Display(Name = "거래처유형")]
		public string CustomerType { get; set; }

		[DataMember]
		[Display(Name = "거래처명")]
		public string CustomerName { get; set; }

		[DataMember]
		[Display(Name = "영문명")]
		public string EngName { get; set; }

		[DataMember]
		[Display(Name = "사업자ID")]
		public int? BizID { get; set; }

		[DataMember]
		[Display(Name = "주소ID")]
		public int? AddressID { get; set; }

		[DataMember]
		[Display(Name = "거래처, 은행 매핑")]
		public IList<LMCustomerBank> CustomerBank { get; set; }

		[DataMember]
		[Display(Name = "거래처, 브랜드 매핑")]
		public IList<LMCustomerBrand> CustomerBrand { get; set; }

		[DataMember]
		[Display(Name = "거래처, 채널 매핑")]
		public IList<LMCustomerChannel> CustomerChannel { get; set; }

		public LMCustomer()
		{
			CustomerBank = new List<LMCustomerBank>();
			CustomerBrand = new List<LMCustomerBrand>();
			CustomerChannel = new List<LMCustomerChannel>();
		}
	}
}
