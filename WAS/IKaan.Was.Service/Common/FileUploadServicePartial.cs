﻿using System;
using System.Collections.Generic;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Model.Base;
using IKaan.Model.Common.Was;
using IKaan.Model.Live;
using IKaan.Was.Core.Mappers;

namespace IKaan.Was.Service.Common
{
	public static class FileUploadServicePartial
	{
		public static void SaveChannelOrder(this WasRequest req, FileUploadModel model, DataMap parameter)
		{
			IList<ChannelOrderModel> datalist = model.UploadData.JsonToAnyType<List<ChannelOrderModel>>();
			string orderNo = string.Empty;
			string orderSeq = string.Empty;
			string goodsCode = string.Empty;

			DaoFactory.InstanceLive.BeginTransaction();
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
						DataMap map = new DataMap()
						{
							{ "OrderNo", orderNo },
							{ "OrderSeq", orderSeq },
							{ "GoodsCode", goodsCode }
						};
						var channelorder = DaoFactory.InstanceLive.QueryForObject<ChannelOrderModel>("SelectChannelOrderByOrderNo", map);
						if (channelorder != null)
						{
							if (data.Option1.IsNullOrEmpty())
								continue;

							if (channelorder.Option1.IsNullOrEmpty())
								channelorder.Option1 = data.Option1;
							else
								channelorder.Option1 = channelorder.Option1 + Environment.NewLine + data.Option1;

							DaoFactory.InstanceLive.Update("UpdateChannelOrder", channelorder);
						}
					}
					else
					{
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
						DataMap map = new DataMap()
						{
							{ "OrderNo", data.OrderNo },
							{ "OrderSeq", data.OrderSeq },
							{ "GoodsCode", data.GoodsCode }
						};
						var channelorder = DaoFactory.InstanceLive.QueryForObject<ChannelOrderModel>("SelectChannelOrderByOrderNo", map);
						if (channelorder != null)
							DaoFactory.InstanceLive.Delete("DeleteChannelOrder", new DataMap() { { "ID", channelorder.ID } });

						//저장
						object id = DaoFactory.InstanceLive.Insert("InsertChannelOrder", data);
						data.ID = id.ToIntegerNullToNull();
						orderNo = data.OrderNo;
						orderSeq = data.OrderSeq;
						goodsCode = data.GoodsCode;
					}
				}
				DaoFactory.InstanceLive.CommitTransaction();
			}
			catch (Exception ex)
			{
				DaoFactory.InstanceLive.RollBackTransaction();
				throw ex;
			}
		}
	}
}
