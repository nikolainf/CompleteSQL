using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompleteSQL.Merge
{
    public class ThenInsertActionStep<TSource> : ActionStepBase
    {
        internal ThenInsertActionStep(QueryPartComponent queryComponent)
            : base(queryComponent)
        { }
    }
}
