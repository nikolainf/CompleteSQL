using CompleteSQL.Merge.QueryPartsFactory;
using System;
using System.Linq.Expressions;

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

        public WMAndActionContainer<TSource> WhenMatchedAnd(Expression<Func<TSource, bool>> targetPredicate, Expression<Func<TSource, bool>> sourcePredicate)
        {
            if (targetPredicate == null)
                throw new ArgumentNullException("targetPredicate");

            if (sourcePredicate == null)
                throw new ArgumentNullException("sourcePredicate");

            var whenMatchedAndTargetSource = queryComponent.CreateWMAndQueryPart(targetPredicate, sourcePredicate);

            return new WMAndActionContainer<TSource>(whenMatchedAndTargetSource);
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
