using System.Windows.Forms;
using DevExpress.XtraEditors;
using IKaan.Win.Core.Resources;
using IKaan.Win.Core.Variables;

namespace IKaan.Win.Core.Helper
{
	public partial class MsgBoxForm : XtraForm
	{
		public MsgBoxForm()
		{
			InitializeComponent();
			Init();

			btnOk.Click += delegate (object sender, System.EventArgs e)
			{
				Close();
			};
			Shown += delegate (object sender, System.EventArgs e)
			{
				btnOk.Focus();
			};
		}

		private void Init()
		{
			this.LookAndFeel.UseDefaultLookAndFeel =
				sc.LookAndFeel.UseDefaultLookAndFeel = false;
			this.LookAndFeel.SetSkinStyle(GlobalVar.SkinInfo.FormSkin);
			sc.LookAndFeel.SetSkinStyle(GlobalVar.SkinInfo.FormSubSkin);

			FormBorderStyle = FormBorderStyle.FixedDialog;
			StartPosition = FormStartPosition.CenterScreen;
			Icon = IconResource.comment;

			memMessage.ReadOnly = true;
		}

		public object Message
		{
			get { return memMessage.EditValue; }
			set { memMessage.EditValue = value; }
		}
	}
}
