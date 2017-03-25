using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CompleteSQL.Merge
{
    public sealed class FirstStep<TSource> : QueryStepBase
    {
        internal FirstStep(QueryPartComponent queryComponent)
            : base(queryComponent)
        { }

        public WhenMatchedConditionStep<TSource> WhenMatched()
        {
            var whenMatchedQueryPart = new WhenMatchedQueryPart();
            whenMatchedQueryPart.QueryPartComponent = queryComponent;

            return new WhenMatchedConditionStep<TSource>(whenMatchedQueryPart);
        }

        public WhenMatchedConditionStep<TSource> WhenMatchedAnd(Expression<Func<TSource, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public WhenNotMatchedConditionStep<TSource> WhenNotMatched()
        {
            var whenNotMatchedByTarget = new WhenNotMatchedQueryPart(true);
            whenNotMatchedByTarget.QueryPartComponent = queryComponent;

            return new WhenNotMatchedConditionStep<TSource>(whenNotMatchedByTarget);
        }

        public WhenNotMatchedConditionStep<TSource> WhenNotMatchedAnd(Expression<Func<TSource, bool>> predicate)
        {
            var whenNotMatchedByTarget = new WhenNotMatchedQueryPart(true);
            whenNotMatchedByTarget.QueryPartComponent = queryComponent;

            var andQueryPart = new AndSourceQueryPart(predicate);
            andQueryPart.QueryPartComponent = whenNotMatchedByTarget;

            return new WhenNotMatchedConditionStep<TSource>(andQueryPart);
        }

        public WhenNotMatchedBySourceConditionStep<TSource> WhenNotMathcedBySource()
        {
            var whenNotMatchedBySource = new WhenNotMatchedQueryPart(false);
            whenNotMatchedBySource.QueryPartComponent = queryComponent;

            return new WhenNotMatchedBySourceConditionStep<TSource>(whenNotMatchedBySource);
        }
    }
}
