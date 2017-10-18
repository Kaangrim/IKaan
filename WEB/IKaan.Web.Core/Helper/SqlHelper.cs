using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
namespace IKaan.Web.Core.Helper
{
    public class SqlHelper : IDisposable
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataAdapter da;
        private DataSet ds;

        public SqlHelper()
        {
            this.connectionstring = ConfigurationManager.ConnectionStrings["IKBiz"].ToString();
        }

        public SqlHelper(string connectionString)
        {
            this.connectionstring = ConfigurationManager.ConnectionStrings[connectionString].ToString();
        }

        public string connectionstring { get; set; }

        public DataSet ExecuteDataSet(string query, SqlParameterCollection param, CommandType cmdType)
        {
            using (this.con = new SqlConnection(this.connectionstring))
            {
                this.cmd = new SqlCommand(query, this.con);
                this.cmd.CommandType = cmdType;
                this.da = new SqlDataAdapter(this.cmd);
                this.ds = new DataSet();
                if (param != null && param.Count > 0)
                {
                    foreach (SqlParameter sqlParameter in param)
                        this.cmd.Parameters.Add(sqlParameter);
                }
                this.con.Open();
                this.da.Fill(this.ds);
            }
            return this.ds;
        }

        public int ExecuteNonQuery(string query, SqlParameterCollection param, CommandType cmdType)
        {
            int num = 0;
            using (this.con = new SqlConnection(this.connectionstring))
            {
                this.cmd = new SqlCommand(query, this.con);
                this.cmd.CommandType = cmdType;
                if (param != null && param.Count > 0)
                {
                    foreach (SqlParameter sqlParameter in param)
                        this.cmd.Parameters.Add(sqlParameter);
                }
                this.con.Open();
                num = this.cmd.ExecuteNonQuery();
            }
            return num;
        }

        public object ExecuteScalar(string query, SqlParameterCollection param, CommandType cmdType)
        {
            object obj;
            using (this.con = new SqlConnection(this.connectionstring))
            {
                this.cmd = new SqlCommand(query, this.con);
                this.cmd.CommandType = cmdType;
                if (param != null && param.Count > 0)
                {
                    foreach (SqlParameter sqlParameter in param)
                        this.cmd.Parameters.Add(sqlParameter);
                }
                this.con.Open();
                obj = this.cmd.ExecuteScalar();
            }
            return obj;
        }

        public object GetReturnValue(string paramName)
        {
            return this.cmd.Parameters[paramName].Value;
        }

        public object GetOutputValue(string paramName)
        {
            return this.cmd.Parameters[paramName].Value;
        }

        public void Dispose()
        {
            if (this.con != null)
                this.con.Dispose();
            if (this.cmd != null)
                this.cmd.Dispose();
            if (this.da != null)
                this.da.Dispose();
            if (this.ds != null)
                this.ds.Dispose();
            GC.SuppressFinalize((object)this);
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}