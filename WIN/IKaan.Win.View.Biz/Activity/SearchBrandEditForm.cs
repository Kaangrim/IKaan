using System;
using System.Collections.Generic;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraTab.ViewInfo;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Model.IKBiz;
using IKaan.Win.Core.Controls.Grid;
using IKaan.Win.Core.Enum;
using IKaan.Win.Core.Forms;
using IKaan.Win.Core.Handler;
using IKaan.Win.Core.Model;
using IKaan.Win.Core.Utils;
using IKaan.Win.Core.Variables;
using IKaan.Win.Core.Was.Handler;

namespace IKaan.Win.View.Biz.Activity
{
	public partial class SearchBrandEditForm : EditForm
	{
		public SearchBrandEditForm()
		{
			InitializeComponent();

			txtBrandLogoUrl.ButtonClick += delegate (object sender, ButtonPressedEventArgs e)
			{
				try
				{
					if (e.Button.Kind == ButtonPredefines.Ellipsis)
					{
						var info = DialogUtils.OpenImageFile();
						if (info != null)
						{
							picBrandLogo.LoadAsync(info.FullName);
							txtBrandLogoUrl.EditValue = info.FullName;							
							txtBrandLogoUrl.Tag = true;
						}
					}
					else if (e.Button.Kind == ButtonPredefines.Delete)
					{
						FTPHandler.DeleteFile(txtBrandLogoUrl.Text);
						picBrandLogo.EditValue = null;
						txtBrandLogoUrl.EditValue = null;
						txtBrandLogoUrl.Tag = null;
						if (txtID.EditValue.IsNullOrEmpty() == false)
						{
							var value = DataSave();
							DetailDataLoad(value);
						}
					}
				}
				catch(Exception ex)
				{
					ShowErrBox(ex);
				}
			};

			txtBrandMainUrl.ButtonClick += delegate (object sender, ButtonPressedEventArgs e)
			 {
				 try
				 {
					 if (e.Button.Kind == ButtonPredefines.Ellipsis)
					 {
						 var info = DialogUtils.OpenImageFile();
						 if (info != null)
						 {
							 picBrandMain.LoadAsync(info.FullName);
							 txtBrandMainUrl.EditValue = info.FullName;
							 txtBrandMainUrl.Tag = true;
						 }
					 }
					 else if (e.Button.Kind == ButtonPredefines.Delete)
					 {
						 FTPHandler.DeleteFile(txtBrandMainUrl.Text);
						 picBrandMain.EditValue = null;
						 txtBrandMainUrl.EditValue = null;
						 txtBrandMainUrl.Tag = null;
						 if (txtID.EditValue.IsNullOrEmpty() == false)
						 {
							 var value = DataSave();
							 DetailDataLoad(value);
						 }
					 }
				 }
				 catch (Exception ex)
				 {
					 ShowErrBox(ex);
				 }
			 };

			lcTab.SelectedPageChanged += (object sender, LayoutTabPageChangedEventArgs e) =>
			{
				if (e.Page.Name == lcTabGroupActivities.Name)
				{
					if (txtID.EditValue.IsNullOrEmpty() == false)
						lcTab.CustomHeaderButtons[0].Visible = true;
					else
						lcTab.CustomHeaderButtons[0].Visible = false;
				}
				else
				{
					lcTab.CustomHeaderButtons[0].Visible = false;
				}
			};
			lcTab.CustomHeaderButtonClick += (object sender, CustomHeaderButtonEventArgs e) =>
			{
				try
				{
					if (lcTab.SelectedTabPage.Name == lcTabGroupActivities.Name)
					{
						ShowEdit(null);
					}
					//MailHandler.Send("nicenomm@naver.com", "Test", "Test");
					//ShowMsgBox("전송하였습니다.");
				}
				catch(Exception ex)
				{
					ShowErrBox(ex);
				}
			};
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			txtFindText.Focus();
		}

		protected override void InitButton()
		{
			base.InitButton();
			SetToolbarButtons(new ToolbarButtons() { New = true, Refresh = true, Save = true, SaveAndNew = true });
		}
		protected override void InitControls()
		{
			base.InitControls();

			SetFieldNames();

			txtID.SetEnable(false);
			txtCreateDate.SetEnable(false);
			txtCreateByName.SetEnable(false);
			txtUpdateDate.SetEnable(false);
			txtUpdateByName.SetEnable(false);

			lcTab.SelectedTabPageIndex = 0;

			InitGrid();
		}
		
