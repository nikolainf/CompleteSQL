using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace CompleteSQL.Mapping
{
    public class SqlTableNameMapper
    {
        
        public FullTableName GetFullTableName(Type type)
        {
            SqlTableAttribute tableAttribute = type.GetCustomAttribute<SqlTableAttribute>();
            if (tableAttribute == null)
                throw new ArgumentException();

            string table = tableAttribute.Name ?? type.Name;
            string schema = string.IsNullOrWhiteSpace(tableAttribute.Schema)?null: tableAttribute.Schema;
            string db = string.IsNullOrWhiteSpace(tableAttribute.DB) ? null : tableAttribute.DB;

            return new FullTableName(table, schema, db);
        }


    }
}
