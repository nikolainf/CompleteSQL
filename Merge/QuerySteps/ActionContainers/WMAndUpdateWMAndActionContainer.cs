using CompleteSQL.Merge.QueryPartsFactory;
using System;
using System.Linq.Expressions;

namespace CompleteSQL.Merge
{
    public class WMAndUpdateWMAndActionContainer<TSource> : QueryStepBase
    {
        internal WMAndUpdateWMAndActionContainer(QueryPartComponent queryComponent):base(queryComponent)
        {

        }

        public WMSomeActionStep<TSource> ThenDelete()
        {
            var thenDeleteQueryPart = queryComponent.CreateThenDeleteQueryPart();

            return new WMSomeActionStep<TSource>(thenDeleteQueryPart);
        }
    }
}
