using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompleteSQL.Merge
{
    public class WMUpdateActionStep<TSource> : ActionStepBase
    {
        internal WMUpdateActionStep(QueryPartComponent queryComponent)
            :base(queryComponent)
        {

        }
    }
}
