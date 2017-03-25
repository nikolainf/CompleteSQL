using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompleteSQL.Merge
{
    public class WhenNotMatchedBySourceConditionStep<TSource> : QueryStepBase
    {
        internal WhenNotMatchedBySourceConditionStep(QueryPartComponent queryComponent)
            : base(queryComponent)
        {

        }

        public ThenDeleteActionStep<TSource> ThenDelete()
        {
            var thenDeleteQueryPart = new ThenDeleteQueryPart();
            thenDeleteQueryPart.QueryPartComponent = queryComponent;

            return new ThenDeleteActionStep<TSource>(thenDeleteQueryPart);
        }
    }
}
