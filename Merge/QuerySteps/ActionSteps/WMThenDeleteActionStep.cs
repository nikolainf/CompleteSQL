using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompleteSQL.Merge
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    public class WMThenDeleteActionStep<TSource> : ActionStepBase
    {
        internal WMThenDeleteActionStep(QueryPartComponent queryComponent)
            : base(queryComponent)
        {

        }

        public WMFirstWNMConditionStep<TSource> WhenNotMatched()
        {
            throw new NotImplementedException();
        }
    }
}
