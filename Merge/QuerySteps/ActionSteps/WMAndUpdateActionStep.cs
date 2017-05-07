using CompleteSQL.Merge.QueryPartsFactory;
using System;
using System.Linq.Expressions;
using CompleteSQL.Merge.QuerySteps.ActionContainers;

namespace CompleteSQL.Merge
{
    public class WMAndUpdateActionStep<TSource> : ActionStepBase
    {
        internal WMAndUpdateActionStep(QueryPartComponent queryComponent) : base(queryComponent) { }


        public WMAndUpdateWMActionContainer<TSource> WhenMatched()
        {
            var whenMatchedQueryPart = queryComponent.CreateWhenMatchedQueryPart();

            return new WMAndUpdateWMActionContainer<TSource>(whenMatchedQueryPart);
        }

        public WMAndUpdateWMAndActionContainer<TSource> WhenMatchedAnd(Expression<Func<TSource, bool>> targetPredicate, Expression<Func<TSource, bool>> sourcePredicate)
        {
            return queryComponent.CreateWMAndActionContainer<WMAndUpdateWMAndActionContainer<TSource>, TSource>(targetPredicate, sourcePredicate);
        }

        public WMAndUpdateWMAndActionContainer<TSource> WhenMatchedAndTarget(Expression<Func<TSource, bool>> targetPredicate)
        {
            if (targetPredicate == null)
                throw new ArgumentNullException("targetPredicate");

            var whenMatchedAndTarget = queryComponent.CreateWMAndTargetQueryPart(targetPredicate);

            return new WMAndUpdateWMAndActionContainer<TSource>(whenMatchedAndTarget);
        }

        public WMAndUpdateWMAndActionContainer<TSource> WhenMatchedAndSource(Expression<Func<TSource, bool>> sourcePredicate)
        {
            if (sourcePredicate == null)
                throw new ArgumentNullException("sourcePredicate");

            var whenMatchedAndTarget = queryComponent.CreateWMAndSourceQueryPart(sourcePredicate);

            return new WMAndUpdateWMAndActionContainer<TSource>(whenMatchedAndTarget);
        }

    }
}
