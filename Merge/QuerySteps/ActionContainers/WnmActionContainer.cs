using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CompleteSQL.Merge;
using CompleteSQL.Merge.QueryPartsFactory;

namespace CompleteSQL.Merge
{
    /// <summary>
    /// Класс условие When Not Matched, содержащий методы действия выполняемые после условия When Not Matched, если оно идет самым первым в merge-запросе
    /// </summary>
    /// <typeparam name="TSource">Тип-Источник</typeparam>
    public class WnmActionContainer<TSource> : QueryStepBase
    {
        internal WnmActionContainer(QueryPartComponent queryComponent)
            : base(queryComponent)
        {
            
        }

        public WnmActionStep<TSource> ThenInsert()
        {
            var thenInsertQueryPart = new ThenInsertQueryPart();
            thenInsertQueryPart.QueryPartComponent = queryComponent;

            return new WnmActionStep<TSource>(thenInsertQueryPart);
        }

        public WnmActionStep<TSource> ThenInsert<TInsert>(Expression<Func<TSource, TInsert>> insertingColumns)
        {
            var thenInsertQueryPart = new ThenInsertQueryPart(insertingColumns);
            thenInsertQueryPart.QueryPartComponent = queryComponent;

            return new WnmActionStep<TSource>(thenInsertQueryPart);
        }

      
    }
}
