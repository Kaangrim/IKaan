using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace IKaan.Model.Scrap.Api
{
	[DataContract]
	public class ApiResultModel
	{
		[DataMember]
		[Display(Name = "성공여부")]
		public string success { get; set; }

		[DataMember]
		[Display(Name = "UID")]
		public int? uid { get; set; }

		[DataMember]
		[Display(Name = "메시지")]
		public string msg { get; set; }

		[DataMember]
		[Display(Name = "상품정보")]
		public object product { get; set; }
	}
}
