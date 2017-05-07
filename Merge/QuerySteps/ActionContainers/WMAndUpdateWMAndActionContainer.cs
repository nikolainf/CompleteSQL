using CompleteSQL.Merge.QueryPartsFactory;
using System;
using System.Linq.Expressions;

namespace CompleteSQL.Merge
{
    public class WMAndUpdateWMAndActionContainer<TSource> : QueryStepBase
    {
        internal WMAndUpdateWMAndActionContainer() { }

        internal WMAndUpdateWMAndActionContainer(QueryPartComponent queryComponent):base(queryComponent)
        {

        }

        public WMAndUpdateWMAndDeleteActionStep<TSource> ThenDelete()
        {
            var thenDeleteQueryPart = queryComponent.CreateThenDeleteQueryPart();

            return new WMAndUpdateWMAndDeleteActionStep<TSource>(thenDeleteQueryPart);
        }
    }
}
