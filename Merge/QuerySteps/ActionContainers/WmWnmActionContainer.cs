using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CompleteSQL.Merge
{
    public class WmWnmActionContainer<TSource> : QueryStepBase
    {
      
        internal WmWnmActionContainer(QueryPartComponent queryComponent)
            :base(queryComponent)
        {

        }


        public WmWnmInsertActionStep<TSource> ThenInsert()
        {
            var thenInsertQueryPart = new ThenInsertQueryPart();
            thenInsertQueryPart.QueryPartComponent = queryComponent;

            return new WmWnmInsertActionStep<TSource>(thenInsertQueryPart);
        }

        public WmWnmInsertActionStep<TSource> ThenInsert<TInsert>(Expression<Func<TSource, TInsert>> insertingColumns)
        {
            var thenInsertQueryPart = new ThenInsertQueryPart(insertingColumns);
            thenInsertQueryPart.QueryPartComponent = queryComponent;

            return new WmWnmInsertActionStep<TSource>(thenInsertQueryPart);
        }
    }
}
