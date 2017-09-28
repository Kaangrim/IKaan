using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using IKaan.Base.Utils;
using IKaan.Model.Common.UserModels ;
using IKaan.Win.Core.Controls.Common;
using IKaan.Win.Core.Controls.Grid;
using IKaan.Win.Core.Enum;
using IKaan.Win.Core.Helper;
using IKaan.Win.Core.Interface;
using IKaan.Win.Core.Model;
using IKaan.Win.Core.Utils;
using IKaan.Win.Core.Variables;

namespace IKaan.Win.Core.Forms
{
	public partial class EditForm : BaseForm, IEditForm
	{
		private EditModeEnum _EditMode;
		private ToolbarButtons _ToolbarButtons;

		public delegate void SaveCallback(object arg, object data);
		public delegate void DeleteCallback(object arg, object data);

		public EditForm()
		{
			InitializeComponent();
			Initialize();

			barManager.ItemClick += (object sender, ItemClickEventArgs e) =>
			{
				switch (e.Item.Name.Replace("barButton", "").ToUpper())
				{
					case "REFRESH":
						ActRefresh();
						break;
					case "NEW":
						ActNew();
						break;
					case "SAVE":
						ActSave();
						break;
					case "SAVEANDCLOSE":
						ActSaveAndClose();
						break;
					case "SAVEANDNEW":
						ActSaveAndNew();
						break;
					case "DELETE":
						ActDelete();
						break;
					case "CANCEL":
						ActCancel();
						break;
					case "EXPORT":
						ActExport();
						break;
					case "PRINT":
						ActPrint();
						break;
					case "HELP":
						AcHelpModel();
						break;
					case "CLOSE":
						Close();
						break;
					default:
						break;
				}
			};
		}

		private void Initialize()
		{
			if (!this.DesignMode)
			{
				if (GlobalVar.SkinInfo.FormSkin.IsNullOrEmpty() == false)
				{
					this.LookAndFeel.UseDefaultLookAndFeel = 
						barAndDockingController.LookAndFeel.UseDefaultLookAndFeel = false;
					this.LookAndFeel.SetSkinStyle(GlobalVar.SkinInfo.FormSkin.ToStringNullToEmpty());
					barAndDockingController.LookAndFeel.SetSkinStyle(GlobalVar.SkinInfo.FormSubSkin.ToStringNullToEmpty());
				}
				else
				{
					this.LookAndFeel.UseDefaultLookAndFeel = 
						barAndDockingController.LookAndFeel.UseDefaultLookAndFeel = true;
				}
				
				barTools.OptionsBar.AllowQuickCustomization = false;

				ToolbarButtons = new ToolbarButtons();
				LoadingElapseTime = new ElapseTime();
				IsLoaded = false;

				if (Name.EndsWith("EditForm"))
				{
					EditMode = EditModeEnum.New;
				}
				else
				{
					EditMode = EditModeEnum.List;
				}
			}
			else
			{
				this.LookAndFeel.UseDefaultLookAndFeel = 
					barAndDockingController.LookAndFeel.UseDefaultLookAndFeel = true;
			}
		}

		[Browsable(false)]
		[Category("Customize")]
		public ElapseTime LoadingElapseTime { get; set; }

		[Browsable(false)]
		[Category("Customize")]
		public ToolbarButtons ToolbarButtons
		{
			get
			{
				return _ToolbarButtons;
			}
			set
			{
				_ToolbarButtons = value;
				ChangeToolbarButtons();
			}
		}

		[Browsable(false)]
		[Category("Customize")]
		public EditModeEnum EditMode
		{
			get { return _EditMode; }
			set
			{
				_EditMode = value;
				barStaticEditMode.Caption = value.ToString().ToUpper();
			}
		}

		[Browsable(true)]
		[Category("Customize")]
		public ViewTypeEnum ViewType { get; set; }

		[Browsable(true)]
		[Category("Customize")]
		public IList<UMenuViewButton> ViewButtons { get; set; }

		[Browsable(true)]
		[Category("Customize")]
		public bool IsTranList { get; set; }

		[Browsable(true)]
		[Category("Customize")]
		public bool VisibleToolbar
		{
			get
			{
				return barTools.Visible;
			}
			set
			{
				barTools.Visible = value;
			}
		}

		[Browsable(true)]
		[Category("Customize")]
		public bool VisibleStatusbar
		{
			get
			{
				return barStatus.Visible;
			}
			set
			{
				barStatus.Visible = value;
			}
		}
		
