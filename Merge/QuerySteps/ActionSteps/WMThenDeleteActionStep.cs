using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompleteSQL.Merge.QueryPartsFactory;

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
            var whenNotMatchedByTarget = queryComponent.CreateWNMByTargetQueryPart();

            return new WMFirstWNMConditionStep<TSource>(whenNotMatchedByTarget);
          
        }

        public WMFirstWNMBySourceConditionStep<TSource> WhenNotMatchedBySource()
        {
            var whenNotMatchedBySource = queryComponent.CreateWNMBySourceQueryPart();

            return new WMFirstWNMBySourceConditionStep<TSource>(whenNotMatchedBySource);
           
        }
    }
}
