using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraLayout;
using HtmlAgilityPack;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Model.Scrap.Common;
using IKaan.Win.Core.Controls.Grid;
using IKaan.Win.Core.Forms;
using IKaan.Win.Core.Model;
using IKaan.Win.Core.Utils;
using IKaan.Win.Core.Was.Handler;

namespace IKaan.Win.View.Scrap.Common
{
	public partial class ScrapEditForm : EditForm
	{
		private bool bContinue = true;

		public ScrapEditForm()
		{
			InitializeComponent();

			lcTab.SelectedPageChanged += (object sender, LayoutTabPageChangedEventArgs e) =>
			{
				if (e.Page.Name == lcTabGroupSiteUrl.Name)
					btnDiffrenctSelect.Enabled = false;
				else if (e.Page.Name == lcTabGroupBrand.Name)
					btnDiffrenctSelect.Enabled = true;
			};

			lupScrapSite.EditValueChanged += (object sender, EventArgs e) =>
			{
				if (this.IsLoaded)
					DataLoad();
			};

			btnStart.Click += (object sender, EventArgs e) =>
			{
				if (lcTab.SelectedTabPage.Name == lcTabGroupSiteUrl.Name)
				{
					StartScrap();
				}
				else if (lcTab.SelectedTabPage.Name == lcTabGroupBrand.Name)
				{
					StartScrapByBrands();
				}
			};
			btnStop.Click += (object sender, EventArgs e) => { StopScrap(); };
			btnDiffrenctSelect.Click += (object sender, EventArgs e) => { DifferentSelect(); };
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

				lcItemDifferentYn.SetFieldName("DifferentView", HorzAlignment.Near);
				lcGroupBrand.Text = DomainUtils.GetFieldName("BrandInfo");
				lcGroupProduct.Text = DomainUtils.GetFieldName("ProductInfo");
				lcGroupImage.Text = DomainUtils.GetFieldName("ImageInfo");

				btnStop.Enabled = false;
				btnStart.Enabled = true;
				bContinue = true;

				lupScrapSite.BindData("ScrapSite");
				lupDifferentYn.BindData("Yn", "All");

				spnSuccessCount.SetFormat("N0", false);
				spnErrorCount.SetFormat("N0", false);
				spnSuccessCount.SetEnable(false);
				spnErrorCount.SetEnable(false);

				chkErrorHide.Checked = true;
				chkImageView.Checked = false;

				InitGrid();

				lcTab.SelectedTabPageIndex = 0;
			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}

