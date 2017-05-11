using CompleteSQL.Merge.QueryPartsFactory;
using System;
using System.Linq.Expressions;

namespace CompleteSQL.Merge
{
    public class WMAndUpdateWMActionContainer<TSource> : QueryStepBase
    {
        internal WMAndUpdateWMActionContainer(QueryPartComponent queryComponent)
            : base(queryComponent)
        { }

        public WMSomeActionStep<TSource> ThenDelete()
        {
            var thenDeleteQueryPart = queryComponent.CreateThenDeleteQueryPart();

            return new WMSomeActionStep<TSource>(thenDeleteQueryPart);
        }
    }
}
