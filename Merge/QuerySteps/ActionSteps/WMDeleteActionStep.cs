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
    public class WMDeleteActionStep<TSource> : ActionStepBase
    {
        internal WMDeleteActionStep(QueryPartComponent queryComponent)
            : base(queryComponent)
        {

        }


        public WMFirstWNMActionContainer<TSource> WhenNotMatched()
        {
            var whenNotMatchedByTarget = queryComponent.CreateWNMByTargetQueryPart();

            return new WMFirstWNMActionContainer<TSource>(whenNotMatchedByTarget);

        }

        public WMFirstWNMBySourceActionContainer<TSource> WhenNotMatchedBySource()
        {
            var whenNotMatchedBySource = queryComponent.CreateWNMBySourceQueryPart();

            return new WMFirstWNMBySourceActionContainer<TSource>(whenNotMatchedBySource);

        }
    }
}
