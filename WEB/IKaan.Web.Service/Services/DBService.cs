using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Web.Caching;
using System.Reflection;
using System.Dynamic;

using IKaan.Web.Core.Helper;
using IKaan.Web.Model.SCM;

namespace IKaan.Web.Service.Services
{
    public class DBService
    {
        private string _dbName;
        private string _dbConnection;

        public DBService()
        {
            _dbName = "IKBiz";
            _dbConnection = ConfigurationManager.ConnectionStrings[_dbName].ToString();
        }

        public IQueryable<SQLParmeter> GetSpParametersAll()
        {

            IQueryable<SQLParmeter> cacheData = HttpContext.Current.Cache["UspParameter"] as IQueryable<SQLParmeter>;

            // 캐쉬에 데이터가 없을경우 적재 
            if (cacheData == null)
            {
                using (SqlHelper db = new SqlHelper(_dbName))
                {
                    SqlParameterCollection pa = new SqlParameterCollection();
                    DataSet ds = db.ExecuteDataSet("UspCacheProcedureSelect", pa, CommandType.StoredProcedure);
                    cacheData = EntityHelper.ConvertToList<SQLParmeter>(ds.Tables[0]).AsQueryable();
                }
                
                HttpContext.Current.Cache.Insert("UspParameter", cacheData, null, DateTime.Now.AddDays(30), Cache.NoSlidingExpiration);
            }
            return cacheData;
        }

        /// <summary>
        /// 캐쉬에 존재하는 SQL 프로시져 정보를 가져옴
        /// </summary>
        /// <param name="spName"></param>
        /// <returns></returns>
        public IQueryable<SQLParmeter> GetSpParameters(string spName)
        {
            return (from c in this.GetSpParametersAll()
                    where c.ObjectName == spName
                    select c);
        }

        /// <summary>
        /// 모델과 SQL프로시져 파라미터를 매핑
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <param name="spName"></param>
        /// <returns></returns>
        public SqlParameterCollection GetParam<T>(T model, string spName)
        {

            var param = this.GetSpParameters(spName);

            SqlParameterCollection pa = new SqlParameterCollection();

            foreach (var p in param)
            {
                foreach (PropertyInfo info in model.GetType().GetProperties())
                {
                    if (info.CanRead)
                    {
                        if (info.Name.ToUpper() == p.ParameterName.ToUpper().Replace("@", ""))
                        {
                            object o = info.GetValue(model, null);
                            pa.Add(p.ParameterName, o);
                        }
                    }
                }
            }

            return pa;

        }

        /// <summary>
        ///  json 딕셔너리 파라미터 가져오기 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="spName"></param>
        /// <returns></returns>
        public SqlParameterCollection GetParam(IDictionary<string, object> model, string spName)
        {
            var param = this.GetSpParameters(spName);
            SqlParameterCollection pa = new SqlParameterCollection();

            foreach (var p in param)
            {
                foreach (var item in model)
                {
                    if (item.Key.ToUpper() == p.ParameterName.ToUpper().Replace("@", ""))
                    {
                        pa.Add(p.ParameterName, item.Value);
                    }

                }
            }

            return pa;

        }

        /// <summary>
        /// 리스트가져오기
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <param name="spName"></param>
        /// <returns></returns>

        public List<T> GetList<T>(T model, string spName) where T : new()
        {
            int returnValue = -1;
            return GetList<T>(model, spName, out returnValue);
        }

        /// <summary>
        /// 리스트 가져오기 (OUT 리턴)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <param name="spName"></param>
        /// <param name="returnValue"></param>
        /// <returns></returns>
        public List<T> GetList<T>(T model, string spName, out int returnValue) where T : new()
        {
            Type t = typeof(T);
            List<T> returnObject = new List<T>();

            using (SqlHelper sql = new SqlHelper(_dbName))
            {
                SqlParameterCollection param = this.GetParam(model, spName);
                param.Add("@Return_Value", SqlDbType.BigInt, 16, ParameterDirection.ReturnValue);

                DataSet ds = sql.ExecuteDataSet(spName, param, CommandType.StoredProcedure);
                returnValue = Convert.ToInt32(sql.GetReturnValue("@Return_Value"));

                returnObject = EntityHelper.ConvertToList<T>(ds.Tables[0]);

                return returnObject;


            }

        }

        /// <summary>
        ///  리스트 가져오기 - JSON 파라미터용
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="paramString"></param>
        /// <param name="spName"></param>
        /// <returns></returns>
        public List<T> GetList<T>(string paramString, string spName) where T : new()
        {
            int returnValue = -1;
            return GetList<T>(paramString, spName, out returnValue);
        }


        public List<T> GetList<T>(string paramString, string spName, out int returnValue) where T : new()
        {
            Type t = typeof(T);
            List<T> returnObject = new List<T>();

            using (SqlHelper sql = new SqlHelper(_dbName))
            {
                IDictionary<string, object> model = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<IDictionary<string, object>>(paramString);

                SqlParameterCollection param = this.GetParam(model, spName);
                param.Add("@Return_Value", SqlDbType.BigInt, 16, ParameterDirection.ReturnValue);

                DataSet ds = sql.ExecuteDataSet(spName, param, CommandType.StoredProcedure);
                returnValue = Convert.ToInt32(sql.GetReturnValue("@Return_Value"));

                returnObject = EntityHelper.ConvertToList<T>(ds.Tables[0]);

                return returnObject;


            }

        }


