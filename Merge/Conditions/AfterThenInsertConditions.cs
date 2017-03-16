using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompleteSQL.Merge
{
    public class AfterThenInsertConditions<TSource> : ActionBase
    {
        internal AfterThenInsertConditions(MergeQueryPartComponent queryComponent)
            : base(queryComponent)
        { }
    }
}
