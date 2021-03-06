﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using FluentFTP;
using IKaan.Base.Utils;
using IKaan.Win.Core.Enum;
using IKaan.Win.Core.Model;
using IKaan.Win.Core.Variables;

namespace IKaan.Win.Core.Handler
{
	public class FTPHandler
	{
		private static int index = 0;
		private static int parentID = 0;

		public static void Download(ImageServerInfo server, string remotePath, string localPath)
		{
			if (server == null)
				server = GlobalVar.ImageServerInfo;

			string fileName = Path.GetFileName(localPath);
			if (remotePath.IsNullOrEmpty())
				remotePath = "/LIB/" + fileName;

			using (var ftp = new FtpClient())
			{
				ftp.Host = server.FtpUrl;
				ftp.Credentials = new System.Net.NetworkCredential(server.ID, server.PW);
				ftp.Connect();
				ftp.UploadFile(localPath, remotePath);
				ftp.Disconnect();
			}
		}

		public static void Upload(ImageServerInfo server, string localPath, string remotePath)
		{
			try
			{
				if (server == null)
					server = GlobalVar.ImageServerInfo;

				string fileName = Path.GetFileName(localPath);
				if (remotePath.IsNullOrEmpty())
					remotePath = "/LIB/" + fileName;

				using (var ftp = new FtpClient())
				{
					ftp.Host = server.FtpUrl;
					ftp.Credentials = new System.Net.NetworkCredential(server.ID, server.PW);
					ftp.Connect();
					if (ftp.FileExists(remotePath))
						ftp.DeleteFile(remotePath);
					ftp.UploadFile(localPath, remotePath);
					ftp.Disconnect();
				}
			}
			catch
			{
				throw;
			}
		}
		public static string UploadGoods(ImageServerInfo server, string localPath, string brandID, string goodsID, string type, string group)
		{
			try
			{
				if (server == null)
					server = GlobalVar.ImageServerInfo;

				if (localPath.IsNullOrEmpty())
					throw new Exception("로컬 파일 경로가 정확하지 않습니다.");
				
				FileInfo info = new FileInfo(localPath);
				string ext = info.Extension;
				string fileName = string.Format(ConstsVar.FILE_DEFINE_GOODS, goodsID, type, group) + ext;

				if (fileName.IsNullOrEmpty())
					throw new Exception("업로드 이미지 구분이 올바르지 않습니다.");

				string remotePath = string.Format("{0}/{1}/{2}", ConstsVar.IMG_URL_GOODS, brandID, goodsID);
				string remoteFull = string.Format("{0}/{1}", remotePath, fileName);

				using (var ftp = new FtpClient())
				{
					ftp.Host = server.FtpUrl;
					ftp.Credentials = new System.Net.NetworkCredential(server.ID, server.PW);
					ftp.Connect();
					if (ftp.DirectoryExists(remotePath) == false)
						ftp.CreateDirectory(remotePath);
					if (ftp.FileExists(remoteFull))
						ftp.DeleteFile(remoteFull);
					ftp.UploadFile(localPath, remoteFull);
					ftp.Disconnect();
				}
				return remoteFull;
			}
			catch
			{
				throw;
			}
		}
		public static string UploadSearchBrand(ImageServerInfo server, string localPath, string brandID, string type)
		{
			try
			{
				if (server == null)
					server = GlobalVar.ImageServerInfo;

				if (localPath.IsNullOrEmpty())
					throw new Exception("로컬 파일 경로가 정확하지 않습니다.");

				string fileName = string.Empty;
				FileInfo info = new FileInfo(localPath);
				string ext = info.Extension;
				if (type.Equals("LOGO"))
					fileName = string.Format(ConstsVar.FILE_DEFINE_BRAND_LOGO, brandID) + ext;
				else if (type.Equals("MAIN"))
					fileName = string.Format(ConstsVar.FILE_DEFINE_BRAND_MAIN, brandID) + ext;
				else
					throw new Exception("업로드 이미지 구분이 올바르지 않습니다.");

				string remotePath = ConstsVar.IMG_URL_SEARCH_BRAND + "/" + brandID;
				string remoteFull = remotePath + "/" + fileName;

				using (var ftp = new FtpClient())
				{
					ftp.Host = server.FtpUrl;
					ftp.Credentials = new System.Net.NetworkCredential(server.ID, server.PW);
					ftp.Connect();
					if (ftp.DirectoryExists(remotePath) == false)
						ftp.CreateDirectory(remotePath);
					if (ftp.FileExists(remoteFull))
						ftp.DeleteFile(remoteFull);
					ftp.UploadFile(localPath, remoteFull);
					ftp.Disconnect();
				}
				return remoteFull;
			}
			catch
			{
				throw;
			}
		}
		public static string UploadBrand(ImageServerInfo server, string localPath, string brandID, string type)
		{
			try
			{
				if (server == null)
					server = GlobalVar.ImageServerInfo;

				if (localPath.IsNullOrEmpty())
					throw new Exception("로컬 파일 경로가 정확하지 않습니다.");
				
				FileInfo info = new FileInfo(localPath);
				string ext = info.Extension;
				string fileName = brandID + "_" + type + ext;
				string remotePath = ConstsVar.IMG_URL_BRAND + "/" + brandID;
				string remoteFull = remotePath + "/" + fileName;

				using (var ftp = new FtpClient())
				{
					ftp.Host = server.FtpUrl;
					ftp.Credentials = new System.Net.NetworkCredential(server.ID, server.PW);
					ftp.Connect();
					if (ftp.DirectoryExists(remotePath) == false)
						ftp.CreateDirectory(remotePath);
					if (ftp.FileExists(remoteFull))
						ftp.DeleteFile(remoteFull);
					ftp.UploadFile(localPath, remoteFull);
					ftp.Disconnect();
				}
				return remoteFull;
			}
			catch
			{
				throw;
			}
		}
		public static string UploadEmployee(ImageServerInfo server, string localPath, string employeeNo)
		{
			try
			{
				if (server == null)
					server = GlobalVar.ImageServerInfo;

				if (localPath.IsNullOrEmpty())
					throw new Exception("로컬 파일 경로가 정확하지 않습니다.");

				FileInfo info = new FileInfo(localPath);
				string ext = info.Extension;
				string fileName = string.Format(ConstsVar.FILE_DEFINE_EMPLOYEE, employeeNo) + ext;
				string remotePath = ConstsVar.IMG_URL_EMPLOYEE;
				string remoteFull = remotePath + "/" + fileName;

				using (var ftp = new FtpClient())
				{
					ftp.Host = server.FtpUrl;
					ftp.Credentials = new System.Net.NetworkCredential(server.ID, server.PW);
					ftp.Connect();
					if (ftp.DirectoryExists(remotePath) == false)
						ftp.CreateDirectory(remotePath);
					if (ftp.FileExists(remoteFull))
						ftp.DeleteFile(remoteFull);
					ftp.UploadFile(localPath, remoteFull);
					ftp.Disconnect();
				}
				return remoteFull;
			}
			catch
			{
				throw;
			}
		}
		public static string UploadBusiness(ImageServerInfo server, string localPath, string bizNo)
		{
			try
			{
				if (server == null)
					server = GlobalVar.ImageServerInfo;

				if (localPath.IsNullOrEmpty())
					throw new Exception("로컬 파일 경로가 정확하지 않습니다.");

				FileInfo info = new FileInfo(localPath);
				string ext = info.Extension;
				string fileName = string.Format(ConstsVar.FILE_DEFINE_BUSINESS, bizNo) + ext;
				string remotePath = ConstsVar.IMG_URL_BUSINESS;
				string remoteFull = remotePath + "/" + fileName;

				using (var ftp = new FtpClient())
				{
					ftp.Host = server.FtpUrl;
					ftp.Credentials = new System.Net.NetworkCredential(server.ID, server.PW);
					ftp.Connect();
					if (ftp.DirectoryExists(remotePath) == false)
						ftp.CreateDirectory(remotePath);
					if (ftp.FileExists(remoteFull))
						ftp.DeleteFile(remoteFull);
					ftp.UploadFile(localPath, remoteFull);
					ftp.Disconnect();
				}
				return remoteFull;
			}
			catch
			{
				throw;
			}
		}
		public static string UploadBank(ImageServerInfo server, string localPath, string bankName, string accountNo)
		{
			try
			{
				if (server == null)
					server = GlobalVar.ImageServerInfo;

				if (localPath.IsNullOrEmpty())
					throw new Exception("로컬 파일 경로가 정확하지 않습니다.");

				FileInfo info = new FileInfo(localPath);
				string ext = info.Extension;
				string fileName = string.Format(ConstsVar.FILE_DEFINE_BANK, bankName+"_" + accountNo) + ext;
				string remotePath = ConstsVar.IMG_URL_BANK;
				string remoteFull = remotePath + "/" + fileName;

				using (var ftp = new FtpClient())
				{
					ftp.Host = server.FtpUrl;
					ftp.Credentials = new System.Net.NetworkCredential(server.ID, server.PW);
					ftp.Connect();
					if (ftp.DirectoryExists(remotePath) == false)
						ftp.CreateDirectory(remotePath);
					if (ftp.FileExists(remoteFull))
						ftp.DeleteFile(remoteFull);
					ftp.UploadFile(localPath, remoteFull);
					ftp.Disconnect();
				}
				return remoteFull;
			}
			catch
			{
				throw;
			}
		}
		public static string UploadStore(ImageServerInfo server, string localPath, string storeName)
		{
			try
			{
				if (server == null)
					server = GlobalVar.ImageServerInfo;

				if (localPath.IsNullOrEmpty())
					throw new Exception("로컬 파일 경로가 정확하지 않습니다.");

				FileInfo info = new FileInfo(localPath);
				string ext = info.Extension;
				string fileName = string.Format(ConstsVar.FILE_DEFINE_STORE, storeName) + ext;
				string remotePath = ConstsVar.IMG_URL_STORE;
				string remoteFull = remotePath + "/" + fileName;

				using (var ftp = new FtpClient())
				{
					ftp.Host = server.FtpUrl;
					ftp.Credentials = new System.Net.NetworkCredential(server.ID, server.PW);
					ftp.Connect();
					if (ftp.DirectoryExists(remotePath) == false)
						ftp.CreateDirectory(remotePath);
					if (ftp.FileExists(remoteFull))
						ftp.DeleteFile(remoteFull);
					ftp.UploadFile(localPath, remoteFull);
					ftp.Disconnect();
				}
				return remoteFull;
			}
			catch
			{
				throw;
			}
		}

