using System.Windows.Forms;

namespace IKaan.Biz.Core.Model
{
	public class SkinInfo
	{
		public bool IsUseSkin { get; set; }
		public string MainSkin { get; set; }
		public string FormSkin { get; set; }
		public string GridSkin { get; set; }
		public bool IsGridEvenAndOdd { get; set; }

		public bool IsVisibleToolbarName { get; set; }

		public FormWindowState MainFormState { get; set; }

		public string UserFontName { get; set; }
		public float UserFontSize { get; set; }
	}
}
