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
            Type type = typeof(TSource);
            string tableName = targetTable;

            if (string.IsNullOrWhiteSpace(tableName))
            {
                tableName = (new SqlTableNameMapper()).GetFullTableName(type).ToString();
            }

            DataTableSchemaCreator schemaCreator = new DataTableSchemaCreator();
            DataTableSchema schema = schemaCreator.CreateSchema<TSource>(targetTable);


            DataTableCreator dtCreator = new DataTableCreator();
            DataTable dataTable = dtCreator.CreateDataTable<TSource>(dataSource, schema);



            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(m_connection.ConnectionString))
            {
                
                foreach(DataColumn dc in dataTable.Columns)
                {
                    bulkCopy.ColumnMappings.Add(dc.ColumnName, dc.ColumnName);
                }

                bulkCopy.DestinationTableName = tableName;
                
                bulkCopy.WriteToServer(dataTable);

            }
        }

        public MergeClass<TSource> CreateMergeUsing<TSource>(IEnumerable<TSource> usingDataSource) where TSource: class
        {
            return new MergeClass<TSource>(usingDataSource);
        }

       
    }
}
