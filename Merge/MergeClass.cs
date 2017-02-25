using CompleteSQL.Mapping;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CompleteSQL.Merge
{
    public class MergeClass<TSource> where TSource : class
    {
        private IEnumerable<TSource> m_dataSource;

        private string m_targetTable;

        internal MergeClass(IEnumerable<TSource> usingDataSource)
        {
            // TODO: Complete member initialization
            this.m_dataSource = usingDataSource;
        }
     

        public MergeClass<TSource> Target(string tableName)
        {
            m_targetTable = tableName;
            return this;
        }

        public AllConditionsAndActions<TSource> On<TPredicate>(Expression<Func<TSource, TPredicate>> predicate)
        {
            // Define table name.
            if(string.IsNullOrEmpty(m_targetTable))
                m_targetTable =  (new SqlTableNameMapper()).GetFullTableName(typeof(TSource)).ToString();

            // Build merge into using query part of query.
            var srcTgtQueryPart = new SourceTargetQueryPartComponent(m_targetTable);

            // Build "on" query part.
            var onQueryPart = new OnQueryPart(predicate);
            onQueryPart.QueryPartComponent = srcTgtQueryPart;

            return new AllConditionsAndActions<TSource>(onQueryPart);
        }
       
    
    }

  
}