        /// <summary>
        /// 로우 가져오기
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <param name="spName"></param>
        /// <returns></returns>

        public T GetRow<T>(T model, string spName) where T : new()
        {
            int returnValue = -1;
            return GetRow<T>(model, spName, out returnValue);
        }

        /// <summary>
        /// 로우 가져오기 (OUT리턴)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <param name="spName"></param>
        /// <param name="returnValue"></param>
        /// <returns></returns>
        public T GetRow<T>(T model, string spName, out int returnValue) where T : new()
        {
            Type t = typeof(T);
            T returnObject = new T();

            using (SqlHelper sql = new SqlHelper(_dbName))
            {

                SqlParameterCollection param = this.GetParam(model, spName);
                param.Add("@Return_Value", SqlDbType.BigInt, 16, ParameterDirection.ReturnValue);

                DataSet ds = sql.ExecuteDataSet(spName, param, CommandType.StoredProcedure);
                returnValue = Convert.ToInt32(sql.GetReturnValue("@Return_Value"));

                returnObject = EntityHelper.ConvertToEntity<T>(ds.Tables[0].Rows[0]);

                return returnObject;


            }

        }

        /// <summary>
        /// 단일값 가져오기
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <param name="spName"></param>
        /// <returns></returns>
        public object GetScalar<T>(T model, string spName) where T : new()
        {
            int returnValue = -1;
            return this.GetScalar<T>(model, spName, out returnValue);
        }

        /// <summary>
        /// 단일값 가져오기 (OUT리턴)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <param name="spName"></param>
        /// <param name="returnValue"></param>
        /// <returns></returns>
        public object GetScalar<T>(T model, string spName, out int returnValue) where T : new()
        {

            using (SqlHelper sql = new SqlHelper(_dbName))
            {
                SqlParameterCollection param = this.GetParam(model, spName);
                param.Add("@Return_Value", SqlDbType.BigInt, 16, ParameterDirection.ReturnValue);
                object value = sql.ExecuteScalar(spName, param, CommandType.StoredProcedure);
                returnValue = Convert.ToInt32(sql.GetReturnValue("@Return_Value"));

                return value;

            }
        }


        /// <summary>
        /// 실행하기 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <param name="spName"></param>
        /// <returns></returns>

        public int Execute<T>(T model, string spName) where T : new()
        {
            using (SqlHelper sql = new SqlHelper(_dbName))
            {
                var param = this.GetParam(model, spName);
                param.Add("@Return_Value", SqlDbType.BigInt, 16, ParameterDirection.ReturnValue);
                sql.ExecuteNonQuery(spName, param, CommandType.StoredProcedure);

                return Convert.ToInt32(sql.GetReturnValue("@Return_Value"));


            }
        }


        /// <summary>
        /// GET LIST - JSON STRING
        /// </summary>
        /// <param name="paramString"></param>
        /// <param name="spName"></param>
        /// <returns></returns>
        public string GetList(string paramString, string spName)
        {
            using (SqlHelper sql = new SqlHelper(_dbName))
            {
                IDictionary<string, object> model = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<IDictionary<string, object>>(paramString);

                SqlParameterCollection param = this.GetParam(model, spName);
                param.Add("@Return_Value", SqlDbType.BigInt, 16, ParameterDirection.ReturnValue);


                DataSet ds = sql.ExecuteDataSet(spName, param, CommandType.StoredProcedure);
                ds.DataSetName = "json_ds";

                for (int i = 0; i < ds.Tables.Count; i++)
                {
                    ds.Tables[i].TableName = "json_table_" + i.ToString();

                    foreach (DataColumn col in ds.Tables[i].Columns)
                    {
                        col.ColumnName = col.ColumnName.ToLower();
                    }

                }

                return JsonHelper.DataSetToJson(ds);

            }
        }


        public object GetScalar(string paramString, string spName)
        {
            using (SqlHelper sql = new SqlHelper(_dbName))
            {
                IDictionary<string, object> model = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<IDictionary<string, object>>(paramString);

                SqlParameterCollection param = this.GetParam(model, spName);

                object value = sql.ExecuteScalar(spName, param, CommandType.StoredProcedure);

                return value;

            }

        }

        public int Execute(string paramString, string spName)
        {
            using (SqlHelper sql = new SqlHelper(_dbName))
            {
                IDictionary<string, object> model = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<IDictionary<string, object>>(paramString);
                SqlParameterCollection param = this.GetParam(model, spName);
                param.Add("@Return_Value", SqlDbType.BigInt, 16, ParameterDirection.ReturnValue);
                sql.ExecuteNonQuery(spName, param, CommandType.StoredProcedure);

                return Convert.ToInt32(sql.GetReturnValue("@Return_Value"));


            }
        }
    }
    
}