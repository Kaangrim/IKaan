using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Biz.Core.Helper;
using IKaan.Biz.Core.Model;
using IKaan.Biz.Core.Utils;

namespace IKaan.Biz.Core.Controls.Common
{
	[ToolboxItem(true)]
	public partial class XLookup : LookUpEdit, IControlExtension
	{
		public bool mIsEnable = true;
		private int _recordCount = 0;
		private string _nullText = string.Empty;
		private bool _mNullable = false;
		private string _listMember = "ListName";
		private bool _IsSetInit = false;

		public XLookup()
		{
			InitializeComponent();

			if (!DesignMode)
			{
				Paint += delegate (object sender, System.Windows.Forms.PaintEventArgs e)
				{
					if (Properties.ReadOnly == false && Enabled)
					{
						if (!Properties.Buttons.Cast<EditorButton>().Where(x => x.Kind == ButtonPredefines.Combo).Any())
						{
							Properties.Buttons.Add(new EditorButton(ButtonPredefines.Combo));
						}

						if (_mNullable && !Properties.Buttons.Cast<EditorButton>().Where(x => x.Kind == ButtonPredefines.Delete).Any())
						{
							Properties.Buttons.Add(new EditorButton(ButtonPredefines.Delete, "삭제"));
						}
						else
						{
							if (_mNullable == false && Properties.Buttons.Cast<EditorButton>().Where(x => x.Kind == ButtonPredefines.Delete).Any())
							{
								ClearDeleteButton();
							}
						}

						if(!Properties.Buttons.OfType<EditorButton>().Where(x=>x.Kind== ButtonPredefines.Redo).Any())
						{
							Properties.Buttons.Add(new EditorButton(ButtonPredefines.Redo, "재구성"));
						}
					}
					else
					{
						Properties.Buttons.Clear();
					}
				};
			}

			ButtonClick += delegate (object sender, ButtonPressedEventArgs e)
			{
				if (e.Button.Kind == ButtonPredefines.Delete)
				{
					EditValue = null;
				}
				else if(e.Button.Kind== ButtonPredefines.Redo)
				{
					BindData(GroupCode, _nullText, true);
				}
			};
		}

		[Browsable(true)]
		public string GroupCode { get; set; }

		[Browsable(true)]
		public string ValueMember
		{
			get
			{
				return Properties.ValueMember;
			}
			set
			{
				Properties.ValueMember = value;
			}
		}

		[Browsable(true)]
		public string DisplayMember
		{
			get
			{
				return Properties.DisplayMember;
			}
			set
			{
				Properties.DisplayMember = value;
			}
		}

		[Browsable(true)]
		public string ListMember
		{
			get
			{
				return _listMember;
			}
			set
			{
				_listMember = value;
			}
		}

		[Browsable(false)]
		public LookUpColumnInfoCollection Columns
		{
			get
			{
				return Properties.Columns;
			}
		}

		[Browsable(true)]
		public string NullText
		{
			get
			{
				return Properties.NullText;
			}
			set
			{
				Properties.NullText = value;
			}
		}

		[Browsable(false)]
		public int RowCount
		{
			get
			{
				return _recordCount;
			}
		}

		[Browsable(false)]
		public int SelectedIndex
		{
			get
			{
				return ItemIndex;
			}
			set
			{
				if (Properties.DataSource != null)
				{
					ItemIndex = value;
				}
			}
		}

		public void Init()
		{
			Properties.BestFitMode = BestFitMode.BestFit;
			Properties.SearchMode = SearchMode.AutoComplete;
			Properties.AutoSearchColumnIndex = 1;
			Properties.AllowNullInput = DefaultBoolean.False;
			Properties.ShowHeader = false;
			Properties.ShowFooter = false;
			NullText = string.Empty;
		}

		public void Clear()
		{
			EditValue = null;
		}

		public void ShowDeleteButton()
		{
			Properties.Buttons.OfType<EditorButton>().Where(x => x.Kind == ButtonPredefines.Delete).ToList().ForEach(x =>
				x.Visible = true
			);
		}
		public void HideDeleteButton()
		{
			Properties.Buttons.OfType<EditorButton>().Where(x => x.Kind == ButtonPredefines.Delete).ToList().ForEach(x =>
				x.Visible = false
			);
		}
		public void ClearDeleteButton()
		{
			foreach (var item in Properties.Buttons.OfType<EditorButton>().ToList().Where(button => button.Kind == ButtonPredefines.Delete))
			{
				Properties.Buttons.RemoveAt(item.Index);
			}
		}

		private void AddDeleteButton()
		{
			foreach (var item in Properties.Buttons.OfType<EditorButton>().ToList().Where(button => button.Kind == ButtonPredefines.Delete))
			{
				Properties.Buttons.RemoveAt(item.Index);
			}
			Properties.Buttons.Add(new EditorButton() { Kind = ButtonPredefines.Delete });
		}

		public void AddColumn(string fieldName)
		{
			AddColumn(fieldName, ResourceUtils.GetColumnCaption(fieldName));
		}
		public void AddColumn(string fieldName, string caption)
		{
			Properties.Columns.Add(new LookUpColumnInfo()
			{
				FieldName = fieldName,
				Caption = caption
			});
		}

