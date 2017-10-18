using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Web.Mvc;

namespace IKaan.Web.Core.Helper
{
    public static class EntityHelper
    {
        public static T ConvertToEntity<T>(this DataRow tableRow) where T : new()
        {
            Type type = typeof(T);
            T obj1 = new T();
            foreach (DataColumn column in (InternalDataCollectionBase)tableRow.Table.Columns)
            {
                string columnName = column.ColumnName;
                PropertyInfo property = type.GetProperty(columnName.ToLower(), BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);
                if (property != (PropertyInfo)null)
                {
                    object obj2 = tableRow[columnName];
                    object obj3 = !(Nullable.GetUnderlyingType(property.PropertyType) != (Type)null) ? (!(obj2 is DBNull) ? Convert.ChangeType(obj2, property.PropertyType) : (object)null) : (!(obj2 is DBNull) ? Convert.ChangeType(obj2, Nullable.GetUnderlyingType(property.PropertyType)) : (object)null);
                    property.SetValue((object)obj1, obj3, (object[])null);
                }
            }
            return obj1;
        }

        public static List<T> ConvertToList<T>(this DataTable table) where T : new()
        {
            Type type = typeof(T);
            List<T> objList = new List<T>();
            foreach (DataRow row in (InternalDataCollectionBase)table.Rows)
            {
                T entity = row.ConvertToEntity<T>();
                objList.Add(entity);
            }
            return objList;
        }

        public static DataTable ConvertToDataTable(this object obj)
        {
            PropertyInfo[] properties = obj.GetType().GetProperties();
            DataTable dataTable = new DataTable();
            foreach (PropertyInfo propertyInfo in properties)
                dataTable.Columns.Add(propertyInfo.Name, propertyInfo.GetType());
            DataRow dataRow = dataTable.NewRow();
            foreach (PropertyInfo propertyInfo in properties)
                dataRow[propertyInfo.Name] = propertyInfo.GetValue(obj, (object[])null);
            return dataTable;
        }
        
        
    }
}
