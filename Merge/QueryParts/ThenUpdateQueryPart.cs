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

            if (m_columnExpr == null)
            {
                throw new NotImplementedException();
            }
            else
            {
                if (m_columnExpr.Parameters.Count == 1)
                {
                    switch (m_columnExpr.Body.NodeType)
                    {
                        case ExpressionType.MemberAccess:
                            break;
                        case ExpressionType.New:
                            NewExpression newBody = (NewExpression)m_columnExpr.Body;


                            var tgtColumns = newBody.GetTargetColumnNames();

                            var operators = newBody.GetOperators();

                            string updateOperators = string.Join(Environment.NewLine,
                                tgtColumns.Select((item, index) =>
                                    string.Concat("\t\ttgt.", item, " = ", operators[index])));

                            string update = string.Concat("\tThen Update Set ", Environment.NewLine, updateOperators);


                            return string.Concat(base.GetQueryPart(), Environment.NewLine, update);


                        default: throw new ArgumentException();
                    }
                }
                else if (m_columnExpr.Parameters.Count == 2)
                {
                    ParameterExpression srcParam = m_columnExpr.Parameters[1];

                    switch (m_columnExpr.Body.NodeType)
                    {
                        case ExpressionType.New:
                            NewExpression newBody = (NewExpression)m_columnExpr.Body;

                            var tgtColumns = newBody.GetTargetColumnNames();

                            var operators = newBody.GetOperators(srcParam);

                            string updateOperators = string.Join(Environment.NewLine,
                              tgtColumns.Select((item, index) =>
                                  string.Concat("\t\ttgt.", item, " = ", operators[index])));

                            string update = string.Concat("\tThen Update Set ", Environment.NewLine, updateOperators);


                            return string.Concat(base.GetQueryPart(), Environment.NewLine, update);


                        default: throw new ArgumentException();
                    }
                }
            }

            throw new NotImplementedException();
        }
    }
}
