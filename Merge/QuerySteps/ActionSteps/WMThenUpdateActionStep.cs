using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompleteSQL.Merge
{
    public class WMThenUpdateActionStep<TSource> : ActionStepBase
    {
        internal WMThenUpdateActionStep(QueryPartComponent queryComponent)
            :base(queryComponent)
        {

        }
    }
}
