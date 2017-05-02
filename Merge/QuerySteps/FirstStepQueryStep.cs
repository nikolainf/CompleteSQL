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

        public WMFirstConditionStep<TSource> WhenMatched()
        {
            var whenMatchedQueryPart = queryComponent.CreateWhenMatchedQueryPart();

            return new WMFirstConditionStep<TSource>(whenMatchedQueryPart);
        }

        public WMFirstConditionStep<TSource> WhenMatchedAnd(Expression<Func<TSource, bool>> targetPredicate, Expression<Func<TSource, bool>> sourcePredicate)
        {
            if (targetPredicate == null)
                throw new ArgumentNullException("targetPredicate");

            if (sourcePredicate == null)
                throw new ArgumentNullException("sourcePredicate");

            var whenMatchedAndTargetSource = queryComponent.CreateWMAndQueryPart(targetPredicate, sourcePredicate);

            return new WMFirstConditionStep<TSource>(whenMatchedAndTargetSource);
        }

        public WMFirstConditionStep<TSource> WhenMatchedAndTarget(Expression<Func<TSource, bool>> targetPredicate)
        {
            if (targetPredicate == null)
                throw new ArgumentNullException("targetPredicate");

            var whenMatchedAndTarget = queryComponent.CreateWMAndTargetQueryPart(targetPredicate);

            return new WMFirstConditionStep<TSource>(whenMatchedAndTarget);
        }

        public WMFirstConditionStep<TSource> WhenMatchedAndSource(Expression<Func<TSource, bool>> sourcePredicate)
        {
            if (sourcePredicate == null)
                throw new ArgumentNullException("sourcePredicate");

            var whenMatchedAndTarget = queryComponent.CreateWMAndSourceQueryPart(sourcePredicate);

            return new WMFirstConditionStep<TSource>(whenMatchedAndTarget);
        }

   
        public WNMFirstConditionStep<TSource> WhenNotMatched()
        {
            var whenNotMatchedByTarget = queryComponent.CreateWNMByTargetQueryPart();

            return new WNMFirstConditionStep<TSource>(whenNotMatchedByTarget);
        }

        public WNMFirstConditionStep<TSource> WhenNotMatchedAnd(Expression<Func<TSource, bool>> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException("predicate");

            var whenNotMatchedAndByTarget = queryComponent.CreateWNMByTargetAndQueryPart(predicate);

            return new WNMFirstConditionStep<TSource>(whenNotMatchedAndByTarget);
        }

        public WNMBySourceFirstConditionStep<TSource> WhenNotMatchedBySource()
        {
            var whenNotMatchedBySource = queryComponent.CreateWNMBySourceQueryPart();

            return new WNMBySourceFirstConditionStep<TSource>(whenNotMatchedBySource);
        }

        public WNMBySourceFirstConditionStep<TSource> WhenNotMatcheBySourceAnd(Expression<Func<TSource, bool>> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException("predicate");

            var whenNotMatchedAndBySource = queryComponent.CreateWNMBySourceAndQueryPart(predicate);

            return new WNMBySourceFirstConditionStep<TSource>(whenNotMatchedAndBySource);
        }

    }
}
