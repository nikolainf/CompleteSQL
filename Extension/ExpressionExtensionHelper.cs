using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CompleteSQL.Extension
{
    internal static class ExpressionExtensionHelper
    {
        internal static string GetTargetColumns(this NewExpression newExpression)
        {
            string columns = null;

            columns = string.Join(", ", newExpression.Members.Select(m => m.Name));

            return columns;
        }

        internal static string GetSourceColumns(this NewExpression newExpression)
        {
            List<string> columnList = new List<string>(newExpression.Arguments.Count);

            foreach(var arg in newExpression.Arguments)
            {
                switch(arg.NodeType)
                {
                    case ExpressionType.MemberAccess:
                        columnList.Add(string.Concat("src.",((MemberExpression)arg).Member.Name));
                        break;
                    case ExpressionType.Constant:
                        ConstantExpression ex = (ConstantExpression)arg;

                        if (ex.Type == typeof(System.Int32))
                            columnList.Add(ex.Value.ToString());
                        else if (ex.Type == typeof(System.Decimal))
                            columnList.Add(Convert.ToDecimal(ex.Value).ToString("0.0000", System.Globalization.CultureInfo.InvariantCulture));
                        else
                            columnList.Add(string.Concat("\'", ex.Value, "\'"));
                       
                        break;
                    default:
                        throw new ArgumentException();

                }
            }

            string columns = string.Join(", ", columnList);

            return columns;

        }
    }
}
