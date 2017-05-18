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

        public WMActionStep<TSource> ThenDelete()
        {
            var thenDeleteQueryPart = queryComponent.CreateThenDeleteQueryPart();

            return new WMActionStep<TSource>(thenDeleteQueryPart);
        }
    }
}
