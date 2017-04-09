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

        public WhenMatchedConditionStep<TSource> WhenMatchedAnd(Expression<Func<TSource, bool>> targetPredicate, Expression<Func<TSource, bool>> sourcePredicate)
        {
            if (targetPredicate == null)
                throw new ArgumentNullException("targetPredicate");

            if (sourcePredicate == null)
                throw new ArgumentNullException("sourcePredicate");

            var whenMatchedAndTargetSource = queryComponent.CreateWMAndQueryPart(targetPredicate, sourcePredicate);

            return new WhenMatchedConditionStep<TSource>(whenMatchedAndTargetSource);
        }

        public WhenMatchedConditionStep<TSource> WhenMatchedAndTarget(Expression<Func<TSource, bool>> targetPredicate)
        {
            if (targetPredicate == null)
                throw new ArgumentNullException("targetPredicate");

            var whenMatchedAndTarget = queryComponent.CreateWMAndTargetQueryPart(targetPredicate);

            return new WhenMatchedConditionStep<TSource>(whenMatchedAndTarget);
        }

        public WhenMatchedConditionStep<TSource> WhenMatchedAndSource(Expression<Func<TSource, bool>> sourcePredicate)
        {
            if (sourcePredicate == null)
                throw new ArgumentNullException("sourcePredicate");

            var whenMatchedAndTarget = queryComponent.CreateWMAndSourceQueryPart(sourcePredicate);

            return new WhenMatchedConditionStep<TSource>(whenMatchedAndTarget);
        }

   
        public WhenNotMatchedConditionStep<TSource> WhenNotMatched()
        {
            var whenNotMatchedByTarget = queryComponent.CreateWNMByTargetQueryPart();

            return new WhenNotMatchedConditionStep<TSource>(whenNotMatchedByTarget);
        }

        public WhenNotMatchedConditionStep<TSource> WhenNotMatchedAnd(Expression<Func<TSource, bool>> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException("predicate");

            var whenNotMatchedAndByTarget = queryComponent.CreateWNMByTargetAndQueryPart(predicate);

            return new WhenNotMatchedConditionStep<TSource>(whenNotMatchedAndByTarget);
        }

        public WhenNotMatchedBySourceConditionStep<TSource> WhenNotMatchedBySource()
        {
            var whenNotMatchedBySource = queryComponent.CreateWNMBySourceQueryPart();

            return new WhenNotMatchedBySourceConditionStep<TSource>(whenNotMatchedBySource);
        }

        public WhenNotMatchedBySourceConditionStep<TSource> WhenNotMatcheBySourceAnd(Expression<Func<TSource, bool>> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException("predicate");

            var whenNotMatchedAndBySource = queryComponent.CreateWNMBySourceAndQueryPart(predicate);

            return new WhenNotMatchedBySourceConditionStep<TSource>(whenNotMatchedAndBySource);
        }

        public object WhenMatchedAndSource(object p)
        {
            throw new NotImplementedException();
        }
    }
}
