using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompleteSQL.Merge
{
    public class WMAndUpdateOrDeleteWNMBySourceDeleteActionStep<TSource> : ActionStepBase
    {
        internal WMAndUpdateOrDeleteWNMBySourceDeleteActionStep(QueryPartComponent queryComponent) : base(queryComponent) { }
    }
}
