﻿namespace IKaan.Biz.Core.Controls
{
	using System;

	public class XPagerButtonClickEventArgs : EventArgs
	{
		public XPagerButtonType GridPagerButtonType { get; internal set; }
		public XPagerButtonClickEventArgs(XPagerButtonType pagerButtonType)
		{
			GridPagerButtonType = pagerButtonType;
		}
	}
}
