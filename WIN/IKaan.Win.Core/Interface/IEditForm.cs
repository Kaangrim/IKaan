using System.Collections.Generic;
using IKaan.Win.Core.Enum;
using IKaan.Win.Core.Model;
using IKaan.Model.Common.UserModels ;

namespace IKaan.Win.Core.Interface
{
	public interface IEditForm
	{
		ToolbarButtons ToolbarButtons { get; set; }
		EditModeEnum EditMode { get; set; }
		bool VisibleToolbar { get; set; }
		bool VisibleStatusbar { get; set; }
		bool IsLoadingRefresh { get; set; }
		ElapseTime LoadingElapseTime { get; set; }
		bool IsLoaded { get; }

		ViewTypeEnum ViewType { get; set; }
		IList<UMenuViewButton> ViewButtons { get; set; }

		void SetToolbarButtons(ToolbarButtons toolbarButtons);
	}
}
