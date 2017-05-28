using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompleteSQL.Merge.QueryPartsFactory;

namespace CompleteSQL.Merge
{
    public class WnmActionStep<TSource> : ActionStepBase
    {
        internal WnmActionStep(QueryPartComponent queryComponent)
            : base(queryComponent)
        { }

        public WnmWmActionContainer<TSource> WhenMatched()
        {
            var whenMatchedQueryComponent = queryComponent.CreateWhenMatchedQueryPart();

            return new WnmWmActionContainer<TSource>(whenMatchedQueryComponent);
        }
    }
}