		public static string UploadScrapProduct(ImageServerInfo server, string siteUrl, string imageName, string brandName)
		{
			try
			{
				if (server == null)
					server = GlobalVar.ImageServerInfo;

				string localPath = GlobalVar.ScrapInfo.ProductFilePath + "\\" + siteUrl.Replace(".", "").Replace("/", "").Replace(":", "") + "\\" + brandName + "\\" + imageName;
				if (localPath.IsNullOrEmpty())
					throw new Exception("로컬 파일 경로가 정확하지 않습니다.");

				string fileName = imageName;

				if (fileName.IsNullOrEmpty())
					throw new Exception("업로드 이미지 구분이 올바르지 않습니다.");

				string remotePath = string.Format("{0}/{1}", ConstsVar.IMG_URL_PRODUCT_SCRAP, brandName);
				string remoteFull = string.Format("{0}/{1}", remotePath, fileName);

				using (var ftp = new FtpClient())
				{
					ftp.Host = server.FtpUrl;
					ftp.Credentials = new System.Net.NetworkCredential(server.ID, server.PW);
					ftp.Connect();
					if (ftp.DirectoryExists(remotePath) == false)
						ftp.CreateDirectory(remotePath);
					if (ftp.FileExists(remoteFull))
						ftp.DeleteFile(remoteFull);
					ftp.UploadFile(localPath, remoteFull);
					ftp.Disconnect();
				}
				return remoteFull;
			}
			catch
			{
				throw;
			}
		}

