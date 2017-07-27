using System.Windows.Forms;
using IKaan.Biz.Core.Model;

namespace IKaan.Biz.Core.PostCode
{
	public static class SearchPostCode
	{
		public static PostalCode Find()
		{
			using (SearchPostCodeForm form = new SearchPostCodeForm())
			{
				form.Text = "우편번호검색(다음)";
				if (form.ShowDialog() == DialogResult.OK)
				{
					return form.ReturnData;
				}
				else
					return null;
			}
		}
	}
}
