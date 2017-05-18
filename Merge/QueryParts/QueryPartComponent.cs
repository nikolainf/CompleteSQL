using System.Collections.ObjectModel;
using System.Linq.Expressions;

namespace CompleteSQL.Merge
{
    /// <summary>
    /// Компонент - часть запроса. Используется Декоратор
    /// </summary>
    abstract public class QueryPartComponent
    {
        internal Expression mergePredicateBody;

        internal DataTableSchema tableSchema;
        internal abstract string GetQueryPart();



     
    }
}
