using CompleteSQL.Merge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CompleteSQL.Merge
{
    public class WhenMatchedConditionStep<TSource> : QueryStepBase
    {
        internal WhenMatchedConditionStep(QueryPartComponent queryComponent)
            : base(queryComponent)
        {
            
        }



        public ThenUpdateActionStep<TSource> ThenUpdate<TUpdate>(Expression<Func<TSource, TUpdate>> updatingColumns)
        {
            var thenUpdateQueryPart = new ThenUpdateQueryPart(updatingColumns);
            thenUpdateQueryPart.QueryPartComponent = queryComponent;

            return new ThenUpdateActionStep<TSource>(thenUpdateQueryPart);
        }

        public ThenDeleteActionStep<TSource> ThenDelete()
        {
            var thenDeleteQueryPart = new ThenDeleteQueryPart();
            thenDeleteQueryPart.QueryPartComponent = queryComponent;

            return new ThenDeleteActionStep<TSource>(thenDeleteQueryPart);
        }
    }
}
