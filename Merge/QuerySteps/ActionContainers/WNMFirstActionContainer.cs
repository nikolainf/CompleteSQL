﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CompleteSQL.Merge;
using CompleteSQL.Merge.QueryPartsFactory;

namespace CompleteSQL.Merge
{
    public class WNMFirstActionContainer<TSource> : QueryStepBase
    {
        internal WNMFirstActionContainer(QueryPartComponent queryComponent)
            : base(queryComponent)
        {
            
        }

        public ThenInsertActionStep<TSource> ThenInsert()
        {
            var thenInsertQueryPart = new ThenInsertQueryPart();
            thenInsertQueryPart.QueryPartComponent = queryComponent;

            return new ThenInsertActionStep<TSource>(thenInsertQueryPart);
        }

        public ThenInsertActionStep<TSource> ThenInsert<TInsert>(Expression<Func<TSource, TInsert>> insertingColumns)
        {
            var thenInsertQueryPart = new ThenInsertQueryPart(insertingColumns);
            thenInsertQueryPart.QueryPartComponent = queryComponent;

            return new ThenInsertActionStep<TSource>(thenInsertQueryPart);
        }

      
    }
}
