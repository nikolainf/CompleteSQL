using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CompleteSQL.Merge.QueryPartBuilders
{
    internal class NewValueBuilder
    {
        private ParameterExpression m_tgtParameter;

        private ParameterExpression m_srcParameter;

        private NewExpression m_newExpression;

        private NewValueBuilder(NewExpression newExpression)
        {
            m_newExpression = newExpression;
        }

        internal static NewValueBuilder CreateBuilder(NewExpression newExpression)
        {
            return new NewValueBuilder(newExpression);
        }

        internal NewValueBuilder SetTgtParameter(ParameterExpression tgtParameter)
        {
            m_tgtParameter = tgtParameter;

            return this;
        }

        internal NewValueBuilder SetSrcParameter(ParameterExpression srcParameter)
        {
            m_srcParameter = srcParameter;

            return this;
        }

        internal string[] GetNewValues()
        {
            List<string> valueList = new List<string>();

            foreach(var arg in m_newExpression.Arguments)
            {
                switch(arg.NodeType)
                {
                    case ExpressionType.MemberAccess:
                        valueList.Add(GetOperandMember((MemberExpression)arg));
                        break;
                    case ExpressionType.Constant:
                        ConstantExpression ex = (ConstantExpression)arg;

                        if (ex.Type == typeof(System.Int32))
                            valueList.Add(ex.Value.ToString());
                        else if (ex.Type == typeof(System.Decimal))
                            valueList.Add(Convert.ToDecimal(ex.Value).ToString().Replace(',', '.'));
                        else
                            valueList.Add(string.Concat("\'", ex.Value, "\'"));

                        break;
                    case ExpressionType.Add:
                        var plusOperands = GetOperands((BinaryExpression)arg);

                        valueList.Add(string.Concat(plusOperands.Item1, " + ", plusOperands.Item2));
                        break;
                    case ExpressionType.Multiply:
                        var multOperands = GetOperands((BinaryExpression)arg);

                        valueList.Add(string.Concat(multOperands.Item1, " * ", multOperands.Item2));
                        break;
                    case ExpressionType.Subtract:
                        var subtract = GetOperands((BinaryExpression)arg);
                        valueList.Add(string.Concat(subtract.Item1, " - ", subtract.Item2));
                        break;
                    case ExpressionType.Divide:
                        var divideOperands = GetOperands((BinaryExpression)arg);
                        valueList.Add(string.Concat(divideOperands.Item1, " / ", divideOperands.Item2));
                        break;
                    default:
                        throw new ArgumentException();
                }
            }

            return valueList.ToArray();
        }

        private Tuple<string, string> GetOperands(BinaryExpression binaryExpression)
        {
            Func<Expression, string> getOperand = (operand) =>
            {
                switch (operand.NodeType)
                {
                    case ExpressionType.MemberAccess:
                        return GetOperandMember((MemberExpression)operand);
                    case ExpressionType.Constant:

                        ConstantExpression constant = (ConstantExpression)operand;

                        if (operand.Type == typeof(System.Int32))
                            return constant.Value.ToString();
                        else if (operand.Type == typeof(System.Decimal))
                            return Convert.ToDecimal(constant.Value).ToString().Replace(',', '.');
                        else if (operand.Type == typeof(System.Double))
                            return constant.Value.ToString();
                        else return string.Concat("\'", constant.Value, "\'");

                    default: throw new ArgumentException();

                }
            };

            return new Tuple<string, string>
            (
                getOperand(binaryExpression.Left),
                getOperand(binaryExpression.Right)
            );
        }

        private string GetOperandMember(MemberExpression memberExpression)
        {
            if (m_srcParameter != null && m_srcParameter.Equals(memberExpression.Expression))
                return string.Concat("src.", memberExpression.Member.Name);
            else
                return string.Concat("tgt.", memberExpression.Member.Name);

        }
    }
}