		[Browsable(true)]
		[Category("Customize")]
		public bool IsLoadingRefresh { get; set; }

		[Browsable(false)]
		[Category("Customize")]
		public bool IsLoaded { get; internal set; }

		private void SetLayout()
		{
			try
			{
				lc.Padding = new Padding(2);
				lc.Margin = new Padding(0);
				lcGroupBase.Padding = new DevExpress.XtraLayout.Utils.Padding(0);
				barTools.Offset = 0;

				try
				{
					lc.Items.OfType<LayoutControlGroup>().Where(x => x.Name.Equals("lcGroupSearch")).ToList().ForEach(group =>
					{
						group.Text = "검색조건";
						group.ExpandButtonVisible = true;						
					});

					lc.Items.OfType<EmptySpaceItem>().Where(x => x.Name == "esSearchTitle").ToList().ForEach(x =>
					{
						try
						{
							x.AppearanceItemCaption.BackColor = Color.FromArgb(50, 50, 50);
							x.AppearanceItemCaption.ForeColor = Color.FromArgb(192, 192, 192);
							x.AppearanceItemCaption.TextOptions.HAlignment = HorzAlignment.Center;						
						}
						catch
						{
							throw;
						}
					});
				}
				catch
				{
					throw;
				}

				var items = new string[] { "CreatedOn", "CreatedBy", "CreatedByName", "UpdatedOn", "UpdatedBy", "UpdatedByName" };
				lc.Items.OfType<LayoutControlItem>().Where(x => items.Contains(x.Name.Replace("lcItem", string.Empty))).ToList().ForEach(x =>
				{
					try
					{
						(x.Control as TextEdit).SetEnable(false);
						x.Control.Name = string.Format("txt{0}", x.Name.Replace("lcItem", string.Empty));
					}
					catch
					{
						throw;
					}
				});

				lc.Items.OfType<LayoutControlItem>().Where(x => x.Control != null && x.Control.GetType() == typeof(SimpleButton)).ToList().ForEach(x =>
				{
					try
					{
						(x.Control as SimpleButton).TabIndex = 0;
						(x.Control as SimpleButton).TabStop = false;
					}
					catch
					{
						throw;
					}
				});

				lc.Items.OfType<LayoutControlGroup>().Where(x => x.Name != lcGroupBase.Name).ToList().ForEach(x =>
				{
					x.Spacing = new DevExpress.XtraLayout.Utils.Padding(2);
				});
			}
			catch(Exception ex)
			{
				ShowErrBox(ex);
			}
		}

		public void SetToolbarButtons(ToolbarButtons toolbarButtons)
		{
			_ToolbarButtons = toolbarButtons;
			ChangeToolbarButtons();
		}

		private void ChangeToolbarButtons()
		{
			barTools.ItemLinks.OfType<BarButtonItemLink>().Where(x => x.Item.Name.StartsWith("barButton")).ToList().ForEach(x =>
			{
				if (_ToolbarButtons.ToDictionary().Where(button => 
						button.Key == x.Item.Name.Replace("barButton", string.Empty)).FirstOrDefault().Value.ToBooleanNullToFalse() == true ||
						x.Item.Name.Replace("barButton", string.Empty) == "Close" ||
						x.Item.Name.Replace("barButton", string.Empty) == "Help")
				{
					x.Item.Visibility = BarItemVisibility.Always;
				}
				else
				{
					x.Item.Visibility = BarItemVisibility.Never;
				}
			});
		}

