using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Base.Common
{
	[DataContract]
	public class FileUploadModel : ModelBase
	{
		[DataMember]
		[Display(Name = "업로드유형")]
		public string UploadType { get; set; }

		[DataMember]
		[Display(Name = "파일명")]
		public string FileName { get; set; }

		[DataMember]
		[Display(Name = "데이터")]
		public object UploadData { get; set; }
	}
}
