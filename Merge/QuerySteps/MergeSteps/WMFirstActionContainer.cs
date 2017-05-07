using CompleteSQL.Merge.QueryPartsFactory;
using System;
using System.Linq.Expressions;

namespace CompleteSQL.Merge
{
    /// <summary>
    /// Класс условие When Matched, содержащий методы действия выполняемые после условия When Matched, если оно идет самым первым в merge-запросе
    /// </summary>
    /// <typeparam name="TSource">Тип-Источник</typeparam>
    public class WMFirstActionContainer<TSource> : QueryStepBase
    {
        internal WMFirstActionContainer(QueryPartComponent queryComponent)
            : base(queryComponent)
        {
            
        }


        public WMThenUpdateActionStep<TSource> ThenUpdate<TUpdate>(Expression<Func<TSource,TSource, TUpdate>> updatingColumns)
        {
            var thenUpdateQueryPart = queryComponent.CreateWMThenUpdateQueryPart(updatingColumns);

            return new WMThenUpdateActionStep<TSource>(thenUpdateQueryPart);
        }


        public WMThenUpdateActionStep<TSource> ThenUpdate()
        {
            var thenUpdateQueryPart = queryComponent.CreateWMThenUpdateQueryPart<TSource>();

            return new WMThenUpdateActionStep<TSource>(thenUpdateQueryPart);
        }

        public WMThenDeleteActionStep<TSource> ThenDelete()
        {
            var thenDeleteQueryPart = queryComponent.CreateThenDeleteQueryPart();

            return new WMThenDeleteActionStep<TSource>(thenDeleteQueryPart);
        }

    }
}
