using CompleteSQL.Merge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CompleteSQL.Merge
{
    public class WhenMatchedConditionStep<TSource> : QueryStepBase
    {
        internal WhenMatchedConditionStep(QueryPartComponent queryComponent)
            : base(queryComponent)
        {
            
        }

        public void ThenUpdate()
        {

        }

        public ThenDeleteActionStep<TSource> ThenUpdate<TUpdate>(Expression<Func<TSource, TUpdate>> updatingColumns)
        {
            throw new NotImplementedException();
        }

        public ThenDeleteActionStep<TSource> ThenDelete()
        {
            var thenDeleteQueryPart = new ThenDeleteQueryPart();
            thenDeleteQueryPart.QueryPartComponent = queryComponent;

            return new ThenDeleteActionStep<TSource>(thenDeleteQueryPart);
        }
    }
}
