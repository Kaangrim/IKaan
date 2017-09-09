using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Base.Authority
{
	[DataContract]
	public class UserPasswordHistModel: ModelBase
	{
		[DataMember]
		[Display(Name = "사용자ID")]
		public int UserID { get; set; }
	}
}
