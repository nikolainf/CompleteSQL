using CompleteSQL.Merge.QueryPartsFactory;
using System;
using System.Linq.Expressions;

namespace CompleteSQL.Merge
{
   
    public class WmWnmBySourceActionContainer<TSource> : QueryStepBase
    {
        internal WmWnmBySourceActionContainer(QueryPartComponent queryComponent)
            : base(queryComponent)
        { }

        public WmWnmUpdateActionStep<TSource> ThenUpdate<TUpdate>(Expression<Func<TSource, TUpdate>> newValues)
        {
            var thenUpdateQueryPart = queryComponent.CreateWNMThenUpdateQueryPart(newValues);

            return new WmWnmUpdateActionStep<TSource>(thenUpdateQueryPart);
        }

      

        public WmWnmDeleteActionStep<TSource> ThenDelete()
        {
            var thenDeleteQueryPart = queryComponent.CreateThenDeleteQueryPart();

            return new WmWnmDeleteActionStep<TSource>(thenDeleteQueryPart);
        }

    
    }
}
