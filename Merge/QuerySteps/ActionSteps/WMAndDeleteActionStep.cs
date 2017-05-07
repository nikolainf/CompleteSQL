using CompleteSQL.Merge.QueryPartsFactory;
using System;
using System.Linq.Expressions;
using CompleteSQL.Merge.QuerySteps.ActionContainers;

namespace CompleteSQL.Merge
{
    public class WMAndDeleteActionStep<TSource> : ActionStepBase
    {
        internal WMAndDeleteActionStep(QueryPartComponent queryComponent)
            : base(queryComponent)
        { }

        public WMAndDeleteWMActionContainer<TSource> WhenMatched()
        {
            var whenMatchedQueryPart = queryComponent.CreateWhenMatchedQueryPart();

            return new WMAndDeleteWMActionContainer<TSource>(whenMatchedQueryPart);
        }

        public WMAndActionContainer<TSource> WhenMatchedAnd(Expression<Func<TSource, bool>> targetPredicate, Expression<Func<TSource, bool>> sourcePredicate)
        {
            return queryComponent.CreateWMAndActionContainer<WMAndActionContainer<TSource>, TSource>(targetPredicate, sourcePredicate);
        }

        public WMAndActionContainer<TSource> WhenMatchedAndTarget(Expression<Func<TSource, bool>> targetPredicate)
        {
            if (targetPredicate == null)
                throw new ArgumentNullException("targetPredicate");

            var whenMatchedAndTarget = queryComponent.CreateWMAndTargetQueryPart(targetPredicate);

            return new WMAndActionContainer<TSource>(whenMatchedAndTarget);
        }

        public WMAndActionContainer<TSource> WhenMatchedAndSource(Expression<Func<TSource, bool>> sourcePredicate)
        {
            if (sourcePredicate == null)
                throw new ArgumentNullException("sourcePredicate");

            var whenMatchedAndTarget = queryComponent.CreateWMAndSourceQueryPart(sourcePredicate);

            return new WMAndActionContainer<TSource>(whenMatchedAndTarget);
        }


    }
}
