using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompleteSQL.Merge
{
    public class WMFirstWNMActionContainer<TSource> : QueryStepBase
    {
        internal WMFirstWNMActionContainer(QueryPartComponent queryComponent)
            :base(queryComponent)
        {

        }
        public ThenInsertActionStep<TSource> ThenInsert()
        {
            var thenInsertQueryPart = new ThenInsertQueryPart();
            thenInsertQueryPart.QueryPartComponent = queryComponent;

            return new ThenInsertActionStep<TSource>(thenInsertQueryPart);
        }
    }
}
