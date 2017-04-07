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
            alias = string.Concat(alias, ".");
            string predicate;

            if (expr.Body is BinaryExpression)
                predicate = GetPredicate((BinaryExpression)expr.Body, alias);
            else
                predicate = alias + GetPredicate((MethodCallExpression)expr.Body);

            return predicate;
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

        private static string GetPredicate(BinaryExpression expr, string alias)
        {
            string equalOperator = null;
            switch (expr.NodeType)
            {
                case ExpressionType.AndAlso:
                    BinaryExpression binaryExpr = (BinaryExpression)expr;


                    string left;
                    if (binaryExpr.Left is BinaryExpression)
                        left = GetPredicate((BinaryExpression)binaryExpr.Left, alias);
                    else
                        left = alias + GetPredicate((MethodCallExpression)binaryExpr.Left);

                    string right;
                    if (binaryExpr.Right is BinaryExpression)
                        right = GetPredicate((BinaryExpression)binaryExpr.Right, alias);
                    else
                    {
                        right = alias + GetPredicate((MethodCallExpression)binaryExpr.Right);
                    }

                    return left + " And " + right;

                case ExpressionType.OrElse:

                    break;

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

            string predicate = string.Concat(GetOperand(expr.Left, alias), equalOperator, GetOperand(expr.Right, alias));

            return predicate;
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
