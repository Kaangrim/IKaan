using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Docking;
using DevExpress.XtraEditors;
using DevExpress.XtraNavBar;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraTabbedMdi;
using DevExpress.XtraTreeList;
using IKaan.Win.View.Forms;
using IKaan.Base.Logging;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Win.Core.Controls.Common;
using IKaan.Win.Core.Enum;
using IKaan.Win.Core.Forms;
using IKaan.Win.Core.Helper;
using IKaan.Win.Core.Interface;
using IKaan.Win.Core.Interfaces;
using IKaan.Win.Core.Resources;
using IKaan.Win.Core.Utils;
using IKaan.Win.Core.Variables;
using IKaan.Win.Core.Was.Handler;
using IKaan.Model.Common.UserModels ;

namespace IKaan.Win.View.Forms
{
	public partial class MainForm : XtraForm, IMainForm
	{
		private string currentFormName = string.Empty;
		private XTree mainMenu = null;

		public MainForm()
		{
			InitializeComponent();
			InitSkin();
			LoadFormLayout();
			Init();

			this.barManager.ItemClick += delegate (object sender, ItemClickEventArgs e) { ToolbarButtonClick(sender, e); };
			this.navBarNavigate.LinkClicked += delegate (object sender, NavBarLinkEventArgs e) { NavBarNavigateLinkClicked(sender, e); };

			#region mdiManager Events
			mdiManager.PageAdded += delegate (object sender, MdiTabPageEventArgs e)
			{
				if (e.Page.MdiChild != null)
				{
					e.Page.Image = ((IBaseForm)e.Page.MdiChild).TabImage;
					//e.Page.Image = e.Page.MdiChild.BackgroundImage;
				}
			};
			mdiManager.BeginDocking += delegate (object sender, FloatingCancelEventArgs e)
			{
				try
				{
					e.Cancel = false;
				}
				catch (Exception ex)
				{
					MsgBox.Show(ex);
				}
			};
			mdiManager.BeginFloating += delegate (object sender, FloatingCancelEventArgs e)
			{
				try
				{
					e.Cancel = false;
				}
				catch (Exception ex)
				{
					MsgBox.Show(ex);
				}
			};
			mdiManager.EndDocking += delegate (object sender, FloatingEventArgs e)
			{
				try
				{
					if (e.ChildForm != null)
					{
					}
				}
				catch (Exception ex)
				{
					MsgBox.Show(ex);
				}
			};
			mdiManager.EndFloating += delegate (object sender, FloatingEventArgs e)
			{
				try
				{
					if (mdiManager.SelectedPage != null && mdiManager.SelectedPage.MdiChild != null)
					{
					}
				}
				catch (Exception ex)
				{
					MsgBox.Show(ex);
				}
			};
			mdiManager.FloatMDIChildDragging += delegate (object sender, FloatMDIChildDraggingEventArgs e)
			{
				try
				{
					var manager = sender as XtraTabbedMdiManager;
					var info = manager.GetType().GetMethod("PointToClient", BindingFlags.Instance | BindingFlags.NonPublic);
					var point = (Point)info.Invoke(manager, new object[] { e.ScreenPoint });
					var rect = manager.Bounds;
					rect.Height = 20;
					if (manager.Pages.Count == 0 && rect.Contains(point))
					{
						manager.FloatForms.Remove(e.ChildForm);
						e.ChildForm.MdiParent = manager.MdiParent;
					}
				}
				catch (Exception ex)
				{
					MsgBox.Show(ex);
				}
			};
			mdiManager.PageRemoved += delegate (object sender, MdiTabPageEventArgs e)
			{
				try
				{
				}
				catch (Exception ex)
				{
					MsgBox.Show(ex);
				}
			};
			mdiManager.SelectedPageChanged += delegate (object sender, EventArgs e)
			{
				try
				{
					if (mdiManager.SelectedPage != null && mdiManager.SelectedPage.MdiChild != null)
					{
					}
				}
				catch (Exception ex)
				{
					MsgBox.Show(ex);
				}
			};
			mdiManager.MouseDown += delegate (object sender, MouseEventArgs e)
			{
				if (e.Button != MouseButtons.Right)
				{
					return;
				}
				var ea = e as DevExpress.Utils.DXMouseEventArgs;
				var hi = mdiManager.CalcHitInfo(new Point(e.X, e.Y));
				if (hi.HitTest == DevExpress.XtraTab.ViewInfo.XtraTabHitTest.PageHeader)
				{
					currentFormName = (hi.Page as XtraMdiTabPage).Text;
					popupMenuTabPage.ShowPopup(Cursor.Position);
					ea.Handled = true;
				}
			};
			#endregion

			#region navBarFavorite Events
			//navBarFavorite.LinkClicked += delegate (object sender, NavBarLinkEventArgs e)
			//{
			//	if (e.Link.Item.Tag != null)
			//	{
			//	}
			//};
			//navBarFavorite.MouseClick += delegate (object sender, MouseEventArgs e)
			//{
			//	if (e.Button == MouseButtons.Right)
			//	{
			//		var navBar = sender as NavBarControl;
			//		var hitInfo = navBar.CalcHitInfo(navBar.PointToClient(MousePosition));

			//		if (hitInfo.InLink && hitInfo.Group.Name.Equals("navBarGroupBookMark"))
			//		{
			//		}
			//	}
			//};
			#endregion

			#region Timer Events
			timerMainTime.Tick += delegate (object sender, EventArgs e) { MainTimeTick(); };
			timerHomeShow.Tick += delegate (object sender, EventArgs e)
			{
				timerHomeShow.Enabled = false;

				ShowHomePage();
			};
			#endregion

			#region Popup Menu Events
			barPopupUxButtonpandAll.ItemClick += delegate (object sender, ItemClickEventArgs e)
			{
				if (mainMenu != null)
				{
					mainMenu.ExpandAll();
				}
			};
			barPopupButtonCollapseAll.ItemClick += delegate (object sender, ItemClickEventArgs e)
			{
				if (mainMenu != null)
				{
					mainMenu.CollapseAll();
				}
			};
			barPopupButtonRefresh.ItemClick += delegate (object sender, ItemClickEventArgs e)
			{
				LoadMainMenu();
				LoadMenuGroup("navBarGroupSystem", "SYS");
				LoadMenuGroup("navBarGroupDatabase", "RDS");
			};
			#endregion

			#region TabPage Close Popup Events
			barButtonTabPageCloseAll.ItemClick += delegate (object sender, ItemClickEventArgs e)
			{
				try
				{
					mdiManager.Pages.Cast<XtraMdiTabPage>().Where(x => x.Text != "HOME").ToList().ForEach(x =>
						x.MdiChild.Close()
					);
				}
				catch (Exception ex)
				{
					MsgBox.Show(ex);
				}
			};
			barButtonTabPageCloseAllButThis.ItemClick += delegate (object sender, ItemClickEventArgs e)
			{
				try
				{
					mdiManager.Pages.Cast<XtraMdiTabPage>().Where(x => x.Text != "HOME" && x.Text != currentFormName).ToList().ForEach(x =>
						x.MdiChild.Close()
					);
				}
				catch (Exception ex)
				{
					MsgBox.Show(ex);
				}
			};
			#endregion
		}

