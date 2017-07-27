using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Base;

namespace IKaan.Model.BIZ.BM
{
	[DataContract]
	public class BMCustomer : ModelBase
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
		[Display(Name = "사용여부")]
		public string UseYn { get; set; }

		[DataMember]
		[Display(Name = "설명")]
		public string Description { get; set; }

		[DataMember]
		[Display(Name = "거래처, 은행 매핑")]
		public IList<BMCustomerBank> CustomerBank { get; set; }

		[DataMember]
		[Display(Name = "거래처, 브랜드 매핑")]
		public IList<BMCustomerBrand> CustomerBrand { get; set; }

		[DataMember]
		[Display(Name = "거래처, 채널 매핑")]
		public IList<BMCustomerChannel> CustomerChannel { get; set; }

		[DataMember]
		[Display(Name = "거래처, 주소 매핑")]
		public IList<BMCustomerAddress> CustomerAddress { get; set; }

		[DataMember]
		[Display(Name = "거래처, 사업자 매핑")]
		public IList<BMCustomerBusiness> CustomerBusiness { get; set; }

		public BMCustomer()
		{
			CustomerBank = new List<BMCustomerBank>();
			CustomerBrand = new List<BMCustomerBrand>();
			CustomerChannel = new List<BMCustomerChannel>();
			CustomerAddress = new List<BMCustomerAddress>();
			CustomerBusiness = new List<BMCustomerBusiness>();
		}
	}
}
