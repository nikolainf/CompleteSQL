using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CompleteSQL.Merge
{
    public class WhenNotMatchedConditionStep<TSource> : QueryStepBase
    {
        internal WhenNotMatchedConditionStep(QueryPartComponent queryComponent)
            : base(queryComponent)
        {
            
        }

        public ThenInsertActionStep<TSource> ThenInsert()
        {
            var thenInsertQueryPart = new ThenInsertQueryPart();
            thenInsertQueryPart.QueryPartComponent = queryComponent;

            return new ThenInsertActionStep<TSource>(thenInsertQueryPart);
        }

        public ThenInsertActionStep<TSource> ThenInsert<TInserting>(Expression<Func<TSource, TInserting>> insertingColumns)
        {
            var thenInsertQueryPart = new ThenInsertQueryPart(insertingColumns);
            thenInsertQueryPart.QueryPartComponent = queryComponent;

            return new ThenInsertActionStep<TSource>(thenInsertQueryPart);
        }
    }
}
