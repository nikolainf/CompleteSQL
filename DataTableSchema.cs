using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompleteSQL
{
    public class DataTableSchema
    {

        public DataTableSchema(string tableName, IEnumerable<DataColumnSchema> columns)
        {
            TableName = tableName;
            Columns = columns;
        }

        public readonly string TableName;

        public readonly IEnumerable<DataColumnSchema> Columns;
    }
}
