using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using HtmlAgilityPack;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Model.IKBase;
using IKaan.Model.IKScrap;
using IKaan.Win.Core.Controls.Grid;
using IKaan.Win.Core.Forms;
using IKaan.Win.Core.Model;
using IKaan.Win.Core.Utils;
using IKaan.Win.Core.Was.Handler;

namespace IKaan.Win.View.Scrap.Forms
{
	public partial class WebCrawlerEditForm : EditForm
	{
		private bool bContinue = true;

		public WebCrawlerEditForm()
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

		protected override void InitButton()
		{
			base.InitButton();
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
				new XGridColumn() { FieldName = "Name", Caption = "검색경로명", Width = 200 },
				new XGridColumn() { FieldName = "Value", Caption = "검색URL", Width = 200 },
				new XGridColumn() { FieldName = "CodeValue01", Caption = "사이트URL", Width = 200 },
				new XGridColumn() { FieldName = "CreateDate" },
				new XGridColumn() { FieldName = "CreateByName" },
				new XGridColumn() { FieldName = "UpdateDate" },
				new XGridColumn() { FieldName = "UpdateByName" }
			);
			gridSiteList.ColumnFix("RowNo");
			gridSiteList.SetRepositoryItemCheckEdit("Checked");
			gridSiteList.SetEditable("Checked");
			//gridSiteList.CheckSelectChanged += (bool check) => { gridSiteList.CheckSelect<TCode>(check); };
			#endregion

