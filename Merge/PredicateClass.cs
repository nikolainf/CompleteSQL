﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompleteSQL.Merge
{
    public class PredicateClass<TSource> where TSource: class
    {
        private IEnumerable<TSource> m_usingDataSource;

        internal PredicateClass(IEnumerable<TSource> usingDataSource) 
        {
            m_usingDataSource = usingDataSource;
        }
        public OperationClass<TSource> WhenMatchedThenUpdate()
        {
            return new OperationClass<TSource>(m_usingDataSource);
        }

        public OperationClass<TSource> WhenNotMatchedThenInsert()
        {
            return new OperationClass<TSource>(m_usingDataSource);
        }
    }
}
