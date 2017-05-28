using CompleteSQL.Merge.QueryPartsFactory;
using System;
using System.Linq.Expressions;

namespace CompleteSQL.Merge
{
    public class WnmWmActionContainer<TSource> : QueryStepBase
    {
        internal WnmWmActionContainer(QueryPartComponent queryComponent): base(queryComponent)
        {

        }

        public WMActionStep<TSource> ThenUpdate<TUpdate>(Expression<Func<TSource, TSource, TUpdate>> updatingColumns)
        {
            var thenUpdateQueryPart = queryComponent.CreateWMThenUpdateQueryPart(updatingColumns);

            return new WMActionStep<TSource>(thenUpdateQueryPart);
        }


        public WnmWmActionStep<TSource> ThenUpdate()
        {
            var thenUpdateQueryPart = queryComponent.CreateWMThenUpdateQueryPart<TSource>();

            return new WnmWmActionStep<TSource>(thenUpdateQueryPart);
        }

        public WnmWmActionStep<TSource> ThenDelete()
        {
            var thenDeleteQueryPart = queryComponent.CreateThenDeleteQueryPart();

            return new WnmWmActionStep<TSource>(thenDeleteQueryPart);
        }


    }
}
