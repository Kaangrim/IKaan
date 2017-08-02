using System;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraTreeList;
using IKaan.Base.Utils;
using IKaan.Biz.Core.Controls.Common;
using IKaan.Biz.Core.Enum;
using IKaan.Biz.Core.Forms;
using IKaan.Biz.Core.Handler;
using IKaan.Biz.Core.Helper;
using IKaan.Biz.Core.Model;
using IKaan.Biz.Core.Resources;
using IKaan.Biz.Core.Utils;
using IKaan.Biz.Core.Variables;

namespace IKaan.Biz.View.Sys.AC
{
	public partial class ACFtpForm : EditForm
	{
		public ACFtpForm()
		{
			InitializeComponent();

			btnUpload.Click += delegate (object sender, EventArgs e) { doUpload(); };
			btnDelete.Click += delegate (object sender, EventArgs e) { doDelete(); };
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			txtFindText.Focus();
		}

		protected override void InitButtons()
		{
			base.InitButtons();
			SetToolbarButtons(new ToolbarButtons() { Refresh = true });
		}
		protected override void InitControls()
		{
			base.InitControls();

			SetFieldNames();

			InitTree();
		}

		void InitTree()
		{
			#region Image Collection
			ImageCollection ic = new ImageCollection();
			ic.Clear();
			ic.AddImage(MenuResource.tree_group_collapse_16x16);
			ic.AddImage(MenuResource.tree_group_expand_16x16);
			ic.AddImage(MenuResource.tree_file_16x16);
			ic.AddImage(MenuResource.tree_up_16x16);
			#endregion

			#region Tree Directiories
			treeDirectories.OptionsBehavior.PopulateServiceColumns = true;
			treeDirectories.OptionsBehavior.AllowExpandOnDblClick = true;
			treeDirectories.OptionsView.ShowColumns = false;
			treeDirectories.OptionsView.ShowIndicator = false;
			treeDirectories.OptionsView.ShowHorzLines = false;
			treeDirectories.OptionsView.ShowVertLines = false;
			treeDirectories.OptionsView.AutoWidth = true;
			treeDirectories.OptionsView.EnableAppearanceEvenRow = false;
			treeDirectories.OptionsView.EnableAppearanceOddRow = false;			
			treeDirectories.StateImageList = ic;

			#region GetStateImage
			treeDirectories.GetStateImage += delegate (object sender, GetStateImageEventArgs e)
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
					e.NodeImageIndex = 0;
				}
			};
			#endregion

			#region GetSelectImage
			treeDirectories.GetSelectImage += delegate (object sender, GetSelectImageEventArgs e)
			{
				if (e.Node.HasChildren)
				{
					e.NodeImageIndex = 1;
				}
			};
			#endregion
			
			#region MouseClick
			treeDirectories.MouseClick += delegate (object sender, MouseEventArgs e)
			{
				try
				{
					var tree = sender as XTree;
					var info = tree.CalcHitInfo(tree.PointToClient(MousePosition));

					if (info.HitInfoType == HitInfoType.Cell && !info.Node.HasChildren)
					{
						DetailDataLoad(info.Node["FullName"].ToStringNullToEmpty());
					}
				}
				catch (Exception ex)
				{
					ShowErrBox(ex);
				}
			};
			#endregion

			treeDirectories.AddColumn("Name");
			treeDirectories.AddColumn("FullName", false);
			treeDirectories.AddColumn("ID", false);
			treeDirectories.AddColumn("ParentID", false);

			treeDirectories.ParentFieldName = "ParentID";
			treeDirectories.KeyFieldName = "ID";
			treeDirectories.RootValue = 0;
			#endregion

			#region Tree Files
			treeFiles.OptionsBehavior.PopulateServiceColumns = false;
			treeFiles.OptionsBehavior.AllowExpandOnDblClick = true;
			treeFiles.OptionsView.ShowColumns = true;
			treeFiles.OptionsView.ShowIndicator = false;
			treeFiles.OptionsView.ShowHorzLines = false;
			treeFiles.OptionsView.ShowVertLines = false;
			treeFiles.OptionsView.AutoWidth = false;
			treeFiles.OptionsView.EnableAppearanceEvenRow = false;
			treeFiles.OptionsView.EnableAppearanceOddRow = false;
			treeFiles.StateImageList = ic;

			#region GetStateImage
			treeFiles.GetStateImage += delegate (object sender, GetStateImageEventArgs e)
			{
				if (e.Node["Type"].ToString() == "D")
				{
					if (e.Node["Name"].ToString() == "상위폴더")
						e.NodeImageIndex = 3;
					else
						e.NodeImageIndex = 0;
				}
				else if (e.Node["Type"].ToString() == "F")
				{
					e.NodeImageIndex = 2;
				}
			};
			#endregion

