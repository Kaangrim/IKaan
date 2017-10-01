using System;
using System.ComponentModel;
using System.IO;
using DevExpress.Utils.Menu;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Events;

namespace IKaan.Win.Core.Controls.Common
{
	public partial class XPicture : XtraUserControl
	{
		public XPicture()
		{
			InitializeComponent();
			Init();

			edit.ButtonClick += (object sender, ButtonPressedEventArgs e) =>
			{
				if (e.Button.Kind == ButtonPredefines.Ellipsis)
				{
					SelectImage();
				}
			};

			picture.PopupMenuShowing += (object sender, PopupMenuShowingEventArgs e)=>
			{
				foreach (DXMenuItem item in e.PopupMenu.Items)
				{
					switch (item.Caption)
					{
						case "Cut":
						case "Paste":
						case "Load":
						case "Take Picture from Camera":
							item.Visible = false;
							break;
						case "Delete":
						case "Save":
						case "Copy":
							if (picture.EditValue == null)
								item.Visible = false;
							else
								item.Visible = true;
							break;
						default:
							break;
					}
				}
			};

			picture.EditValueChanged += (object sender, EventArgs e)=>
			{
				if (picture.EditValue == null)
					DeleteImage();
			};
		}

		[Browsable(false)]
		public object EditValue { get { return picture.EditValue; } }

		[Browsable(false)]
		public object ImageID { get; set; }

		[Browsable(true)]
		public string ImageType { get; private set; }

		[Browsable(true)]
		public string ImagePath { get; private set; }

		[Browsable(true)]
		public string ImageUrl { get; private set; }

		[Browsable(true)]
		public int ImageWidth
		{
			get
			{
				return (picture.Image == null) ? 0 : picture.Image.Width;
			}
		}

		[Browsable(true)]
		public int ImageHeight
		{
			get
			{
				return (picture.Image == null) ? 0 : picture.Image.Height;
			}
		}

		[Browsable(true)]
		public PictureSizeMode SizeMode
		{
			get { return picture.Properties.SizeMode; }
			set { picture.Properties.SizeMode = value; }
		}

		[Browsable(true)]
		public bool ShowMenu
		{
			get { return picture.Properties.ShowMenu; }
			set { picture.Properties.ShowMenu = value; }
		}

		[Browsable(true)]
		public bool ShowEdit
		{
			get { return edit.Visible; }
			set { edit.Visible = value; }
		}

		private void Init()
		{
			picture.Properties.SizeMode = PictureSizeMode.Squeeze;
			picture.Properties.ShowMenu = true;
		}

		public void Clear()
		{
			ImageID = null;
			ImagePath = null;
			ImageUrl = null;
			edit.EditValue = null;
			picture.EditValue = null;
		}

		public void LoadImage(string url)
		{
			ImagePath = null;
			ImageUrl = url;
			picture.LoadAsync(url);
			edit.EditValue = url;
		}

		public void SelectImage()
		{
			var path = picture.GetLoadedImageLocation();
			picture.LoadImage();
			if (picture.EditValue != null)
			{
				if (path != picture.GetLoadedImageLocation())
				{
					ImagePath = picture.GetLoadedImageLocation();
					ImageUrl = null;
					edit.EditValue = ImagePath;
				}
			}
		}

		public void DeleteImage()
		{
			picture.EditValue = null;
			edit.EditValue = null;
		}

		public string GetFileName()
		{
			if (string.IsNullOrEmpty(ImagePath))
				return null;
			else
				return Path.GetFileName(ImagePath);
		}
	}
}
