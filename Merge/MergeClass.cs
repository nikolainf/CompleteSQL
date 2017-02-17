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

        public AllConditionsAndActions<TSource> On(Expression<Func<TSource,object>> predicate)
        {
            if(string.IsNullOrEmpty(m_targetTable))
                m_targetTable =  (new SqlTableNameMapper()).GetFullTableName(typeof(TSource)).ToString();



            return new AllConditionsAndActions<TSource>(new SourceTargetQueryPartComponent(m_targetTable));
        }
       
    
    }

  
}