			#region MouseDoubleClick
			treeFiles.MouseDoubleClick += delegate (object sender, MouseEventArgs e)
			{
				try
				{
					var tree = sender as XTree;
					var info = tree.CalcHitInfo(tree.PointToClient(MousePosition));

					if (info.HitInfoType == HitInfoType.Cell && !info.Node.HasChildren && info.Node["Type"].ToString() == "D")
					{
						DetailDataLoad(info.Node["FullName"].ToStringNullToEmpty());
					}
				}
				catch (Exception ex)
				{
					ShowErrBox(ex);
				}
			};
			#endregion

			#region MouseClick
			treeFiles.MouseClick += delegate (object sender, MouseEventArgs e)
			{
				try
				{
					var tree = sender as XTree;
					var info = tree.CalcHitInfo(tree.PointToClient(MousePosition));

					if (info.HitInfoType == HitInfoType.Cell && !info.Node.HasChildren && info.Node["Type"].ToString() == "F")
					{
						string filePath = string.Concat(ConstsVar.IMG_URL, info.Node["FullName"].ToString());
						picImage.LoadAsync(filePath);
						memFileInfo.Text = filePath;
					}
				}
				catch (Exception ex)
				{
					ShowErrBox(ex);
				}
			};
			#endregion

			treeFiles.AddColumn("Name", "Name", HorzAlignment.Near);
			treeFiles.AddColumn("Size", "Size", HorzAlignment.Far);
			treeFiles.AddColumn("ModifiedDate", "Modified Date", HorzAlignment.Center);
			treeFiles.AddColumn("FullName", false);
			treeFiles.AddColumn("ID", false);
			treeFiles.AddColumn("ParentID", false);
			treeFiles.AddColumn("Type", false);

			treeFiles.SetWidth("Name", 300);
			treeFiles.SetWidth("Size", 80);
			treeFiles.SetWidth("ModifiedDate", 180);

			treeFiles.ParentFieldName = "ParentID";
			treeFiles.KeyFieldName = "ID";
			treeFiles.RootValue = 0;
			#endregion
		}

		protected override void LoadForm()
		{
			base.LoadForm();
			DataLoad(null);
		}

		protected override void DataLoad(object param = null)
		{
			treeDirectories.DataSource = null;
			treeFiles.DataSource = null;
			esPath.Text = " ";

			var list = FTPHandler.GetList("/", FtpListType.Directory, pbarDir);
			treeDirectories.DataSource = list;
			if (list != null && list.Count > 0)
			{
				treeDirectories.ExpandLevel(1);
			}

			if (param != null)
				DetailDataLoad(param);
			else
				DataInit();
		}

		void DetailDataLoad(object id)
		{
			try
			{
				picImage.EditValue = null;
				memFileInfo.EditValue = null;
				esPath.Text = id.ToStringNullToEmpty();
				var list = FTPHandler.GetList(id.ToString(), FtpListType.All, pBarFiles);				
				treeFiles.DataSource = list;
				treeFiles.ExpandLevel(1);
			}
			catch(Exception ex)
			{
				ShowErrBox(ex);
			}
		}

		void doTagCopy()
		{
			var node = treeFiles.FocusedNode;
			if (node != null && node["Type"].ToString() == "F")
			{
				string tag = @"< img src = ""http://" + node["FullName"].ToString() + @" alt = """" border = ""0"" >";
				Clipboard.SetText(tag, TextDataFormat.Html);
			}
		}

		void doUpload()
		{
			try
			{
				var info = DialogUtils.OpenImageFile();
				if (info != null)
				{
					FTPHandler.Upload(info.FullName, esPath.Text + "/" + info.Name);
					DetailDataLoad(esPath.Text);
				}
			}
			catch(Exception ex)
			{
				ShowErrBox(ex);
			}
		}

		void doDelete()
		{
			try
			{
				var node = treeFiles.FocusedNode;
				if (node != null)
				{
					string type = node["Type"].ToString();
					string fullName = node["FullName"].ToStringNullToEmpty();

					if (fullName.IsNullOrEmpty() == false)
					{
						if (type == "F")
						{
							if (MsgBox.Show("선택한 파일을 삭제하겠습니까?" + Environment.NewLine + fullName, "확인!!", MessageBoxButtons.YesNo) != DialogResult.Yes)
								return;
							FTPHandler.DeleteFile(fullName);
						}
						else if (type == "D")
						{
							if (MsgBox.Show("선택한 폴더를 삭제하겠습니까?" + Environment.NewLine + fullName, "확인!!", MessageBoxButtons.YesNo) != DialogResult.Yes)
								return;
							FTPHandler.DeleteDirectory(fullName);
						}
						DetailDataLoad(esPath.Text);
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