		void InitGrid()
		{
			gridSites.Init();
			gridSites.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "Checked" },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "Code", Visible = false },
				new XGridColumn() { FieldName = "Name", Caption = "검색경로명", Width = 200 },
				new XGridColumn() { FieldName = "Url", Caption = "검색URL", Width = 200 },
				new XGridColumn() { FieldName = "CreatedOn" },
				new XGridColumn() { FieldName = "CreatedByName" },
				new XGridColumn() { FieldName = "UpdatedOn" },
				new XGridColumn() { FieldName = "UpdatedByName" }
			);
			gridSites.ColumnFix("RowNo");
			gridSites.SetRepositoryItemCheckEdit("Checked");
			gridSites.SetEditable("Checked");

			gridBrands.Init();
			gridBrands.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "Checked" },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "SiteID", Visible = false },
				new XGridColumn() { FieldName = "Code", CaptionCode = "BrandCode", Width = 100 },
				new XGridColumn() { FieldName = "ProductCount", Width = 80, HorzAlignment = HorzAlignment.Far, FormatType = FormatType.Numeric, FormatString = "N0" },
				new XGridColumn() { FieldName = "ScrapProductCount", Width = 80, HorzAlignment = HorzAlignment.Far, FormatType = FormatType.Numeric, FormatString = "N0" },
				new XGridColumn() { FieldName = "Name", CaptionCode = "BrandName", Width = 200 },
				new XGridColumn() { FieldName = "Url", Caption = "URL", Width = 200 },
				new XGridColumn() { FieldName = "Description", Width = 300 },
				new XGridColumn() { FieldName = "CreatedOn" },
				new XGridColumn() { FieldName = "CreatedByName" },
				new XGridColumn() { FieldName = "UpdatedOn" },
				new XGridColumn() { FieldName = "UpdatedByName" }
			);
			gridBrands.ColumnFix("RowNo");
			gridBrands.SetRepositoryItemCheckEdit("Checked");
			gridBrands.SetEditable("Checked");
		}

		protected override void DataLoad(object param = null)
		{
			if (lcTab.SelectedTabPage.Name == lcTabGroupSiteUrl.Name)
			{
				gridSites.BindList<ScrapSiteModel>("Scrap", "GetList", "Select", new DataMap()
				{
					{ "SiteID", lupScrapSite.EditValue },
					{ "FindText", txtFindText.EditValue },
					{ "ParentID", lupScrapSite.EditValue }
				});
			}
			else if (lcTab.SelectedTabPage.Name == lcTabGroupBrand.Name)
			{
				gridBrands.BindList<ScrapBrandModel>("Scrap", "GetList", "Select", new DataMap()
				{
					{ "SiteID", lupScrapSite.EditValue },
					{ "DifferentYn", lupDifferentYn.EditValue },
					{ "FindText", txtFindText.EditValue }
				});
			}
		}

		private void InitCrawling()
		{
			bContinue = true;
		}

		private void StartScrap()
		{
			try
			{
				if (gridSites.DataSource == null || gridSites.RowCount == 0)
					return;

				if (gridSites.GetFilteredData<ScrapSiteModel>().Where(x =>
					 x.Checked == "Y" &&
					 x.Url.IsNullOrEmpty() == false).Any() == false)
					return;

				InitCrawling();

				btnStart.Enabled = false;
				btnStop.Enabled = true;

				progSites.Properties.Maximum = gridSites.GetFilteredData<ScrapSiteModel>().Where(x =>
					x.Checked == "Y" &&
					x.Url.IsNullOrEmpty() == false).ToList().Count();
				Application.DoEvents();

				int i = 0;
				foreach (var data in gridSites.GetFilteredData<ScrapSiteModel>().Where(x =>
					x.Checked == "Y" &&
					x.Url.IsNullOrEmpty() == false))
				{
					if (bContinue == false)
						break;

					progSites.EditValue = (i + 1);
					gridSites.SelectRow(gridSites.MainView.GetVisibleRowHandle(i));
					Application.DoEvents();

					string name = data.Name;
					string url = data.Url;
					string siteUrl = lupScrapSite.GetValue(1).ToStringNullToEmpty();

					if (siteUrl == "http://www.wconcept.co.kr")
					{
						ScrapWConcept(siteUrl + url, name);
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

		private void StartScrapByBrands()
		{
			try
			{
				if (gridBrands.DataSource == null || gridBrands.RowCount == 0)
					return;

				if (gridBrands.GetFilteredData<ScrapBrandModel>().Where(x =>
					 x.Checked == "Y" &&
					 x.Url.IsNullOrEmpty() == false).Any() == false)
					return;

				InitCrawling();

				btnStart.Enabled = false;
				btnStop.Enabled = true;

				progSites.Properties.Maximum = 0;
				Application.DoEvents();

				string siteUrl = lupScrapSite.GetValue(1).ToStringNullToEmpty();

				if (siteUrl == "http://www.wconcept.co.kr")
				{
					ScrapWConcept(siteUrl, "");
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

		private void StopScrap()
		{
			bContinue = false;
		}

		private void ScrapWConcept(string url, string name)
		{
			try
			{
				SetMessage("사이트 " + name + "의 브랜드 및 상품정보 추출을 시작합니다.");
				Application.DoEvents();

				//초기화
				SetMessage("크롤링 초기화를 진행하는 중입니다..");
				Application.DoEvents();

				var brands = new List<ScrapBrandModel>();
				var products = new List<ScrapProductModel>();
				var images = new List<ScrapProductImageModel>();
				HtmlAgilityPack.HtmlDocument doc = null;

				memHtml.Clear();
				memBrandInfo.Clear();
				memProductInfo.Clear();
				memImageInfo.Clear();
				picImage.EditValue = null;
				spnSuccessCount.Value = 0;
				spnErrorCount.Value = 0;

				int siteId = lupScrapSite.EditValue.ToIntegerNullToZero();
				string siteUrl = lupScrapSite.GetValue(1).ToStringNullToEmpty();

				#region Set Cookies
				SetMessage("쿠키정보를 이관하는 중입니다..");
				Application.DoEvents();

				var Cookies = new CookieCollection();
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
						var reqStream = request.GetRequestStream();
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
				#endregion

				//크롤링 사이트 로딩
				SetMessage("크롤링 사이트 " + name + "를 로딩하는 중입니다..");
				Application.DoEvents();

				#region 브랜드목록 추출
				if (lcTab.SelectedTabPage.Name == lcTabGroupSiteUrl.Name)
				{
					doc = web.Load(url);
					if (doc != null)
					{
						SetMessage("브랜드목록을 추출하는 중입니다.. 잠시만..");
						memHtml.Text = doc.DocumentNode.SelectSingleNode("//body").OuterHtml;
						Application.DoEvents();

						//브랜드 추출
						int i = 0;
						var nodes = doc.DocumentNode.SelectNodes("//a[@href]");
						if (nodes != null)
						{
							progBrands.Properties.Maximum = nodes.Count;
							Application.DoEvents();

							foreach (var link in nodes)
							{
								if (bContinue == false)
									break;

								i++;
								progBrands.EditValue = i;
								SetMessage(string.Format("브랜드검색=> {0}/{1}", i, nodes.Count));
								Application.DoEvents();

								var att = link.Attributes["href"];
								if (att.Value.IsNullOrEmpty() == false && att.Value.StartsWith("/ShopMain/BrandShop"))
								{
									var brand = new ScrapBrandModel() { SiteID = siteId };
									brand.Code = att.Value.Replace(@"/ShopMain/BrandShop.cshtml?brandcd=", "").Replace("#paginganchor", "");
									brand.Name = att.OwnerNode.InnerText;
									brand.Url = att.Value;

									if (brand.Code.IsNullOrEmpty() || brand.Name.IsNullOrEmpty() || brand.Url.IsNullOrEmpty())
										continue;

									if (brands.Where(x => x.Code == brand.Code).Any())
										continue;

									memBrandInfo.EditValue =
										brand.Code + Environment.NewLine +
										brand.Name + Environment.NewLine +
										brand.Url;
									brands.Add(brand);
									Application.DoEvents();
								}
							}
						}
						SetMessage("브랜드목록을 추출하였습니다.");
						Application.DoEvents();
					}
				}
				else if (lcTab.SelectedTabPage.Name == lcTabGroupBrand.Name)
				{
					brands = gridBrands.GetFilteredData<ScrapBrandModel>().Where(x =>
						x.Checked == "Y" &&
						x.Url.IsNullOrEmpty() == false).ToList();
				}
				#endregion

				//상품목록 추출
				if (brands.Count > 0)
				{
					SetMessage("상품목록을 추출하는 중입니다.. 잠시만..");
					progBrands.Properties.Maximum = brands.Count;
					Application.DoEvents();

					#region 브랜드 페이지 로딩하여 상품목록 및 상품정보 추출
					int brandIndex = 0;
					foreach (var brand in brands)
					{
						if (bContinue == false)
							break;

						if (brand == null)
							continue;

						brandIndex++;
						progBrands.EditValue = brandIndex;
						memBrandInfo.EditValue =
							brand.Code + Environment.NewLine +
							brand.Name + Environment.NewLine +
							brand.Url;
						products = new List<ScrapProductModel>();
						images = new List<ScrapProductImageModel>();
						Application.DoEvents();

						string pageIndex = "1";
						string pageTotal = "10000";
						string listUrl = siteUrl + @"/ShopMain/_Partial/_Brand/BrandDetailList.cshtml";

						if (brand.Code.IsNullOrEmpty())
							continue;

						#region  브랜드정보
						doc = web.Load(siteUrl + @"/ShopMain/BrandShop.cshtml?brandcd=" + brand.Code);
						if (doc != null)
						{
							var brandPageNodes = doc.DocumentNode.SelectNodes("//div[@class='brand_info']");
							if (brandPageNodes != null && brandPageNodes.Count > 0)
							{
								foreach (var brandPageNode in brandPageNodes)
								{
									var brandDescription = brandPageNode.SelectSingleNode(".//p[@class='desc ellipsis multiline']");
									if (brandDescription != null && brandDescription.InnerText.IsNullOrEmpty() == false)
									{
										brand.Description = brandDescription.InnerText;
									}
								}
							}
						}
						#endregion

						string postUrl = string.Concat(
							listUrl,
							"?PageIndex=",
							pageIndex,
							"&maxdisp=",
							pageTotal,
							"&brandcd=",
							brand.Code,
							"&sortnum=1&myheart=N&searchCategoryCd=&searchBrandCd=&searchMaxPrice=&searchSize=&searchColor=");

						doc = web.Load(postUrl, "POST");
						if (doc == null)
							continue;

						memHtml.Text = doc.DocumentNode.OuterHtml;
						Application.DoEvents();

						var links = doc.DocumentNode.SelectNodes("//div[@class='thumbnail_list']//ul//li");
						if (links == null || links.Count == 0)
							continue;

						brand.ProductCount = links.Count;

						#region 브랜드 저장
						SetMessage("브랜드 정보 저장하는 중입니다... 잠시만...");
						Application.DoEvents();

						try
						{
							using (var res = WasHandler.Execute<ScrapBrandModel>("Scrap", "Save", "SaveScrapBrand", brand, "ID"))
							{
								if (res.Error.Number != 0)
									throw new Exception(res.Error.Message);

								SetMessage("브랜드 정보를 저장하였습니다.");
							}
						}
						catch (Exception ex)
						{
							if (chkErrorHide.Checked == false)
								throw new Exception(ex.Message);
							else
								memProductInfo.EditValue = ex.Message;
						}
						#endregion

						if (chkOnlyBrand.Checked == false)
						{
							#region 브랜드 페이지에서 상품목록 추출
							int linkIndex = 0;
							progProducts.Properties.Maximum = links.Count;
							Application.DoEvents();

							foreach (var link in links)
							{
								linkIndex++;
								progProducts.EditValue = linkIndex;
								SetMessage(string.Format("상품처리=> {0}/{1}", linkIndex, links.Count));
								Application.DoEvents();

								var product = new ScrapProductModel
								{
									SiteID = siteId,
									BrandCode = brand.Code,
									BrandName = brand.Name
								};

								var nodeproductUrl = link.SelectSingleNode(".//a[@href]");
								if (nodeproductUrl != null)
								{
									var attrproductUrl = nodeproductUrl.Attributes["href"];
									if (attrproductUrl != null && attrproductUrl.Value.IsNullOrEmpty() == false)
										product.Url = attrproductUrl.Value;
								}

								if (product.Url.IsNullOrEmpty() == false)
									product.Code = product.Url.Substring(product.Url.LastIndexOf("itemcd=") + 7);

								var nodeProductName = link.SelectSingleNode(".//div[@class='product ellipsis']");
								if (nodeProductName != null && nodeProductName.InnerText.IsNullOrEmpty() == false)
									product.Name = nodeProductName.InnerText;

								var nodeListPrice = link.SelectSingleNode(".//span[@class='base_price']");
								if (nodeListPrice != null && nodeListPrice.InnerText.IsNullOrEmpty() == false && nodeListPrice.InnerText.IsNumeric())
									product.ListPrice = nodeListPrice.InnerText.ToDecimalNullToZero();

								var nodeSalePrice = link.SelectSingleNode(".//span[@class='discount_price']");
								if (nodeSalePrice != null && nodeSalePrice.InnerText.IsNullOrEmpty() == false && nodeSalePrice.InnerText.IsNumeric())
									product.SalePrice = nodeSalePrice.InnerText.ToDecimalNullToZero();

								if (product.Code != null)
								{
									if (products.Where(x =>
											x.SiteID == siteId &&
											x.BrandCode == brand.Code &&
											x.Code == product.Code).Any())
										continue;

									memProductInfo.EditValue =
										"[" + product.Code + "] " + product.Name + Environment.NewLine +
										product.Url;

									products.Add(product);
								}
								Application.DoEvents();
							}
							#endregion

							#region  상품 상세 추출
							if (products.Count > 0)
							{
								int scrapCount = 0;
								#region 상품상세 추출
								SetMessage("상품상세를 추출하는 중입니다.. 잠시만..");
								progProducts.Properties.Maximum = products.Count;
								Application.DoEvents();

								int pindex = 0;
								foreach (var product in products)
								{
									if (bContinue == false)
										break;

									pindex++;
									picImage.EditValue = null;
									progProducts.EditValue = pindex;
									images = new List<ScrapProductImageModel>();
									memProductInfo.EditValue =
										"[" + product.Code + "] " + product.Name + Environment.NewLine +
										product.Url;
									Application.DoEvents();

									if (product.Url.IsNullOrEmpty())
										continue;

									if (chkOnlyProduct.Checked == false)
									{
										doc = web.Load(siteUrl + product.Url);
										memHtml.Text = doc.DocumentNode.OuterHtml;
										Application.DoEvents();

										if (doc == null)
											continue;

										string mcd = string.Empty;
										string ca = string.Empty;
										string itemCd = string.Empty;
										string imageUrl = string.Empty;
										string category = string.Empty;

										#region 카테고리
										var catLinks = doc.DocumentNode.SelectNodes("//div[@class='pdt']//ul[@class='location']//li");
										if (catLinks != null && catLinks.Count > 0)
										{
											foreach (var node in catLinks)
											{
												var catNode = node.SelectSingleNode(".//button");
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
												product.CategoryName = category;
												Application.DoEvents();
											}
										}
										#endregion

										#region 상품 이미지 경로 및 이미지 저장
										IList<ScrapProductImageModel> images1 = GetProductImages(doc, siteUrl, product, "M", "//div[@class='img_goods']", ".//img[@id='img_01']");
										IList<ScrapProductImageModel> images2 = GetProductImages(doc, siteUrl, product, "D", "//div[@class='marketing']", ".//img[@class='txc-image']");
										if (images1 != null && images1.Count > 0)
										{
											foreach (var image in images1)
												images.Add(image);
										}
										if (images2 != null && images2.Count > 0)
										{
											foreach (var image in images2)
												images.Add(image);
										}
										if (images != null && images.Count > 0)
											product.Images = images;
										#endregion

										#region 상품설명 가져오기
										var productForm = doc.GetElementbyId("frmproduct");
										if (productForm == null)
											continue;

										foreach (var node in productForm.Elements("input"))
										{
											var valueAttribute = node.Attributes["value"];
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

										#region 옵션 가져오기
										var option1 = GetOptions(doc, "//dl[@class='option option_one']");
										if (option1 != null && option1.Title.IsNullOrEmpty() == false)
										{
											product.Option1Type = option1.Title;

											if (option1.Value != null && option1.Value.Count > 0)
												product.Option1Name = string.Join(",", option1.Value);

											memProductInfo.EditValue =
												memProductInfo.Text + Environment.NewLine +
												product.Option1Type + " : " + product.Option1Name;
											Application.DoEvents();
										}
										

										var option2 = GetOptions(doc, "//dl[@class='option option_two']");
										if (option2 != null && option2.Title.IsNullOrEmpty() == false)
										{
											product.Option2Type = option2.Title;

											if (option2.Value != null && option2.Value.Count > 0)
												product.Option2Name = string.Join(",", option2.Value);

											memProductInfo.EditValue =
												memProductInfo.Text + Environment.NewLine +
												product.Option2Type + " : " + product.Option2Name;
											Application.DoEvents();
										}
										#endregion
									}

									try
									{
										using (var res = WasHandler.Execute<ScrapProductModel>("Scrap", "Save", "SaveScrapProduct", product, "ID"))
										{
											if (res.Error.Number != 0)
												throw new Exception(res.Error.Message);
											scrapCount++;
											spnSuccessCount.Value++;
											if (lcTab.SelectedTabPage.Name == lcTabGroupBrand.Name)
											{
												gridBrands.MainView.BeginUpdate();
												var gridrow = (gridBrands.DataSource as IList<ScrapBrandModel>).Where<ScrapBrandModel>(x => x.Code == brand.Code).FirstOrDefault();
												if (gridrow != null)
													gridrow.ScrapProductCount = scrapCount;
												gridBrands.MainView.EndUpdate();
											}
										}
									}
									catch (Exception ex)
									{
										spnErrorCount.Value++;
										if (chkErrorHide.Checked == false)
											throw new Exception(ex.Message);
										else
											memProductInfo.EditValue = ex.Message;
									}

									Application.DoEvents();
								}
								SetMessage("상품상세를 추출하였습니다.");
								Application.DoEvents();
								#endregion
							}
							#endregion
						}
					}
					SetMessage("상품목록을 추출하였습니다.");
					Application.DoEvents();
					#endregion
				}

				SetMessage("사이트 " + name + "의 브랜드 및 상품정보 추출을 완료하였습니다.");
				Application.DoEvents();
			}
			catch
			{
				throw;
			}
		}

		private IList<ScrapProductImageModel> GetProductImages(HtmlAgilityPack.HtmlDocument doc, string siteUrl, ScrapProductModel product, string gubun, string groupNodes, string imageNodes)
		{
			string imgUrl = string.Empty;
			string orgUrl = string.Empty;

			try
			{
				int index = 0;
				var images = new List<ScrapProductImageModel>();
				var linkNodes = doc.DocumentNode.SelectNodes(groupNodes);

				foreach (var linkNode in linkNodes)
				{
					var imageNodeList = linkNode.SelectNodes(imageNodes);
					if (imageNodeList == null)
						continue;

					progImages.Properties.Maximum = imageNodeList.Count;
					foreach (var imageNode in imageNodeList)
					{
						index++;
						progImages.EditValue = index;
						Application.DoEvents();

						var src = imageNode.Attributes["src"];
						if (src != null)
						{
							imgUrl = src.Value;
							if (imgUrl.IndexOf("?") > 0)
								imgUrl = imgUrl.Substring(0, imgUrl.IndexOf("?"));

							if (orgUrl == imgUrl)
								continue;
							else
								orgUrl = imgUrl;

							if (chkImageView.Checked)
							{
								picImage.EditValue = null;
								picImage.LoadAsync(imgUrl);
							}
							string imagePath = siteUrl.Replace(".", "").Replace("/", "").Replace(":", "") + "\\" + product.BrandName;
							string filePath = ImageUtils.DownloadByStream(imgUrl, imagePath, product.Code + "_" + gubun + "_" + index.ToString());

							memImageInfo.EditValue =
								"URL: " + imgUrl + Environment.NewLine +
								"경로: " + filePath + Environment.NewLine +
								"파일명: " + Path.GetFileName(filePath) + Environment.NewLine +
								"Width: " + ImageUtils.GetSizePixel(filePath).Width.ToString() + Environment.NewLine +
								"Height: " + ImageUtils.GetSizePixel(filePath).Height.ToString();
							Application.DoEvents();

							#region Loading Image
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
							#endregion

							images.Add(new ScrapProductImageModel()
							{
								Name = Path.GetFileName(filePath),
								ProductID = product.ID,
								ImageType = gubun,
								Url = imgUrl,
								Width = ImageUtils.GetSizePixel(filePath).Width,
								Height = ImageUtils.GetSizePixel(filePath).Height
							});
							Application.DoEvents();
						}
					}
				}
				return images;
			}
			catch (Exception ex)
			{
				if (chkErrorHide.Checked == false)
					ShowMsgBox(ex.Message + Environment.NewLine + "Image URL: " + imgUrl);
				else
					memImageInfo.EditValue = ex.Message + Environment.NewLine + "Image URL: " + imgUrl;
				return null;
			}
		}

		private OptionValue GetOptions(HtmlAgilityPack.HtmlDocument doc, string tag)
		{
			try
			{
				var optionValue = new OptionValue();
				var optionNode = doc.DocumentNode.SelectSingleNode(tag);
				if (optionNode != null)
				{
					var dts = optionNode.SelectNodes("dt");
					var dds = optionNode.SelectNodes("dd/select[@id='optionidx']//option");

					if (dts != null)
					{
						foreach (var dt in dts)
						{
							if (dt.InnerText == "사이즈")
								optionValue.Title = "Size";
							else if (dt.InnerText == "색상")
								optionValue.Title = "Color";
							else
								optionValue.Title = "ColorOrSize";
						}

						if (dds != null)
						{
							foreach (var opt in dds)
							{
								if (opt.NextSibling.InnerText != "선택해 주세요.")
									optionValue.Value.Add(opt.NextSibling.InnerText);
							}
						}
					}
					return optionValue;
				}
				else
				{
					return null;
				}
				
			}
			catch(Exception ex)
			{
				if (chkErrorHide.Checked)
					memProductInfo.EditValue = ex.Message;
				else
					ShowErrBox(ex);
				return null;
			}
		}

		private void DifferentSelect()
		{
			for (int i = 0; i < gridBrands.RowCount; i++)
			{
				if (gridBrands.GetValue(i, "ProductCount").ToIntegerNullToZero() != gridBrands.GetValue(i, "ScrapProductCount").ToIntegerNullToZero())
				{
					gridBrands.SetValue(i, "Checked", "Y");
				}
				else
				{
					gridBrands.SetValue(i, "Checked", "N");
				}
			}
		}

		public class OptionValue
		{
			public string Title { get; set; }
			public IList<string> Value { get; set; }

			public OptionValue()
			{
				Value = new List<string>();
			}
		}
	}
}
 