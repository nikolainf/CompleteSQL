using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompleteSQL.Merge
{
    public class AllWhenNotMatchedBySourceActions<TSource> : ConditionAndActionBase
    {
        internal AllWhenNotMatchedBySourceActions(MergeQueryPartComponent queryComponent)
            : base(queryComponent)
        {

        }

        public AfterThenDeleteConditions<TSource> ThenDelete()
        {
            var thenDeleteQueryPart = new ThenDeleteQueryPart();
            thenDeleteQueryPart.QueryPartComponent = queryComponent;

            return new AfterThenDeleteConditions<TSource>(thenDeleteQueryPart);
        }
    }
}
