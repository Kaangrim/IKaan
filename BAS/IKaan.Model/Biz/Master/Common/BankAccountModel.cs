using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Biz.Common
{
	[DataContract]
	public class BankAccountModel : ModelBase
	{
		[DataMember]
		[Display(Name = "계좌명")]
		public string Name { get; set; }

		[DataMember]
		[Display(Name = "은행명")]
		public string BankName { get; set; }

		[DataMember]
		[Display(Name = "계좌번호")]
		public string AccountNo { get; set; }

		[DataMember]
		[Display(Name = "예금주명")]
		public string Depositor { get; set; }

		[DataMember]
		[Display(Name = "이미지ID")]
		public int? ImageID { get; set; }

		[DataMember]
		[Display(Name = "설명")]
		public string Description { get; set; }

		[DataMember]
		[Display(Name = "이미지")]
		public ImageModel Image { get; set; }
	}
}
