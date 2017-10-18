using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace IKaan.Web.Core.Helper
{
    public class SqlParameterCollection : IEnumerable
    {
        private List<object> list;

        public int Count
        {
            get
            {
                return this.list.Count;
            }
        }

        public SqlParameter this[int index]
        {
            get
            {
                return (SqlParameter)this.list[index];
            }
        }

        public SqlParameterCollection()
        {
            this.list = new List<object>();
        }

        public void Add(string name, object value)
        {
            SqlParameter sqlParameter = new SqlParameter
            {
                ParameterName = name,
                Value = value
            };
            this.list.Add((object)sqlParameter);
        }

        public void Add(string name, SqlDbType type, int size, object value)
        {
            SqlParameter sqlParameter = new SqlParameter
            {
                ParameterName = name,
                SqlDbType = type,
                Size = size,
                Value = value
            };
            this.list.Add((object)sqlParameter);
        }

        public void Add(string name, SqlDbType type, int size, ParameterDirection direction)
        {
            SqlParameter sqlParameter = new SqlParameter
            {
                ParameterName = name,
                SqlDbType = type,
                Size = size,
                Direction = direction
            };
            this.list.Add((object)sqlParameter);
        }

        public void Add(string name, SqlDbType type, int size, ParameterDirection direction, object value)
        {
            SqlParameter sqlParameter = new SqlParameter
            {
                ParameterName = name,
                SqlDbType = type,
                Size = size,
                Direction = direction,
                Value = value
            };
            this.list.Add((object)sqlParameter);
        }

        public void Clear()
        {
            this.list.Clear();
        }

        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)this.list.GetEnumerator();
        }
    }
}