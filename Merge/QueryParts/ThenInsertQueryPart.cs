using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CompleteSQL.Merge
{
    public sealed class ThenInsertQueryPart : MergeQueryPartDecorator
    {

        private Type m_type;

        private LambdaExpression m_columnExpr;
        internal ThenInsertQueryPart(Type type)
        {
            m_type = type;
        }

        internal ThenInsertQueryPart(LambdaExpression columnExpr)
        {
            m_columnExpr = columnExpr;
        }
        internal override string GetQueryPart()
        {
            return string.Concat(base.GetQueryPart(), "Then Insert");
        }
    }
}
