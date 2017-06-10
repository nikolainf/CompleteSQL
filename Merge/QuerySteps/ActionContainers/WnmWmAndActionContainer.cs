using CompleteSQL.Merge.QueryPartsFactory;
using System;
using System.Linq.Expressions;

namespace CompleteSQL.Merge
{
    public class WnmWmAndActionContainer<TSource> : QueryStepBase
    {
        internal WnmWmAndActionContainer(QueryPartComponent queryComponent)
            : base(queryComponent)
        { }

        public ActionStepBase ThenUpdate<TUpdate>(Expression<Func<TSource, TSource, TUpdate>> updatingColumns)
        {
            var thenUpdateQueryPart = queryComponent.CreateWMThenUpdateQueryPart(updatingColumns);

            return new WMActionStep<TSource>(thenUpdateQueryPart);
        }

        public ActionStepBase ThenUpdate()
        {
            var thenUpdateQueryPart = queryComponent.CreateWMThenUpdateQueryPart<TSource>();

            return new WMActionStep<TSource>(thenUpdateQueryPart);
        }

        public ActionStepBase ThenDelete()
        {
            var thenDeleteQueryPart = queryComponent.CreateThenDeleteQueryPart();

            return new WMActionStep<TSource>(thenDeleteQueryPart);
        }
    }
}