		public static string UploadSmapsAgency(ImageServerInfo server, string localPath, string agencyName)
		{
			try
			{
				if (server == null)
					server = GlobalVar.ImageServerInfo;

				if (localPath.IsNullOrEmpty())
					throw new Exception("로컬 파일 경로가 정확하지 않습니다.");

				var info = new FileInfo(localPath);
				string ext = info.Extension;
				string fileName = agencyName + ext;
				string remotePath = ConstsVar.IMG_URL_SMAPS_AGENCY;
				string remoteFull = remotePath + "/" + fileName;

				using (var ftp = new FtpClient())
				{
					ftp.Host = server.FtpUrl;
					ftp.Credentials = new System.Net.NetworkCredential(server.ID, server.PW);
					ftp.Connect();
					if (ftp.DirectoryExists(remotePath) == false)
						ftp.CreateDirectory(remotePath);
					if (ftp.FileExists(remoteFull))
						ftp.DeleteFile(remoteFull);
					ftp.UploadFile(localPath, remoteFull);
					ftp.Disconnect();
				}
				return remoteFull;
			}
			catch
			{
				throw;
			}
		}

		public static void DeleteFile(ImageServerInfo server, string remotePath)
		{
			try
			{
				if (server == null)
					server = GlobalVar.ImageServerInfo;

				if (remotePath.IsNullOrEmpty())
					return;

				using (var ftp = new FtpClient())
				{
					ftp.Host = server.FtpUrl;
					ftp.Credentials = new System.Net.NetworkCredential(server.ID, server.PW);
					ftp.Connect();
					if (ftp.FileExists(remotePath))
						ftp.DeleteFile(remotePath);
					ftp.Disconnect();
				}
			}
			catch
			{
				throw;
			}
		}
		public static void DeleteDirectory(ImageServerInfo server, string remotePath)
		{
			try
			{
				if (server == null)
					server = GlobalVar.ImageServerInfo;

				if (remotePath.IsNullOrEmpty())
					return;

				using (var ftp = new FtpClient())
				{
					ftp.Host = server.FtpUrl;
					ftp.Credentials = new System.Net.NetworkCredential(server.ID, server.PW);
					ftp.Connect();
					if (ftp.DirectoryExists(remotePath))
						ftp.DeleteDirectory(remotePath);
					ftp.Disconnect();
				}
			}
			catch
			{
				throw;
			}
		}

