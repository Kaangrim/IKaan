using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;
using System.Text;

namespace IKaan.Web.Core.Utils
{
    public class ComUtils
    {
        //alert 창 띄우기
        public static string JavascriptAlert(string str)
        {
            StringBuilder strbuild = new StringBuilder("");

            strbuild.Append("<script language=\"javascript\">");
            strbuild.Append("   alert(\"" + str + "\");");
            strbuild.Append("</" + "script>");

            return strbuild.ToString();
        }
        //Window.open
        public static string Javascriptwindowopen(string str, string at)
        {
            StringBuilder strbuild = new StringBuilder("");

            strbuild.Append("<script language=\"javascript\">");
            strbuild.Append("   window.open(\"" + str + "\",\"\",\"" + at + "\");");
            strbuild.Append("</" + "script>");

            return strbuild.ToString();
        }
        public static string Javascriptwindowopen(string str)
        {
            StringBuilder strbuild = new StringBuilder("");

            strbuild.Append("<script language=\"javascript\">");
            strbuild.Append("   window.open(\"" + str + "\",\"\",\"\");");
            strbuild.Append("</" + "script>");

            return strbuild.ToString();
        }

        public static string JavascriptRedirect(string str)
        {
            StringBuilder strbuild = new StringBuilder("");

            strbuild.Append("<script language=\"javascript\">");
            strbuild.Append("   document.location.href=\'" + str + "';");
            strbuild.Append("</" + "script>");

            return strbuild.ToString();
        }

        public static string JavascriptReload()
        {
            StringBuilder strbuild = new StringBuilder("");

            strbuild.Append("<script language=\"javascript\">");
            strbuild.Append("window.location.reload(true);");
            strbuild.Append("</" + "script>");

            return strbuild.ToString();
        }

        public static string JavascriptBack()
        {
            StringBuilder strbuild = new StringBuilder("");

            strbuild.Append("<script language=\"javascript\">");
            strbuild.Append("   history.back();");
            strbuild.Append("</" + "script>");

            return strbuild.ToString();
        }

        public static string JavascriptAlertAndBack(string str)
        {
            StringBuilder strbuild = new StringBuilder("");

            strbuild.Append("<script language=\"javascript\">");
            strbuild.Append("   alert(\"" + str + "\");history.back();");
            strbuild.Append("</" + "script>");

            return strbuild.ToString();
        }

        public static string JavascriptClose()
        {
            StringBuilder strbuild = new StringBuilder("");

            strbuild.Append("<script language=\"javascript\">");
            strbuild.Append("   self.close();");
            strbuild.Append("</" + "script>");

            return strbuild.ToString();
        }

        public static string HTMLtoSQLServer(string str)
        {
            StringBuilder strbuild = new StringBuilder(str);

            strbuild.Replace("'", "''");

            return strbuild.ToString();
        }

        public static string JavascriptAlertAndLocation(string str, string locationstr)
        {
            StringBuilder strbuild = new StringBuilder("");

            strbuild.Append("<script language=\"javascript\">");
            strbuild.Append("   alert(\"" + str + "\");location.href=\"" + locationstr + "\";");
            strbuild.Append("</" + "script>");

            return strbuild.ToString();
        }

        public static string JavascriptAlertAndOpenerReload(string str)
        {
            StringBuilder strbuild = new StringBuilder("");

            strbuild.Append("<script language=\"javascript\">");
            strbuild.Append("   alert(\"" + str + "\");window.opener.location.reload();window.close();");
            strbuild.Append("</" + "script>");

            return strbuild.ToString();
        }

        //html를 해석을 못하게 할때 이 함수를 가져다 쓴다.
        public static string TagDisable(string str)
        {
            StringBuilder strbuild = new StringBuilder(str);

            strbuild.Replace("&apos;", "'");
            strbuild.Replace("&", "&amp;");
            strbuild.Replace("<", "&lt;");
            strbuild.Replace(">", "&gt;");
            strbuild.Replace("\n", "<br>");
            strbuild.Replace("\t", "&nbsp;&nbsp;&nbsp;&nbsp;");
            strbuild.Replace(" ", "&nbsp;");

            return strbuild.ToString();
        }

        public static string Tagdate(string str)
        {
            StringBuilder strbuild = new StringBuilder(str);

            strbuild.Replace("&apos;", "'");
            strbuild.Replace("&", "&amp;");
            strbuild.Replace("<", "&lt;");
            strbuild.Replace(">", "&gt;");
            strbuild.Replace("\n", "");
            strbuild.Replace("\r", "");
            strbuild.Replace("\"", "");
            strbuild.Replace("\t", "&nbsp;&nbsp;&nbsp;&nbsp;");
            strbuild.Replace(" ", "&nbsp;");

            return strbuild.ToString();
        }

        public static string Taglecture(string str)
        {


            StringBuilder strbuild = new StringBuilder(str);

            strbuild.Replace("\r\n", "<br>");

            return strbuild.ToString();
        }

        //XSS injection 처리
        public static string ChkXSS(string strval)
        {
            if (string.IsNullOrEmpty(strval))
            {
                strval = "";
            }
            else
            {
                strval = strval.Replace("'", "");
                strval = strval.Replace("--", "");
                strval = strval.Replace(":", "");
                strval = strval.Replace("&", "");
                strval = strval.Replace("<", "");
                strval = strval.Replace(">", "");
                strval = strval.Replace("%", "");
                strval = strval.Replace(";", "");
                strval = strval.Replace("(", "");
                strval = strval.Replace(")", "");
                strval = strval.Replace("+", "");
            }

            return strval;
        }

        //SQL injection 처리
        public static string ChkSql(string strval)
        {
            if (string.IsNullOrEmpty(strval))
            {
                strval = "";
            }
            else
            {
                strval = strval.Replace("'", "");
                strval = strval.Replace(";", "");
                strval = strval.Replace("--", "");
                strval = strval.Replace("<", "");
                strval = strval.Replace(">", "");
            }

            return strval;
        }
    }
}