﻿using System.Drawing;

namespace IKaan.Biz.Core.Controls.Common
{
	public interface IControlExtension
	{
		void Init();
		void Clear();
		void SetEnable(bool bEnable = false, Color? backColor = null);
		void SetForeColor(Color color);
	}
}