		private void NavBarNavigateLinkClicked(object sender, NavBarLinkEventArgs e)
		{
			try
			{
				if (sender == null)
				{
					return;
				}
				if (e.Link.Item.Tag != null)
				{
					if (e.Link.Item.Tag is UMainMenu)
					{
						UMainMenu model = e.Link.Item.Tag as UMainMenu;
						OpenForm(model.MenuID);
					}
				}
			}
			catch (Exception ex)
			{
				MsgBox.Show(ex);
			}
		}

		private void MainTimeTick()
		{
			timerMainTime.Enabled = false;
			barStatusBarDatetime.Caption = DateTime.Now.ToString("F");
			timerMainTime.Enabled = true;

			if (NetworkUtils.IsConnectedToNetwork())
			{
				barStatusBarDatetime.ItemAppearance.Normal.Options.UseBackColor = false;
			}
			else
			{
				barStatusBarDatetime.ItemAppearance.Normal.BackColor = Color.Red;
				barStatusBarDatetime.ItemAppearance.Normal.ForeColor = Color.White;
			}
		}
		
		private void Init()
		{
			this.Icon = IconResource.logo;
			this.barManager.Items.OfType<BarButtonItem>().ToList().ForEach(x => x.Tag = x.Name.Replace("barButton", string.Empty));
			this.dockPanelLog.Padding = new Padding(2);

			//this.mdiManager.Appearance.BackColor = Color.White;
			////this.mdiManager.Appearance.Image = ImageResource.IKaanLogo;
			//this.mdiManager.MdiParent.BackgroundImage = ImageResource.IKaanLogo;
			//this.mdiManager.MdiParent.BackgroundImageLayout = ImageLayout.Center;
			
		}

