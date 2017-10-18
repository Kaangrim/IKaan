using Newtonsoft.Json;
using System.Data;
using System.IO;
using System.Text;
using System.Xml;

namespace IKaan.Web.Core.Helper
{
    public class JsonHelper
    {
        public static string DataTableToJson(DataTable Dt)
        {
            string[] strArray = new string[Dt.Columns.Count];
            string str1 = string.Empty;
            for (int index = 0; index < Dt.Columns.Count; ++index)
            {
                strArray[index] = Dt.Columns[index].Caption;
                str1 = str1 + "\"" + strArray[index] + "\" : \"" + strArray[index] + index.ToString() + "\x00BE\",";
            }
            string str2 = str1.Substring(0, str1.Length - 1);
            StringBuilder stringBuilder1 = new StringBuilder();
            stringBuilder1.Append("{\"" + Dt.TableName + "\" : [");
            for (int index1 = 0; index1 < Dt.Rows.Count; ++index1)
            {
                string str3 = str2;
                stringBuilder1.Append("{");
                for (int index2 = 0; index2 < Dt.Columns.Count; ++index2)
                    str3 = str3.Replace(Dt.Columns[index2].ToString() + index2.ToString() + "\x00BE", Dt.Rows[index1][index2].ToString());
                stringBuilder1.Append(str3 + "},");
            }
            StringBuilder stringBuilder2 = new StringBuilder(stringBuilder1.ToString().Substring(0, stringBuilder1.ToString().Length - 1));
            stringBuilder2.Append("]}");
            return stringBuilder2.ToString();
        }

        public static string DataSetToJson(DataSet ds)
        {
            StringWriter stringWriter = new StringWriter();
            ds.WriteXml((TextWriter)stringWriter, XmlWriteMode.IgnoreSchema);
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(stringWriter.ToString());
            return JsonConvert.SerializeXmlNode((XmlNode)xmlDocument);
        }
    }
}
