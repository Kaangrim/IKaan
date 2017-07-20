﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using FluentFTP;
using IKaan.Base.Utils;
using IKaan.Biz.Core.Enum;
using IKaan.Biz.Core.Model;
using IKaan.Biz.Core.Variables;

namespace IKaan.Biz.Core.Handler
{
	public class FTPHandler
	{
		private static string url = ConstsVar.FTP_URL;
		private static string id = ConstsVar.FTP_ID;
		private static string pw = ConstsVar.FTP_PW;
		private static int index = 0;
		private static int parentID = 0;

		public static void Download(string remotePath, string localPath)
		{
			string fileName = Path.GetFileName(localPath);
			if (remotePath.IsNullOrEmpty())
				remotePath = "/LIB/" + fileName;

			using (var ftp = new FtpClient())
			{
				ftp.Host = url;
				ftp.Credentials = new System.Net.NetworkCredential(id, pw);
				ftp.Connect();
				ftp.UploadFile(localPath, remotePath);
				ftp.Disconnect();
			}
		}
		public static void Upload(string localPath, string remotePath)
		{
			try
			{
				string fileName = Path.GetFileName(localPath);
				if (remotePath.IsNullOrEmpty())
					remotePath = "/LIB/" + fileName;

				using (var ftp = new FtpClient())
				{
					ftp.Host = url;
					ftp.Credentials = new System.Net.NetworkCredential(id, pw);
					ftp.Connect();
					ftp.UploadFile(localPath, remotePath);
					ftp.Disconnect();
				}
			}
			catch
			{
				throw;
			}
		}
		public static void Delete(string remotePath, string type)
		{
			try
			{
				if (remotePath.IsNullOrEmpty())
					return;

				using (var ftp = new FtpClient())
				{
					ftp.Host = url;
					ftp.Credentials = new System.Net.NetworkCredential(id, pw);
					ftp.Connect();
					if (type == "F")
						ftp.DeleteFile(remotePath);
					else if (type == "D")
						ftp.DeleteDirectory(remotePath);
					ftp.Disconnect();
				}
			}
			catch
			{
				throw;
			}
		}

		public static IList<FtpList> GetDirectoriesReclusive(string rootDir = null, Control progressBar = null)
		{
			List<FtpList> list = new List<FtpList>();

			using (var ftp = new FtpClient())
			{
				ftp.Host = url;
				ftp.Credentials = new System.Net.NetworkCredential(id, pw);
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

		public static IList<FtpList> GetFiles(string rootDir = null, Control progressBar = null)
		{
			List<FtpList> list = new List<FtpList>();

			using (var ftp = new FtpClient())
			{
				ftp.Host = url;
				ftp.Credentials = new System.Net.NetworkCredential(id, pw);
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

		public static IList<FtpList> GetList(string rootDir = null, FtpListType listType = FtpListType.All, Control progressBar = null)
		{
			index = 0;
			List<FtpList> list = new List<FtpList>();

			using (var ftp = new FtpClient())
			{
				ftp.Host = url;
				ftp.Credentials = new System.Net.NetworkCredential(id, pw);
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

				index++;
				list.Add(new FtpList()
				{
					ID = index,
					ParentID = 0,
					Name = rootDir,
					FullName = rootDir,
					Size = null,
					Type = "D",
					ModifiedDate = null,
					Checked = "N"
				});

				parentID = index;
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