		private void InitSkin()
		{
			this.LookAndFeel.UseDefaultLookAndFeel = 
					barAndDockingController.LookAndFeel.UseDefaultLookAndFeel = false;
			this.LookAndFeel.SetSkinStyle(GlobalVar.SkinInfo.MainSkin);
			barAndDockingController.LookAndFeel.SetSkinStyle(GlobalVar.SkinInfo.MainSkin);
		}

		private void LoadFormLayout()
		{
			if (!string.IsNullOrEmpty(GlobalVar.SkinInfo.MainFormState.ToStringNullToEmpty()))
				WindowState = GlobalVar.SkinInfo.MainFormState;
			else
				WindowState = FormWindowState.Maximized;
		}
		
		protected override void OnFormClosing(FormClosingEventArgs e)
		{
			try
			{
				base.OnFormClosing(e);

				if (MsgBox.Show(DomainUtils.GetMessageValue("SYSTEM_CLOSE"), "HELP", MessageBoxButtons.YesNo) != DialogResult.Yes)
				{
					e.Cancel = true;
				}
			}
			catch (Exception ex)
			{
				MsgBox.Show(ex);
			}
		}

		protected override void OnFormClosed(FormClosedEventArgs e)
		{
			try
			{
				base.OnFormClosed(e);
				SaveLogout();
				Logger.Debug("MainForm Closed...({0})", e.CloseReason);
			}
			catch (Exception ex)
			{
				MsgBox.Show(ex);
			}
		}

		private void SaveLogout()
		{
			try
			{
				DataMap parameter = new DataMap()
				{
					{ "UserID", GlobalVar.UserInfo.UserId },
					{ "MacAddress", CommonUtils.GetMacAddress() }
				};
				using (var res = WasHandler.Execute("AUTH", "Logout", "UpdateLogout", parameter))
				{
					if (res.Error.Number != 0)
						throw new Exception(res.Error.Message);
				}
			}
			catch (Exception ex)
			{
				MsgBox.Show(ex);
			}
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			try
			{
				SetFormTitle();

				barStatusBarCorpName.Caption = GlobalVar.UserInfo.CustomerName.ToStringNullToEmpty();
				barStatusBarUserInfo.Caption = GlobalVar.UserInfo.UserName.ToStringNullToEmpty();
				barStatusBarCulture.Caption = Thread.CurrentThread.CurrentCulture.ThreeLetterISOLanguageName.ToUpper();	// Application.CurrentCulture.ToString();
				barStatusBarDatetime.Caption = DateTime.Now.ToString("F");
				timerMainTime.Interval = 1000;
				timerMainTime.Enabled = true;
				timerMainTime.Start();

				InitLayoutSetting();
				InitMainMenu();
				wbSearch.Navigate(ConstsVar.SERVER_REAL + @"Search");

				timerHomeShow.Interval = 100;
				timerHomeShow.Enabled = true;
				timerHomeShow.Start();

				Logger.Debug("MainForm Loaded..");
			}
			catch (Exception ex)
			{
				MsgBox.Show(ex);
			}
			finally
			{
				if (SplashScreenManager.Default != null)
				{
					SplashScreenManager.CloseForm();
				}
			}
		}

