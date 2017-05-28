using CompleteSQL.Merge.QueryPartsFactory;
using System;
using System.Linq.Expressions;

namespace CompleteSQL.Merge
{
    /// <summary>
    /// Класс условие When Matched, содержащий методы действия выполняемые после условия When Matched, если оно идет самым первым в merge-запросе
    /// </summary>
    /// <typeparam name="TSource">Тип-Источник</typeparam>
    public class WmActionContainer<TSource> : QueryStepBase
    {
        internal WmActionContainer(QueryPartComponent queryComponent)
            : base(queryComponent)
        {
            
        }


        public WMActionStep<TSource> ThenUpdate<TUpdate>(Expression<Func<TSource,TSource, TUpdate>> updatingColumns)
        {
            var thenUpdateQueryPart = queryComponent.CreateWMThenUpdateQueryPart(updatingColumns);

            return new WMActionStep<TSource>(thenUpdateQueryPart);
        }


        public WMActionStep<TSource> ThenUpdate()
        {
            var thenUpdateQueryPart = queryComponent.CreateWMThenUpdateQueryPart<TSource>();

            return new WMActionStep<TSource>(thenUpdateQueryPart);
        }

        public WMActionStep<TSource> ThenDelete()
        {
            var thenDeleteQueryPart = queryComponent.CreateThenDeleteQueryPart();

            return new WMActionStep<TSource>(thenDeleteQueryPart);
        }

    }
}
