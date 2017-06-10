using CompleteSQL.Merge.QueryPartsFactory;
using System;
using System.Linq.Expressions;

namespace CompleteSQL.Merge
{
    /// <summary>
    /// Класс-условие When Not Matched By Source, содержащий методы действия, доступные после условия When Not Matched By Source, если оно иде самым первым условием в merge-запросе
    /// </summary>
    /// <typeparam name="TSource">Тип-Источик</typeparam>
    public class WnmBySrcActionContainer<TSource> : QueryStepBase
    {
        internal WnmBySrcActionContainer(QueryPartComponent queryComponent)
            : base(queryComponent)
        {

        }

     

        public WNMThenUpdateActionStep<TSource> ThenUpdate<TUpdate>(Expression<Func<TSource, TUpdate>> newValues)
        {
            
            var thenUpdateQueryPart = queryComponent.CreateWNMThenUpdateQueryPart(newValues);

            return new WNMThenUpdateActionStep<TSource>(thenUpdateQueryPart);
        }

        public WNMThenDeleteActionStep<TSource> ThenDelete()
        {

            var thenDeleteQueryPart = queryComponent.CreateThenDeleteQueryPart();

            return new WNMThenDeleteActionStep<TSource>(thenDeleteQueryPart);
        }
    }
}
