using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CompleteSQL.Extension;

namespace CompleteSQL.Merge
{
    public sealed class ThenUpdateQueryPart : QueryPartDecorator
    {
        private LambdaExpression m_columnExpr;

        #region ctors

        internal ThenUpdateQueryPart()
        {

        }

        internal ThenUpdateQueryPart(LambdaExpression columnExpr)
        {
            m_columnExpr = columnExpr;
        }

        #endregion


        internal override string GetQueryPart()
        {
            string tgtColumns = string.Empty;
            string srcColumns = string.Empty;

            if (m_columnExpr == null)
            {
                tgtColumns = string.Join(", ", tableSchema.Columns.Select(col => col.Name));
                srcColumns = string.Join(", ", tableSchema.Columns.Select(col => string.Concat("src.", col.Name)));
            }
            else
            {
                switch (m_columnExpr.Body.NodeType)
                {
                    case ExpressionType.MemberAccess:
                        break;
                    case ExpressionType.New:
                        NewExpression newBody = (NewExpression)m_columnExpr.Body;


                        tgtColumns = newBody.GetTargetColumns();

                        srcColumns = newBody.GetSourceColumns();

                        break;
                    default: throw new ArgumentException();
                }
            }

            string update = string.Concat("\tThen Update", Environment.NewLine, "\tSet ");

            string values = string.Format("\t\tValues({0})", srcColumns);
            return string.Concat(base.GetQueryPart(), Environment.NewLine, string.Concat(update, Environment.NewLine, values));

            return string.Concat(base.GetQueryPart(), "Then Update");
        }
    }
}
