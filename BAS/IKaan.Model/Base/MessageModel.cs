using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Base
{
	[DataContract]
	public class MessageModel: ModelBase
	{
		[DataMember]
		[Display(Name = "언어코드")]
		public string LanguageCode { get; set; }

		[DataMember]
		[Display(Name = "물리명")]
		public string PhysicalName { get; set; }

		[DataMember]
		[Display(Name = "논리명")]
		public string LogicalName { get; set; }

		[DataMember]
		[Display(Name = "설명")]
		public string Description { get; set; }
	}
}
