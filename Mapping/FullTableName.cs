using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompleteSQL.Mapping
{
    public struct FullTableName
    {
        private readonly string m_table;

        private readonly string m_schema;

        private readonly string m_db;

        public string TableName
        {
            get
            {
                return m_table;
            }
        }

        public string SchemaName
        {
            get
            {
                return m_schema;
            }
        }

        public string DbName
        {
            get
            {
                return m_db;
            }
        }
        public FullTableName(string table, string schema, string db)
        {
            m_table = table;
            m_schema = schema;
            m_db = db;
        }

        public override string ToString()
        {
            return string.Concat(
                m_db!= null? m_db + ".":null,
                m_schema !=null?m_schema + ".":null,
                m_table
                );
        }

     
    }
}
