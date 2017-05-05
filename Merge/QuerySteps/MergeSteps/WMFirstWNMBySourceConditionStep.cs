using CompleteSQL.Merge.QueryPartsFactory;
using System;
using System.Linq.Expressions;

namespace CompleteSQL.Merge
{
    public class WMFirstWNMBySourceConditionStep<TSource> : QueryStepBase
    {
        internal WMFirstWNMBySourceConditionStep(QueryPartComponent queryComponent)
            : base(queryComponent)
        { }

        public WNMThenUpdateActionStep<TSource> ThenUpdate<TUpdate>(Expression<Func<TSource, TUpdate>> newValues)
        {
            var thenUpdateQueryPart = queryComponent.CreateWNMThenUpdateQueryPart(newValues);

            return new WNMThenUpdateActionStep<TSource>(thenUpdateQueryPart);
        }

        public WNMThenDeleteActionStep<TSource> ThenDelete()
        {
            var thenDeleteQueryPart = queryComponent.CreateThenDeleteQueryPart();

            return new WNMThenDeleteActionStep<TSource>(thenDeleteQueryPart);
        }
    }
}
