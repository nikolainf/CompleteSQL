using CompleteSQL.Merge.QueryPartsFactory;
using System;
using System.Linq.Expressions;

namespace CompleteSQL.Merge
{
    public class WMAndActionContainer<TSource> : QueryStepBase
    {
        internal WMAndActionContainer() { }
         public WMAndActionContainer(QueryPartComponent queryComponent)
            : base(queryComponent)
        {
            
        }


        public WMAndUpdateActionStep<TSource> ThenUpdate<TUpdate>(Expression<Func<TSource,TSource, TUpdate>> updatingColumns)
        {
            var thenUpdateQueryPart = queryComponent.CreateWMThenUpdateQueryPart(updatingColumns);

            return new WMAndUpdateActionStep<TSource>(thenUpdateQueryPart);
        }


        public WMAndUpdateActionStep<TSource> ThenUpdate()
        {
            var thenUpdateQueryPart = queryComponent.CreateWMThenUpdateQueryPart<TSource>();

            return new WMAndUpdateActionStep<TSource>(thenUpdateQueryPart);
        }

        public WMAndDeleteActionStep<TSource> ThenDelete()
        {
            var thenDeleteQueryPart = queryComponent.CreateThenDeleteQueryPart();

            return new WMAndDeleteActionStep<TSource>(thenDeleteQueryPart);
        }
    }
}
