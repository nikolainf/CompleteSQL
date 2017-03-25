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

       
        internal static WhenNotMatchedQueryPart CreateWhenNotMatchedByTargetQueryPart(this QueryPartComponent queryComponent)
        {
            var whenNotMatched = new WhenNotMatchedQueryPart(true);
            whenNotMatched.QueryPartComponent = queryComponent;

            return whenNotMatched;
        }

        internal static WhenNotMatchedQueryPart CreateWhenNotMatchedBySourceQueryPart(this QueryPartComponent queryComponent)
        {
            var whenNotMatched = new WhenNotMatchedQueryPart(false);
            whenNotMatched.QueryPartComponent = queryComponent;

            return whenNotMatched;
        }

        internal static AndSourceQueryPart CreateWhenNotMatchedByTargetAndQueryPart<TSource>(this QueryPartComponent queryComponent, Expression<Func<TSource, bool>> predicate)
        {
            var whenNotMatchedByTarget = new WhenNotMatchedQueryPart(true);
            whenNotMatchedByTarget.QueryPartComponent = queryComponent;

            var andQueryPart = new AndSourceQueryPart(predicate);
            andQueryPart.QueryPartComponent = whenNotMatchedByTarget;

            return andQueryPart;
        }
    }
}
