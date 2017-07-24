using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.UserSkins;
using DevExpress.Utils;
using Ikaan.Biz.View.Utils;
using IKaan.Base.Logging;
using IKaan.Base.Utils;
using IKaan.Biz.Core.Helper;
using IKaan.Biz.Core.Variables;
using IKaan.Biz.View.Forms;

namespace IKaan.Biz
{
	static class Program
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

			BonusSkins.Register();
			SkinManager.EnableFormSkins();
			UserLookAndFeel.Default.SetSkinStyle(ConstsVar.USER_MAIN_SKIN);
			UserLookAndFeel.Default.UseDefaultLookAndFeel = true;
			UserLookAndFeel.Default.UseWindowsXPTheme = false;
			AppearanceObject.DefaultFont = SystemFonts.DefaultFont;

			Logger.Debug("Application Start!!");

			try
			{
				Setting.Init();

				if (GlobalVar.SkinInfo.MainSkin.IsNullOrEmpty() == false)
				{
					UserLookAndFeel.Default.Style = LookAndFeelStyle.Skin;
					UserLookAndFeel.Default.UseDefaultLookAndFeel = true;
					if (GlobalVar.SkinInfo.MainSkin.ToStringNullToEmpty() != ConstsVar.USER_MAIN_SKIN)
					{
						UserLookAndFeel.Default.SetSkinStyle(GlobalVar.SkinInfo.MainSkin.ToStringNullToEmpty());
					}
				}
				else
				{
					UserLookAndFeel.Default.UseDefaultLookAndFeel = false;
				}

				if (GlobalVar.SkinInfo.UserFontName.ToStringNullToEmpty() != ConstsVar.USER_FONT_NAME ||
					Convert.ToSingle(GlobalVar.SkinInfo.UserFontSize) != ConstsVar.USER_FONT_SIZE)
				{
					AppearanceObject.DefaultFont = new Font(GlobalVar.SkinInfo.UserFontName.ToStringNullToEmpty(), 
																Convert.ToSingle(GlobalVar.SkinInfo.UserFontSize));
				}
			}
			catch (Exception ex)
			{
				MsgBox.Show(ex);
				Application.ExitThread();
				Environment.Exit(0);
			}

			try
			{
				using (var f = new LoginForm()
				{
					Name = "LoginForm",
					Text = "Sign In"
				})
				{
					if (f.ShowDialog() != DialogResult.OK)
					{
						Logger.Debug("Application Exit!!");
						Application.ExitThread();
						Environment.Exit(0);
					}
				}
			}
			catch (Exception ex)
			{
				MsgBox.Show(ex);
				Application.ExitThread();
				Environment.Exit(0);
			}

			try
			{
				Application.Run(new MainForm());
			}
			catch (Exception ex)
			{
				MsgBox.Show(ex);
				Application.ExitThread();
				Environment.Exit(0);
			}

			Logger.Debug("Application Close!!");
		}
    }
}
