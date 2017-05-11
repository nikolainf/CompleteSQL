using CompleteSQL.Merge.QueryPartsFactory;
using System;
using System.Linq.Expressions;

namespace CompleteSQL.Merge
{
    public class WMAndDeleteActionStep<TSource> : ActionStepBase
    {
        internal WMAndDeleteActionStep(QueryPartComponent queryComponent)
            : base(queryComponent)
        { }

        #region WhenMatched Action Containers

        public WMAndDeleteWMActionContainer<TSource> WhenMatched()
        {
            var whenMatchedQueryPart = queryComponent.CreateWhenMatchedQueryPart();

            return new WMAndDeleteWMActionContainer<TSource>(whenMatchedQueryPart);
        }

        public WMAndDeleteWMActionContainer<TSource> WhenMatchedAnd(Expression<Func<TSource, bool>> targetPredicate, Expression<Func<TSource, bool>> sourcePredicate)
        {
            var wmAndTargetSourceQueryComponent = queryComponent.CreateWMAndQueryPart<TSource>(targetPredicate, sourcePredicate);

            return new WMAndDeleteWMActionContainer<TSource>(wmAndTargetSourceQueryComponent);

        }

        public WMAndDeleteWMActionContainer<TSource> WhenMatchedAndTarget(Expression<Func<TSource, bool>> targetPredicate)
        {

            var wmAndTargetQueryComponent = queryComponent.CreateWMAndTargetQueryPart<TSource>(targetPredicate);

            return new WMAndDeleteWMActionContainer<TSource>(wmAndTargetQueryComponent);
         
        }

        public WMAndDeleteWMActionContainer<TSource> WhenMatchedAndSource(Expression<Func<TSource, bool>> sourcePredicate)
        {
            var whenMatchedAndTarget = queryComponent.CreateWMAndSourceQueryPart(sourcePredicate);

            return new WMAndDeleteWMActionContainer<TSource>(whenMatchedAndTarget);
        }

        #endregion


        public WMAndUpdateOrDeleteWNMActionContainer<TSource> WhenNotMatched()
        {
            var whenNotMatchedQueryComponent = queryComponent.CreateWNMByTargetQueryPart();

            return new WMAndUpdateOrDeleteWNMActionContainer<TSource>(whenNotMatchedQueryComponent);
        }

        public WMAndUpdateOrDeleteWNMActionContainer<TSource> WhenNotMatchedAnd(Expression<Func<TSource, bool>> predicate)
        {
            var whenNotMatchedQueryComponent = queryComponent.CreateWNMByTargetAndQueryPart<TSource>(predicate);

            return new WMAndUpdateOrDeleteWNMActionContainer<TSource>(whenNotMatchedQueryComponent);
        }
    }
}
