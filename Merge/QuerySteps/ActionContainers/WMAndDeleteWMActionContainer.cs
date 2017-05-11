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

        public WMSomeActionStep<TSource> ThenUpdate()
        {
            var thenUpdateQueryPart = queryComponent.CreateWMThenUpdateQueryPart<TSource>();

            return new WMSomeActionStep<TSource>(thenUpdateQueryPart);
        }

        public WMSomeActionStep<TSource> ThenUpdate<TUpdate>(Expression<Func<TSource, TSource, TUpdate>> updatingColumns)
        {
            var thenUpdateQueryPart = queryComponent.CreateWMThenUpdateQueryPart(updatingColumns);

            return new WMSomeActionStep<TSource>(thenUpdateQueryPart);
        }
    }
}