		private void InitLayoutSetting()
		{
			try
			{
				dpSearch.Visibility = DockVisibility.AutoHide;
				//dpFavorite.Visibility = DockVisibility.Hidden;
				//nbGroupBookMark.Visible = false;
				barButtonFav.Visibility = BarItemVisibility.Never;
			}
			catch (Exception ex)
			{
				MsgBox.Show(ex);
			}
		}

		private void InitMainMenu()
		{
			try
			{
				navBarNavigate.BeginUpdate();
				navBarNavigate.PaintStyleKind = NavBarViewKind.NavigationPane;
				navBarNavigate.Groups.Clear();
				navBarNavigate.Items.Clear();

				var navBarGroupBusiness = new NavBarGroup()
				{
					Name = "navBarGroupBusiness",
					Caption = "Business",
					GroupStyle = NavBarGroupStyle.ControlContainer,
					SmallImage = MenuResource.menu_business_16x16,
					LargeImage = MenuResource.menu_business_32x32
				};
				var navBarGroupLibrary = new NavBarGroup()
				{
					Name = "navBarGroupLibrary",
					Caption = "Library",
					SmallImage = MenuResource.menu_system_16x16,
					LargeImage = MenuResource.menu_system_32x32
				};
				var navBarGroupSystem = new NavBarGroup()
				{
					Name = "navBarGroupSystem",
					Caption = "System",					
					SmallImage = MenuResource.menu_system_16x16,
					LargeImage = MenuResource.menu_system_32x32
				};
				var navBarGroupDatabase = new NavBarGroup()
				{
					Name = "navBarGroupDatabase",
					Caption = "Database",
					SmallImage = MenuResource.menu_system_16x16,
					LargeImage = MenuResource.menu_system_32x32
				};

				navBarNavigate.OptionsNavPane.ShowExpandButton = false;
				//navBarNavigate.Groups.AddRange(new NavBarGroup[] { navBarGroupBusiness, navBarGroupAnalysis, navBarGroupSystem });
				navBarNavigate.Groups.AddRange(new NavBarGroup[] { navBarGroupBusiness, navBarGroupLibrary, navBarGroupSystem, navBarGroupDatabase });
				navBarGroupBusiness.ControlContainer = new NavBarGroupControlContainer();
;
				//navBarNavigate.Groups.AddRange(new NavBarGroup[] { navBarGroupBusiness, navBarGroupAnalysis, navBarGroupSystem });
				//navBarNavigate.Groups.AddRange(new NavBarGroup[] { navBarGroupBusiness, navBarGroupSystem });
				//navBarGroupBusiness.ControlContainer = new NavBarGroupControlContainer();

				//#region Search TextBox
				//navBarGroupBusiness.ControlContainer.Controls.Add(new ComboBoxEdit()
				//{
				//	Name = "txtFindMenu",
				//	Dock = DockStyle.Top,
				//	Margin = new Padding(3)				
				//});
				//#endregion

				#region Load TreeMenu
				mainMenu = new XTree()
				{
					Name = "mainMenu",
					Dock = DockStyle.Fill
				};

				mainMenu.LookAndFeel.UseDefaultLookAndFeel = false;
				mainMenu.LookAndFeel.SetSkinStyle(GlobalVar.SkinInfo.MainSkin);

				if (mainMenu != null)
				{
					navBarGroupBusiness.ControlContainer.Controls.Add(mainMenu);

					mainMenu.OptionsBehavior.PopulateServiceColumns = true;
					mainMenu.OptionsBehavior.AllowExpandOnDblClick = true;
					mainMenu.OptionsView.ShowColumns = false;
					mainMenu.OptionsView.ShowIndicator = false;
					mainMenu.OptionsView.ShowHorzLines = false;
					mainMenu.OptionsView.ShowVertLines = false;
					mainMenu.OptionsView.AutoWidth = true;
					mainMenu.OptionsView.EnableAppearanceEvenRow = false;
					mainMenu.OptionsView.EnableAppearanceOddRow = false;

					imageCollection.Clear();
					imageCollection.AddImage(MenuResource.tree_group_collapse_16x16);
					imageCollection.AddImage(MenuResource.tree_group_expand_16x16);
					imageCollection.AddImage(MenuResource.tree_item_normal3_16x16);
					imageCollection.AddImage(MenuResource.tree_item_hot3_16x16);
					imageCollection.AddImage(MenuResource.tree_item_not3_16x16);

					mainMenu.StateImageList = imageCollection;

					#region mainMenu.GetStateImage
					mainMenu.GetStateImage += delegate (object sender, GetStateImageEventArgs e)
					{
						if (e.Node.HasChildren)
						{
							if (e.Node.Expanded)
							{
								e.NodeImageIndex = 1;
							}
							else
							{
								e.NodeImageIndex = 0;
							}
						}
						else
						{
							if (e.Node.GetValue("ViewYn").ToStringNullToEmpty().Equals("N"))
							{
								e.NodeImageIndex = 4;
							}
							else
							{
								if (e.Node.GetValue("BookmarkYn").ToStringNullToEmpty().Equals("Y"))
								{
									e.NodeImageIndex = 3;
								}
								else
								{
									e.NodeImageIndex = 2;
								}
							}
						}
					};
					#endregion

					#region mainMenu.GetSelectImage
					mainMenu.GetSelectImage += delegate (object sender, GetSelectImageEventArgs e)
					{
						if (e.Node.HasChildren)
						{
							e.NodeImageIndex = 1;
						}
					};
					#endregion

					#region mainMenu.MouseDoubleClick
					mainMenu.MouseDoubleClick += delegate (object sender, MouseEventArgs e)
					{
						try
						{
							if (e.Button == MouseButtons.Left && e.Clicks == 2)
							{
								var tree = sender as XTree;
								var info = tree.CalcHitInfo(tree.PointToClient(MousePosition));

								if (info.HitInfoType == HitInfoType.Cell && !info.Node.HasChildren)
								{
									OpenForm(info.Node["MenuID"].ToIntegerNullToZero());
								}
							}
						}
						catch (Exception ex)
						{
							MsgBox.Show(ex);
						}
					};
					#endregion

					#region mainMenu.MouseClick
					mainMenu.MouseClick += delegate (object sender, MouseEventArgs e)
					{
						try
						{
							var tree = sender as XTree;
							var info = tree.CalcHitInfo(tree.PointToClient(MousePosition));

							if (e.Button == MouseButtons.Right && ModifierKeys == Keys.None && tree.State == TreeListState.Regular)
							{
								if (info.HitInfoType == HitInfoType.Cell && info.Node.HasChildren == false)
								{
									barPopupButtonBookmark.Visibility = BarItemVisibility.Always;
								}
								else
								{
									barPopupButtonBookmark.Visibility = BarItemVisibility.Never;
								}
								popupMenuOfMainMenu.ShowPopup(MousePosition);
							}
						}
						catch (Exception ex)
						{
							MsgBox.Show(ex);
						}
					};
					#endregion

					#region Add Columns
					mainMenu.AddColumn("MenuName");
					mainMenu.AddColumn("MenuID", false);
					mainMenu.AddColumn("ParentID", false);
					mainMenu.AddColumn("HierID", false);
					mainMenu.AddColumn("Assembly", false);
					mainMenu.AddColumn("Namespace", false);
					mainMenu.AddColumn("Instance", false);
					mainMenu.AddColumn("ChildCount", false);
					mainMenu.AddColumn("BookmarkYn", false);
					mainMenu.AddColumn("ViewType", false);
					mainMenu.AddColumn("ViewYn", false);
					mainMenu.AddColumn("EditYn", false);

					mainMenu.ParentFieldName = "ParentID";
					mainMenu.KeyFieldName = "MenuID";
					mainMenu.RootValue = "MenuGroupBiz";
					#endregion

					LoadMainMenu();					
				}
				#endregion

				LoadMenuGroup("navBarGroupLibrary", "LIB");
				LoadMenuGroup("navBarGroupSystem", "SYS");
				LoadMenuGroup("navBarGroupDatabase", "RDS");

				navBarNavigate.EndUpdate();
			}
			catch (Exception ex)
			{
				MsgBox.Show(ex);
			}
		}

