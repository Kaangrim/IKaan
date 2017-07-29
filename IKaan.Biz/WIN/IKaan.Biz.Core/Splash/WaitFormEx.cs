using DevExpress.XtraWaitForm;
using IKaan.Biz.Core.Variables;

namespace IKaan.Biz.Core.Splash
{
	public partial class WaitFormEx : WaitForm
	{
		public WaitFormEx()
		{
			InitializeComponent();
			Init();
		}

		private void Init()
		{
			this.TargetLookAndFeel.UseDefaultLookAndFeel = false;
			this.TargetLookAndFeel.SetSkinStyle(GlobalVar.SkinInfo.MainSkin);

			progressPanel1.AutoHeight = false;
		}

		public override void SetCaption(string caption)
		{
			base.SetCaption(caption);
			progressPanel1.Caption = caption;
		}
		public override void SetDescription(string description)
		{
			base.SetDescription(description);
			progressPanel1.Description = description;
		}
		//public override void ProcessCommand(WaitFormCommand cmd, object arg)
		//{
		//	switch (cmd)
		//	{
		//		case WaitFormCommand.LoadingImage:

		//			break;
		//		default:
		//			break;
		//	}
		//	base.ProcessCommand(cmd, arg);
		//}



		public enum WaitFormCommand
		{
			LoadingImage
		}
	}
}