		void InitGrid()
		{
			#region List
			gridList.Init();
			gridList.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "BrandName", Width = 200 },
				new XGridColumn() { FieldName = "CreateDate" },
				new XGridColumn() { FieldName = "CreateByName" },
				new XGridColumn() { FieldName = "UpdateDate" },
				new XGridColumn() { FieldName = "UpdateByName" }
			);
			gridList.ColumnFix("RowNo");

			gridList.RowCellClick += delegate (object sender, RowCellClickEventArgs e)
			{
				if (e.RowHandle < 0)
					return;

				try
				{
					if (e.Button == System.Windows.Forms.MouseButtons.Left && e.Clicks == 1)
					{
						GridView view = sender as GridView;
						DetailDataLoad(view.GetRowCellValue(e.RowHandle, "ID"));
					}
				}
				catch(Exception ex)
				{
					ShowErrBox(ex);
				}
			};
			#endregion

			#region Activities
			gridActivities.Init();
			gridActivities.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "SearchBrandID", Visible = false },
				new XGridColumn() { FieldName = "ActivityDate" },
				new XGridColumn() { FieldName = "Description", Width = 300 },
				new XGridColumn() { FieldName = "CreateDate" },
				new XGridColumn() { FieldName = "CreateByName" },
				new XGridColumn() { FieldName = "UpdateDate" },
				new XGridColumn() { FieldName = "UpdateByName" }
			);
			gridActivities.ColumnFix("RowNo");

			gridActivities.RowCellClick += delegate (object sender, RowCellClickEventArgs e)
			{
				if (e.RowHandle < 0)
					return;

				try
				{
					if (e.Button == System.Windows.Forms.MouseButtons.Left && e.Clicks == 2)
					{
						GridView view = sender as GridView;
						ShowEdit(view.GetRowCellValue(e.RowHandle, "ID"));
					}
				}
				catch (Exception ex)
				{
					ShowErrBox(ex);
				}
			};
			#endregion
		}

		protected override void LoadForm()
		{
			base.LoadForm();
			DataLoad();
		}

		protected override void DataInit()
		{
			ClearControlData<SearchBrandModel>();
			picBrandLogo.EditValue = null;
			txtBrandLogoUrl.Tag = null;
			picBrandMain.EditValue = null;
			txtBrandMainUrl.Tag = null;

			SetToolbarButtons(new ToolbarButtons() { New = true, Refresh = true, Save = true, SaveAndNew = true });
			EditMode = EditModeEnum.New;
			txtBrandName.Focus();
		}

		protected override void DataLoad(object param = null)
		{
			gridList.BindList<SearchBrandModel>("Biz", "GetList", "Select", new DataMap() { { "FindText", txtFindText.EditValue } });

			if (param != null)
				DetailDataLoad(param);
			else
				DataInit();
		}

		void DetailDataLoad(object id)
		{
			try
			{
				var model = WasHandler.GetData<SearchBrandModel>("Biz", "GetData", "Select", new DataMap() { { "ID", id } });
				if (model == null)
					throw new Exception("조회할 데이터가 없습니다.");

				SetControlData(model);
				if (model.BrandLogoUrl.IsNullOrEmpty() == false)
				{
					string logoUrl = ConstsVar.IMG_URL + model.BrandLogoUrl;
					picBrandLogo.LoadAsync(logoUrl);
				}
				if (model.BrandMainUrl.IsNullOrEmpty() == false)
				{
					string imageUrl = ConstsVar.IMG_URL + model.BrandMainUrl;
					picBrandMain.LoadAsync(imageUrl);
				}
				gridActivities.DataSource = model.Activities ?? new List<SearchBrandActivityModel>();

				if (lcTab.SelectedTabPage.Name == lcTabGroupActivities.Name)
				{
					if (txtID.EditValue.IsNullOrEmpty() == false)
						lcTab.CustomHeaderButtons[0].Visible = true;
					else
						lcTab.CustomHeaderButtons[0].Visible = false;
				}
				else
				{
					lcTab.CustomHeaderButtons[0].Visible = false;
				}

				SetToolbarButtons(new ToolbarButtons() { New = true, Refresh = true, Save = true, SaveAndNew = true, Delete = true });
				this.EditMode = EditModeEnum.Modify;
				txtBrandName.Focus();

			}
			catch(Exception ex)
			{
				ShowErrBox(ex);
			}
		}

		protected override void DataSave(object arg, SaveCallback callback)
		{
			try
			{
				var returnValue = DataSave();

				if (returnValue != null)
				{
					int iChanged = 0;
					string id = returnValue.ToString();

					//브랜드로고 업로드
					//브랜드로고가 변경되었다면 다시 업로드한다.
					if (txtBrandLogoUrl.Tag.ToBooleanNullToFalse())
					{
						string logopath = FTPHandler.UploadSearchBrand(txtBrandLogoUrl.Text, id, "LOGO");
						txtBrandLogoUrl.EditValue = logopath;
						iChanged++;
					}

					//브랜드대표이미지 업로드
					//브랜드대표이지가 변경되었다면 다시 업로드한다.
					if (txtBrandMainUrl.Tag.ToBooleanNullToFalse())
					{
						string mainpath = FTPHandler.UploadSearchBrand(txtBrandMainUrl.Text, id, "MAIN");
						txtBrandMainUrl.EditValue = mainpath;
						iChanged++;
					}

					if (iChanged > 0)
					{						
						returnValue = DataSave("Update");
					}
				}
				ShowMsgBox("저장하였습니다.");
				callback(arg, returnValue);
			}
			catch(Exception ex)
			{
				ShowErrBox(ex);
			}
		}

		private object DataSave(string sqlId = null)
		{
			var model = this.GetControlData<SearchBrandModel>();			
			if (sqlId.IsNullOrEmpty())
			{
				sqlId = (this.EditMode == EditModeEnum.New) ? "Insert" : "Update";
			}
			using (var res = WasHandler.Execute<SearchBrandModel>("Biz", "Save", sqlId, model, "ID"))
			{
				if (res.Error.Number != 0)
					throw new Exception(res.Error.Message);
				return res.Result.ReturnValue;
			}
		}

		protected override void DataDelete(object arg, DeleteCallback callback)
		{
			try
			{
				string id = txtID.EditValue.ToStringNullToEmpty();
				if (id.IsNullOrEmpty() == false)
				{
					try
					{
						string logopath = txtBrandLogoUrl.Text;
						if (logopath.IsNullOrEmpty() == false)
							FTPHandler.DeleteFile(logopath);
					}
					catch(Exception ex)
					{
						throw new Exception("브랜드 로고 이미지 삭제 중 오류가 발생하였습니다.", ex);
					}

					try
					{
						string mainpath = txtBrandMainUrl.Text;
						if (mainpath.IsNullOrEmpty() == false)
							FTPHandler.DeleteFile(mainpath);
					}
					catch(Exception ex)
					{
						throw new Exception("브랜드 대표 이미지 삭제 중 오류가 발생하였습니다.", ex);
					}

					FTPHandler.DeleteDirectory(ConstsVar.IMG_URL_SEARCH_BRAND + "/" + id);
					DataDelete();
					ShowMsgBox("삭제하였습니다.");
					callback(arg, null);
				}
			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}

		private void DataDelete()
		{
			DataMap map = new DataMap() { { "ID", txtID.EditValue } };
			using (var res = WasHandler.Execute<DataMap>("Biz", "Delete", "DeleteSearchBrand", map, "ID"))
			{
				if (res.Error.Number != 0)
					throw new Exception(res.Error.Message);
			}
		}

		protected override void ShowEdit(object data = null)
		{
			try
			{
				if (txtID.EditValue.IsNullOrEmpty())
					throw new Exception("브랜드 서칭 데이터가 저장되어야 활동내역을 추가할 수 있습니다.");

				DataMap map = new DataMap()
				{
					{ "SearchBrandID", txtID.EditValue },
					{ "ID", data }
				};
				using (SearchBrandActivityEditForm form = new SearchBrandActivityEditForm())
				{
					form.Text = "활동내역등록";
					form.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
					form.ParamsData = map;
					form.IsLoadingRefresh = true;
					if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
					{
						DetailDataLoad(txtID.EditValue);
					}
				}
			}
			catch(Exception ex)
			{
				ShowErrBox(ex);
			}
		}
	}
}