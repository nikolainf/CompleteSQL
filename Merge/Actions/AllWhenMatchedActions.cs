using CompleteSQL.Merge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CompleteSQL.Merge
{
    public class AllWhenMatchedActions<TSource> : ConditionAndActionBase
    {
        internal AllWhenMatchedActions(MergeQueryPartComponent queryComponent)
            : base(queryComponent)
        {
            
        }

        public void ThenUpdate()
        {

        }

        public AfterThenDeleteConditions<TSource> ThenUpdate<TUpdate>(Expression<Func<TSource, TUpdate>> updatingColumns)
        {
            throw new NotImplementedException();
        }

        public AfterThenDeleteConditions<TSource> ThenDelete()
        {
            var thenDeleteQueryPart = new ThenDeleteQueryPart();
            thenDeleteQueryPart.QueryPartComponent = queryComponent;

            return new AfterThenDeleteConditions<TSource>(thenDeleteQueryPart);
        }
    }
}
