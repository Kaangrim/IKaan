using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;

using IKaan.Web.Core.Helper;
using IKaan.Web.Model.SCM;
using IKaan.Web.Model.SCM.Biz;

namespace IKaan.Web.Service.Services
{
    public class AccountService
    {
        private string _dbName;
        private string _dbConnection;
        public AccountService()
        {
            _dbName = "IKBiz";
            _dbConnection = ConfigurationManager.ConnectionStrings[_dbName].ToString();
        }

        public ContactModel UserSSLLogin(string LoginID, string LoginPW)
        {

            using (SqlHelper sql = new SqlHelper(_dbName))
            {
                SqlParameterCollection pa = new SqlParameterCollection
                {
                    { "@pLoginID", LoginID },
                    { "@pLoginPW", LoginPW }
                };

                DataSet ds = sql.ExecuteDataSet("UspContactLoginSelect", pa, CommandType.StoredProcedure);


                return ds.Tables[0].Rows.Count == 0 ? null : EntityHelper.ConvertToEntity<ContactModel>(ds.Tables[0].Rows[0]);
            }


        }
    }
}