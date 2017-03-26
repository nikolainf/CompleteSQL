using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CompleteSQL.Merge.QueryPartsFactory;

namespace CompleteSQL.Merge
{
    public sealed class FirstStep<TSource> : QueryStepBase
    {
        internal FirstStep(QueryPartComponent queryComponent)
            : base(queryComponent)
        { }

        public WhenMatchedConditionStep<TSource> WhenMatched()
        {
            var whenMatchedQueryPart = queryComponent.CreateWhenMatchedQueryPart();

            return new WhenMatchedConditionStep<TSource>(whenMatchedQueryPart);
        }

        public WhenMatchedConditionStep<TSource> WhenMatchedAnd(Expression<Func<TSource, bool>> tgtPredicate, Expression<Func<TSource, bool>> srcPredicate)
        {

            throw new NotImplementedException();
        }

        public WhenNotMatchedConditionStep<TSource> WhenNotMatched()
        {
            var whenNotMatchedByTarget = queryComponent.CreateWhenNotMatchedByTargetQueryPart();

            return new WhenNotMatchedConditionStep<TSource>(whenNotMatchedByTarget);
        }

        public WhenNotMatchedConditionStep<TSource> WhenNotMatchedAnd(Expression<Func<TSource, bool>> predicate)
        {
            var whenNotMatchedAndByTarget = queryComponent.CreateWhenNotMatchedByTargetAndQueryPart(predicate);

            return new WhenNotMatchedConditionStep<TSource>(whenNotMatchedAndByTarget);
        }

        public WhenNotMatchedBySourceConditionStep<TSource> WhenNotMathcedBySource()
        {
            var whenNotMatchedBySource = queryComponent.CreateWhenNotMatchedBySourceQueryPart();

            return new WhenNotMatchedBySourceConditionStep<TSource>(whenNotMatchedBySource);
        }

        public WhenNotMatchedBySourceConditionStep<TSource> WhenNotMatcheBySourceAnd(Expression<Func<TSource, bool>> predicate)
        {
            var whenNotMatchedAndBySource = queryComponent.CreateWhenNotMatcheBySourceAndQueryPart(predicate);

            return new WhenNotMatchedBySourceConditionStep<TSource>(whenNotMatchedAndBySource);
        }
    }
}
