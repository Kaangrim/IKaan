using System;
using System.Collections.Generic;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Model.Base.Common;
using IKaan.Model.Biz.Sales.Order;
using IKaan.Model.Common.Was;
using IKaan.Was.Core.Mappers;

namespace IKaan.Was.Service.Common
{
	public static class FileUploadServicePartial
	{
		public static void SaveChannelOrder(this WasRequest req, FileUploadModel model, DataMap parameter)
		{
			var datalist = model.UploadData.JsonToAnyType<List<ChannelOrderModel>>();
			string orderNo = string.Empty;
			string orderSeq = string.Empty;
			string goodsCode = string.Empty;

			DaoFactory.InstanceBiz.BeginTransaction();
			try
			{
				foreach (var data in datalist)
				{
					//더훅의 경우 머지된 경우로 인해서 아래와 같이 체크하고 업데이트한다.
					if (data.OrderNo.IsNullOrEmpty() && data.OrderSeq.IsNullOrEmpty() && data.GoodsCode.IsNullOrEmpty())
					{
						if (orderNo.IsNullOrEmpty() && orderSeq.IsNullOrEmpty() && goodsCode.IsNullOrEmpty())
							continue;

						data.UpdatedBy = req.User.UserId;
						data.UpdatedByName = req.User.UserName;

						if (parameter != null)
						{
							data.ChannelID = parameter.GetValue("ChannelID").ToIntegerNullToZero();
							if (data.OrderDate == null && parameter.GetValue("OrderDate") != null)
								data.OrderDate = Convert.ToDateTime(parameter.GetValue("OrderDate"));
						}

						//채널주문 중복검사 및 기 등록된 데이터 삭제
						var map = new DataMap()
						{
							{ "OrderNo", orderNo },
							{ "OrderSeq", orderSeq },
							{ "GoodsCode", goodsCode }
						};
						var channelorder = DaoFactory.InstanceBiz.QueryForObject<ChannelOrderModel>("SelectChannelOrderByOrderNo", map);
						if (channelorder != null)
						{
							if (data.Option1.IsNullOrEmpty())
								continue;

							if (channelorder.Option1.IsNullOrEmpty())
								channelorder.Option1 = data.Option1;
							else
								channelorder.Option1 = channelorder.Option1 + Environment.NewLine + data.Option1;

							DaoFactory.InstanceBiz.Update("UpdateChannelOrder", channelorder);
						}
					}
					else
					{						
						if (data.BrandID == null || data.BrandID == default(int))
						{
							var findMap = new DataMap()
							{
								{ "ChannelID", data.ChannelID },
								{ "GoodsCode", data.GoodsCode }
							};
							var find = DaoFactory.InstanceBiz.QueryForObject<ChannelOrderModel>("SelectChannelOrderByGoodsCode", findMap);
							if (find != null && find.BrandID != null)
							{
								data.BrandID = find.BrandID;
								data.BrandName = find.BrandName;
							}
						}

						data.CreatedBy = req.User.UserId;
						data.CreatedByName = req.User.UserName;
						data.FileUploadID = model.ID;

						if (parameter != null)
						{
							data.ChannelID = parameter.GetValue("ChannelID").ToIntegerNullToZero();
							if (data.OrderDate == null && parameter.GetValue("OrderDate") != null)
								data.OrderDate = Convert.ToDateTime(parameter.GetValue("OrderDate"));
						}

						//채널주문 중복검사 및 기 등록된 데이터 삭제
						var map = new DataMap()
						{
							{ "OrderNo", data.OrderNo },
							{ "OrderSeq", data.OrderSeq },
							{ "GoodsCode", data.GoodsCode }
						};
						var channelorder = DaoFactory.InstanceBiz.QueryForObject<ChannelOrderModel>("SelectChannelOrderByOrderNo", map);
						if (channelorder != null)
							DaoFactory.InstanceBiz.Delete("DeleteChannelOrder", new DataMap() { { "ID", channelorder.ID } });

						//저장
						object id = DaoFactory.InstanceBiz.Insert("InsertChannelOrder", data);
						data.ID = id.ToIntegerNullToNull();
						orderNo = data.OrderNo;
						orderSeq = data.OrderSeq;
						goodsCode = data.GoodsCode;
					}
				}
				DaoFactory.InstanceBiz.CommitTransaction();
			}
			catch (Exception ex)
			{
				DaoFactory.InstanceBiz.RollBackTransaction();
				throw ex;
			}
		}
	}
}
