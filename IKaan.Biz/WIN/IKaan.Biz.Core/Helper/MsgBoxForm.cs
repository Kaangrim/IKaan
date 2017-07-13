using System.Windows.Forms;
using DevExpress.XtraEditors;
using IKaan.Biz.Core.Resources;

namespace IKaan.Biz.Core.Helper
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