		private void LoadMainMenu()
		{
			try
			{
				if (mainMenu != null)
				{
					var list = WasHandler.GetData<List<UMainMenu>>("AUTH", "GetMainMenu", null, new DataMap()
					{
						{ "UserID", GlobalVar.UserInfo.UserId },
						{ "MenuGroup", "BIZ" }
					});

					if (list != null)
					{
						mainMenu.DataSource = list;
						mainMenu.ExpandAll();
						mainMenu.BestFitColumns();
						mainMenu.Sort(new string[] { "HierID" }, new SortOrder[] { SortOrder.Ascending });
					}
				}
			}
			catch (Exception ex)
			{
				MsgBox.Show(ex);
			}
		}
				
		private void LoadMenuGroup(string navBarGroupName, string menuGroupName)
		{
			try
			{
				if (navBarNavigate != null && navBarNavigate.Groups.Where(x => x.Name == navBarGroupName).Any())
				{
					var navGroup = navBarNavigate.Groups.Where(x => x.Name == navBarGroupName).FirstOrDefault();
					navGroup.ItemLinks.Clear();

					var list = WasHandler.GetData<List<UMainMenu>>("AUTH", "GetMainMenu", null, new DataMap()
					{
						{ "UserID", GlobalVar.UserInfo.UserId },
						{ "MenuGroup", menuGroupName }
					});

					if (list != null)
					{
						foreach (UMainMenu model in list)
						{
							navGroup.ItemLinks.Add(navBarNavigate.Items.Add(new DevExpress.XtraNavBar.NavBarItem()
							{
								Caption = model.MenuName.ToStringNullToEmpty(),
								Tag = model,
								SmallImage = MenuResource.menu_system_16x16,
								SmallImageSize = new Size(16, 16)
							}));
						}
					}
				}
			}
			catch (Exception ex)
			{
				MsgBox.Show(ex);
			}
		}

