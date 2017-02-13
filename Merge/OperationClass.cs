using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompleteSQL.Merge
{
    public class OperationClass<TSource> where TSource: class
    {
        private IEnumerable<TSource> m_usingDataSource;
        internal OperationClass(IEnumerable<TSource> usingDataSource)
        {  
            m_usingDataSource = usingDataSource;
        }
        public OperationClass<TSource> WhenMatchedThenUpdate()
        {
            return this;
        }

        public OperationClass<TSource> WhenNotMatchedThenInsert()
        {
            return this;
        }
        public void Merge()
        {
            var e = m_usingDataSource.ToArray();
             
        }
    }
}
