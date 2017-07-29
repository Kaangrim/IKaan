using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Biz.Core.Forms;
using IKaan.Biz.Core.Helper;
using IKaan.Biz.Core.Resources;
using IKaan.Biz.Core.Variables;
using IKaan.Biz.Core.Was.Handler;
using IKaan.Model.UserModels;

namespace IKaan.Biz.View.Forms
{
	public partial class LoginForm : BaseForm
	{
		public LoginForm()
		{
			InitializeComponent();
			Initialize();

			btnOk.Click += delegate (object sender, EventArgs e) { doLogin(); };

			txtLoginId.GotFocus += delegate (object sender, EventArgs e)
			{
				SetStatusMessage("사용자ID를 입력하세요!!!");
			};
			txtLoginId.LostFocus += delegate (object sender, EventArgs e)
			{
				SetStatusMessage("Ready!!");
			};

			txtPassword.GotFocus += delegate (object sender, EventArgs e)
			{
				SetStatusMessage("비밀번호를 입력하세요!!!");
			};
			txtPassword.LostFocus += delegate (object sender, EventArgs e)
			{
				SetStatusMessage("Ready!!");
			};

			txtLoginId.KeyDown += delegate (object sender, KeyEventArgs e) { doTextKeyDown(sender, e); };
			txtPassword.KeyDown+= delegate (object sender, KeyEventArgs e) { doTextKeyDown(sender, e); };
		}

		private void doTextKeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if ((sender as TextEdit).Name == txtLoginId.Name)
				{
					txtPassword.Focus();
				}
				else if ((sender as TextEdit).Name == txtPassword.Name)
				{
					doLogin();
				}
			}
		}

		private void Initialize()
		{
			FormBorderStyle = FormBorderStyle.FixedDialog;
			StartPosition = FormStartPosition.CenterScreen;
			MaximizeBox = false;
			MinimizeBox = false;
			Icon = IconResource.logo;
			//this.BackColor = SkinUtils.FormBackColor;

			txtLoginId.EditValue = RegistryUtils.GetValue(ConstsVar.REGISTRY_LOGIN_INFO, "LoginId");
			txtPassword.EditValue = RegistryUtils.GetValue(ConstsVar.REGISTRY_LOGIN_INFO, "Password");

		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			txtLoginId.Focus();
		}

		private void SetStatusMessage(string msg)
		{
			barMessage.Caption = string.Format(" >>> {0}", msg);
		}

		private void doLogin()
		{
			try
			{
				if (txtLoginId.EditValue.ToStringNullToEmpty() == string.Empty)
				{
					MsgBox.Show("접속 아이디를 입력하세요!!!");
					txtLoginId.Focus();
					return;
				}

				if (txtPassword.EditValue.ToStringNullToEmpty() == string.Empty)
				{
					MsgBox.Show("비밀번호를 입력하세요!!!");
					txtPassword.Focus();
					return;
				}

				var data = WasHandler.GetData<UMLoginUser>("AUTH", "CheckLoginUser", null, new DataMap()
				{
					{ "LoginId", txtLoginId.EditValue },
					{ "Password", txtPassword.EditValue },
					{ "Version", CommonUtils.GetClickOnceVersion() },
					{ "MainSkin", GlobalVar.SkinInfo.MainSkin },
					{ "GridSkin", GlobalVar.SkinInfo.GridSkin },
					{ "IpAddress", CommonUtils.GetIp() },
					{ "MacAddress", CommonUtils.GetMacAddress() }
				});

				if (data == null)
					throw new Exception("로그인 사용자의 정보가 정확하지 않습니다.");

				GlobalVar.UserInfo.LoginId = data.LoginId;
				GlobalVar.UserInfo.UserId = data.UserId;
				GlobalVar.UserInfo.UserName = data.UserName;
				GlobalVar.Codes = data.Codes;

				if (chkRemember.Checked)
				{
					RegistryUtils.SetValue(ConstsVar.REGISTRY_LOGIN_INFO, "LoginId", txtLoginId.EditValue.ToStringNullToEmpty());
					RegistryUtils.SetValue(ConstsVar.REGISTRY_LOGIN_INFO, "Password", txtPassword.EditValue.ToStringNullToEmpty());
				}

				SetModifiedCount();
				Close();
			}
			catch (Exception ex)
			{
				MsgBox.Show(ex);
			}
		}
	}
}