		private void SeButtonModelName()
		{
			try
			{
				barButtonRefresh.Caption = DomainUtils.GetFieldName(barButtonRefresh.Name);
				barButtonNew.Caption = DomainUtils.GetFieldName(barButtonNew.Name);
				barButtonSave.Caption = DomainUtils.GetFieldName(barButtonSave.Name);
				barButtonSaveAndClose.Caption = DomainUtils.GetFieldName(barButtonSaveAndClose.Name);
				barButtonSaveAndNew.Caption = DomainUtils.GetFieldName(barButtonSaveAndNew.Name);
				barButtonDelete.Caption = DomainUtils.GetFieldName(barButtonDelete.Name);
				barButtonCancel.Caption = DomainUtils.GetFieldName(barButtonCancel.Name);
				barButtonExport.Caption = DomainUtils.GetFieldName(barButtonExport.Name);
				barButtonPrint.Caption = DomainUtils.GetFieldName(barButtonPrint.Name);
				barButtonHelp.Caption = DomainUtils.GetFieldName(barButtonHelp.Name);
				barButtonClose.Caption = DomainUtils.GetFieldName(barButtonClose.Name);
			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}

		/// <summary>
		/// 버튼초기화
		/// </summary>
		protected virtual void InitButton()
		{
			barTools.ItemLinks.OfType<BarButtonItemLink>().Where(x => x.Item.Name.Contains("barButton")).ToList().ForEach(x =>
			{
				x.Item.PaintStyle = BarItemPaintStyle.Standard;
			});
		}

		/// <summary>
		/// 컨트롤 초기화
		/// </summary>
		protected virtual void InitControls() { }

		/// <summary>
		/// 폼이 로드되었을 때의 이벤트 (상속폼에서 이벤트 델리게이트 하지 않고 사용하는 경우)
		/// </summary>
		protected override void LoadForm()
		{
			try
			{
				if (Name.EndsWith("ListForm"))
				{
					EditMode = EditModeEnum.List;
				}
				else
				{
					if (Name.EndsWith("ViewForm"))
					{
						EditMode = EditModeEnum.View;
					}
				}
				SeButtonModelName();

				SetLayout();

				barTitle.Caption = (this.MenuPath.IsNullOrEmpty()) ? this.Text : this.MenuPath;
				barTitle.ItemAppearance.Normal.ForeColor = Color.White;
				barTitle.ItemAppearance.Normal.BackColor = Color.Black;
				barTitle.ItemAppearance.Normal.BackColor2 = Color.Transparent;
				barStaticMessage.Caption = string.Empty;
				barStaticTotalRecords.Caption = string.Empty;
				barStaticEditMode.Caption = EditMode.ToString().ToUpper();

				InitButton();
				InitControls();
				barStaticViewName.Caption = Name;
				SeButtonModelNotFocus();
				SetTextBoxKeydownEvent();

				if (IsLoadingRefresh)
				{
					if (ParamsData != null)
					{
						DataLoad(ParamsData);
					}
					else
					{
						DataInit();
					}
				}

				IsLoaded = true;
			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}

		/// <summary>
		/// 편집화면 로딩 메소드
		/// </summary>
		/// <param name="data"></param>
		protected virtual void ShowEdit(object data = null) { }

		protected override void ChildCallback(object data = null)
		{
			if (InvokeRequired)
			{
				Invoke(new Action(() => DataLoad(data)));
			}
		}

		/// <summary>
		/// 툴바버튼 New 클릭 이벤트 상속 메소드
		/// </summary>
		protected virtual void ActNew()
		{
			if (EditMode == EditModeEnum.List || EditMode == EditModeEnum.View)
			{
				ShowEdit(null);
			}
			else
			{
				if (EditMode != EditModeEnum.New && ViewType == ViewTypeEnum.Edit)
				{
					if (MsgBox.Show("신규로 등록하겠습니까?", "New", MessageBoxButtons.OKCancel) != DialogResult.OK)
					{
						return;
					}
				}
				DataInit();
			}
		}

		/// <summary>
		/// 툴바버튼 Save 클릭 이벤트 상속 메소드
		/// DataSave 메소드를 호출하고 DataCallback 메소드를 콜백메소드로 설정한다.
		/// </summary>
		protected virtual void ActSave()
		{
			SplashUtils.ShowWait("저장하는 중입니다... 잠시만...");
			try
			{
				DataSave(MethodBase.GetCurrentMethod().Name, DataCallback);
			}
			catch (Exception ex)
			{
				MsgBox.Show(ex);
			}
			finally
			{
				SplashUtils.CloseWait();
			}
		}

		/// <summary>
		/// 툴바버튼 SaveAndNew 클릭 이벤트 상속 메소드
		/// DataSave 메소드를 호출하고 DataCallback 메소드를 콜백메소드로 설정한다.
		/// </summary>
		protected virtual void ActSaveAndNew()
		{
			SplashUtils.ShowWait("저장하는 중입니다... 잠시만...");
			try
			{
				DataSave(MethodBase.GetCurrentMethod().Name, DataCallback);
			}
			catch (Exception ex)
			{
				MsgBox.Show(ex);
			}
			finally
			{
				SplashUtils.CloseWait();
			}
		}

		/// <summary>
		/// 툴바버튼 SaveAndClose 클릭 이벤트 상속 메소드
		/// DataSave 메소드를 호출하고 DataCallback 메소드를 콜백메소드로 설정한다.
		/// </summary>
		protected virtual void ActSaveAndClose()
		{
			SplashUtils.ShowWait("저장하는 중입니다... 잠시만...");
			try
			{
				DataSave(MethodBase.GetCurrentMethod().Name, DataCallback);
			}
			catch (Exception ex)
			{
				MsgBox.Show(ex);
			}
			finally
			{
				SplashUtils.CloseWait();
			}
		}

		/// <summary>
		/// 툴바버튼 Cancel 클릭 이벤트 상속 메소드
		/// 편집모드가 Modify이면 DataLoad 호출, New이면 DataInit 호출함
		/// </summary>
		protected virtual void ActCancel()
		{
			if (EditMode == EditModeEnum.Modify)
			{
				DataLoad(ParamsData);
			}
			else
			{
				if (EditMode == EditModeEnum.New)
				{
					DataInit();
				}
			}
		}

		/// <summary>
		/// 툴바버튼 Delete 클릭 이벤트 상속 메소드
		/// 삭제확인 메시지박스를 보여주고 OK인 경우
		/// DataDelete를 실행하고 DataCallback으로 콜백메소드를 설정한다.
		/// </summary>
		protected virtual void ActDelete()
		{
			if (EditMode == EditModeEnum.Modify)
			{
				if (MsgBox.Show("삭제하겠습니까?", "삭제", MessageBoxButtons.OKCancel) != DialogResult.OK)
				{
					return;
				}
				SplashUtils.ShowWait("삭제하는 중입니다... 잠시만...");
				try
				{
					DataDelete(MethodBase.GetCurrentMethod().Name, DataCallback);
				}
				catch (Exception ex)
				{
					MsgBox.Show(ex);
				}
				finally
				{
					SplashUtils.CloseWait();
				}
			}
			else
			{
				DataInit();
			}
		}

		/// <summary>
		/// 툴바버튼 Refresh 클릭 이벤트 상속 메소드
		/// DataLoad를 호출한다.
		/// </summary>
		protected virtual void ActRefresh()
		{
			SplashUtils.ShowWait();
			try
			{
				DataLoad(ParamsData);
			}
			catch (Exception ex)
			{
				MsgBox.Show(ex);
			}
			finally
			{
				SplashUtils.CloseWait();
			}
		}

		/// <summary>
		/// 툴바버튼 Export 클릭 이벤트 상속 메소드
		/// </summary>
		protected virtual void ActExport()
		{
			if (EditMode == EditModeEnum.List || EditMode == EditModeEnum.View)
			{
				foreach (var c in Controls)
				{
					if (c.GetType() == typeof(LayoutControl) || c.GetType() == typeof(LayoutControl))
					{
						foreach (var g in ((LayoutControl)c).Controls)
						{
							if (g.GetType() == typeof(XGrid))
							{
								return;
							}
						}
					}
				}
			}
		}

		/// <summary>
		/// 툴바버튼 Print 클릭 이벤트 상속 메소드
		/// </summary>
		protected virtual void ActPrint() { }

		protected virtual void AcHelpModel()
		{
			try
			{
				FormUtils.ShowHelp(null, FormId);
			}
			catch (Exception ex)
			{
				MsgBox.Show(ex);
			}
		}

		/// <summary>
		/// 데이터 초기화 메소드
		/// </summary>
		protected virtual void DataInit() { }

		/// <summary>
		/// 데이터 로드 메소드
		/// </summary>
		/// <param name="param"></param>
		protected virtual void DataLoad(object param = null) { }

		/// <summary>
		/// 데이터 저장 메소드
		/// 파라미터로 처리된 콜백 메소드를 호출한다.
		/// </summary>
		/// <param name="arg"></param>
		/// <param name="callback"></param>
		protected virtual void DataSave(object arg, SaveCallback callback) { callback?.Invoke(arg, null); }

		/// <summary>
		/// 데이터 삭제 메소드
		/// 파라미터로 처리된 콜백 메소드를 호출한다.
		/// </summary>
		/// <param name="arg"></param>
		/// <param name="callback"></param>
		protected virtual void DataDelete(object arg, DeleteCallback callback) { callback?.Invoke(arg, null); }

		/// <summary>
		/// 데이터 처리 이후의 콜백 메소드
		/// 저장, 삭제에 대한 사전 정의된 콜백 메소드
		/// </summary>
		/// <param name="arg"></param>
		/// <param name="data"></param>
		protected virtual void DataCallback(object arg, object data)
		{
			SetModifiedCount();

			if (arg.ToString().Equals("ActSave"))
			{
				DataLoad(data);
			}
			else if (arg.ToString().Equals("ActSaveAndClose"))
			{
				Close();
			}
			else
			{
				//ActSaveAndNew or ActDelete
				if (this.ViewType == ViewTypeEnum.ListAndEdit)
					DataLoad(null);
				else
					DataInit();
			}
		}
		
		/// <summary>
		/// 데이터를 검사하는 메소드
		/// </summary>
		/// <returns></returns>
		protected virtual bool DataValidate()
		{
			string msg = string.Empty;
			try
			{
				foreach(LayoutControlItem item in lc.Items.OfType<LayoutControlItem>().Where(x => x.Tag != null && x.Tag.ToBooleanNullToFalse()).Reverse().ToList())
				{
					if (item.Control != null)
					{
						if (item.Control.GetType() == typeof(TextEdit))
						{
							if ((item.Control as TextEdit).EditValue.ToStringNullToEmpty().Trim() == string.Empty)
							{
								item.Control.Focus();
								msg = string.Format("{0}을(를) 입력해야 합니다.", item.Text.Replace(":", string.Empty));
								break;
							}
						}
						else if (item.Control.GetType() == typeof(MemoEdit))
						{
							if ((item.Control as MemoEdit).EditValue.ToStringNullToEmpty().Trim() == string.Empty)
							{
								item.Control.Focus();
								msg = string.Format("{0}을(를) 입력해야 합니다.", item.Text.Replace(":", string.Empty));
								break;
							}
						}
						else if (item.Control.GetType() == typeof(XLookup))
						{
							if ((item.Control as XLookup).EditValue.ToStringNullToEmpty().Trim() == string.Empty)
							{
								item.Control.Focus();
								msg = string.Format("{0}을(를) 입력해야 합니다.", item.Text.Replace(":", string.Empty));
								break;
							}
						}
						else if (item.Control.GetType() == typeof(SpinEdit))
						{
							if ((item.Control as SpinEdit).EditValue.ToDecimalNullToZero() == 0)
							{
								item.Control.Focus();
								msg = string.Format("{0}을(를) 입력해야 합니다.", item.Text.Replace(":", string.Empty));
								break;
							}
						}
						else if (item.Control.GetType() == typeof(XSearch))
						{
							if ((item.Control as XSearch).EditValue.ToStringNullToEmpty().Trim() == string.Empty)
							{
								item.Control.Focus();
								msg = string.Format("{0}을(를) 입력해야 합니다.", item.Text.Replace(":", string.Empty));
								break;
							}
						}
						else if (item.Control.GetType() == typeof(DateEdit))
						{
							if ((item.Control as DateEdit).EditValue.ToStringNullToEmpty().Trim() == string.Empty)
							{
								item.Control.Focus();
								msg = string.Format("{0}을(를) 입력해야 합니다.", item.Text.Replace(":", string.Empty));
								break;
							}
						}
						else if (item.Control.GetType() == typeof(ButtonEdit))
						{
							if ((item.Control as ButtonEdit).EditValue.ToStringNullToEmpty().Trim() == string.Empty)
							{
								item.Control.Focus();
								msg = string.Format("{0}을(를) 입력해야 합니다.", item.Text.Replace(":", string.Empty));
								break;
							}
						}
					}
				};

				if (!string.IsNullOrEmpty(msg))
				{
					ShowMsgBox(msg);
					return false;
				}
				else
				{
					return true;
				}
			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
				return false;
			}
		}

		public EditForm Init(BaseForm parentForm, object data, object optionalData = null)
		{
			Name = parentForm.Name.Replace("ListForm", "EditForm");
			Text = string.Format("{0} [편집]", parentForm.Text);
			StartPosition = FormStartPosition.CenterScreen;
			FormId = parentForm.FormId;
			MenuId = parentForm.MenuId;
			ParamsData = data;
			OptionData = optionalData;
			ParentFormName = parentForm.Name;
			EditMode = (data == null) ? EditModeEnum.New : EditModeEnum.Modify;
			IsLoadingRefresh = true;
			return this;
		}

		/// <summary>
		/// 메시지박스 보이기
		/// </summary>
		/// <param name="msg"></param>
		public void ShowMsgBox(string msg) { MsgBox.Show(msg); }

		/// <summary>
		/// 에러 메시지박스 보이기(오류객체)
		/// </summary>
		/// <param name="ex"></param>
		public void ShowErrBox(Exception ex) { MsgBox.Show(ex); }

		/// <summary>
		/// 에러 메시지박스 보이기(문자열)
		/// </summary>
		/// <param name="msg"></param>
		public void ShowErrBox(string msg)
		{
			MsgBox.Show(new Exception(msg));
		}
		protected virtual void SetFieldName(LayoutControlItem item)
		{
			var itemName = item.Name.Replace("lcItem", string.Empty);
			if (ConstsVar.DICTIONARY_CASE.Equals("UpperCase"))
				itemName = StringUtils.ToUpperUnderscoreByPattern(itemName).Replace("_", " ");
			SetFieldName(item, itemName, HorzAlignment.Far, VertAlignment.Center);
		}
		protected virtual void SetFieldName(LayoutControlItem item, string fieldName)
		{
			SetFieldName(item, fieldName, HorzAlignment.Far, VertAlignment.Center);
		}
		protected virtual void SetFieldName(LayoutControlItem item, string fieldName, VertAlignment vertAlign)
		{
			SetFieldName(item, fieldName, HorzAlignment.Far, vertAlign);
		}
		protected virtual void SetFieldName(LayoutControlItem item, string fieldName, HorzAlignment horzAlign)
		{
			SetFieldName(item, fieldName, horzAlign, VertAlignment.Center);
		}
		protected virtual void SetFieldName(LayoutControlItem item, string fieldName, HorzAlignment horzAlign, VertAlignment vertAlign)
		{
			item.Text = DomainUtils.GetFieldName(fieldName) + ":";
		}
		protected virtual void SetFieldNames()
		{
			try
			{
				SuspendLayout();
				if (Controls.Count > 0)
				{
					Controls.OfType<LayoutControl>().ToList().ForEach(control =>
					{
						control.BeginUpdate();
						SetFieldNames(control);
						control.EndUpdate();
					});
				}
				ResumeLayout(true);
			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}

		private void SetFieldNames(LayoutControl control)
		{
			try
			{
				if (control.Items.Count > 0)
				{
					string itemName = string.Empty;
					control.Items.OfType<LayoutControlItem>().Where(x => x.Name.StartsWith("lcItem")).ToList().ForEach(item =>
					{
						if (item.TextLocation == Locations.Top)
						{
							item.AppearanceItemCaption.TextOptions.HAlignment = HorzAlignment.Near;
							item.AppearanceItemCaption.Font = new Font(item.AppearanceItemCaption.Font, FontStyle.Bold);
						}
						else
						{
							item.AppearanceItemCaption.TextOptions.HAlignment = HorzAlignment.Far;
						}
						item.AppearanceItemCaption.TextOptions.VAlignment = VertAlignment.Center;

						itemName = item.Name.Replace("lcItem", string.Empty);
						if (ConstsVar.DICTIONARY_CASE.Equals("UpperCase"))
							itemName = StringUtils.ToUpperUnderscoreByPattern(itemName);

						var itemText = DomainUtils.GetFieldName(itemName);

						if (string.IsNullOrEmpty(itemText))
						{
							itemText = itemName.Replace("_", " ");
						}
						if (item.Tag != null && item.Tag.GetType() == typeof(bool) && (bool)item.Tag == true)
						{
							item.Text = string.Format("*{0}:", itemText);
							item.AppearanceItemCaption.ForeColor = (SkinUtils.IsDarkSkin) ? Color.Yellow : Color.Red;
							item.AppearanceItemCaption.Options.UseForeColor = true;
						}
						else
						{
							item.Text = itemText + ":";
							item.AppearanceItemCaption.Options.UseForeColor = false;
						}
					});
				}
			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}

		public void SetRecords(int rowcount)
		{
			barStaticTotalRecords.Caption = string.Format("조회건수: {0:N0}건", rowcount);
		}

		private void SetTextBoxKeydownEvent()
		{
			try
			{
				lc.Items.OfType<LayoutControlItem>().Where
					(x =>
						x.Parent != null &&
						x.Parent.Name.Equals("lcGroupSearch") &&
						x.Control != null &&
						x.Control.GetType() == typeof(TextEdit)
					).ToList().ForEach(c =>
					{
						((TextEdit)c.Control).KeyDown += delegate (object sender, KeyEventArgs e)
						{
							if (e.KeyCode == Keys.Enter)
							{
								DataLoad(null);
							}
						};
					});
			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}

		private void SeButtonModelNotFocus()
		{
			try
			{
				lc.Items.OfType<LayoutControlItem>().Where
					(x =>
						x.Control != null &&
						x.Control.GetType() == typeof(SimpleButton)
					).ToList().ForEach(c =>
					{
						(c.Control as SimpleButton).AllowFocus = false;
						(c.Control as SimpleButton).TabStop = true;
						(c.Control as SimpleButton).TabIndex = 0;
					});
			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}

		public void SetMessage(string msg)
		{
			barStaticMessage.Caption = msg;
		}

		public void ClearControlData<T>()
		{
			var entityType = typeof(T);
			var properties = TypeDescriptor.GetProperties(entityType);

			foreach (PropertyDescriptor prop in properties)
			{
				var list = lc.Items.OfType<LayoutControlItem>().Where
					(x => 
						x.Name.StartsWith("lcItem") && 
						x.Control != null && 
						x.Control.Name.Remove(0, 3).Equals(prop.Name) &&
						(
							x.Parent == null || 
							(
								x.Parent != null && x.Parent.Name != "lcGroupSearch"
							)
						)
					).ToList();

				foreach (var item in list)
				{
					if (item.Control.GetType() == typeof(TextEdit))
					{
						(item.Control as TextEdit).Clear();
					}
					else if (item.Control.GetType() == typeof(MemoEdit))
					{
						(item.Control as MemoEdit).Clear();
					}
					else if (item.Control.GetType() == typeof(XLookup))
					{
						(item.Control as XLookup).SelectedIndex = 0;
					}
					else if (item.Control.GetType() == typeof(SpinEdit))
					{
						(item.Control as SpinEdit).Clear();
					}
					else if (item.Control.GetType() == typeof(XSearch))
					{
						(item.Control as XSearch).Clear();
					}
					else if (item.Control.GetType() == typeof(DateEdit))
					{
					}
					else if (item.Control.GetType() == typeof(ButtonEdit))
					{
						(item.Control as ButtonEdit).Clear();
					}
					else if (item.Control.GetType() == typeof(CheckEdit))
					{
					}
				};
			}
		}

		public void SetControlData<T>(T data)
		{
			var entityType = typeof(T);
			var properties = TypeDescriptor.GetProperties(entityType);

			foreach (PropertyDescriptor prop in properties)
			{
				var value = prop.GetValue(data);
				var item = lc.Items.OfType<LayoutControlItem>().Where
					(x =>
						x.Name.StartsWith("lcItem") &&
						x.Control != null &&
						x.Control.Name.Remove(0, 3).Equals(prop.Name) &&
						(
							x.Parent == null ||
							(
								x.Parent != null && x.Parent.Name != "lcGroupSearch"
							)
						)
					).FirstOrDefault();

				if (item != null)
				{
					if (item.Control.GetType() == typeof(TextEdit))
					{
						(item.Control as TextEdit).EditValue = value;
					}
					else if (item.Control.GetType() == typeof(MemoEdit))
					{
						(item.Control as MemoEdit).EditValue = value;
					}
					else if (item.Control.GetType() == typeof(XLookup))
					{
						(item.Control as XLookup).EditValue = (value.ToStringNullToEmpty().IsNullOrEmpty()) ? null : value.ToStringNullToEmpty();
					}
					else if (item.Control.GetType() == typeof(SpinEdit))
					{
						(item.Control as SpinEdit).EditValue = value;
					}
					else if (item.Control.GetType() == typeof(XSearch))
					{
						(item.Control as XSearch).EditValue = value;
						PropertyInfo nameProp = data.GetType().GetProperty(string.Concat(prop.Name, "Name"));
						if (nameProp != null)
						{
							object nameValue = nameProp.GetValue(data, null);
							(item.Control as XSearch).EditText = nameValue.ToStringNullToEmpty();
						}
					}
					else if (item.Control.GetType() == typeof(DateEdit))
					{
						if (prop.PropertyType == typeof(DateTime) ||
							prop.PropertyType == typeof(DateTime?))
						{
							(item.Control as DateEdit).EditValue = value;
						}
						else if (prop.PropertyType == typeof(string))
						{
							if (value.ToStringNullToEmpty().Length == 6)
							{
								(item.Control as DateEdit).SetDateChar6(value);
							}
							else
							{
								(item.Control as DateEdit).SetDateChar8(value);
							}
						}
					}
					else if (item.Control.GetType() == typeof(ButtonEdit))
					{
						(item.Control as ButtonEdit).EditValue = value;
					}
					else if (item.Control.GetType() == typeof(CheckEdit))
					{
						if (value.ToStringNullToEmpty() == "Y")
							(item.Control as CheckEdit).Checked = true;
						else
							(item.Control as CheckEdit).Checked = false;
					}
				}
			}
		}

		public T GetControlData<T>()
		{
			var data = (T)Activator.CreateInstance(typeof(T), null);
			var entityType = typeof(T);
			var properties = TypeDescriptor.GetProperties(entityType);

			foreach (PropertyDescriptor prop in properties)
			{
				var item = lc.Items.OfType<LayoutControlItem>().Where
					(x =>
						x.Name.StartsWith("lcItem") &&
						x.Control != null &&
						x.Control.Name.Remove(0, 3).Equals(prop.Name) &&
						(
							x.Parent == null ||
							(
								x.Parent != null && x.Parent.Name != "lcGroupSearch"
							)
						)
					).FirstOrDefault();

				if (item != null)
				{
					if (item.Control.GetType() == typeof(TextEdit))
					{
						if ((item.Control as TextEdit).EditValue.IsNullOrEmpty() && prop.PropertyType != typeof(string))
							prop.SetValue(data, null);
						else
							prop.SetValue(data, (item.Control as TextEdit).EditValue);
					}
					else if (item.Control.GetType() == typeof(MemoEdit))
					{
						prop.SetValue(data, (item.Control as MemoEdit).EditValue);
					}
					else if (item.Control.GetType() == typeof(XLookup))
					{
						if((item.Control as XLookup).EditValue == null)
						{
							prop.SetValue(data, null);
						}
						else
						{
							if (prop.PropertyType == typeof(int?) || 
								prop.PropertyType == typeof(int))
								prop.SetValue(data, (item.Control as XLookup).EditValue.ToIntegerNullToNull());
							else
								prop.SetValue(data, (item.Control as XLookup).EditValue.ToString());
						}
					}
					else if (item.Control.GetType() == typeof(SpinEdit))
					{
						if (prop.PropertyType == typeof(int?) || prop.PropertyType == typeof(int))
							prop.SetValue(data, (item.Control as SpinEdit).EditValue.ToIntegerNullToNull());
						else
							prop.SetValue(data, (item.Control as SpinEdit).EditValue);
					}
					else if (item.Control.GetType() == typeof(XSearch))
					{
						if ((item.Control as XSearch).EditValue.IsNullOrEmpty())
							prop.SetValue(data, null);
						else
						{
							if (prop.PropertyType == typeof(int) ||
								prop.PropertyType == typeof(int?))
								prop.SetValue(data, (item.Control as XSearch).EditValue.ToIntegerNullToNull());
							else
								prop.SetValue(data, (item.Control as XSearch).EditValue);
						}
					}
					else if (item.Control.GetType() == typeof(DateEdit))
					{
						if((item.Control as DateEdit).EditValue == null)
						{
							prop.SetValue(data, null);
						}
						else if (prop.Name.EndsWith("Year"))
						{
							prop.SetValue(data, (item.Control as DateEdit).GetDateChar4());
						}
						else if (prop.Name.EndsWith("Ym") || prop.Name.EndsWith("Mon") || prop.Name.EndsWith("Month"))
						{
							prop.SetValue(data, (item.Control as DateEdit).GetDateChar6());
						}
						else
						{
							if (prop.PropertyType == typeof(DateTime?) || 
								prop.PropertyType == typeof(DateTime))
								prop.SetValue(data, (item.Control as DateEdit).EditValue);
							else if (prop.PropertyType == typeof(string))
								prop.SetValue(data, (item.Control as DateEdit).GetDateChar8());
						}
					}
					else if (item.Control.GetType() == typeof(ButtonEdit))
					{
						prop.SetValue(data, (item.Control as ButtonEdit).EditValue);
					}
					else if (item.Control.GetType() == typeof(CheckEdit))
					{
						prop.SetValue(data, ((item.Control as CheckEdit).Checked) ? "Y" : "N");
					}
				}
			}
			return data;
		}
	}
}
