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

        public WMActionStep<TSource> ThenUpdate()
        {
            var thenUpdateQueryPart = queryComponent.CreateWMThenUpdateQueryPart<TSource>();

            return new WMActionStep<TSource>(thenUpdateQueryPart);
        }

        public WMActionStep<TSource> ThenUpdate<TUpdate>(Expression<Func<TSource, TSource, TUpdate>> updatingColumns)
        {
            var thenUpdateQueryPart = queryComponent.CreateWMThenUpdateQueryPart(updatingColumns);

            return new WMActionStep<TSource>(thenUpdateQueryPart);
        }
    }
}
