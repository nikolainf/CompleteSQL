using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CompleteSQL.Merge.QueryPartsFactory;

namespace CompleteSQL.Merge
{
    public class WhenNotMatchedBySourceConditionStep<TSource> : QueryStepBase
    {
        internal WhenNotMatchedBySourceConditionStep(QueryPartComponent queryComponent)
            : base(queryComponent)
        {

        }

        public ThenDeleteActionStep<TSource> ThenDelete()
        {
            var thenDeleteQueryPart = new ThenDeleteQueryPart();
            thenDeleteQueryPart.QueryPartComponent = queryComponent;

            return new ThenDeleteActionStep<TSource>(thenDeleteQueryPart);
        }

        public WNMThenUpdateActionStep<TSource> ThenUpdate()
        {
            throw new NotImplementedException();
        }

        public WNMThenUpdateActionStep<TSource> ThenUpdate<TUpdate>(Expression<Func<TSource, TUpdate>> newValues)
        {
            
            var thenUpdateQueryPart = queryComponent.CreateWNMThenUpdateQueryPart(newValues);

            return new WNMThenUpdateActionStep<TSource>(thenUpdateQueryPart);
        }
    }
}
