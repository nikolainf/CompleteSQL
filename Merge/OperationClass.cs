using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompleteSQL.Merge
{
    public class OperationClass<TSource> where TSource: class
    {
        private MergeQueryPartComponent m_queryComponent;


        internal OperationClass(string targetTable)
        {
            m_queryComponent = new SourceTargetQueryPartComponent(targetTable);
        }

        public OperationClass<TSource> WhenMatchedThenUpdate()
        {
          
            var queryPart = new WhenMatchedQueryPart();
            queryPart.QueryPartComponent = m_queryComponent;
            m_queryComponent = queryPart;

            string query = m_queryComponent.GetQueryPart();

            return this;
        }

        public OperationClass<TSource> WhenNotMatchedThenInsert()
        {
            var queryPart = new WhenNotMatchedQueryPart();
            queryPart.QueryPartComponent = m_queryComponent;
            m_queryComponent = queryPart;

            string query = m_queryComponent.GetQueryPart();

            return this;
        }
        public void Merge()
        {
         
             
        }
    }
}
