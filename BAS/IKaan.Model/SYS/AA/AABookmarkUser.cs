using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace IKaan.Model.SYS.AA
{
	[DataContract]
	public class AABookmarkUser
	{
		[DataMember]
		[Display(Name = "Row번호")]
		public int RowNo { get; set; }

		[DataMember]
		[Display(Name = "사용자ID")]
		public int UserID { get; set; }

		[DataMember]
		[Display(Name = "사용자ID")]
		public string UserName { get; set; }

		[DataMember]
		[Display(Name = "북마크수")]
		public int BookmarkCount { get; set; }
	}
}
