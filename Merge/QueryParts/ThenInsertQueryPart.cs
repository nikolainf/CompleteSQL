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
        private LambdaExpression m_columnExpr;
       
        internal ThenInsertQueryPart()
        {

        }
        internal ThenInsertQueryPart(LambdaExpression columnExpr)
        {
            m_columnExpr = columnExpr;
        }
        internal override string GetQueryPart()
        {
            if (m_columnExpr == null)
            {
                string tgtColumns = string.Join(", ", tableSchema.Columns.Select(col => col.Name));
                string srcColumns = string.Join(", ", tableSchema.Columns.Select(col => string.Concat("src.", col.Name)));

                string insert = string.Format("\tThen Insert({0})", tgtColumns);
                string values = string.Format("\t\tValues({0})", srcColumns);
                return string.Concat(base.GetQueryPart(), string.Concat(insert, Environment.NewLine, values));
            }

            throw new NotImplementedException();
        }
    }
}
