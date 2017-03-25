using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CompleteSQL.Merge.QueryPartsFactory
{
    public sealed class AndTargetQueryPart : QueryPartDecorator
    {
        LambdaExpression m_predicate;

        internal AndTargetQueryPart(LambdaExpression expr)
        {
            m_predicate = expr;
        }

        internal override string GetQueryPart()
        {
            var p = m_predicate;
            return string.Concat(base.GetQueryPart(), "And");

        }
    }
}
