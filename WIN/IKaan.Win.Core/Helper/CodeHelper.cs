using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Win.Core.Model;
using IKaan.Win.Core.Variables;
using IKaan.Win.Core.Was.Handler;
using IKaan.Model.Common.UserModels ;

namespace IKaan.Win.Core.Helper
{
	public static class CodeHelper
	{
		public static IList<LookupSource> GetLookup(string groupCode, string nullText = null, DataMap parameter = null)
		{
			if (parameter == null)
				parameter = new DataMap();

			//글로벌 변수에 정의된 공통코드를 읽어온다.
			var datasource = GlobalVar.Codes.OfType<UCodeLookup>().Where
				(x => x.GroupCode == groupCode &&
					(
						(
							parameter == null ||
							parameter.Count == 0
						) ||
						(
							(
								parameter.GetValue("Option1").IsNullOrEmpty() == false && 
								x.Option1.ToStringNullToEmpty() == parameter.GetValue("Option1").ToStringNullToEmpty()
							) ||
							(
								parameter.GetValue("Option2").IsNullOrEmpty() == false && 
								x.Option2.ToStringNullToEmpty() == parameter.GetValue("Option2").ToStringNullToEmpty()
							) ||
							(
								parameter.GetValue("Option3").IsNullOrEmpty() == false && 
								x.Option3.ToStringNullToEmpty() == parameter.GetValue("Option3").ToStringNullToEmpty()
							) ||
							(
								parameter.GetValue("Option4").IsNullOrEmpty() == false && 
								x.Option4.ToStringNullToEmpty() == parameter.GetValue("Option4").ToStringNullToEmpty()
							) ||
							(
								parameter.GetValue("Option5").IsNullOrEmpty() == false && 
								x.Option5.ToStringNullToEmpty() == parameter.GetValue("Option5").ToStringNullToEmpty()
							) ||
							(
								parameter.GetValue("Option6").IsNullOrEmpty() == false && 
								x.Option6.ToStringNullToEmpty() == parameter.GetValue("Option6").ToStringNullToEmpty()
							) ||
							(
								parameter.GetValue("Option7").IsNullOrEmpty() == false && 
								x.Option7.ToStringNullToEmpty() == parameter.GetValue("Option7").ToStringNullToEmpty()
							) ||
							(
								parameter.GetValue("Option8").IsNullOrEmpty() == false && 
								x.Option8.ToStringNullToEmpty() == parameter.GetValue("Option8").ToStringNullToEmpty()
							) ||
							(
								parameter.GetValue("Option9").IsNullOrEmpty() == false && 
								x.Option9.ToStringNullToEmpty() == parameter.GetValue("Option9").ToStringNullToEmpty()
							)
						)
					)
				).ToList();

			if (datasource == null)
				datasource = new List<UCodeLookup>();

			//글로벌 변수에 정의되지 않은 공통코드라면 서버에 요청한다.
			if (datasource.Count == 0)
			{
				parameter.SetValue("UseYn", "Y");
				var data = Search(groupCode, parameter);
				if (data != null && data.Count > 0)
				{
					data.OfType<UCodeHelp>().ToList().ForEach(x =>
					{
						datasource.Add(new UCodeLookup()
						{
							Code = x.Code,
							Name = x.Name,
							ListName = x.ListName,
							DispName = x.DispName,
							Value = x.Value,
							MaxLength = x.MaxLength,
							Option1 = x.Option1.ToStringNullToEmpty(),
							Option2 = x.Option2.ToStringNullToEmpty(),
							Option3 = x.Option3.ToStringNullToEmpty(),
							Option4 = x.Option4.ToStringNullToEmpty(),
							Option5 = x.Option5.ToStringNullToEmpty(),
							Option6 = x.Option6.ToStringNullToEmpty(),
							Option7 = x.Option7.ToStringNullToEmpty(),
							Option8 = x.Option8.ToStringNullToEmpty(),
							Option9 = x.Option9.ToStringNullToEmpty()
						});
					});
				}
			}

			IList<LookupSource> source = new List<LookupSource>();
			if (!string.IsNullOrEmpty(nullText))
			{
				source.Add(new LookupSource()
				{
					Code = null,
					Name = nullText,
					ListName = nullText,
					DispName = nullText,
					MaxLength = 0
				});
			}

			if (datasource.Count > 0)
			{
				foreach (UCodeLookup code in datasource)
				{
					source.Add(new LookupSource()
					{
						Code = code.Code,
						Name = code.Name,
						ListName = code.ListName,
						DispName = code.DispName,
						Value = code.Value,
						MaxLength = code.MaxLength,
						Option1 = code.Option1,
						Option2 = code.Option2,
						Option3 = code.Option3,
						Option4 = code.Option4,
						Option5 = code.Option5,
						Option6 = code.Option6,
						Option7 = code.Option7,
						Option8 = code.Option8,
						Option9 = code.Option9
					});
				}
			}
			return source;
		}
		public static IList<UCodeHelp> Search(string parentCode, DataMap parameters = null)
		{
			try
			{
				if (parameters == null)
					parameters = new DataMap();

				parameters.SetValue("ParentCode", parentCode);
				return WasHandler.GetList<UCodeHelp>("CodeHelp", "GetList", parentCode, parameters);
			}
			catch
			{
				throw;
			}
		}
		public static DataMap ShowForm(string parentCode, DataMap parameters, object data)
		{
			DataMap resultMap = new DataMap();
			try
			{
				if (parameters == null)
				{
					parameters = new DataMap();
				}
				parameters.SetValue("ParentCode", parentCode);

				string formName = "CodeHelperForm_" + parentCode;
				string formText = "코드검색";
				string codeField = "Code";
				string nameField = "Name";
				string[] displayFields = new string[] { "Code", "Name" };

				switch (parentCode)
				{
					case "ALL_PRODUCT":
						formText = "제품검색";
						codeField = "PRODUCT_ID";
						nameField = "PRODUCT_NAME";
						displayFields = new string[] { "PRODUCT_TYPE", "CATEGORY", "PRODUCT_ID", "PRODUCT_NAME", "PRODUCT_CODE" };
						break;
					case "MATERIAL":
						formText = "원부자재검색";
						codeField = "MATERIAL_ID";
						nameField = "MATERIAL_NAME";
						displayFields = new string[] { "MATERIAL_ID", "MATERIAL_NAME", "UNIT_TYPE" };
						break;
					case "PRODUCT":
					case "PROD_PRODUCT":
						formText = "제품검색";
						codeField = "PRODUCT_ID";
						nameField = "PRODUCT_NAME";
						displayFields = new string[] { "PRODUCT_ID", "PRODUCT_NAME", "PRODUCT_CODE" };
						break;
					case "PURCITEM":
						formText = "구매품목검색";
						codeField = "PRODUCT_ID";
						nameField = "PRODUCT_NAME";
						displayFields = new string[] { "PRODUCT_ID", "PRODUCT_NAME", "PRODUCT_CODE" };
						break;
					case "CUSTOMER":
						formText = "거래처검색";
						codeField = "CUSTOMER_ID";
						nameField = "CUSTOMER_NAME";
						displayFields = new string[] { "CUSTOMER_ID", "CUSTOMER_NAME", "BIZ_REG_NO", "REP_NAME" };
						break;
					case "USER":
						formText = "사용자검색";
						codeField = "USER_ID";
						nameField = "USER_NAME";
						displayFields = new string[] { "USER_ID", "USER_NAME" };
						break;
				}

				using (var form = new CodeHelperForm()
				{
					Name = formName,
					Text = formText,
					StartPosition = FormStartPosition.CenterScreen,
					CodeField = codeField,
					NameField = nameField,
					CodeGroup = parentCode,
					Parameters = parameters,
					DisplayFields = displayFields
				})
				{
					form.Init();
					form.BindData(data);

					if (form.ShowDialog() == DialogResult.OK)
					{
						if (form.ReturnData != null && form.ReturnData.GetType() == typeof(DataMap))
						{
							resultMap = (form.ReturnData as DataMap);
						}
					}
				}
				return resultMap;
			}
			catch
			{
				throw;
			}
		}
	}
}
