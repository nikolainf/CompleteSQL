using System;
using System.Linq.Expressions;

namespace CompleteSQL.Merge
{
    /// <summary>
    /// Contains full set of merge actions.
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    public sealed class AllConditionsAndActions<TSource> : ConditionsAndActionsBase 
    {
        internal AllConditionsAndActions(MergeQueryPartComponent queryComponent):base(queryComponent)
        { }

        #region WhenMatched

        // Здесь в предикате для методов с AND может быть сравнение атрибута из таргета или из источника или обоих между собой.

        public AfterWhenMatchedThenUpdateOrDeleteCA<TSource> WhenMatchedThenUpdate()
        {
            
            var whenMatchedQueryPart = new WhenMatchedQueryPart();
            whenMatchedQueryPart.QueryPartComponent = queryComponent;

            var thenUpdateQueryPart = new ThenUpdateQueryPart();
            thenUpdateQueryPart.QueryPartComponent = whenMatchedQueryPart;


            return new AfterWhenMatchedThenUpdateOrDeleteCA<TSource>(thenUpdateQueryPart);

        }


        public AfterWhenMatchedAndThenUpdateCA<TSource> WhenMatchedAndThenUpdate(Expression<Func<TSource, object>> predicate)
        {
            var whenMatchedQueryPart = new WhenMatchedQueryPart();
            whenMatchedQueryPart.QueryPartComponent = queryComponent;

            var andQueryPart = new AndQueryPart();
            andQueryPart.QueryPartComponent = whenMatchedQueryPart;

            var thenUpdateQueryPart = new ThenUpdateQueryPart();
            thenUpdateQueryPart.QueryPartComponent = andQueryPart;

            return new AfterWhenMatchedAndThenUpdateCA<TSource>(thenUpdateQueryPart);
        }

        public AfterWhenMatchedThenUpdateOrDeleteCA<TSource> WhenMatchedThenDelete()
        {
            var whenMatchedQueryPart = new WhenMatchedQueryPart();
            whenMatchedQueryPart.QueryPartComponent = queryComponent;

            var thenDeleteQueryPart = new ThenDeleteQueryPart();
            thenDeleteQueryPart.QueryPartComponent = whenMatchedQueryPart;


            return new AfterWhenMatchedThenUpdateOrDeleteCA<TSource>(thenDeleteQueryPart);
        }

        public AfterWhenMatchedAndThenDeleteCA<TSource> WhenMatchedAndThenDelete(Expression<Func<TSource, object>> predicate)
        {
            var whenMatchedQueryPart = new WhenMatchedQueryPart();
            whenMatchedQueryPart.QueryPartComponent = queryComponent;

            var andQueryPart = new AndQueryPart();
            andQueryPart.QueryPartComponent = whenMatchedQueryPart;

            var thenUpdateQueryPart = new ThenDeleteQueryPart();
            thenUpdateQueryPart.QueryPartComponent = andQueryPart;

            return new AfterWhenMatchedAndThenDeleteCA<TSource>(thenUpdateQueryPart);
        }

        #endregion

        #region WhenNotMatchedByTargetThenInsert
        public AfterWhenNotMatchedByTargetThenCA<TSource> WhenNotMatchedThenInsert()
        {
            var whenNotMatchedByTarget = new WhenNotMatchedQueryPart();
            whenNotMatchedByTarget.QueryPartComponent = queryComponent;

            var thenInsertQueryPart = new ThenInsertQueryPart();
            thenInsertQueryPart.QueryPartComponent = whenNotMatchedByTarget;

            return new AfterWhenNotMatchedByTargetThenCA<TSource>(thenInsertQueryPart);

        }

        /// <summary>
        /// Инсерт, когда выполняется условие в predicate.
        /// </summary>
        /// <param name="predicate">Условие применяемое к source'у</param>
        /// <returns></returns>
        public AfterWhenNotMatchedByTargetThenCA<TSource> WhenNotMatchedAndThenInsert(Expression<Func<TSource, object>> predicate)
        {
            var whenNotMatchedByTarget = new WhenNotMatchedQueryPart();
            whenNotMatchedByTarget.QueryPartComponent = queryComponent;

            var andQueryPart = new AndQueryPart();
            andQueryPart.QueryPartComponent = whenNotMatchedByTarget;

            var thenInsertQueryPart = new ThenInsertQueryPart();
            thenInsertQueryPart.QueryPartComponent = andQueryPart;

            return new AfterWhenNotMatchedByTargetThenCA<TSource>(thenInsertQueryPart);
        }

        #endregion

        #region WhenNotMatchedBySource
        // Здесь в предикате для методов с AND должно быть сравнение атрибута из таргета
        // Или любое другое выражение, но только не сравнение атрибута из источника

        public AfterWhenNotMatchedBySourceThenUpdateCA<TSource> WhenNotMatchedBySourceThenUpdate()
        {
            var whenNotMatchedQueryPart = new WhenNotMatchedQueryPart();
            whenNotMatchedQueryPart.QueryPartComponent = queryComponent;

            var thenUpdateQueryPart = new ThenUpdateQueryPart();
            thenUpdateQueryPart.QueryPartComponent = whenNotMatchedQueryPart;

            return new AfterWhenNotMatchedBySourceThenUpdateCA<TSource>(thenUpdateQueryPart);
        }


        public AfterWhenNotMatchedBySourceAndThenUpdateCA<TSource> WhenNotMatchedBySourceAndThenUpdate(Expression<Func<TSource, object>> predicate)
        {
            var whenNotMatchedQueryPart = new WhenNotMatchedQueryPart();
            whenNotMatchedQueryPart.QueryPartComponent = queryComponent;

            var andQueryPart = new AndQueryPart();
            andQueryPart.QueryPartComponent = whenNotMatchedQueryPart;

            var thenUpdateQueryPart = new ThenUpdateQueryPart();
            thenUpdateQueryPart.QueryPartComponent = andQueryPart;

            return new AfterWhenNotMatchedBySourceAndThenUpdateCA<TSource>(thenUpdateQueryPart);
        }


        public AllConditionsAndActions<TSource> WhenNotMatchedBySourceThenDelete()
        {
            throw new NotImplementedException();
        }

        public AllConditionsAndActions<TSource> WhenNotMatchedBySourceAndThenDelete(Expression<Func<TSource, object>> predicate)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
