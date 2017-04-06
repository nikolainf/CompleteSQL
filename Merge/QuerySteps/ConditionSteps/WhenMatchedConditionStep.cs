using CompleteSQL.Merge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CompleteSQL.Merge.QueryPartsFactory;

namespace CompleteSQL.Merge
{
    public class WhenMatchedConditionStep<TSource> : QueryStepBase
    {
        internal WhenMatchedConditionStep(QueryPartComponent queryComponent)
            : base(queryComponent)
        {
            
        }



        public WMThenUpdateActionStep<TSource> ThenUpdate<TUpdate>(Expression<Func<TSource,TSource, TUpdate>> updatingColumns)
        {
            var thenUpdateQueryPart = queryComponent.CreateWMThenUpdateQueryPart(updatingColumns);

            return new WMThenUpdateActionStep<TSource>(thenUpdateQueryPart);
        }

        public ThenDeleteActionStep<TSource> ThenDelete()
        {
            var thenDeleteQueryPart = queryComponent.CreateThenDeleteQueryPart();

            return new ThenDeleteActionStep<TSource>(thenDeleteQueryPart);
        }
    }
}