		public static IList<FtpList> GetDirectoriesReclusive(ImageServerInfo server, string rootDir = null, Control progressBar = null)
		{
			if (server == null)
				server = GlobalVar.ImageServerInfo;

			List<FtpList> list = new List<FtpList>();

			using (var ftp = new FtpClient())
			{
				ftp.Host = server.FtpUrl;
				ftp.Credentials = new System.Net.NetworkCredential(server.ID, server.PW);
				ftp.Connect();

				if (rootDir.IsNullOrEmpty())
					rootDir = ftp.GetWorkingDirectory();

				list = GetDirectoriesReclusive(ftp, rootDir, null, progressBar);
				ftp.Disconnect();
			}

			return list;
		}

		private static List<FtpList> GetDirectoriesReclusive(FtpClient ftp, string rootDir = null, int? parentID = null, Control progressBar = null)
		{
			List<FtpList> list = new List<FtpList>();

			if (rootDir.IsNullOrEmpty())
				rootDir = ftp.GetWorkingDirectory();

			if (parentID == null)
			{
				list.Add(new FtpList() { ID = index, Name = "/", FullName = "/", ParentID = null });
				parentID = 0;
			}

			var dirlist = ftp.GetListing(rootDir, FtpListOption.Modify | FtpListOption.Size)
				.Where(x => x.Type == FtpFileSystemObjectType.Directory).ToList();

			if (dirlist != null && dirlist.Count > 0)
			{
				int max = dirlist.Count;
				int cur = 0;

				if (progressBar != null && parentID == 0)
				{
					((ProgressBarControl)progressBar).Properties.Maximum = max;
				}

				foreach (var item in dirlist)
				{
					index++;					
					if (progressBar != null && parentID == 0)
					{
						cur++;
						((ProgressBarControl)progressBar).EditValue = cur;
						Application.DoEvents();
					}

					list.Add(new FtpList() { ID = index, Name = item.Name, FullName = item.FullName, ParentID = parentID });
					var childs = GetDirectoriesReclusive(ftp, item.FullName, index);
					if (childs != null && childs.Count > 0)
						list.AddRange(childs);
				}
			}

			return list;
		}

		public static IList<FtpList> GetFiles(ImageServerInfo server, string rootDir = null, Control progressBar = null)
		{
			if (server == null)
				server = GlobalVar.ImageServerInfo;

			List<FtpList> list = new List<FtpList>();

			using (var ftp = new FtpClient())
			{
				ftp.Host = server.FtpUrl;
				ftp.Credentials = new System.Net.NetworkCredential(server.ID, server.PW);
				ftp.Connect();

				if (rootDir.IsNullOrEmpty())
					rootDir = ftp.GetWorkingDirectory();

				var filelist = ftp.GetListing(rootDir, FtpListOption.Modify | FtpListOption.Size)
				.Where(x => x.Type == FtpFileSystemObjectType.File).ToList();

				if (filelist != null && filelist.Count > 0)
				{
					int max = filelist.Count;
					int cur = 0;

					if (progressBar != null)
					{
						((ProgressBarControl)progressBar).Properties.Maximum = max;
					}

					foreach (var item in filelist)
					{
						index++;
						if (progressBar != null)
						{
							cur++;
							((ProgressBarControl)progressBar).EditValue = cur;
							Application.DoEvents();
						}
						long size = ftp.GetFileSize(item.FullName);
						DateTime time = ftp.GetModifiedTime(item.FullName);
						string timeStr = time.ToString();

						list.Add(new FtpList()
						{
							Name = item.Name,
							Size = size.BytesToMegaBytes().ToString("0.00") + "MB",
							FullName = item.FullName,
							ModifiedDate = timeStr,
							Checked = "N"
						});
					}
				}

				ftp.Disconnect();
			}

			return list;
		}

