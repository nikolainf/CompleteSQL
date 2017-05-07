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

        public WMFirstActionContainer<TSource> WhenMatched()
        {
            var whenMatchedQueryPart = queryComponent.CreateWhenMatchedQueryPart();

            return new WMFirstActionContainer<TSource>(whenMatchedQueryPart);
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

   
        public WNMFirstActionContainer<TSource> WhenNotMatched()
        {
            var whenNotMatchedByTarget = queryComponent.CreateWNMByTargetQueryPart();

            return new WNMFirstActionContainer<TSource>(whenNotMatchedByTarget);
        }

        public WNMFirstActionContainer<TSource> WhenNotMatchedAnd(Expression<Func<TSource, bool>> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException("predicate");

            var whenNotMatchedAndByTarget = queryComponent.CreateWNMByTargetAndQueryPart(predicate);

            return new WNMFirstActionContainer<TSource>(whenNotMatchedAndByTarget);
        }

        public WNMBySourceFirstActionContainer<TSource> WhenNotMatchedBySource()
        {
            var whenNotMatchedBySource = queryComponent.CreateWNMBySourceQueryPart();

            return new WNMBySourceFirstActionContainer<TSource>(whenNotMatchedBySource);
        }

        public WNMBySourceFirstActionContainer<TSource> WhenNotMatcheBySourceAnd(Expression<Func<TSource, bool>> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException("predicate");

            var whenNotMatchedAndBySource = queryComponent.CreateWNMBySourceAndQueryPart(predicate);

            return new WNMBySourceFirstActionContainer<TSource>(whenNotMatchedAndBySource);
        }

    }
}
