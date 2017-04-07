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
    }
}
