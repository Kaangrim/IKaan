using System;
using System.Collections.Generic;
using IKaan.Base.Utils;
using IKaan.Model.Biz.Catalog.Product;
using IKaan.Win.Core.Forms;
using IKaan.Win.Core.Model;

namespace IKaan.Win.View.Biz.Catalog.Product
{
	public partial class ProductOptionEditForm : EditForm
	{
		public ProductOptionEditForm()
		{
			InitializeComponent();
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			lupOption1Type.Focus();
		}

		protected override void InitButton()
		{
			base.InitButton();
			SetToolbarButtons(new ToolbarButtons() { Save = true });
		}
		protected override void InitControls()
		{
			base.InitControls();

			SetFieldNames();

			lupOption1Type.BindData("OptionType", "==선택하세요==");
			lupOption2Type.BindData("OptionType", "==선택하세요==");
		}

		protected override void DataSave(object arg, SaveCallback callback)
		{
			if (lupOption1Type.EditValue != null && memOption1Name.EditValue.IsNullOrEmpty())
			{
				ShowMsgBox("옵션명(1)을 입력하세요!!");
				memOption1Name.Focus();
				return;
			}

			if (lupOption1Type.EditValue == null && memOption1Name.EditValue.IsNullOrEmpty() == false)
			{
				ShowMsgBox("옵션유형(1)을 입력하세요!!");
				lupOption1Type.Focus();
				return;
			}

			if (lupOption2Type.EditValue != null && memOption2Name.EditValue.IsNullOrEmpty())
			{
				ShowMsgBox("옵션명(2)을 입력하세요!!");
				memOption2Name.Focus();
				return;
			}

			if (lupOption2Type.EditValue == null && memOption2Name.EditValue.IsNullOrEmpty() == false)
			{
				ShowMsgBox("옵션유형(2)을 입력하세요!!");
				lupOption2Type.Focus();
				return;
			}

			if (memOption2Name.EditValue.IsNullOrEmpty() == false && memOption1Name.EditValue.IsNullOrEmpty())
			{
				ShowMsgBox("옵션(1)을 선택, 입력하지 않고 옵션(2)를 입력할 수 없습니다.");
				return;
			}

			var options = new List<ProductItemModel>();
			if (memOption1Name.EditValue.IsNullOrEmpty() == false)
			{
				foreach (var opt1 in memOption1Name.EditValue.ToStringNullToEmpty().Split(','))
				{
					if (memOption2Name.EditValue.IsNullOrEmpty() == false)
					{
						foreach (var opt2 in memOption2Name.EditValue.ToStringNullToEmpty().Split(','))
						{
							options.Add(new ProductItemModel()
							{
								Option1Type = lupOption1Type.EditValue.ToStringNullToEmpty(),
								Option1Name = opt1,
								Option2Type = lupOption2Type.EditValue.ToStringNullToEmpty(),
								Option2Name = opt2
							});
						}
					}
					else
					{
						options.Add(new ProductItemModel()
						{
							Option1Type = lupOption1Type.EditValue.ToStringNullToEmpty(),
							Option1Name = opt1,
							Option2Type = null,
							Option2Name = null
						});
					}
				}
			}

			this.ReturnData = options;
			SetModifiedCount();
			Close();
		}
	}
}