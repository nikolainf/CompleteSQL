
using System;
using System.Linq.Expressions;
using CompleteSQL.Merge.QueryPartsFactory;

namespace CompleteSQL.Merge
{
    public class WMAndUpdateOrDeleteWNMBySourceActionContainer<TSource> : QueryStepBase
    {
        internal WMAndUpdateOrDeleteWNMBySourceActionContainer(QueryPartComponent queryComponent) : base(queryComponent) { }

        public WMAndUpdateOrDeleteWNMBySourceUpdateActionStep<TSource> ThenUpdate<TUpdate>(Expression<Func<TSource, TUpdate>> newValues)
        {
            var thenUpdateQueryPart = queryComponent.CreateWNMThenUpdateQueryPart(newValues);

            return new WMAndUpdateOrDeleteWNMBySourceUpdateActionStep<TSource>(thenUpdateQueryPart);
        }

        public WMAndUpdateOrDeleteWNMBySourceDeleteActionStep<TSource> ThenDelete()
        {
            var thenDeleteQueryComponent = queryComponent.CreateThenDeleteQueryPart();

            return new WMAndUpdateOrDeleteWNMBySourceDeleteActionStep<TSource>(thenDeleteQueryComponent);
        }


    
    }
}
