using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Windows.Forms;
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
			try
			{
				using (var dialog = new OpenFileDialog()
				{
					Filter = GetImageFilter(),
					FilterIndex = 1,
					RestoreDirectory = true
				})
				{
					if (dialog.ShowDialog() == DialogResult.OK)
					{
						ImagePath = dialog.FileName;
						ImageUrl = null;
						edit.EditValue = ImagePath;
						picture.LoadAsync(ImagePath);
					}
				}
			}
			catch
			{
				throw;
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

		private string GetImageFilter()
		{
			StringBuilder allImageExtensions = new StringBuilder();
			string separator = "";
			ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
			Dictionary<string, string> images = new Dictionary<string, string>();
			foreach (var codec in codecs)
			{
				allImageExtensions.Append(separator);
				allImageExtensions.Append(codec.FilenameExtension);
				separator = ";";
				images.Add(string.Format("{0} Files: ({1})", codec.FormatDescription, codec.FilenameExtension), codec.FilenameExtension);
			}
			StringBuilder sb = new StringBuilder();
			if (allImageExtensions.Length > 0)
			{
				sb.AppendFormat("{0}|{1}", "All Images", allImageExtensions.ToString());
			}
			images.Add("All Files", "*.*");
			foreach(KeyValuePair<string, string> image in images)
			{
				sb.AppendFormat("|{0}|{1}", image.Key, image.Value);
			}
			return sb.ToString();
		}
	}
}
