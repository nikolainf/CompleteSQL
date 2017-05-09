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

        public WMAndUpdateWMAndActionContainer<TSource> WhenMatchedAnd(Expression<Func<TSource, bool>> targetPredicate, Expression<Func<TSource, bool>> sourcePredicate)
        {
            var wmAndTargetSourceQueryComponent = queryComponent.CreateWMAndQueryPart<TSource>(targetPredicate, sourcePredicate);

            return new WMAndUpdateWMAndActionContainer<TSource>(wmAndTargetSourceQueryComponent);
        }

        public WMAndUpdateWMAndActionContainer<TSource> WhenMatchedAndTarget(Expression<Func<TSource, bool>> targetPredicate)
        {
            var wmAndTargetQueryComponent = queryComponent.CreateWMAndTargetQueryPart<TSource>(targetPredicate);

            return new WMAndUpdateWMAndActionContainer<TSource>(wmAndTargetQueryComponent);
         
        }

        public WMAndUpdateWMAndActionContainer<TSource> WhenMatchedAndSource(Expression<Func<TSource, bool>> sourcePredicate)
        {
            var whenMatchedAndTarget = queryComponent.CreateWMAndSourceQueryPart(sourcePredicate);

            return new WMAndUpdateWMAndActionContainer<TSource>(whenMatchedAndTarget);
        }

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

        public WMAndUpdateOrDeleteWNMBySourceActionContainer<TSource> WhenNotMatchedBySource()
        {
            var wnmBySourceQueryComponent = queryComponent.CreateWNMBySourceQueryPart();

            return new WMAndUpdateOrDeleteWNMBySourceActionContainer<TSource>(wnmBySourceQueryComponent);
        }

        public WMAndUpdateOrDeleteWNMBySourceAndActionContainer<TSource> WhenNotMatchedBySourceAnd(Expression<Func<TSource, bool>> predicate)
        {
            var wnmAndBySource = queryComponent.CreateWNMBySourceAndQueryPart(predicate);

            return new WMAndUpdateOrDeleteWNMBySourceAndActionContainer<TSource>(wnmAndBySource);
        }

     

    }
}
