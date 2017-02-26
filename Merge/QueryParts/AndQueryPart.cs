using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CompleteSQL.Merge
{
    public sealed class AndQueryPart : MergeQueryPartDecorator
    {
        LambdaExpression m_predicate;
        internal AndQueryPart(Expression expr)
        {
            m_predicate = (LambdaExpression)expr;
        }

        internal override string GetQueryPart()
        {
            var p = m_predicate;
            return string.Concat(base.GetQueryPart(), "And");
        }
    }
}
