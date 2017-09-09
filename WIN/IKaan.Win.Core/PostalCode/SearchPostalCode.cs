using System.Windows.Forms;
using IKaan.Win.Core.Model;

namespace IKaan.Win.Core.PostalCode
{
	public static class SearchPostalCode
	{
		public static PostalCodeModel Find()
		{
			using (var form = new SearchPostalCodeForm())
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