			#region Brand List
			gridBrandList.Init();
			gridBrandList.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "SiteCode", Visible = false },
				new XGridColumn() { FieldName = "BrandCode", Width = 80, Visible = false },
				new XGridColumn() { FieldName = "BrandName", Width = 150 },
				new XGridColumn() { FieldName = "GoodsCnt", Width = 60, HorzAlignment = HorzAlignment.Far },
				new XGridColumn() { FieldName = "BrandURL", Width = 300 }
			);
			gridBrandList.ColumnFix("RowNo");
			#endregion

			#region Goods List
			gridGoodsList.Init();
			gridGoodsList.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "SiteCode", Visible = false },
				new XGridColumn() { FieldName = "BrandCode", Visible = false },
				new XGridColumn() { FieldName = "GoodsCode", Width = 100, Visible = false },
				new XGridColumn() { FieldName = "GoodsName", Width = 200 },
				new XGridColumn() { FieldName = "ListPrice", Width = 90, HorzAlignment = HorzAlignment.Far, FormatType = FormatType.Numeric, FormatString = "N0" },
				new XGridColumn() { FieldName = "SalePrice", Width = 90, HorzAlignment = HorzAlignment.Far, FormatType = FormatType.Numeric, FormatString = "N0" },
				new XGridColumn() { FieldName = "ImageURL", Width = 100 },
				new XGridColumn() { FieldName = "Option1Type", Width = 100 },
				new XGridColumn() { FieldName = "Option1Name", Width = 100 },
				new XGridColumn() { FieldName = "Option2Type", Width = 100 },
				new XGridColumn() { FieldName = "Option2Name", Width = 100 },
				new XGridColumn() { FieldName = "CategoryName", Width = 100 },
				new XGridColumn() { FieldName = "GoodsURL", Width = 300 }
			);
			gridGoodsList.ColumnFix("RowNo");
			gridGoodsList.RowCellClick += (object sender, RowCellClickEventArgs e) =>
			{
				if (e.RowHandle < 0)
					return;

				try
				{
					if (e.Button == MouseButtons.Left && e.Clicks == 2)
					{
						GridView view = sender as GridView;
						if (view.GetRowCellValue(e.RowHandle, "ImageURL").IsNullOrEmpty() == false)
							picImage.LoadAsync(view.GetRowCellValue(e.RowHandle, "ImageURL").ToStringNullToEmpty());
					}
				}
				catch(Exception ex)
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
		
		protected override void DataLoad(object param = null)
		{
			gridSiteList.BindList<CodeModel>("Biz", "GetList", "Select", new DataMap()
			{
				{ "FindText", txtFindText.EditValue },
				{ "UseYn", "Y" },
				{ "ParentCode", "CrawlingSite" },
				{ "IsNotParent", "Y" }
			});
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

				if (gridSiteList.GetFilteredData<CodeModel>().Where(x =>
					 x.Checked == "Y" &&
					 x.Value.IsNullOrEmpty() == false &&
					 x.CodeValue01.IsNullOrEmpty() == false).Any() == false)
					return;

				InitCrawling();

				btnStart.Enabled = false;
				btnStop.Enabled = true;
				progSiteList.Properties.Maximum = gridSiteList.GetFilteredData<CodeModel>().Where(x =>
					x.Checked == "Y" &&
					x.Value.IsNullOrEmpty() == false &&
					x.CodeValue01.IsNullOrEmpty() == false).ToList().Count();
				Application.DoEvents();

				int i = 0;
				foreach (var data in gridSiteList.GetFilteredData<CodeModel>().Where(x =>
					x.Checked == "Y" &&
					x.Value.IsNullOrEmpty() == false &&
					x.CodeValue01.IsNullOrEmpty() == false))
				{
					if (bContinue == false)
						break;
					
					progSiteList.EditValue = (i + 1);
					gridSiteList.SelectRow(gridSiteList.MainView.GetVisibleRowHandle(i));
					Application.DoEvents();

					string crawlName = data.Name;
					string crawlUrl = data.Value;
					string siteUrl = data.CodeValue01;

					if (siteUrl == "http://www.wconcept.co.kr")
					{
						CrawlWConcept(siteUrl, siteUrl + crawlUrl, crawlName);
					}

					i++;
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

		private void CrawlWConcept(string siteUrl, string crawlUrl, string crawlName)
		{
			try
			{
				SetMessage("사이트 " + crawlName + "의 브랜드 및 상품정보 추출을 시작합니다.");
				Application.DoEvents();

				//초기화
				SetMessage("크롤링 초기화를 진행하는 중입니다..");
				Application.DoEvents();

				gridBrandList.DataSource = null;
				gridGoodsList.DataSource = null;
				memScript.EditValue = null;

				int gcount = 0;
				int bcount = 0;

				SetMessage("쿠키정보를 이관하는 중입니다..");
				Application.DoEvents();

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
				SetMessage("크롤링 사이트 " + crawlName + "를 로딩하는 중입니다..");
				Application.DoEvents();

				HtmlAgilityPack.HtmlDocument doc = web.Load(crawlUrl);

				//브랜드목록 추출
				if (doc != null)
				{
					SetMessage("브랜드목록을 추출하는 중입니다.. 잠시만..");
					memScript.Text = doc.DocumentNode.SelectSingleNode("//body").OuterHtml;
					Application.DoEvents();

					//브랜드 추출
					int i = 0;
					var nodes = doc.DocumentNode.SelectNodes("//a[@href]");
					if (nodes != null)
					{
						progBrandList.Properties.Maximum = nodes.Count;
						Application.DoEvents();

						List<BrandInfoModel> brandList = new List<BrandInfoModel>();
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
								string brandCode = att.Value.Replace(@"/ShopMain/BrandShop.cshtml?brandcd=", "").Replace("#paginganchor", "");
								string brandName = att.OwnerNode.InnerText;
								string brandUrl = att.Value;

								if (brandCode.IsNullOrEmpty() || brandName.IsNullOrEmpty() || brandUrl.IsNullOrEmpty())
									continue;

								if (brandList.Where(x => x.BrandCode == brandCode).Any())
									continue;

								bcount++;
								brandList.Add(new BrandInfoModel()
								{
									RowNo = bcount,
									SiteCode = siteUrl,
									BrandCode = brandCode,
									BrandName = brandName,
									BrandURL = brandUrl
								});
							}
						}
						gridBrandList.DataSource = brandList;
					}
					SetMessage("브랜드목록을 추출하였습니다.");
					Application.DoEvents();
				}
				
				//상품목록 추출
				if (gridBrandList.RowCount > 0)
				{
					SetMessage("상품목록을 추출하는 중입니다.. 잠시만..");
					progBrandList.Properties.Maximum = gridBrandList.RowCount;
					Application.DoEvents();

					#region 브랜드 페이지 로딩하여 상품목록 및 상품정보 추출
					for (int rowIndex = 0; rowIndex < gridBrandList.RowCount; rowIndex++)
					{
						if (bContinue == false)
							break;

						gridBrandList.SelectRow(rowIndex);
						progBrandList.EditValue = (rowIndex + 1);
						Application.DoEvents();

						string pageIndex = "1";
						string pageTotal = "10000";
						string listUrl = siteUrl + @"/ShopMain/_Partial/_Brand/BrandDetailList.cshtml";
						string brandCode = gridBrandList.GetValue(rowIndex, "BrandCode").ToStringNullToEmpty();
						string brandName = gridBrandList.GetValue(rowIndex, "BrandName").ToStringNullToEmpty();

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

						gridBrandList.SetValue(rowIndex, "GoodsCnt", links.Count);
						progGoodsList.Properties.Maximum = links.Count;
						Application.DoEvents();
						
						#region 브랜드 목록 저장
						SetMessage("브랜드 정보 저장하는 중입니다... 잠시만...");
						Application.DoEvents();

						BrandInfoModel brand = gridBrandList.MainView.GetRow(rowIndex) as BrandInfoModel;
						if (brand != null)
						{
							using (var res = WasHandler.Execute<BrandInfoModel>("Scrap", "Save", "SaveBrandInfo", brand, "ID"))
							{
								if (res.Error.Number != 0)
									throw new Exception(res.Error.Message);

								SetMessage("브랜드 정보를 저장하였습니다.");
							}
						}
						#endregion

						//상품목록 그리드 초기화
						List<GoodsInfoModel> goodsList = new List<GoodsInfoModel>();
						gridGoodsList.DataSource = null;
						gcount = 0;

						#region 브랜드 페이지에서 상품목록 추출
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
								if (goodsList.Where(x => 
										x.SiteCode == siteUrl && 
										x.BrandCode == brandCode && 
										x.GoodsCode == goodsCode).Any())
									continue;

								gcount++;
								goodsList.Add(new GoodsInfoModel()
								{
									RowNo = gcount,
									SiteCode = siteUrl,
									BrandCode = brandCode,
									GoodsCode = goodsCode,
									GoodsName = goodsName,
									GoodsURL = goodsUrl,
									ListPrice = listPrice.Replace(",","").ToIntegerNullToZero(),
									SalePrice = salePrice.Replace(",", "").ToIntegerNullToZero()
								});
							}
						}

						//추출된 상품목록 바인딩
						gridGoodsList.DataSource = goodsList;
						Application.DoEvents();
						#endregion

						//상품상세 추출
						if (gridGoodsList.RowCount > 0)
						{
							#region 상품상세 추출
							SetMessage("상품상세를 추출하는 중입니다.. 잠시만..");
							progGoodsList.Properties.Maximum = gridGoodsList.RowCount;
							Application.DoEvents();

							for (int gIndex = 0; gIndex < gridGoodsList.RowCount; gIndex++)
							{
								if (bContinue == false)
									break;

								picImage.EditValue = null;
								gridGoodsList.SelectRow(gIndex);
								progGoodsList.EditValue = (gIndex + 1);
								Application.DoEvents();

								string gCode = gridGoodsList.GetValue(gIndex, "GoodsCode").ToStringNullToEmpty();
								string dtlUrl = gridGoodsList.GetValue(gIndex, "GoodsURL").ToStringNullToEmpty();
								if (dtlUrl.IsNullOrEmpty())
									continue;

								doc = web.Load(siteUrl + dtlUrl);
								if (doc == null)
									continue;

								string mcd = string.Empty;
								string ca = string.Empty;
								string itemCd = string.Empty;
								string imageUrl = string.Empty;
								string category = string.Empty;

								#region 카테고리
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
									if (category.IsNullOrEmpty() == false)
									{
										gridGoodsList.SetValue(gIndex, "CategoryName", category);
										Application.DoEvents();
									}
								}
								#endregion

								#region 상품 이미지 경로 및 이미지 저장
								HtmlNodeCollection linkNodes = doc.DocumentNode.SelectNodes("//div[@class='img_area']");
								foreach (HtmlNode linkNode in linkNodes)
								{
									HtmlNode imageNode = linkNode.SelectSingleNode(".//img[@id='img_01']");
									HtmlAttribute src = imageNode.Attributes["src"];
									if (src != null)
									{
										imageUrl = src.Value;
										picImage.EditValue = null;
										picImage.LoadAsync(imageUrl);
										string imagePath = siteUrl.Replace(".", "").Replace("/", "").Replace(":", "") + "\\" + brandName;
										ImageUtils.DownloadByStream(imageUrl, imagePath, gCode);

										int ii = 0;
										while (picImage.IsLoading)
										{
											if (picImage.IsLoading == false)
												break;

											if (ii > 100)
												break;

											Thread.Sleep(100);
											ii++;
										}
										gridGoodsList.SetValue(gIndex, "ImageURL", imageUrl);
										Application.DoEvents();
									}
								}
								#endregion

								#region 상품설명 가져오기
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
								#endregion

								Application.DoEvents();
							}
							SetMessage("상품상세를 추출하였습니다.");
							Application.DoEvents();
							#endregion

							#region 상품정보저장
							SetMessage("상품정보를 저장하는 중입니다... 잠시만...");
							Application.DoEvents();

							if (gridGoodsList.DataSource is List<GoodsInfoModel> glist && glist.Count > 0)
							{
								using (var res = WasHandler.Execute<GoodsInfoModel>("Scrap", "Save", "SaveGoodsInfo", glist, "ID"))
								{
									if (res.Error.Number != 0)
										throw new Exception(res.Error.Message);

									SetMessage("상품정보를 저장하였습니다.");
								}
							}
							#endregion
						}
					}
					SetMessage("상품목록을 추출하였습니다.");
					Application.DoEvents();
					#endregion
				}

				SetMessage("사이트 " + crawlName + "의 브랜드 및 상품정보 추출을 완료하였습니다.");
				Application.DoEvents();
			}
			catch
			{
				throw;
			}
		}
	}
}
 