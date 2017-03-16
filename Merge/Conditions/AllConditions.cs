using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CompleteSQL.Merge
{
    public sealed class AllConditions<TSource> : ConditionAndActionBase
    {
        internal AllConditions(MergeQueryPartComponent queryComponent)
            : base(queryComponent)
        { }

        public AllWhenMatchedActions<TSource> WhenMatched()
        {
            var whenMatchedQueryPart = new WhenMatchedQueryPart();
            whenMatchedQueryPart.QueryPartComponent = queryComponent;

            return new AllWhenMatchedActions<TSource>(whenMatchedQueryPart);
        }

        public AllWhenMatchedActions<TSource> WhenMatchedAnd(Expression<Func<TSource, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public AllWhenNotMatchedActions<TSource> WhenNotMatched()
        {
            var whenNotMatchedByTarget = new WhenNotMatchedQueryPart();
            whenNotMatchedByTarget.QueryPartComponent = queryComponent;

            return new AllWhenNotMatchedActions<TSource>(whenNotMatchedByTarget);
        }

        public AllWhenNotMatchedActions<TSource> WhenNotMatchedAnd(Expression<Func<TSource, bool>> predicate)
        {
            var whenNotMatchedByTarget = new WhenNotMatchedQueryPart();
            whenNotMatchedByTarget.QueryPartComponent = queryComponent;

            var andQueryPart = new AndSourceQueryPart(predicate);
            andQueryPart.QueryPartComponent = whenNotMatchedByTarget;

            return new AllWhenNotMatchedActions<TSource>(andQueryPart);
        }
    }
}