		public void SetFormTitle()
		{
			try
			{
				var attributes = GetType().Assembly.GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
				var version = Assembly.GetExecutingAssembly().GetName().Version;

				this.Text = string.Format("{0} ({1})", ((AssemblyTitleAttribute)attributes[0]).Title, version);
				barStatusBarCorpName.Caption = GlobalVar.UserInfo.CustomerName.ToStringNullToEmpty();
				notifyIcon1.Text = this.Text;
			}
			catch (Exception ex)
			{
				MsgBox.Show(ex);
			}
		}

		private void ShowHomePage()
		{
			try
			{
				CreateChildForm(new UMenuView()
				{
					MenuID = 0,
					MenuName = "HOME",
					//Image = null,
					Assembly = "IKaan.Win.View.dll",
					Namespace = "IKaan.Win.View.Forms",
					Instance = "HomeForm",
					ViewType = "",
					ViewButtons = new List<UMenuViewButton> { new UMenuViewButton() { ButtonID = 0, ButtonName = "조회", Instance = null } }
				});
			}
			catch(Exception ex)
			{
				MsgBox.Show(ex);
			}
		}

		private void ShowEmailPage()
		{
			try
			{
				CreateChildForm(new UMenuView()
				{
					MenuID = 0,
					MenuName = "Email",
					//Image = null,
					Assembly = "IKaan.Win.View.dll",
					Namespace = "IKaan.Win.View.Forms",
					Instance = "EmailForm",
					ViewType = "",
					ViewButtons = new List<UMenuViewButton> { new UMenuViewButton() { ButtonID = 0, ButtonName = "조회", Instance = null } }
				});
			}
			catch (Exception ex)
			{
				MsgBox.Show(ex);
			}
		}

