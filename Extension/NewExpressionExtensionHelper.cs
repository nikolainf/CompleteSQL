using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CompleteSQL.Extension
{
    internal static class NewExpressionExtensionHelper
    {
        internal static string GetTargetStringColumns(this NewExpression newExpression)
        {
            string columns = null;

            columns = string.Join(", ", newExpression.Members.Select(m => m.Name));

            return columns;
        }

        internal static string[] GetTargetColumnNames(this NewExpression newExpression)
        {
            return newExpression.Members.Select(m => m.Name).ToArray();
        }

        internal static string[] GetNewValues(this NewExpression newExpression, ParameterExpression srcParam = null)
        {
            List<string> columnList = new List<string>(newExpression.Arguments.Count);

            foreach(var arg in newExpression.Arguments)
            {
                switch (arg.NodeType)
                {
                    case ExpressionType.MemberAccess:
                        columnList.Add(GetOperandMember((MemberExpression)arg, srcParam));
                        break;
                    case ExpressionType.Constant:
                        ConstantExpression ex = (ConstantExpression)arg;

                        if (ex.Type == typeof(System.Int32))
                            columnList.Add(ex.Value.ToString());
                        else if (ex.Type == typeof(System.Decimal))
                            columnList.Add(Convert.ToDecimal(ex.Value).ToString().Replace(',', '.'));
                        else
                            columnList.Add(string.Concat("\'", ex.Value, "\'"));

                        break;
                    case ExpressionType.Add:
                        var plusOperands = GetOperands((BinaryExpression)arg, srcParam);

                        columnList.Add(string.Concat(plusOperands.Item1, " + ", plusOperands.Item2));
                        break;
                    case ExpressionType.Multiply:
                        var multOperands = GetOperands((BinaryExpression)arg, srcParam);

                        columnList.Add(string.Concat(multOperands.Item1, " * ", multOperands.Item2));
                        break;
                    case ExpressionType.Subtract:
                        var subtract = GetOperands((BinaryExpression)arg, srcParam);
                        columnList.Add(string.Concat(subtract.Item1, " - ", subtract.Item2));
                        break;
                    case ExpressionType.Divide:
                        var divideOperands = GetOperands((BinaryExpression)arg, srcParam);
                        columnList.Add(string.Concat(divideOperands.Item1, " / ", divideOperands.Item2));
                        break;
                    default:
                        throw new ArgumentException();

                }
            }

            return columnList.ToArray();
        }

     
        internal static string GetInsertedValues(this NewExpression newExpression)
        {
            string columns = string.Join(", ", newExpression.GetNewValues());

            return columns;
        }


        private static Tuple<string, string> GetOperands(BinaryExpression expr, ParameterExpression srcParam)
        {
            Func<Expression, string> getOperand = (operand) =>
            {
                switch (operand.NodeType)
                {
                    case ExpressionType.MemberAccess:
                        return GetOperandMember((MemberExpression)operand, srcParam);
                    case ExpressionType.Constant:

                        ConstantExpression constant = (ConstantExpression)operand;

                        if (operand.Type == typeof(System.Int32))
                            return constant.Value.ToString();
                        else if (operand.Type == typeof(System.Decimal))
                            return Convert.ToDecimal(constant.Value).ToString().Replace(',', '.');
                        else return string.Concat("\'", constant.Value, "\'");

                    default: throw new ArgumentException();

                }
            };

            return new Tuple<string, string>
            (
                getOperand(expr.Left),
                getOperand(expr.Right)
            );
        }

     

        /// <summary>
        /// Return operand presented in sql string
        /// </summary>
        /// <param name="memberExpr">Expression of memeber</param>
        /// <param name="srcParam">Expression of source parameter</param>
        /// <returns>sql string</returns>
        private static string GetOperandMember(MemberExpression memberExpr, ParameterExpression srcParam)
        {
            return string.Concat(
                (srcParam == null || memberExpr.Expression.Equals(srcParam))
                ? "src."
                : "tgt.",
                memberExpr.Member.Name);
        }

    }
}