		public static IList<FtpList> GetList(ImageServerInfo server, string rootDir = null, FtpListType listType = FtpListType.All, Control progressBar = null)
		{
			if (server == null)
				server = GlobalVar.ImageServerInfo;

			index = 0;
			List<FtpList> list = new List<FtpList>();

			using (var ftp = new FtpClient())
			{
				ftp.Host = server.FtpUrl;
				ftp.Credentials = new System.Net.NetworkCredential(server.ID, server.PW);
				ftp.Connect();

				if (rootDir.IsNullOrEmpty())
					rootDir = ftp.GetWorkingDirectory();

				if (rootDir.IsNullOrEmpty() == false && rootDir != "/")
				{
					string[] dirArrName = rootDir.Split('/');
					string dirName = string.Empty;
					for (int i = 0; i < dirArrName.Length - 1; i++)
					{
						if (i == 0)
							dirName = dirArrName[i];
						else
							dirName += "/" + dirArrName[i];
					}

					if (dirName.IsNullOrEmpty() == false && dirName != "/")
					{
						index++;
						list.Add(new FtpList()
						{
							ID = index,
							ParentID = 0,
							Name = "상위폴더",
							FullName = dirName,
							Size = null,
							Type = "D",
							ModifiedDate = null,
							Checked = "N"
						});
					}
				}
				
				var alllist = ftp.GetListing(rootDir, FtpListOption.Modify | FtpListOption.Size).ToList();

				if (alllist != null && alllist.Count > 0)
				{
					int max = alllist.Count;
					int cur = 0;					

					List<FtpListItem> dirlist = new List<FtpListItem>();
					List<FtpListItem> filelist = new List<FtpListItem>();
					List<FtpListItem> linklist = new List<FtpListItem>();

					if (listType == FtpListType.All || listType == FtpListType.Directory)
					{
						dirlist = alllist.Where(x => x.Type == FtpFileSystemObjectType.Directory).ToList();
					}

					if (listType == FtpListType.All || listType == FtpListType.File)
					{
						filelist = alllist.Where(x => x.Type == FtpFileSystemObjectType.File).ToList();
					}

					if (listType == FtpListType.All || listType == FtpListType.Link)
					{
						linklist = alllist.Where(x => x.Type == FtpFileSystemObjectType.Link).ToList();
					}

					if (progressBar != null)
					{
						max = dirlist.Count + filelist.Count + linklist.Count;
						((ProgressBarControl)progressBar).Properties.Maximum = max;
					}

					//Directory
					foreach (var item in dirlist)
					{
						index++;
						if (progressBar != null)
						{
							cur++;
							((ProgressBarControl)progressBar).EditValue = cur;
							Application.DoEvents();
						}

						string time = item.Modified.ToString();
						if (time.StartsWith("00"))
							time = string.Empty;

						list.Add(new FtpList()
						{
							ID = index,
							ParentID = parentID,
							Name = item.Name,
							FullName = item.FullName,
							Size = null,
							Type = "D",
							ModifiedDate = time,
							Checked = "N"
						});
					}

					//File
					foreach (var item in filelist)
					{
						index++;
						if (progressBar != null)
						{
							cur++;
							((ProgressBarControl)progressBar).EditValue = cur;
							Application.DoEvents();
						}

						string time = item.Modified.ToString();
						if (time.StartsWith("00"))
							time = string.Empty;

						list.Add(new FtpList()
						{
							ID = index,
							ParentID = parentID,
							Name = item.Name,
							FullName = item.FullName,
							Size = item.Size.BytesToMegaBytes().ToString("0.00") + "MB",
							Type = "F",
							ModifiedDate = time,
							Checked = "N"
						});
					}

					foreach (var item in linklist)
					{
						index++;
						if (progressBar != null)
						{
							cur++;
							((ProgressBarControl)progressBar).EditValue = cur;
							Application.DoEvents();
						}

						string time = item.Modified.ToString();
						if (time.StartsWith("00"))
							time = string.Empty;

						list.Add(new FtpList()
						{
							ID = index,
							ParentID = parentID,
							Name = item.Name,
							FullName = item.FullName,
							Size = item.Size.BytesToMegaBytes().ToString("0.00") + "MB",
							Type = "L",
							ModifiedDate = time,
							Checked = "N"
						});
					}
				}

				ftp.Disconnect();
			}

			return list;
		}
	}
}
