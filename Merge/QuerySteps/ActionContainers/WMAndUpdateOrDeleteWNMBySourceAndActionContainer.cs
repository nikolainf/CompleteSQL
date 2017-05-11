
using System;
using System.Linq.Expressions;
using CompleteSQL.Merge.QueryPartsFactory;

namespace CompleteSQL.Merge
{
    public class WMAndUpdateOrDeleteWNMBySourceAndActionContainer<TSource> : QueryStepBase
    {
        internal WMAndUpdateOrDeleteWNMBySourceAndActionContainer(QueryPartComponent queryComponent) : base(queryComponent) { }

        public WMAndUpdateOrDeleteWNMBySourceAndUpdateActionStep<TSource> ThenUpdate<TUpdate>(Expression<Func<TSource, TUpdate>> newValues)
        {
            var thenUpdateQueryComponent = queryComponent.CreateWNMThenUpdateQueryPart(newValues);

            return new WMAndUpdateOrDeleteWNMBySourceAndUpdateActionStep<TSource>(thenUpdateQueryComponent);
        }

        public WMAndUpdateOrDeleteWNMBySourceAndDeleteActionStep<TSource> ThenDelete()
        {
            var thenDeleteQueryComponent = queryComponent.CreateThenDeleteQueryPart();

            return new WMAndUpdateOrDeleteWNMBySourceAndDeleteActionStep<TSource>(thenDeleteQueryComponent);
        }
    }
}
