using System.Collections.Generic;

namespace IKaan.Model.Base
{
	public class PagedList<T>
	{
		public IList<T> Content { get; set; }
		public int CurrentPage { get; set; }
		public int PageSize { get; set; }
		public int TotalRecords { get; set; }
	}
}
