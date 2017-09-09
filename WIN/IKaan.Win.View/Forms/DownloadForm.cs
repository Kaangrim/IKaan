﻿using System;
using System.Windows.Forms;
using IKaan.Base.Map;
using IKaan.Win.Core.Forms;
using IKaan.Win.Core.Helper;
using IKaan.Win.Core.Resources;
using IKaan.Win.Core.Utils;
using IKaan.Win.Core.Variables;
using IKaan.Win.Core.Was.Handler;
using IKaan.Model.Common.UserModels ;

namespace IKaan.Win.View.Forms
{
	public partial class DownloadForm : EditForm
	{
		public DownloadForm()
		{
			InitializeComponent();

			btnDownload.Click += delegate (object sender, System.EventArgs e) { doDownload(); };
		}

		protected override void InitButton()
		{
			VisibleToolbar = false;
			VisibleStatusbar = false;
		}

		protected override void InitControls()
		{
			SetFieldNames();

			lcItemDictionary.Text = "표준용어사전";
			lcItemMessage.Text = "표준메시지";
			lcItemCodes.Text = "공통코드";

			lcItemDictionary.AppearanceItemCaption.TextOptions.HAlignment =
				lcItemMessage.AppearanceItemCaption.TextOptions.HAlignment =
				lcItemCodes.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
		}

		private void doDownload()
		{			
			GetDictionary();
			GetMessage();
			GetCodes();

			SetMessage("다운로드를 완료하였습니다.");
			Close();
		}

		void GetDictionary()
		{
			try
			{
				SetMessage("용어사전을 다운로드 하는 중입니다...");
				prgDictionary.Properties.Maximum = 0;
				prgDictionary.EditValue = 0;
				Application.DoEvents();

				DataMap map = new DataMap()
				{
					{ "LanguageCode", GlobalVar.UserInfo.LanguageCode }
				};
				var list = WasHandler.GetList<UCodeValue>("AUTH", "GetDictionary", null, map);
				Application.DoEvents();

				if (list != null && list.Count > 0)
				{
					int count = 0;
					prgDictionary.Properties.Maximum = list.Count;
					Application.DoEvents();

					foreach (UCodeValue data in list)
					{
						count++;
						prgDictionary.EditValue = count;
						Application.DoEvents();

						DomainResource.Fields.SetValue(data.Code, data.Value);
					}
				}
				SetMessage("용어사전을 다운로드하였습니다.");
				Application.DoEvents();
			}
			catch(Exception ex)
			{
				MsgBox.Show(ex);
			}
		}

		void GetMessage()
		{
			try
			{
				SetMessage("표준메시지를 다운로드 하는 중입니다...");
				prgMessage.Properties.Maximum = 0;
				prgMessage.EditValue = 0;
				Application.DoEvents();

				DataMap map = new DataMap()
				{
					{ "LanguageCode", GlobalVar.UserInfo.LanguageCode }
				};
				var list = WasHandler.GetList<UCodeValue>("AUTH", "GetMessage", null, map);
				Application.DoEvents();

				if (list != null && list.Count > 0)
				{
					int count = 0;
					prgMessage.Properties.Maximum = list.Count;
					Application.DoEvents();
					foreach (UCodeValue data in list)
					{
						count++;
						prgMessage.EditValue = count;
						Application.DoEvents();

						DomainResource.Messages.SetValue(data.Code, data.Value);
					}
				}
				SetMessage("표준메시지를 다운로드하였습니다.");
				Application.DoEvents();
			}
			catch (Exception ex)
			{
				MsgBox.Show(ex);
			}
		}

		void GetCodes()
		{
			try
			{
				SetMessage("공통코드를 다운로드 하는 중입니다...");
				prgCodes.Properties.Maximum = 0;
				prgCodes.EditValue = 0;
				Application.DoEvents();

				var list = WasHandler.GetList<UCodeLookup>("AUTH", "GetCodes", null, null);
				Application.DoEvents();

				int count = (list == null) ? 0 : list.Count;
				prgCodes.Properties.Maximum = count;
				GlobalVar.Codes = list;
				prgCodes.EditValue = count;
				SetMessage("공통코드를 다운로드하였습니다.");
				Application.DoEvents();
			}
			catch (Exception ex)
			{
				MsgBox.Show(ex);
			}
		}
	}
}