		private void ShowWebPage()
		{
			try
			{
				CreateChildForm(new UMenuView()
				{
					MenuID = 0,
					MenuName = "Web",
					//Image = null,
					Assembly = "IKaan.Win.View.dll",
					Namespace = "IKaan.Win.View.Forms",
					Instance = "WebForm",
					ViewType = "",
					ViewButtons = new List<UMenuViewButton> { new UMenuViewButton() { ButtonID = 0, ButtonName = "조회", Instance = null } },
				});
			}
			catch (Exception ex)
			{
				MsgBox.Show(ex);
			}
		}

		private void ToggleDockPanel(DockPanel dock)
		{
			if (dock.Visibility == DockVisibility.Visible)
			{
				dock.Visibility = DockVisibility.Hidden;
			}
			else
			{
				dock.Visibility = DockVisibility.Visible;

				if (dock.Name == "dockPanelLog")
				{
					if (dockPanelLog.ControlContainer.Controls.OfType<ListBoxControl>().Any() == false)
					{
						dockPanelLog.Controls.Add(new ListBoxControl()
						{
							Name = "lbLogList",
							Dock = DockStyle.Fill,
							SelectionMode = SelectionMode.MultiExtended
						});
					}

					if (dockPanelLog.ControlContainer.Controls.OfType<ListBoxControl>().Any() == true)
					{
						using (var stRead = new StreamReader(ConstsVar.APP_PATH + @"\Log\log.log", Encoding.Default))
						{
							while (!stRead.EndOfStream)
							{
#if (DEBUG)
								dockPanelLog.ControlContainer.Controls.OfType<ListBoxControl>().ToList()[0].Items.Add(stRead.ReadLine());
#else
                                string text = stRead.ReadLine();
                                if (text.Contains("DEBUG") == false)
                                {
                                    ((ListBoxControl)dockPanelLog.ControlContainer.Controls.OfType<ListBoxControl>().ToList()[0]).Items.Add(stRead.ReadLine());
                                }
#endif
							}
						}
					}
				}
			}
		}

		#region 툴바버튼 클릭 이벤트 (ToolbarButtonClick)
		public void ToolbarButtonClick(object sender, ItemClickEventArgs e)
		{
			if (e == null || e.Item == null || e.Item.Tag == null || e.Item.Tag.IsNullOrEmpty()) return;
			if (e.Item.Name == "barButtonSkin") return;

			try
			{
				switch (e.Item.Tag.ToString().ToUpper())
				{
					case "CLOSE":
						CloseForm();
						break;
					case "NAV":
						ToggleDockPanel(dpNavigation);
						break;
					case "FAV":
						ToggleDockPanel(dpSearch);
						break;
					case "LOG":
						ToggleDockPanel(dockPanelLog);
						break;
					case "DOWNLOAD":
						using (DownloadCodeForm form = new DownloadCodeForm())
						{
							form.Text = "공통코드 다운로드";
							form.StartPosition = FormStartPosition.CenterScreen;
							form.ShowDialog();
						}
						break;
					case "HOME":
						ShowHomePage();
						break;
					case "EMAIL":
						ShowEmailPage();
						break;
					case "WEB":
						ShowWebPage();
						break;
					case "CHANGEPASSWORD":
						ShowChangePwd();
						break;
					case "SETTING":
						OpenSaleTran();
						break;
				}
			}
			catch (Exception ex)
			{
				MsgBox.Show(ex);
			}
		}
		#endregion

		/// <summary>
		/// 상태바의 메시지를 변경하는 메서드
		/// </summary>
		/// <param name="message"></param>
		public void SetMessage(string message)
		{
			try
			{
				barStatusBarMessage.Caption = message.Trim();
			}
			catch (Exception ex)
			{
				MsgBox.Show(ex);
			}
		}

		public bool ExistsChildForm(string childName)
		{
			return mdiManager.Pages.Where(x => x.MdiChild.Name.Equals(childName)).Any();
		}

