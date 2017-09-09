using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Base.Common
{
	[DataContract]
	public class HolidayModel : ModelBase
	{
		[DataMember]
		[Display(Name = "휴일일자")]
		public DateTime HolidayDate { get; set; }

		[DataMember]
		[Display(Name = "설명")]
		public string Description { get; set; } 
	}
}
