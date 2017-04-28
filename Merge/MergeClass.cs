using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CompleteSQL.Merge
{
    public sealed class MergeClass<TSource> where TSource : class
    {
        private IEnumerable<TSource> m_dataSource;

        private string m_targetTable;

        internal MergeClass(IEnumerable<TSource> usingDataSource)
        {
           
            this.m_dataSource = usingDataSource;
        }
     

        public MergeClass<TSource> Target(string tableName)
        {
            m_targetTable = tableName;
            return this;
        }

       
        public FirstStep<TSource> On<TPredicate>(Expression<Func<TSource, TPredicate>> mergePredicate)
        {
            DataTableSchemaCreator schemaCreator = new DataTableSchemaCreator();
            DataTableSchema schema = schemaCreator.CreateSchema<TSource>(m_targetTable);



            // Start to build merge into using query part of query.
            var srcTgtQueryPart = new SourceTargetQueryPartComponent(schema.TableName);
            srcTgtQueryPart.tableSchema = schema;

            // Build "on" query part.
            var onQueryPart = new OnQueryPart(mergePredicate);
            onQueryPart.QueryPartComponent = srcTgtQueryPart;

            return new FirstStep<TSource>(onQueryPart);
        }
       
    
    }

  
}
