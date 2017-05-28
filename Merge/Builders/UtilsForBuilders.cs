using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CompleteSQL
{
    internal static class UtilsForBuilders
    {
        internal static string GetValue(this ConstantExpression expr)
        {
            if (expr.Type == typeof(System.Int32))
                return expr.Value.ToString();
            else if (expr.Type == typeof(System.Decimal))
                return Convert.ToDecimal(expr.Value).ToString().Replace(',', '.');
            else if (expr.Type == typeof(System.Double))
                return expr.Value.ToString();
            else return string.Concat("\'", expr.Value, "\'");
        }
    }
}
