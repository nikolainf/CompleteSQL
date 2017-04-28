using CompleteSQL.ConnectionStringParser;
using CompleteSQL.Mapping;
using CompleteSQL.Merge;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
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

        public MergeClass<TSource> Merge<TSource, TPredicate>(string target, IEnumerable<TSource> source, Expression<Func<TSource, TPredicate>> mergePredicate)where TSource: class
        {
            throw new Exception();
        }

        public MergeClass<TSource> Merge<TSource, TPredicate>(IEnumerable<TSource> source, Expression<Func<TSource, TPredicate>> mergePredicate) where TSource: class
        {
            throw new NotImplementedException();
        }

       

       
    }
}
