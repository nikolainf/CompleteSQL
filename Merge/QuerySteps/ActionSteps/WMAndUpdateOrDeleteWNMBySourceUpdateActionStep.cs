using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompleteSQL.Merge
{
    public class WMAndUpdateOrDeleteWNMBySourceUpdateActionStep<TSource> : ActionStepBase
    {
        internal WMAndUpdateOrDeleteWNMBySourceUpdateActionStep(QueryPartComponent queryComponent) : base(queryComponent) { }
    }
}
