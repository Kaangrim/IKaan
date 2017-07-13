using System;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Biz.Core.Forms;
using IKaan.Biz.Core.Helper;
using IKaan.Biz.Core.Utils;
using IKaan.Biz.Core.Variables;
using IKaan.Biz.Core.Was.Handler;

namespace IKaan.Biz.View.Forms
{
	public partial class PasswordForm : BaseForm
	{
		public PasswordForm()
		{
			InitializeComponent();
			Init();

			btnConfirm.Click += delegate (object sender, System.EventArgs e)
			{
				doConfirm();
			};
		}

		void Init()
		{
			this.BackColor = SkinUtils.FormBackColor;

			lcItemPwd1.Text = "현재비밀번호:";
			lcItemPwd2.Text = "변경비밀번호:";
			lcItemPwd3.Text = "비밀번호확인:";

			lcItemPwd1.AppearanceItemCaption.TextOptions.HAlignment =
				lcItemPwd2.AppearanceItemCaption.TextOptions.HAlignment =
				lcItemPwd3.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
		}

		void doConfirm()
		{
			if (txtCurPwd.EditValue.IsNullOrEmpty())
			{
				MsgBox.Show("현재 비밀번호를 입력하세요!!!");
				txtCurPwd.Focus();
				return;
			}

			if (txtChgPwd.EditValue.IsNullOrEmpty())
			{
				MsgBox.Show("변경할 비밀번호를 입력하세요!!!");
				txtCurPwd.Focus();
				return;
			}

			if (txtChkPwd.EditValue.IsNullOrEmpty())
			{
				MsgBox.Show("변경할 비밀번호를 비밀번호 확인란에 한번 더 입력하세요!!!");
				txtCurPwd.Focus();
				return;
			}

			if (txtChgPwd.EditValue.ToStringNullToEmpty() != txtChkPwd.EditValue.ToStringNullToEmpty())
			{
				MsgBox.Show("변경할 비밀번호와 비밀번호 확인이 일치해야 합니다.");
				txtChgPwd.Focus();
				return;
			}

			if (txtCurPwd.EditValue.ToStringNullToEmpty() == txtChgPwd.EditValue.ToStringNullToEmpty())
			{
				MsgBox.Show("기존 비밀번호와 변경할 비밀번호가 일치합니다. 다시 입력하세요!!!");
				txtChgPwd.Focus();
				return;
			}

			try
			{
				using (var ret = WasHandler.Execute<DataMap>("AUTH", "ChangePassword", null, new DataMap()
				{
					{ "LoginId", GlobalVar.UserInfo.LoginId },
					{ "Password", txtCurPwd.EditValue },
					{ "ChangePassword", txtChgPwd.EditValue }
				}, null))
				{

					if (ret.Error.Number != 0)
						throw new Exception(ret.Error.Message);

					MsgBox.Show("변경하였습니다.");
					Close();
				}
			}
			catch(Exception ex)
			{
				MsgBox.Show(ex);
			}
		}
	}
}
