﻿using CompleteSQL.Merge.QueryPartsFactory;
using System;
using System.Linq.Expressions;

namespace CompleteSQL.Merge
{
    /// <summary>
    /// Класс условие When Matched, содержащий методы действия выполняемые после условия When Matched, если оно идет самым первым в merge-запросе
    /// </summary>
    /// <typeparam name="TSource">Тип-Источник</typeparam>
    public class WMActionContainer<TSource> : QueryStepBase
    {
        internal WMActionContainer(QueryPartComponent queryComponent)
            : base(queryComponent)
        {
            
        }


        public WMUpdateActionStep<TSource> ThenUpdate<TUpdate>(Expression<Func<TSource,TSource, TUpdate>> updatingColumns)
        {
            var thenUpdateQueryPart = queryComponent.CreateWMThenUpdateQueryPart(updatingColumns);

            return new WMUpdateActionStep<TSource>(thenUpdateQueryPart);
        }


        public WMUpdateActionStep<TSource> ThenUpdate()
        {
            var thenUpdateQueryPart = queryComponent.CreateWMThenUpdateQueryPart<TSource>();

            return new WMUpdateActionStep<TSource>(thenUpdateQueryPart);
        }

        public WMDeleteActionStep<TSource> ThenDelete()
        {
            var thenDeleteQueryPart = queryComponent.CreateThenDeleteQueryPart();

            return new WMDeleteActionStep<TSource>(thenDeleteQueryPart);
        }

    }
}