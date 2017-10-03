using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Biz.Master.Brand
{
	[DataContract]
	public class BrandAttributeModel : ModelBase
	{
		[DataMember]
		[Display(Name = "브랜드ID")]
		public int? BrandID { get; set; }

		[DataMember]
		[Display(Name = "속성유형ID")]
		public int AttributeTypeID { get; set; }

		[DataMember]
		[Display(Name = "속성ID")]
		public int AttributeID { get; set; }

		[DataMember]
		[Display(Name = "속성값")]
		public string AttributeValue { get; set; }

		[DataMember]
		[Display(Name = "속성유형명")]
		public string AttributeTypeName { get; set; }

		[DataMember]
		[Display(Name = "속성명")]
		public string AttributeName { get; set; }
	}
}
