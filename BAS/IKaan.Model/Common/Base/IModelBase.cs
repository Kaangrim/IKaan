using System;

namespace IKaan.Model.Common.Base
{
	public interface IModelBase
	{
		string RowState { get; set; }
		string Checked { get; set; }
		int? RowNo { get; set; }
		int? ID { get; set; }
		DateTime? CreateDate { get; set; }
		int? CreateBy { get; set; }
		string CreateByName { get; set; }
		DateTime? UpdateDate { get; set; }
		int? UpdateBy { get; set; }
		string UpdateByName { get; set; }
	}
}
