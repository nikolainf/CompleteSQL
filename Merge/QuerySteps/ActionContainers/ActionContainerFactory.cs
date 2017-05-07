using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using CompleteSQL.Merge.QueryPartsFactory;

namespace CompleteSQL.Merge.QuerySteps.ActionContainers
{
    public static class ActionContainerFactory
    {
        public static T CreateWMAndActionContainer<T, TSource>(this QueryPartComponent queryComponent, Expression<Func<TSource, bool>> targetPredicate, Expression<Func<TSource, bool>> sourcePredicate)
            where T : QueryStepBase
        {
            if (targetPredicate == null)
                throw new ArgumentNullException("targetPredicate");

            if (sourcePredicate == null)
                throw new ArgumentNullException("sourcePredicate");


            var whenMatchedQueryPart = new WhenMatchedQueryPart();
            whenMatchedQueryPart.QueryPartComponent = queryComponent;

            var andTargetQueryPart = new AndTargetQueryPart(targetPredicate);
            andTargetQueryPart.QueryPartComponent = whenMatchedQueryPart;

            var whenMatchedAndTargetSource = new AndSourceQueryPart(sourcePredicate);
            whenMatchedAndTargetSource.QueryPartComponent = andTargetQueryPart;


          
            var instance = Activator.CreateInstance(typeof(T), true) as T;

            instance.QueryComponent = whenMatchedAndTargetSource;


            return instance;
        }
    }
}
