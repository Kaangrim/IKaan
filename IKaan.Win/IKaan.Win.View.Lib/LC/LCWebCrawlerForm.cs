using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
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
	public partial class LCWebCrawlerForm : EditForm
	{
		private bool bContinue = true;

		public LCWebCrawlerForm()
		{
			InitializeComponent();

			btnStart.Click += (object sender, EventArgs e) => { StartCrawling(); };
			btnStop.Click += (object sender, EventArgs e) => { StopCrawling(); };
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

				InitGrid();
			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}

		void InitGrid()
		{
			#region Site List
			gridSiteList.Init();
			gridSiteList.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "Checked" },
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
			gridSiteList.ColumnFix("RowNo");
			gridSiteList.SetRepositoryItemCheckEdit("Checked");
			gridSiteList.SetEditable("Checked");
			#endregion

			#region Brand List
			gridBrandList.Init();
			gridBrandList.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "BrandCode", Width = 80, Visible = false },
				new XGridColumn() { FieldName = "BrandName", Width = 150 },
				new XGridColumn() { FieldName = "GoodsCount", Width = 60, HorzAlignment = HorzAlignment.Far },
				new XGridColumn() { FieldName = "BrandUrl", Width = 200 }
			);
			gridBrandList.ColumnFix("RowNo");
			#endregion

			#region Goods List
			gridGoodsList.Init();
			gridGoodsList.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "GoodsCode", Width = 100, Visible = false },
				new XGridColumn() { FieldName = "GoodsName", Width = 200 },
				new XGridColumn() { FieldName = "ListPrice", Width = 90, HorzAlignment = HorzAlignment.Far, FormatType = FormatType.Numeric, FormatString = "N0" },
				new XGridColumn() { FieldName = "SalePrice", Width = 90, HorzAlignment = HorzAlignment.Far, FormatType = FormatType.Numeric, FormatString = "N0" },
				new XGridColumn() { FieldName = "Options", Width = 100 },
				new XGridColumn() { FieldName = "Category", Width = 100 },
				new XGridColumn() { FieldName = "GoodsUrl", Width = 200 }
			);
			gridGoodsList.ColumnFix("RowNo");
			#endregion
		}

		protected override void LoadForm()
		{
			base.LoadForm();
			DataLoad();
		}
		
		protected override void DataLoad(object param = null)
		{
			gridSiteList.BindList<ACCode>("AC", "GetList", "Select", new DataMap()
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

		private void InitCrawling()
		{
			bContinue = true;

			gridBrandList.DataSource = null;
			gridGoodsList.DataSource = null;

		}

		private void StartCrawling()
		{
			try
			{
				if (gridSiteList.DataSource == null || gridSiteList.RowCount == 0)
					return;

				InitCrawling();

				btnStart.Enabled = false;
				btnStop.Enabled = true;
				progSiteList.Properties.Maximum = gridSiteList.RowCount;
				Application.DoEvents();

				for (int i = 0; i < gridSiteList.RowCount; i++)
				{
					if (bContinue == false)
						break;

					progSiteList.EditValue = (i + 1);
					gridSiteList.SelectRow(i);
					Application.DoEvents();

					if (gridSiteList.GetValue(i, "Checked").ToStringNullToEmpty() != "Y")
						continue;

					string url = gridSiteList.GetValue(i, "Value").ToStringNullToEmpty();
					string site = gridSiteList.GetValue(i, "CodeValue01").ToStringNullToEmpty();

					if (url.IsNullOrEmpty() || site.IsNullOrEmpty())
						continue;

					if (site == "http://www.wconcept.co.kr")
						CrawlWConcept(site, url);

					Application.DoEvents();
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

		private void CrawlWConcept(string site, string url)
		{
			try
			{
				//초기화
				gridBrandList.DataSource = null;
				gridGoodsList.DataSource = null;
				memScript.EditValue = null;

				int gcount = 0;
				int bcount = 0;
				CookieCollection Cookies = new CookieCollection();
				HtmlWeb web = new HtmlWeb()
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

				//크롤링 사이트 로딩
				HtmlAgilityPack.HtmlDocument doc = web.Load(url);

				//브랜드목록 추출
				if (doc != null)
				{
					memScript.Text = doc.DocumentNode.SelectSingleNode("//body").OuterHtml;

					//브랜드 추출
					int i = 0;
					var nodes = doc.DocumentNode.SelectNodes("//a[@href]");
					if (nodes != null)
					{
						progBrandList.Properties.Maximum = nodes.Count;
						Application.DoEvents();

						foreach (HtmlNode link in nodes)
						{
							if (bContinue == false)
								break;

							i++;
							progBrandList.EditValue = (i + 1);
							SetMessage(string.Format("브랜드검색=> {0}/{1}", (i + 1), nodes.Count));
							Application.DoEvents();

							HtmlAttribute att = link.Attributes["href"];
							if (att.Value.IsNullOrEmpty() == false && att.Value.StartsWith("/ShopMain/BrandShop"))
							{
								if (gridBrandList.DataSource == null)
									gridBrandList.DataSource = new List<CrawlBrand>();

								string brandCode = att.Value.Replace(@"/ShopMain/BrandShop.cshtml?brandcd=", "").Replace("#paginganchor", "");
								string brandName = att.OwnerNode.InnerText;
								string brandUrl = att.Value;

								if (brandCode.IsNullOrEmpty() || brandName.IsNullOrEmpty() || brandUrl.IsNullOrEmpty())
									continue;

								if ((gridBrandList.DataSource as List<CrawlBrand>).Where(x => x.BrandCode == brandCode).Any())
									continue;

								bcount++;
								(gridBrandList.DataSource as List<CrawlBrand>).Add(new CrawlBrand()
								{
									RowNo = bcount,
									BrandCode = brandCode,
									BrandName = brandName,
									BrandUrl = brandUrl
								});
								gridBrandList.SelectRow(gridBrandList.RowCount - 1);
								Application.DoEvents();
							}
						}
					}
				}
				Application.DoEvents();

				//브랜드목록 저장
				if (gridBrandList.RowCount > 0)
				{
					SetMessage("브랜드목록을 저장하는 중입니다... 잠시만...");
					Application.DoEvents();

					IList<CrawlBrand> brandList = gridBrandList.DataSource as List<CrawlBrand>;


					//using(var res = WasHandler.Execute<>("SW", "Save", "", ))
					//{

					//}

					Application.DoEvents();
				}

				//상품목록 추출
				if (gridBrandList.RowCount > 0)
				{
					progBrandList.Properties.Maximum = gridBrandList.RowCount;
					Application.DoEvents();

					for (int rowIndex = 0; rowIndex < gridBrandList.RowCount; rowIndex++)
					{
						if (bContinue == false)
							break;

						gridBrandList.SelectRow(rowIndex);
						progBrandList.EditValue = (rowIndex + 1);
						Application.DoEvents();

						string pageIndex = "1";
						string pageTotal = "10000";
						string listUrl = site + @"/ShopMain/_Partial/_Brand/BrandDetailList.cshtml";
						string brandCode = gridBrandList.GetValue(rowIndex, "BrandCode").ToStringNullToEmpty();

						if (brandCode.IsNullOrEmpty())
							continue;

						string postUrl = string.Concat(
							listUrl, 
							"?PageIndex=", 
							pageIndex, 
							"&maxdisp=", 
							pageTotal, 
							"&brandcd=", 
							brandCode, 
							"&sortnum=1&myheart=N&searchCategoryCd=&searchBrandCd=&searchMaxPrice=&searchSize=&searchColor=");

						doc = web.Load(postUrl, "POST");

						if (doc == null)
							continue;

						memScript.Text = doc.DocumentNode.OuterHtml;
						Application.DoEvents();

						string goodsUrl = string.Empty;
						string goodsCode = string.Empty;
						string goodsName = string.Empty;
						string listPrice = string.Empty;
						string salePrice = string.Empty;
						int lcount = 0;

						HtmlNodeCollection links = doc.DocumentNode.SelectNodes("//div[@class='thumbnail_list']//ul//li");
						if (links == null || links.Count == 0)
							continue;

						gridBrandList.SetValue(rowIndex, "GoodsCount", links.Count);
						progGoodsList.Properties.Maximum = links.Count;
						Application.DoEvents();

						foreach (HtmlNode link in links)
						{
							lcount++;
							progGoodsList.EditValue = lcount;
							SetMessage(string.Format("상품처리=> {0}/{1}", lcount, links.Count));
							Application.DoEvents();

							goodsUrl = string.Empty;
							goodsCode = string.Empty;
							goodsName = string.Empty;
							listPrice = string.Empty;
							salePrice = string.Empty;

							HtmlNode nodeGoodsUrl = link.SelectSingleNode(".//a[@href]");
							if (nodeGoodsUrl != null)
							{
								HtmlAttribute attrGoodsUrl = nodeGoodsUrl.Attributes["href"];
								if (attrGoodsUrl != null)
									goodsUrl = attrGoodsUrl.Value;
							}

							if (goodsUrl.IsNullOrEmpty() == false)
								goodsCode = goodsUrl.Substring(goodsUrl.LastIndexOf("itemcd=") + 7);

							HtmlNode nodeGoodsName = link.SelectSingleNode(".//div[@class='product ellipsis']");
							if (nodeGoodsName != null)
								goodsName = nodeGoodsName.InnerText;

							HtmlNode nodeListPrice = link.SelectSingleNode(".//span[@class='base_price']");
							if (nodeListPrice != null)
								listPrice = nodeListPrice.InnerText;

							HtmlNode nodeSalePrice = link.SelectSingleNode(".//span[@class='discount_price']");
							if (nodeSalePrice != null)
								salePrice = nodeSalePrice.InnerText;

							if (goodsCode != null)
							{
								if (gridGoodsList.DataSource == null)
									gridGoodsList.DataSource = new List<CrawlGoods>();

								if ((gridGoodsList.DataSource as List<CrawlGoods>).Where(x => x.GoodsCode == goodsCode).Any())
									continue;

								gcount++;
								(gridGoodsList.DataSource as List<CrawlGoods>).Add(new CrawlGoods()
								{
									RowNo = gcount,
									BrandCode = brandCode,
									GoodsCode = goodsCode,
									GoodsName = goodsName,
									ListPrice = listPrice.Replace(",","").ToIntegerNullToZero(),
									SalePrice = salePrice.Replace(",", "").ToIntegerNullToZero()
								});
								gridGoodsList.SelectRow(gridGoodsList.RowCount - 1);
								Application.DoEvents();
							}
						}
						Application.DoEvents();
					}
				}
				Application.DoEvents();

				//상품정보 저장
				if (gridGoodsList.RowCount > 0)
				{
					progGoodsList.Properties.Maximum = gridGoodsList.RowCount;
					Application.DoEvents();

					for (int rowIndex = 0; rowIndex < gridGoodsList.RowCount; rowIndex++)
					{
						if (bContinue == false)
							break;

						picImage.EditValue = null;
						gridGoodsList.SelectRow(rowIndex);
						progGoodsList.EditValue = (rowIndex + 1);
						Application.DoEvents();

						string dtlUrl = gridGoodsList.GetValue(rowIndex, "GoodsUrl").ToStringNullToEmpty();
						if (dtlUrl.IsNullOrEmpty())
							continue;

						doc = web.Load(dtlUrl);
						if (doc == null)
							continue;

						string mcd = string.Empty;
						string ca = string.Empty;
						string itemCd = string.Empty;
						string imageUrl = string.Empty;
						string category = string.Empty;

						//카테고리
						HtmlNodeCollection catLinks = doc.DocumentNode.SelectNodes("//div[@class='pdt']//ul[@class='location']//li");
						if (catLinks != null && catLinks.Count > 0)
						{
							foreach (HtmlNode node in catLinks)
							{
								HtmlNode catNode = node.SelectSingleNode(".//button");
								if (catNode != null)
								{
									if (category.IsNullOrEmpty())
										category = catNode.InnerText;
									else
										category = string.Concat(category, ">", catNode.InnerText);
								}
							}
						}

						//상품 메인이미지 경로 가져오기
						HtmlNodeCollection linkNodes = doc.DocumentNode.SelectNodes("//div[@class='img_area']");
						foreach (HtmlNode linkNode in linkNodes)
						{
							HtmlNode imageNode = linkNode.SelectSingleNode(".//img[@id='img_01']");
							HtmlAttribute src = imageNode.Attributes["src"];
							if (src != null)
							{
								imageUrl = src.Value;
								picImage.LoadAsync(string.Concat(site, imageUrl));
								gridGoodsList.SetValue(rowIndex, "ImageUrl", imageUrl);
							}
						}

						//상품설명 가져오기
						HtmlNode productForm = doc.GetElementbyId("frmproduct");
						if (productForm == null)
							continue;

						foreach (HtmlNode node in productForm.Elements("input"))
						{
							HtmlAttribute valueAttribute = node.Attributes["value"];
							if (valueAttribute != null)
							{
								if (node.Name == "mcd")
									mcd = valueAttribute.Value;
								else if (node.Name == "ca")
									ca = valueAttribute.Value;
								else if (node.Name == "itemcd")
									itemCd = valueAttribute.Value;
							}
						}
					}
				}
				Application.DoEvents();
			}
			catch
			{
				throw;
			}
		}

		public class CrawlBrand
		{
			public int RowNo { get; set; }
			public string BrandCode { get; set; }
			public string BrandName { get; set; }
			public string BrandUrl { get; set; }
			public int GoodsCount { get; set; }
		}

		public class CrawlGoods
		{
			public int RowNo { get; set; }
			public string BrandCode { get; set; }
			public string GoodsCode { get; set; }
			public string GoodsName { get; set; }
			public int ListPrice { get; set; }
			public int SalePrice { get; set; }
			public string GoodsUrl { get; set; }
			public string Options { get; set; }
			public string Category { get; set; }
			public string ImageUrl { get; set; }
		}
	}
}