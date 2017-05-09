using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompleteSQL.Merge
{
    public class WMAndUpdateOrDeleteWNMInsertActionStep<TSource> : ActionStepBase
    {
        internal WMAndUpdateOrDeleteWNMInsertActionStep(QueryPartComponent queryComponent) : base(queryComponent) { }
    }
}
