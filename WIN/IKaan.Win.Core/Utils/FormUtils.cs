using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Model.Base;
using IKaan.Win.Core.Forms;
using IKaan.Win.Core.Was.Handler;

namespace IKaan.Win.Core.Utils
{
	public static class FormUtils
	{
		public static IEnumerable<Control> GetAllControls(Control parent)
		{
			var controls = new List<Control>();
			parent.Controls.Cast<Control>().ToList().ForEach(x => controls.AddRange(GetAllControls(x))
			);
			controls.Add(parent);
			return controls;
		}

		public static bool IsExistsForm(string formName)
		{
			return Application.OpenForms.OfType<Form>().Where(x => x.Name == formName).Any();
		}

		public static Form GetForm(string formName)
		{
			if (IsExistsForm(formName))
			{
				return Application.OpenForms[formName];
			}
			else
			{
				return null;
			}
		}

		public static Assembly GetAssembly(string assemblyName)
		{
			try
			{
				Assembly assembly = null;
				if (Assembly.GetExecutingAssembly().Equals(Assembly.LoadFrom(string.Empty + assemblyName)))
				{
					assembly = Assembly.GetExecutingAssembly();
				}
				else
				{
					assembly = Assembly.LoadFrom(string.Format(@"{0}\\{1}", Application.StartupPath, assemblyName));
				}
				return assembly;
			}
			catch
			{
				throw;
			}
		}

		public static void ShowHelp(object helpId, object menuId = null)
		{
			if (helpId == null && menuId == null)
			{
				return;
			}
			try
			{
				string textValue;
				string rtfValue;
				string helpName;

				var parameter = new DataMap() { { "HelpId", helpId }, { "MenuId", menuId } };
				var data = WasHandler.GetData<HelpModel>("Auth", "GeHelpModelContent", null, parameter);
				if (data != null)
				{
					helpId = data.ID;
					helpName = data.HelpName.ToStringNullToEmpty();
					rtfValue = data.ContentByRte.ToStringNullToEmpty();
					textValue = data.Content.ToStringNullToEmpty();

					if (rtfValue.IsNullOrEmpty() == false || textValue.IsNullOrEmpty() == false)
					{
						HelpForm form = new HelpForm() { Name = string.Format("HELP_{0}", helpId), Text = "[도움말]", Subject = helpName };
						if (rtfValue.IsNullOrEmpty())
						{
							form.Content = textValue;
						}
						else
						{
							form.ContentByRte = rtfValue;
						}
						form.InsertDtime = data.CreatedOn.ToStringNullToEmpty();
						form.InsertUserName = data.CreatedByName.ToStringNullToEmpty();
						form.UpdateDtime = data.UpdatedOn.ToStringNullToEmpty();
						form.UpdateUserName = data.UpdatedByName.ToStringNullToEmpty();
						form.StartPosition = FormStartPosition.CenterScreen;
						form.TopMost = true;
						form.Show();
					}
				}
			}
			catch
			{
				throw;
			}
		}
	}
}
