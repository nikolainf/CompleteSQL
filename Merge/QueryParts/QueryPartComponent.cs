using System.Collections.ObjectModel;
using System.Linq.Expressions;

namespace CompleteSQL.Merge
{
    abstract public class QueryPartComponent
    {
        internal Expression mergePredicateBody;

        internal DataTableSchema tableSchema;
        internal abstract string GetQueryPart();
    }
}
