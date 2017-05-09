using System;
using System.Linq.Expressions;


namespace CompleteSQL.Merge
{
    public class WMAndUpdateOrDeleteWNMActionContainer<TSource> : QueryStepBase
    {
        internal WMAndUpdateOrDeleteWNMActionContainer(QueryPartComponent queryComponent) : base(queryComponent)
        {

        }

        public WMAndUpdateOrDeleteWNMInsertActionStep<TSource> ThenInsert()
        {
            var thenInsertQueryPart = new ThenInsertQueryPart();
            thenInsertQueryPart.QueryPartComponent = queryComponent;

            return new WMAndUpdateOrDeleteWNMInsertActionStep<TSource>(thenInsertQueryPart);
        }

        public WMAndUpdateOrDeleteWNMInsertActionStep<TSource> ThenInsert<TInsert>(Expression<Func<TSource, TInsert>> insertingColumns)
        {
            var thenInsertQueryPart = new ThenInsertQueryPart(insertingColumns);
            thenInsertQueryPart.QueryPartComponent = queryComponent;

            return new WMAndUpdateOrDeleteWNMInsertActionStep<TSource>(thenInsertQueryPart);
        }
    }
}
