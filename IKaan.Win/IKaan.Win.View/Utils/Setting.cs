using System;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using DevExpress.Utils;
using IKaan.Base.Logging;
using IKaan.Base.Utils;
using IKaan.Win.Core.Helper;
using IKaan.Win.Core.Utils;
using IKaan.Win.Core.Variables;

namespace IKaan.Win.View.Utils
{
	public class Setting
	{
		public static void Init()
		{
			try
			{
				Logger.Debug("Setting Start!!");
				
				//기본값 설정				
				GlobalVar.ServerInfo.DatabaseId = "REAL";
				GlobalVar.ServerInfo.ServerUrl = ConstsVar.SERVER_REAL;

				GlobalVar.UserInfo.LanguageCode = Thread.CurrentThread.CurrentCulture.ThreeLetterISOLanguageName.ToUpper();
				GlobalVar.SkinInfo.IsUseSkin = ConstsVar.USER_USE_SKIN;
				GlobalVar.SkinInfo.MainSkin = ConstsVar.USER_MAIN_SKIN;
				GlobalVar.SkinInfo.FormSkin = ConstsVar.USER_FORM_SKIN;
				GlobalVar.SkinInfo.FormSubSkin = ConstsVar.USER_FORM_SUB_SKIN;
				GlobalVar.SkinInfo.GridSkin = ConstsVar.USER_GRID_SKIN;
				GlobalVar.SkinInfo.IsGridEvenAndOdd = ConstsVar.USER_GRID_EVEN_AND_ODD;

				if (FontFamily.Families.Where(x => x.Name == ConstsVar.USER_FONT_NAME).Any())
				{
					GlobalVar.SkinInfo.UserFontName = ConstsVar.USER_FONT_NAME;
				}
				else
				{
					GlobalVar.SkinInfo.UserFontName = SystemFonts.DefaultFont.Name;
				}
				GlobalVar.SkinInfo.UserFontSize = ConstsVar.USER_FONT_SIZE;
				AppearanceObject.DefaultFont = new Font(GlobalVar.SkinInfo.UserFontName.ToStringNullToEmpty(), (float)GlobalVar.SkinInfo.UserFontSize);

				GlobalVar.UserInfo.CustomerName = "Kaangrim";
				GlobalVar.UserInfo.DepartmentName = "Brand Lab";
				GlobalVar.UserInfo.UserName = "Tester";
				GlobalVar.SkinInfo.IsVisibleToolbarName = true;
				GlobalVar.SkinInfo.MainFormState = FormWindowState.Maximized;


				//try
				//{
				//	DataTable data = (DataTable)DBTranHelper.GetData("Auth", "GetSettings", "Setting", new DataMap()).TranList[0].Data;
				//	if (data != null && data.Rows.Count > 0)
				//	{
				//		foreach (DataRow row in data.Rows)
				//		{
				//			GlobalVar.Settings.SetValue(row["CODE"].ToString(), row["VALUE"]);
				//		}
				//	}
				//}
				//catch (Exception ex)
				//{
				//	MsgBox.Show(ex);
				//}

				SplashUtils.ShowWait("리소스 데이터를 생성하는 중입니다... 잠시만...");
				DomainUtils.Init();
				try
				{
					DomainUtils.GetDictionary();
					DomainUtils.GetMessage();
				}
				catch (Exception ex)
				{
					MsgBox.Show(ex);
				}
				SplashUtils.CloseWait();
				Logger.Debug("Setting End!!");
			}
			catch (Exception ex)
			{
				MsgBox.Show(ex);
			}
		}
	}
}
