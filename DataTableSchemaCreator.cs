using CompleteSQL.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CompleteSQL
{
    public class DataTableSchemaCreator
    {
        public DataTableSchema CreateSchema<T>(string tableName)
        {
            PropertyInfo[] props = typeof(T).GetProperties();
            bool b = props[0].GetGetMethod().IsPublic;
            
            List<DataColumnSchema> columnSchemaList = new List<DataColumnSchema>();
            foreach(PropertyInfo prop in typeof(T).GetProperties(BindingFlags.Public| BindingFlags.Instance))
            {
             
                columnSchemaList.Add(new DataColumnSchema(prop.Name, prop.PropertyType));
            }

            if (string.IsNullOrWhiteSpace(tableName))
            {
                tableName = (new SqlTableNameMapper()).GetFullTableName(typeof(T)).ToString();
            }

            return new DataTableSchema(tableName, columnSchemaList);
        }

        public DataTableSchema CreateSchema<T>()
        {
            string tableName = typeof(T).Name;

            return CreateSchema<T>(tableName);
        }
    }
}
