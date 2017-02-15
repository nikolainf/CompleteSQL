using CompleteSQL.ConnectionStringParser;
using CompleteSQL.Mapping;
using CompleteSQL.Merge;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompleteSQL
{
    public class DataContext
    {
      
        private readonly SqlConnection m_connection;
        public DataContext(string nameOrConnectionString)
        {
            string connectionString = ((IConnectionStringParser)new ConnectionStringParser.ConnectionStringParser()).Parse(nameOrConnectionString);

            m_connection = new SqlConnection(connectionString);
        }

        public void BulkInsert<TSource>(IEnumerable<TSource> dataSource, string targetTable = null) where TSource: class
        {
            DataTableCreator dtBuilder = new DataTableCreator();
            DataTable dataTable = dtBuilder.Create(dataSource, targetTable);


            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(m_connection.ConnectionString))
            {
                
                foreach(DataColumn dc in dataTable.Columns)
                {
                    bulkCopy.ColumnMappings.Add(dc.ColumnName, dc.ColumnName);
                }

                bulkCopy.DestinationTableName = dataTable.TableName;
                
                bulkCopy.WriteToServer(dataTable);

            }
        }

        public MergeClass<TSource> CreateMergeUsing<TSource>(IEnumerable<TSource> usingDataSource) where TSource: class
        {
            return new MergeClass<TSource>(usingDataSource);
        }

       
    }
}