		public void CreateChildForm(UMenuView data)
		{
			try
			{
				var formName = string.Format("{0}_{1}", data.MenuID.ToString("000000"), data.Instance);
				var bOpened = ExistsChildForm(formName);
				if (bOpened)
				{
					mdiManager.SelectedPage = mdiManager.Pages.Where(x => x.MdiChild.Name.Equals(formName)).ToList()[0];
					return;
				}

				if (string.IsNullOrEmpty(data.Namespace) || string.IsNullOrEmpty(data.Instance))
				{
					return;
				}
				
				var assembly = FormUtils.GetAssembly(data.Assembly);
				if (assembly == null)
				{
					throw new Exception("어셈블리를 찾을 수 없습니다.");
				}

				var form = (BaseForm)assembly.CreateInstance(string.Format("{0}.{1}", data.Namespace, data.Instance));
				if (form == null)
				{
					throw new Exception("해당 화면을 생성할 수 없습니다.");
				}

				form.Name = formName;
				form.Text = data.MenuName;
				form.Padding = new Padding(2);
				form.MenuId = data.MenuID;
				form.TabImage = MenuResource.Window_16x16;
				form.Icon = Icon.FromHandle(MenuResource.Window_16x16.GetHicon());
				form.MdiParent = this;

				if (!string.IsNullOrEmpty(data.ViewType))
				{
					switch (data.ViewType.ToStringNullToEmpty())
					{
						case "1":
							((IEditForm)form).ViewType = ViewTypeEnum.Edit;
							break;
						case "2":
							((IEditForm)form).ViewType = ViewTypeEnum.ListAndEdit;
							break;
						case "3":
							((IEditForm)form).ViewType = ViewTypeEnum.View;
							break;
						case "4":
							((IEditForm)form).ViewType = ViewTypeEnum.Web;
							break;
						default:
							((IEditForm)form).ViewType = ViewTypeEnum.List;
							break;
					}
					((IEditForm)form).ViewButtons = data.ViewButtons;
				}

				form.Show();
			}
			catch (Exception ex)
			{
				MsgBox.Show(ex);
			}
		}

		private void CloseForm()
		{
			try
			{
				if (mdiManager.Pages.Count > 0)
				{
					mdiManager.SelectedPage.MdiChild.Close();
				}
				else
				{
					Close();
				}
			}
			catch (Exception ex)
			{
				MsgBox.Show(ex);
			}
		}

		public void OpenForm(object obj)
		{
			try
			{
				if (obj.GetType() == typeof(UMenuView))
				{
					if (obj != null)
					{
						var menuView = obj as UMenuView;
						CreateChildForm(menuView);
					}
				}
				else
				{
					var menuView = WasHandler.GetData<UMenuView>("AUTH", "GetMenuView", null, new DataMap() { { "ID", obj } });
					if (menuView != null)
					{
						CreateChildForm(menuView);
					}
				}
			}
			catch (Exception ex)
			{
				MsgBox.Show(ex);
			}
		}

		private void ShowChangePwd()
		{
			using (var form = new PasswordForm())
			{
				form.Text = "비밀번호변경";
				form.Name = "PasswordForm";
				form.FormBorderStyle = FormBorderStyle.FixedDialog;
				form.StartPosition = FormStartPosition.CenterScreen;

				if (form.ShowDialog() == DialogResult.OK)
				{
					Close();
				}
			}
		}

		public void RefreshMainMenu() { }

		public void RefreshBookmark() { }

		public void OpenSaleTran(object param = null)
		{
			//if (FormUtils.IsExistsForm("SaleTranForm") == false)
			//{
			//	SaleTranForm form = new SaleTranForm()
			//	{
			//		Name = "SaleTranForm",
			//		Text = "판매등록",
			//		MdiParent = null,
			//		Padding = new Padding(2),
			//		MenuId = 10,
			//		TabImage = null,
			//		ParamsData = param,
			//		StartPosition = FormStartPosition.CenterScreen
			//	};
			//	((IEditForm)form).FormType = Core.Enumerations.FormTypeEnum.Edit;
			//	((IEditForm)form).IsTranList = true;
			//	((IEditForm)form).IsDataEdit = true;
			//	form.Show();
			//} 
			//else
			//{
			//	FormUtils.GetForm("SaleTranForm").Focus();
			//}
		}
	}
}
