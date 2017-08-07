using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using DevExpress.Utils;
using HtmlAgilityPack;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Win.Core.Controls.Grid;
using IKaan.Win.Core.Enum;
using IKaan.Win.Core.Forms;
using IKaan.Win.Core.Model;
using IKaan.Win.Core.Was.Handler;
using IKaan.Model.BIZ.BM;
using IKaan.Model.SYS.AC;

namespace IKaan.Win.View.Lib.LC
{
	public partial class LCWebCrawlerFormTemp : EditForm
	{
		private bool bContinue = true;
		private bool bEditing = false;

		public LCWebCrawlerFormTemp()
		{
			InitializeComponent();

			btnStart.Click += (object sender, EventArgs e) => { StartCrawling(); };
			btnStop.Click += (object sender, EventArgs e) => { StopCrawling(); };

			chkWebBrowser.CheckedChanged += (object sender, EventArgs e) =>
			{
				if (bEditing)
					return;

				bEditing = true;
				chkHtmlAgilityPack.Checked = false;
				bEditing = false;
			};
			chkHtmlAgilityPack.CheckedChanged += (object sender, EventArgs e) =>
			{
				if (bEditing)
					return;

				bEditing = true;
				chkWebBrowser.Checked = false;
				bEditing = false;
			};
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
			try
			{
				base.InitControls();

				SetFieldNames();

				btnStop.Enabled = false;
				btnStart.Enabled = true;
				bContinue = true;

				chkWebBrowser.Checked = true;
				chkHtmlAgilityPack.Checked = false;

				SetStatusColor(0);
				InitGrid();
				InitWebBrowser();
			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}

		void InitGrid()
		{
			#region List
			gridList.Init();
			gridList.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "Code", Visible = false },
				new XGridColumn() { FieldName = "Name", Width = 100 },
				new XGridColumn() { FieldName = "Value", Width = 200 },
				new XGridColumn() { FieldName = "CodeValue01", CaptionCode = "HostName", Width = 200 },
				new XGridColumn() { FieldName = "CreateDate", Width = 150, HorzAlignment = HorzAlignment.Center, FormatType = FormatType.DateTime, FormatString = "yyyy.MM.dd HH:mm:ss" },
				new XGridColumn() { FieldName = "CreateByName", Width = 80, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "UpdateDate", Width = 150, HorzAlignment = HorzAlignment.Center, FormatType = FormatType.DateTime, FormatString = "yyyy.MM.dd HH:mm:ss" },
				new XGridColumn() { FieldName = "UpdateByName", Width = 80, HorzAlignment = HorzAlignment.Center }
			);
			gridList.ColumnFix("RowNo");
			#endregion

			#region Brand
			gridBrand.Init();
			gridBrand.AddGridColumns(
				new XGridColumn() { FieldName = "BrandCode", Width = 80 },
				new XGridColumn() { FieldName = "BrandName", Width = 100 },
				new XGridColumn() { FieldName = "BrandUrl", Width = 200 }
			);
			#endregion

