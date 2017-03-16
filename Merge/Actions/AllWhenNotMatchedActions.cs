using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CompleteSQL.Merge
{
    public class AllWhenNotMatchedActions<TSource> : ConditionAndActionBase
    {
        internal AllWhenNotMatchedActions(MergeQueryPartComponent queryComponent)
            : base(queryComponent)
        {
            
        }

        public AfterThenInsertConditions<TSource> ThenInsert()
        {
            var thenInsertQueryPart = new ThenInsertQueryPart();
            thenInsertQueryPart.QueryPartComponent = queryComponent;

            return new AfterThenInsertConditions<TSource>(thenInsertQueryPart);
        }

        public AfterThenInsertConditions<TSource> ThenInsert<TInserting>(Expression<Func<TSource, TInserting>> insertingColumns)
        {
            var thenInsertQueryPart = new ThenInsertQueryPart(insertingColumns);
            thenInsertQueryPart.QueryPartComponent = queryComponent;

            return new AfterThenInsertConditions<TSource>(thenInsertQueryPart);
        }
    }
}