		public void AddColumns(string[] columns)
		{
			if (columns != null)
			{
				foreach (string col in columns)
				{
					AddColumn(col);
				}
			}
		}

		public void SetValueAndDisplayMember(string valueMember, string displayMember)
		{
			if (!string.IsNullOrEmpty(valueMember))
			{
				ValueMember = valueMember;
			}
			if (!string.IsNullOrEmpty(displayMember))
			{
				DisplayMember = displayMember;
			}
		}

		public void SetDefault(bool bDeleteButtonVisible = true)
		{
			Init();
			Columns.Clear();
			SetValueAndDisplayMember("Code", "DispName");
			AddColumns(new string[] { "Code", "Name", "ListName", "DispName" });

			Columns["Code"].Visible = false;
			Columns["Name"].Visible = false;
			Columns["DispName"].Visible = false;

			_mNullable = false;
			ClearDeleteButton();
			if (bDeleteButtonVisible)
			{
				AddDeleteButton();
			}
			_IsSetInit = true;
		}

		public void SetNullText(string text)
		{
			SetDefault();
			Properties.AllowNullInput = DefaultBoolean.True;
			Properties.NullText = text;
			_nullText = text;
			_mNullable = true;
		}
		public void SetNullText()
		{
			SetNullText("None");
		}

		public void BindData(string groupCode, string nullText = null, bool init = false, DataMap parameter = null)
		{
			if (init == true || _IsSetInit == false)
			{
				if (nullText.IsNullOrEmpty())
				{
					SetDefault();
				}
				else
				{
					SetNullText(nullText);
				}
			}

			if (groupCode.IsNullOrEmpty() == false)
			{
				GroupCode = groupCode;
			}

			object value = null;
			if (Properties.DataSource != null && EditValue != null)
			{
				value = EditValue;
			}

			//글로벌 변수에 정의된 공통코드를 읽어온다.
			var datasource = CodeHelper.GetLookup(this.GroupCode, _nullText, parameter);

			_recordCount = datasource.Count;
			Properties.DataSource = datasource;

			if (RowCount > 0)
			{
				if (value != null)
				{
					EditValue = value;
				}
				else
				{
					if (Properties.AllowNullInput == DefaultBoolean.False)
					{
						SelectedIndex = 0;
					}
					else
					{
						EditValue = null;
					}
				}

				if (RowCount <= 20)
				{
					Properties.DropDownRows = RowCount;
				}
				else
				{
					Properties.DropDownRows = 20;
				}
			}
		}

		public int GetRowCount() { return Properties.DropDownRows; }

		public int GetSelectedIndex() { return ItemIndex; }

		public void SetSelectedIndex(int index) { ItemIndex = index; }

		public object GetValue(int optionNumber)
		{
			var data = this.GetSelectedDataRow() as LookupSource;
			if (data == null)
				return string.Empty;

			if (optionNumber == 0)
				return data.Value;
			else if (optionNumber == 1)
				return data.Option1;
			else if (optionNumber == 2)
				return data.Option2;
			else if (optionNumber == 3)
				return data.Option3;
			else if (optionNumber == 4)
				return data.Option4;
			else if (optionNumber == 5)
				return data.Option5;
			else if (optionNumber == 6)
				return data.Option6;
			else if (optionNumber == 7)
				return data.Option7;
			else if (optionNumber == 8)
				return data.Option8;
			else if (optionNumber == 9)
				return data.Option9;

			return null;
		}

		public void SetForeColor(Color color)
		{
			Properties.Appearance.Options.UseForeColor = true;
			Properties.Appearance.ForeColor = color;
		}

		public void SetEnable(bool bEnable = false, Color? backColor = null)
		{
			mIsEnable = bEnable;
			Properties.AllowFocused = bEnable;
			Properties.ReadOnly = !bEnable;

			if (bEnable == false)
			{
				Properties.Appearance.BackColor = SkinUtils.DisableBackColor;
				Properties.Appearance.ForeColor = SkinUtils.DisableForeColor;
			}
			else
			{
				Properties.Appearance.Options.UseBackColor = false;
				Properties.Appearance.Options.UseForeColor = false;
			}

			if (backColor != null)
			{
				Properties.Appearance.Options.UseBackColor = true;
				Properties.Appearance.BackColor = (Color)backColor;
			}

			if (Properties.Buttons.Count > 0)
			{
				foreach (EditorButton btn in Properties.Buttons)
				{
					btn.Visible = bEnable;
				}
			}
		}

		protected override void OnEnter(EventArgs e)
		{
			//if (!Properties.ReadOnly && Enabled)
			//{
			//	BackColor = SkinUtils.EditBackColor;
			//	ForeColor = SkinUtils.EditForeColor;
			//}
			base.OnEnter(e);
		}
		protected override void OnLeave(EventArgs e)
		{
			//if (!Properties.ReadOnly && Enabled)
			//{
			//	BackColor = SkinUtils.BackColor();
			//	ForeColor = SkinUtils.ForeColor();
			//}
			base.OnLeave(e);
		}
	}
}
