using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CompleteSQL.Extension;
using CompleteSQL.Merge.QueryPartBuilders;

namespace CompleteSQL.Merge
{
    public sealed class ThenInsertQueryPart : QueryPartDecorator
    {
        private LambdaExpression m_columnExpr;

        #region ctors
        internal ThenInsertQueryPart()
        {

        }
        internal ThenInsertQueryPart(LambdaExpression columnExpr)
        {
            m_columnExpr = columnExpr;
        }

        #endregion

        internal override string GetQueryPart()
        {

            string tgtColumns = string.Empty;
            string newValues = string.Empty;

            if (m_columnExpr == null)
            {
                tgtColumns = string.Join(", ", tableSchema.Columns.Select(col => col.Name));
                newValues = string.Join(", ", tableSchema.Columns.Select(col => string.Concat("src.", col.Name)));
            }
            else
            {
                switch (m_columnExpr.Body.NodeType)
                {
                    case ExpressionType.MemberAccess:
                        break;
                    case ExpressionType.New:
                        NewExpression newBody = (NewExpression)m_columnExpr.Body;

                        NewValueBuilder builder = NewValueBuilder.CreateBuilder(newBody);
                        builder.SetSrcParameter(m_columnExpr.Parameters[0]);

                        tgtColumns = newBody.GetTargetStringColumns();

                        newValues = string.Join(", ", builder.GetNewValues());

                        break;
                    default: throw new ArgumentException();
                }
            }

            string insert = string.Format("\tThen Insert({0})", tgtColumns);
            string values = string.Format("\t\tValues({0})", newValues);
            return string.Concat(base.GetQueryPart(),Environment.NewLine, string.Concat(insert, Environment.NewLine, values));
        }
    }
}
