﻿using System;
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

        public WMActionContainer<TSource> WhenMatched()
        {
            var whenMatchedQueryPart = queryComponent.CreateWhenMatchedQueryPart();

            return new WMActionContainer<TSource>(whenMatchedQueryPart);
        }

        public WMAndActionContainer<TSource> WhenMatchedAnd(Expression<Func<TSource, bool>> targetPredicate, Expression<Func<TSource, bool>> sourcePredicate)
        {
            var wmAndTargetSourceQueryComponent = queryComponent.CreateWMAndQueryPart<TSource>(targetPredicate, sourcePredicate);

            return new WMAndActionContainer<TSource>(wmAndTargetSourceQueryComponent);
           
        }

        public WMAndActionContainer<TSource> WhenMatchedAndTarget(Expression<Func<TSource, bool>> targetPredicate)
        {
            var wmAndTargetQueryComponent = queryComponent.CreateWMAndTargetQueryPart<TSource>(targetPredicate);

            return new WMAndActionContainer<TSource>(wmAndTargetQueryComponent);
        }

        public WMAndActionContainer<TSource> WhenMatchedAndSource(Expression<Func<TSource, bool>> sourcePredicate)
        {
            var wmAndSourceQueryComponent = queryComponent.CreateWMAndSourceQueryPart<TSource>(sourcePredicate);

            return new WMAndActionContainer<TSource>(wmAndSourceQueryComponent);
        }

   
        public WNMFirstActionContainer<TSource> WhenNotMatched()
        {
            var whenNotMatchedByTarget = queryComponent.CreateWNMByTargetQueryPart();

            return new WNMFirstActionContainer<TSource>(whenNotMatchedByTarget);
        }

        public WNMFirstActionContainer<TSource> WhenNotMatchedAnd(Expression<Func<TSource, bool>> predicate)
        {
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
           
            var whenNotMatchedAndBySource = queryComponent.CreateWNMBySourceAndQueryPart(predicate);

            return new WNMBySourceFirstActionContainer<TSource>(whenNotMatchedAndBySource);
        }

    }
}
