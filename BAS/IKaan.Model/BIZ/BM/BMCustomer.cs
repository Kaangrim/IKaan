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
		[Display(Name = "사업자유형")]
		public string BizType { get; set; }

		[DataMember]
		[Display(Name = "사업자번호")]
		public string BizNo { get; set; }

		[DataMember]
		[Display(Name = "상호")]
		public string BizName { get; set; }

		[DataMember]
		[Display(Name = "대표자")]
		public string RepName { get; set; }

		[DataMember]
		[Display(Name = "업태")]
		public string BizKind { get; set; }

		[DataMember]
		[Display(Name = "종목")]
		public string BizItem { get; set; }

		[DataMember]
		[Display(Name = "주소1")]
		public string AddressLine1 { get; set; }

		[DataMember]
		[Display(Name = "주소2")]
		public string AddressLine2 { get; set; }

		[DataMember]
		[Display(Name = "거래처유형명")]
		public string CustomerTypeName { get; set; }

		[DataMember]
		[Display(Name = "거래처, 은행 매핑")]
		public IList<BMCustomerBank> BankList { get; set; }

		[DataMember]
		[Display(Name = "거래처, 브랜드 매핑")]
		public IList<BMCustomerBrand> BrandList { get; set; }

		[DataMember]
		[Display(Name = "거래처, 채널 매핑")]
		public IList<BMCustomerChannel> ChannelList { get; set; }

		[DataMember]
		[Display(Name = "거래처, 주소 매핑")]
		public IList<BMCustomerAddress> AddressList { get; set; }

		[DataMember]
		[Display(Name = "거래처, 사업자 매핑")]
		public IList<BMCustomerBusiness> BusinessList { get; set; }

		public BMCustomer()
		{
			BankList = new List<BMCustomerBank>();
			BrandList = new List<BMCustomerBrand>();
			ChannelList = new List<BMCustomerChannel>();
			AddressList = new List<BMCustomerAddress>();
			BusinessList = new List<BMCustomerBusiness>();
		}
	}
}