			#region Result
			gridGoods.Init();
			gridGoods.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "ResultCode", Visible = false },
				new XGridColumn() { FieldName = "ResultName", Width = 100 },
				new XGridColumn() { FieldName = "ResultValue", Width = 200 }
			);
			gridGoods.ColumnFix("RowNo");
			#endregion
		}

		void InitWebBrowser()
		{
			try
			{
				wb.ScriptErrorsSuppressed = false;

				wb.Navigating += (object sender, WebBrowserNavigatingEventArgs e) =>
				{
					this.Invoke(new MethodInvoker(delegate ()
					{
						SetStatusColor(1);
					}));
				};

				wb.Navigated += (object sender, WebBrowserNavigatedEventArgs e) =>
				{
					this.Invoke(new MethodInvoker(delegate ()
					{
						SetStatusColor(2);
					}));
				};

				wb.DocumentCompleted += (object sender, WebBrowserDocumentCompletedEventArgs e) =>
				{
					this.Invoke(new MethodInvoker(delegate ()
					{
						SetStatusColor(3);
					}));
				};
			}
			catch(Exception ex)
			{
				ShowErrBox(ex);
			}
		}

		private void SetStatusColor(int step)
		{
			esStatus1.AppearanceItemCaption.BackColor =
				esStatus2.AppearanceItemCaption.BackColor =
				esStatus3.AppearanceItemCaption.BackColor =
				esStatus4.AppearanceItemCaption.BackColor = Color.White;

			if (step == 1)
				esStatus1.AppearanceItemCaption.BackColor = Color.Red;
			else if (step == 2)
				esStatus2.AppearanceItemCaption.BackColor = Color.Red;
			else if (step == 3)
				esStatus3.AppearanceItemCaption.BackColor = Color.Red;
			else if (step == 4)
				esStatus4.AppearanceItemCaption.BackColor = Color.Red;
		}

		protected override void LoadForm()
		{
			base.LoadForm();
			DataLoad();
		}
		
		protected override void DataLoad(object param = null)
		{
			gridList.BindList<ACCode>("AC", "GetList", "Select", new DataMap()
			{
				{ "FindText", txtFindText.EditValue },
				{ "UseYn", "Y" },
				{ "ParentCode", "CrawlingSite" },
				{ "IsNotParent", "Y" }
			});
		}

		protected override void DataSave(object arg, SaveCallback callback)
		{
			try
			{
				var model = this.GetControlData<BMBrand>();

				using (var res = WasHandler.Execute<BMBrand>("BM", "Save", (this.EditMode == EditModeEnum.New) ? "Insert" : "Update", model, "ID"))
				{
					if (res.Error.Number != 0)
						throw new Exception(res.Error.Message);

					ShowMsgBox("저장하였습니다.");
					callback(arg, res.Result.ReturnValue);
				}
			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}

		private void StartCrawling()
		{
			try
			{
				if (gridList.DataSource == null || gridList.RowCount == 0)
					return;

				gridGoods.DataSource = null;
				gridBrand.DataSource = null;

				btnStart.Enabled = false;
				btnStop.Enabled = true;
				prgMainBar.Properties.Maximum = gridList.RowCount;
				Application.DoEvents();

				for (int i = 0; i < gridList.RowCount; i++)
				{
					if (bContinue == false)
						break;

					prgMainBar.EditValue = (i + 1);
					gridList.SelectRow(i);
					Application.DoEvents();

					string url = gridList.GetValue(i, "Value").ToStringNullToEmpty();
					if (url.IsNullOrEmpty())
						continue;

					if (chkHtmlAgilityPack.Checked)
						CrawlingHtmlAgilityPack(url, "Brand");
					else
						CrawlingWebBrowser(url, "Brand");

					Application.DoEvents();

					if (gridGoods.RowCount > 0)
					{
						DataSave();
						gridGoods.DataSource = null;
					}
				}
			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
			finally
			{
				btnStart.Enabled = true;
				btnStop.Enabled = false;
				bContinue = true;
			}
		}

		private void StopCrawling()
		{
			bContinue = false;
		}

		private void CrawlingHtmlAgilityPack(string url, string type)
		{
			try
			{
				HtmlWeb web = new HtmlWeb();
				HtmlAgilityPack.HtmlDocument doc = web.Load(url);

				if (doc != null)
				{
					memScript.Text = doc.DocumentNode.SelectSingleNode("//body").OuterHtml;

					ExtractAllTags(doc, "//a[@href]", type);

					if (type == "Brand")
						CrawlingBrand();
					else if (type == "GoodsList")
						CrawlingGoodsList();
				}
			}
			catch
			{
				throw;
			}
		}

		private void CrawlingWebBrowser(string url, string type)
		{
			try
			{
				if (bContinue == false)
					return;

				wb.Navigate(url);
				Application.DoEvents();

				if (WaitingWebBrowser(url) == 0)
				{
					HtmlAgilityPack.HtmlDocument html = new HtmlAgilityPack.HtmlDocument()
					{
						OptionOutputAsXml = true
					};
					html.LoadHtml(wb.DocumentText);

					if (html != null)
					{
						memScript.Text = html.DocumentNode.SelectSingleNode("//body").OuterHtml;

						ExtractAllTags(html, "//a[@href]", type);

						if (type == "Brand")
							CrawlingBrand();
						else if (type == "GoodsList")
							CrawlingGoodsList();
					}
				}
			}
			catch
			{
				throw;
			}
		}

		private void ExtractAllTags(HtmlAgilityPack.HtmlDocument doc, string xpath, string type)
		{
			List<CrawlResult> tags = new List<CrawlResult>();
			List<CrawlBrand> brands = new List<CrawlBrand>();
			int i = 0;
			var nodes = doc.DocumentNode.SelectNodes(xpath);
			if (nodes != null)
			{
				prgSubBar.Properties.Maximum = nodes.Count;
				Application.DoEvents();

				foreach (HtmlNode link in nodes)
				{
					i++;
					prgSubBar.EditValue = (i + 1);
					Application.DoEvents();

					if (type == "Brand")
					{
						var result = GetBrandResult(link, i);
						if (result != null)
							brands.Add(result);
					}
					else
					{
						var result = GetHrefResult(link, i);
						if (result != null)
							tags.Add(result);
					}
				}

				if (type == "Brand")
				{
					gridBrand.DataSource = brands;
				}
				else
				{
					if (gridGoods.DataSource == null)
						gridGoods.DataSource = new List<CrawlResult>();

					gridGoods.MainView.BeginUpdate();
					(gridGoods.DataSource as List<CrawlResult>).AddRange(tags);
					gridGoods.SelectRow(gridGoods.RowCount - 1);
					gridGoods.MainView.EndUpdate();
				}
			}
		}

		private CrawlResult GetHrefResult(HtmlNode node, int index)
		{
			HtmlAttribute att = node.Attributes["href"];
			return new CrawlResult()
			{
				RowNo = index,
				ResultCode = index.ToString("00000"),
				ResultName = att.OwnerNode.InnerText,
				ResultValue = att.Value
			};
		}

		private CrawlBrand GetBrandResult(HtmlNode node, int index)
		{
			HtmlAttribute att = node.Attributes["href"];
			if (att.Value.StartsWith("/ShopMain/BrandShop"))
			{
				return new CrawlBrand()
				{
					BrandCode = "",
					BrandName = att.OwnerNode.InnerText,
					BrandUrl = att.Value
				};
			}
			else
				return null;
		}

		private CrawlGoods GetGoodsResult(HtmlNode node, int index)
		{
			HtmlAttribute att = node.Attributes["href"];
			if (att.Value.StartsWith("/ShopMain/BrandShop"))
			{
				return new CrawlGoods()
				{
					GoodsCode = "",
					GoodsName = att.OwnerNode.InnerText,
					GoodsUrl = att.Value
				};
			}
			else
				return null;
		}

		private void CrawlingBrand()
		{
			for (int i = 0; i < gridBrand.RowCount; i++)
			{
				if (bContinue == false)
					break;

				SetStatusColor(4);
				gridBrand.SelectRow(i);
				Application.DoEvents();

				string host = gridList.GetValue(gridList.FocusedRowHandle, "CodeValue01").ToStringNullToEmpty();
				string url = gridBrand.GetValue(i, "BrandUrl").ToStringNullToEmpty();
				if (url.IsNullOrEmpty())
					continue;
			
				if (chkWebBrowser.Checked)
					CrawlingWebBrowser(string.Concat(host, url), "GoodsList");
				else
					CrawlingHtmlAgilityPack(string.Concat(host, url), "GoodsList");

				SetStatusColor(0);
				Application.DoEvents();
			}
		}

		private void CrawlingGoodsList()
		{
			CookieCollection Cookies = new CookieCollection();
			var web = new HtmlWeb()
			{
				OverrideEncoding = Encoding.UTF8,
				UseCookies = true
			};
			web.PreRequest += (request) =>
			{
				if (request.Method == "POST")
				{
					string payload = request.Address.Query;
					byte[] buff = Encoding.UTF8.GetBytes(payload.ToCharArray());
					request.ContentLength = buff.Length;
					request.ContentType = "application/x-www-form-urlencoded";
					System.IO.Stream reqStream = request.GetRequestStream();
					reqStream.Write(buff, 0, buff.Length);
				}

				request.CookieContainer.Add(Cookies);

				return true;
			};

			web.PostResponse += (request, response) =>
			{
				if (request.CookieContainer.Count > 0 || response.Cookies.Count > 0)
				{
					Cookies.Add(response.Cookies);
				}
			};

			string pageIndex = "1";
			string pageTotal = "21";
			string siteUrl = @"http://www.wconcept.co.kr";
			string baseUrl = siteUrl + @"/ShopMain/_Partial/_Brand/BrandDetailList.cshtml";

			for (int i = 0; i < gridBrand.RowCount; i++)
			{
				if (bContinue == false)
					break;

				gridBrand.SelectRow(i);
				Application.DoEvents();

				string brandCode = gridBrand.GetValue(i, "BrandUrl").ToStringNullToEmpty();
				if (brandCode.IsNullOrEmpty() == false)
				{
					brandCode = brandCode.Replace(@"/ShopMain/BrandShop.cshtml?brandcd=", "").Replace("#paginganchor", "");
					string urlToHit = string.Concat(baseUrl, "?PageIndex=", pageIndex, "&maxdisp=", pageTotal, "&brandcd=", brandCode, "&sortnum=1&myheart=N&searchCategoryCd=&searchBrandCd=&searchMaxPrice=&searchSize=&searchColor=");
					HtmlAgilityPack.HtmlDocument doc = web.Load(urlToHit, "POST");

					if (doc != null)
					{
						memScript.Text = doc.DocumentNode.OuterHtml;
						Application.DoEvents();
					}
				}
			}
		}

		private int WaitingWebBrowser(string url, int timeout = 0)
		{
			if (timeout == 0)
				timeout = 30;

			try
			{
				int _timeout = 0;
				while (wb.Url.ToStringNullToEmpty() != url ||
					wb.ReadyState != WebBrowserReadyState.Complete ||
					wb.Document == null ||
					wb.Document.Body == null)
				{
					if (bContinue == false)
					{
						wb.Stop();
						break;
					}

					if (_timeout > timeout)
					{
						wb.Stop();
						break;
					}

					_timeout++;
					Application.DoEvents();
					Thread.Sleep(100);
				}

				if (wb.Document == null || wb.Document.Body == null)
				{
					return -1;
				}
				return 0;
			}
			catch
			{
				throw;
			}
		}

		private void DataSave()
		{

		}

		private void AddBrand(CrawlBrand brand)
		{

		}
		private void AddGoods(CrawlResult goods)
		{

		}

		public class CrawlResult
		{
			public int RowNo { get; set; }
			public string ResultCode { get; set; }
			public string ResultName { get; set; }
			public string ResultValue { get; set; }
		}

		public class CrawlBrand
		{
			public string BrandCode { get; set; }
			public string BrandName { get; set; }
			public string BrandUrl { get; set; }
		}

		public class CrawlGoods
		{
			public string GoodsCode { get; set; }
			public string GoodsName { get; set; }
			public string ListPrice { get; set; }
			public string SalePrice { get; set; }
			public string GoodsUrl { get; set; }
		}
	}
}