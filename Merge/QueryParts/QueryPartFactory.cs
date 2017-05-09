using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CompleteSQL.Merge.QueryPartsFactory
{
    internal static class QueryPartFactory
    {
        internal static WhenMatchedQueryPart CreateWhenMatchedQueryPart(this QueryPartComponent queryComponent)
        {
            var whenMatchedQueryPart = new WhenMatchedQueryPart();
            whenMatchedQueryPart.QueryPartComponent = queryComponent;

            return whenMatchedQueryPart;
        }

        internal static AndTargetQueryPart CreateWhenMatchedAndQueryPart<TSource>(this QueryPartComponent queryComponent, Expression<Func<TSource, bool>> predicate)
        {
            var whenMatchedQueryPart = new WhenMatchedQueryPart();
            whenMatchedQueryPart.QueryPartComponent = queryComponent;

            var andQueryPart = new AndTargetQueryPart(predicate);
            andQueryPart.QueryPartComponent = whenMatchedQueryPart;

            return andQueryPart;
        }

        internal static WhenNotMatchedQueryPart CreateWNMByTargetQueryPart(this QueryPartComponent queryComponent)
        {
            var whenNotMatched = new WhenNotMatchedQueryPart(true);
            whenNotMatched.QueryPartComponent = queryComponent;

            return whenNotMatched;
        }

        internal static WhenNotMatchedQueryPart CreateWNMBySourceQueryPart(this QueryPartComponent queryComponent)
        {
            var whenNotMatchedBySource = new WhenNotMatchedQueryPart(false);
            whenNotMatchedBySource.QueryPartComponent = queryComponent;

            return whenNotMatchedBySource;
        }

        internal static AndSourceQueryPart CreateWNMByTargetAndQueryPart<TSource>(this QueryPartComponent queryComponent, Expression<Func<TSource, bool>> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException("predicate");

            var whenNotMatchedByTarget = new WhenNotMatchedQueryPart(true);
            whenNotMatchedByTarget.QueryPartComponent = queryComponent;

            var andQueryPart = new AndSourceQueryPart(predicate);
            andQueryPart.QueryPartComponent = whenNotMatchedByTarget;

            return andQueryPart;
        }

        internal static AndTargetQueryPart CreateWNMBySourceAndQueryPart<TSource>(this QueryPartComponent queryComponent, Expression<Func<TSource, bool>> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException("predicate");

            var whenNotMatchedBySource = new WhenNotMatchedQueryPart(false);
            whenNotMatchedBySource.QueryPartComponent = queryComponent;

            var andQueryPart = new AndTargetQueryPart(predicate);
            andQueryPart.QueryPartComponent = whenNotMatchedBySource;

            return andQueryPart;
        }

        internal static ThenUpdateQueryPart CreateWNMThenUpdateQueryPart<TSource, TUpdate>(this QueryPartComponent queryComponent, Expression<Func<TSource, TUpdate>> newValues)
        {
            var thenUpdateQueryPart = new ThenUpdateQueryPart(newValues, ParamAliasSet.OnlyTarget);
            thenUpdateQueryPart.QueryPartComponent = queryComponent;

            return thenUpdateQueryPart;
        }

        internal static ThenUpdateQueryPart CreateWMThenUpdateQueryPart<TSource, TUpdate>(this QueryPartComponent queryComponent, Expression<Func<TSource,TSource, TUpdate>> newValues)
        {
            var thenUpdateQueryPart = new ThenUpdateQueryPart(newValues, ParamAliasSet.TargetSource);
            thenUpdateQueryPart.QueryPartComponent = queryComponent;

            return thenUpdateQueryPart;
        }

        internal static ThenUpdateQueryPart CreateWMThenUpdateQueryPart<TSource>(this QueryPartComponent queryComponent)
        {
            var thenUpdateQueryPart = new ThenUpdateQueryPart();
            thenUpdateQueryPart.QueryPartComponent = queryComponent;

            return thenUpdateQueryPart;
        }

        internal static ThenDeleteQueryPart CreateThenDeleteQueryPart(this QueryPartComponent queryComponent)
        {
            var thenDeleteQueryPart = new ThenDeleteQueryPart();
            thenDeleteQueryPart.QueryPartComponent = queryComponent;
            return thenDeleteQueryPart;
        }


        public static AndTargetQueryPart CreateWMAndTargetQueryPart<TSource>(this QueryPartComponent queryComponent, Expression<Func<TSource, bool>> targetPredicate)
        {
            if (targetPredicate == null)
                throw new ArgumentNullException("targetPredicate");


            var whenMatchedQueryPart = new WhenMatchedQueryPart();
            whenMatchedQueryPart.QueryPartComponent = queryComponent;

            var whenMatchedAndTarget = new AndTargetQueryPart(targetPredicate);
            whenMatchedAndTarget.QueryPartComponent = whenMatchedQueryPart;


            return whenMatchedAndTarget;
        }
        


        internal static AndSourceQueryPart CreateWMAndSourceQueryPart<TSource>(this QueryPartComponent queryComponent, Expression<Func<TSource, bool>> sourcePredicate)
        {
            if (sourcePredicate == null)
                throw new ArgumentNullException("sourcePredicate");

            var whenMatchedQueryPart = new WhenMatchedQueryPart();
            whenMatchedQueryPart.QueryPartComponent = queryComponent;

            var andSourceQueryPart = new AndSourceQueryPart(sourcePredicate);
            andSourceQueryPart.QueryPartComponent = whenMatchedQueryPart;

            return andSourceQueryPart;
        }

        public static AndSourceQueryPart CreateWMAndQueryPart<TSource>(this QueryPartComponent queryComponent, Expression<Func<TSource, bool>> targetPredicate, Expression<Func<TSource, bool>> sourcePredicate)
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

            return whenMatchedAndTargetSource;


        }

       
    }
}
