using CompleteSQL.Merge.QueryPartsFactory;
using System;
using System.Linq.Expressions;

namespace CompleteSQL.Merge
{
    public class WMAndDeleteWMActionContainer<TSource> : QueryStepBase
    {
        internal WMAndDeleteWMActionContainer(QueryPartComponent queryComponent)
            : base(queryComponent)
        { }

        public WMAndDeleteWMUpdateActionStep<TSource> ThenUpdate()
        {
            var thenUpdateQueryPart = queryComponent.CreateWMThenUpdateQueryPart<TSource>();

            return new WMAndDeleteWMUpdateActionStep<TSource>(thenUpdateQueryPart);
        }

        public WMAndDeleteWMUpdateActionStep<TSource> ThenUpdate<TUpdate>(Expression<Func<TSource,TSource, TUpdate>> updatingColumns)
        {
            var thenUpdateQueryPart = queryComponent.CreateWMThenUpdateQueryPart(updatingColumns);

            return new WMAndDeleteWMUpdateActionStep<TSource>(thenUpdateQueryPart);
        }
    }
}
