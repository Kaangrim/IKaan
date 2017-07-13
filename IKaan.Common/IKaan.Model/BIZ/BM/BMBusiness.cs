using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Base;

namespace IKaan.Model.BIZ.BM
{
	[DataContract]
	public class BMBusiness : ModelBase
	{
		[DataMember]
		[Display(Name = "상호")]
		public string BizName { get; set; }

		[DataMember]
		[Display(Name = "사업자등록번호")]
		public string RegNo { get; set; }

		[DataMember]
		[Display(Name = "법인번호")]
		public string CorpNo { get; set; }

		[DataMember]
		[Display(Name = "대표자명")]
		public string RepName { get; set; }

		[DataMember]
		[Display(Name = "업태")]
		public string BizType { get; set; }

		[DataMember]
		[Display(Name = "종목")]
		public string BizItem { get; set; }

		[DataMember]
		[Display(Name = "주소ID")]
		public int AddressId { get; set; }

		[DataMember]
		[Display(Name = "비고")]
		public string Remarks { get; set; }

		[DataMember]
		[Display(Name = "사용여부")]
		public string UseYn { get; set; }
	}
}
