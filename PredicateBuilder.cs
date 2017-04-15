using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CompleteSQL
{
    internal static class PredicateBuilder
    {
        internal static string BuildPredicate(this LambdaExpression expr, string alias)
        {
            return BuildPredicate(expr.Body, string.Concat(alias, "."));
          
        }

        private static string BuildPredicate(Expression expr, string alias)
        {
            if (expr is BinaryExpression)
            {
                var binaryExpression = (BinaryExpression)expr;

                switch (expr.NodeType)
                {
                    case ExpressionType.AndAlso:

                        return BuildPredicate(binaryExpression.Left, alias) + " And " + BuildPredicate(binaryExpression.Right, alias);

                    case ExpressionType.OrElse:

                        throw new NotImplementedException();

                    case ExpressionType.Equal:

                        return ComparePredicate(" = ", binaryExpression.Left, binaryExpression.Right, alias);
                    case ExpressionType.NotEqual:

                        return ComparePredicate(" <> ", binaryExpression.Left, binaryExpression.Right, alias);
                    case ExpressionType.GreaterThan:

                        return ComparePredicate(" > ", binaryExpression.Left, binaryExpression.Right, alias);
                    case ExpressionType.GreaterThanOrEqual:

                        return ComparePredicate(" >= ", binaryExpression.Left, binaryExpression.Right, alias);
                    case ExpressionType.LessThan:

                        return ComparePredicate(" < ", binaryExpression.Left, binaryExpression.Right, alias);
                    case ExpressionType.LessThanOrEqual:

                        return ComparePredicate(" <= ", binaryExpression.Left, binaryExpression.Right, alias);
                    default:

                        throw new ArgumentException();
                }

            }

            else
                return alias + GetPredicate((MethodCallExpression)expr);

        }

        private static string ComparePredicate(string equalOperator, Expression left, Expression right, string alias)
        {
            return string.Concat(GetOperand(left, alias), equalOperator, GetOperand(right, alias));
        }


        private static string GetPredicate(MethodCallExpression expr)
        {
            switch (expr.Method.Name)
            {
                case "Contains": return ((MemberExpression)expr.Object).Member.Name + " Like '%" + ((ConstantExpression)expr.Arguments[0]).Value.ToString() + "%'";
                case "StartsWith": return ((MemberExpression)expr.Object).Member.Name + " Like '" + ((ConstantExpression)expr.Arguments[0]).Value.ToString() + "%'";
                case "EndsWith": return ((MemberExpression)expr.Object).Member.Name + " Like '%" + ((ConstantExpression)expr.Arguments[0]).Value.ToString() + "'";

            }

            return null;
        }

      
        private static string GetOperand(Expression expr, string alias)
        {
            if (expr is MemberExpression)
                return string.Concat(alias, ((MemberExpression)expr).Member.Name);
            else if (expr is ConstantExpression)
                return ((ConstantExpression)expr).Value.ToString();
            else
                throw new ArgumentNullException(expr.ToString());
        }
    }
}
