using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompleteSQL.Merge
{
    public class ThenUpdateActionStep<TSource> : ActionStepBase
    {
        internal ThenUpdateActionStep(QueryPartComponent queryComponent)
            :base(queryComponent)
        {

        }
    }
}
