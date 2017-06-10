using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompleteSQL.Merge.QueryPartsFactory;
using System.Linq.Expressions;

namespace CompleteSQL.Merge
{
    public class WnmActionStep<TSource> : ActionStepBase
    {
        internal WnmActionStep(QueryPartComponent queryComponent)
            : base(queryComponent)
        { }

        public WnmWmActionContainer<TSource> WhenMatched()
        {
            var whenMatchedQueryComponent = queryComponent.CreateWhenMatchedQueryPart();

            return new WnmWmActionContainer<TSource>(whenMatchedQueryComponent);
        }

        public WnmWmAndActionContainer<TSource> WhenMatchedAnd(Expression<Func<TSource, bool>> targetPredicate, Expression<Func<TSource, bool>> sourcePredicate)
        {
            var whenMathcedQueryComponent = queryComponent.CreateWMAndQueryPart(targetPredicate, sourcePredicate);

            return new WnmWmAndActionContainer<TSource>(whenMathcedQueryComponent);
        }

        public WnmWmAndActionContainer<TSource> WhenMatchedAndTarget(Expression<Func<TSource, bool>> targetPredicate)
        {
            var wmAndTargetQueryComponent = queryComponent.CreateWMAndTargetQueryPart<TSource>(targetPredicate);

            return new WnmWmAndActionContainer<TSource>(wmAndTargetQueryComponent);
        }

        public WnmWmAndActionContainer<TSource> WhenMatchedAndSource(Expression<Func<TSource, bool>> sourcePredicate)
        {
            var wmAndSourceQueryComponent = queryComponent.CreateWMAndSourceQueryPart<TSource>(sourcePredicate);

            return new WnmWmAndActionContainer<TSource>(wmAndSourceQueryComponent);
        }
    }
}
