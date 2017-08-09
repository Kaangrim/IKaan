using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Base;

namespace IKaan.Model.SYS.AA
{
	[DataContract]
	public class AAUserPasswordHist: ModelBase
	{
		[DataMember]
		[Display(Name = "사용자ID")]
		public int UserID { get; set; }
	}
}
