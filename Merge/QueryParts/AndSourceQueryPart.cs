using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CompleteSQL.Merge
{
    public sealed class AndSourceQueryPart : MergeQueryPartDecorator
    {
        LambdaExpression m_predicate;
        internal AndSourceQueryPart(Expression expr)
        {
            m_predicate = (LambdaExpression)expr;
        }

        internal override string GetQueryPart()
        {
            string predicate = "src.";

             string equalOperator = null;
            switch(m_predicate.Body.NodeType)
            {
                
                case ExpressionType.Equal:
                    equalOperator = " = ";
                    break;
                case ExpressionType.GreaterThan:
                    equalOperator = " > ";
                    break;
                case ExpressionType.GreaterThanOrEqual:
                    equalOperator = " >= ";
                    break;
                case ExpressionType.LessThan:
                    equalOperator = " < ";
                    break;
                case ExpressionType.LessThanOrEqual:
                    equalOperator = " <= ";
                    break;

                default: throw new ArgumentException();
            }

            BinaryExpression expression = (BinaryExpression)m_predicate.Body;
            predicate += ((MemberExpression)expression.Left).Member.Name + equalOperator + ((ConstantExpression)expression.Right).Value.ToString();

            return string.Concat(base.GetQueryPart(), " And ", predicate);
        }
    }
}
