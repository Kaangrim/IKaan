using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.IKBiz
{
	[DataContract]
	public class BusinessModel : ModelBase
	{
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
		[Display(Name = "대표자명")]
		public string RepName { get; set; }

		[DataMember]
		[Display(Name = "업태")]
		public string BizKind { get; set; }

		[DataMember]
		[Display(Name = "종목")]
		public string BizItem { get; set; }

		[DataMember]
		[Display(Name = "상태")]
		public string Status { get; set; }

		[DataMember]
		[Display(Name = "주소ID")]
		public int? AddressID { get; set; }

		[DataMember]
		[Display(Name = "전자세금계산서 전용 전자우편주소")]
		public string Email { get; set; }

		[DataMember]
		[Display(Name = "이미지경로")]
		public string ImageUrl { get; set; }

		[DataMember]
		[Display(Name = "사업자유형명")]
		public string BizTypeName { get; set; }

		[DataMember]
		[Display(Name = "상태명")]
		public string StatusName { get; set; }

		[DataMember]
		[Display(Name = "주소")]
		public AddressModel Address { get; set; }

		[DataMember]
		[Display(Name = "거래처")]
		public IList<CustomerBusinessModel> Customers { get; set; }

		public BusinessModel()
		{
			Address = new AddressModel();
			Customers = new List<CustomerBusinessModel>();
		}
	}
}
