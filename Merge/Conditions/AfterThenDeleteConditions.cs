using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompleteSQL.Merge
{
    public class AfterThenDeleteConditions<TSource> : ActionBase
    {
        internal AfterThenDeleteConditions(MergeQueryPartComponent queryComponent)
            : base(queryComponent)
        { }
    }
}
