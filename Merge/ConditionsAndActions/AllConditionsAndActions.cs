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

        public AfterWMThenUOrDCA<TSource> WhenMatchedThenUpdate()
        {
            
            var whenMatchedQueryPart = new WhenMatchedQueryPart();
            whenMatchedQueryPart.QueryPartComponent = queryComponent;

            var thenUpdateQueryPart = new ThenUpdateQueryPart();
            thenUpdateQueryPart.QueryPartComponent = whenMatchedQueryPart;


            return new AfterWMThenUOrDCA<TSource>(thenUpdateQueryPart);

        }


        public AfterWMAndThenUCA<TSource> WhenMatchedAndThenUpdate(Expression<Func<TSource, bool>> predicate)
        {
            var whenMatchedQueryPart = new WhenMatchedQueryPart();
            whenMatchedQueryPart.QueryPartComponent = queryComponent;

            var andQueryPart = new AndQueryPart(predicate);
            andQueryPart.QueryPartComponent = whenMatchedQueryPart;

            var thenUpdateQueryPart = new ThenUpdateQueryPart();
            thenUpdateQueryPart.QueryPartComponent = andQueryPart;

            return new AfterWMAndThenUCA<TSource>(thenUpdateQueryPart);
        }

        public AfterWMThenUOrDCA<TSource> WhenMatchedThenDelete()
        {
            var whenMatchedQueryPart = new WhenMatchedQueryPart();
            whenMatchedQueryPart.QueryPartComponent = queryComponent;

            var thenDeleteQueryPart = new ThenDeleteQueryPart();
            thenDeleteQueryPart.QueryPartComponent = whenMatchedQueryPart;


            return new AfterWMThenUOrDCA<TSource>(thenDeleteQueryPart);
        }

        public AfterWMAndThenDCA<TSource> WhenMatchedAndThenDelete(Expression<Func<TSource, bool>> predicate)
        {
            var whenMatchedQueryPart = new WhenMatchedQueryPart();
            whenMatchedQueryPart.QueryPartComponent = queryComponent;

            var andQueryPart = new AndQueryPart(predicate);
            andQueryPart.QueryPartComponent = whenMatchedQueryPart;

            var thenUpdateQueryPart = new ThenDeleteQueryPart();
            thenUpdateQueryPart.QueryPartComponent = andQueryPart;

            return new AfterWMAndThenDCA<TSource>(thenUpdateQueryPart);
        }

        #endregion

        #region WhenNotMatchedByTargetThenInsert
        public AfterWNMByTgtThenCA<TSource> WhenNotMatchedThenInsert<TPredicate>(Expression<Func<TSource, TPredicate>> expr)
        {
            var whenNotMatchedByTarget = new WhenNotMatchedQueryPart();
            whenNotMatchedByTarget.QueryPartComponent = queryComponent;

            var thenInsertQueryPart = new ThenInsertQueryPart(expr);
            thenInsertQueryPart.QueryPartComponent = whenNotMatchedByTarget;

            return new AfterWNMByTgtThenCA<TSource>(thenInsertQueryPart);

        }

        public AfterWNMByTgtThenCA<TSource> WhenNotMatchedThenInsert()
        {
            var whenNotMatchedByTarget = new WhenNotMatchedQueryPart();
            whenNotMatchedByTarget.QueryPartComponent = queryComponent;

            var thenInsertQueryPart = new ThenInsertQueryPart();
            thenInsertQueryPart.QueryPartComponent = whenNotMatchedByTarget;

            return new AfterWNMByTgtThenCA<TSource>(thenInsertQueryPart);

        }

        /// <summary>
        /// Инсерт, когда выполняется условие в predicate.
        /// </summary>
        /// <param name="predicate">Условие применяемое к source'у</param>
        /// <returns></returns>
        public AfterWNMByTgtThenCA<TSource> WhenNotMatchedAndThenInsert(Expression<Func<TSource, bool>> predicate)
        {
            var whenNotMatchedByTarget = new WhenNotMatchedQueryPart();
            whenNotMatchedByTarget.QueryPartComponent = queryComponent;

            var andQueryPart = new AndQueryPart(predicate);
            andQueryPart.QueryPartComponent = whenNotMatchedByTarget;

            var thenInsertQueryPart = new ThenInsertQueryPart();
            thenInsertQueryPart.QueryPartComponent = andQueryPart;

            return new AfterWNMByTgtThenCA<TSource>(thenInsertQueryPart);
        }

        #endregion

        #region WhenNotMatchedBySource
        // Здесь в предикате для методов с AND должно быть сравнение атрибута из таргета
        // Или любое другое выражение, но только не сравнение атрибута из источника

        public AfterWNMBySrcThenUOrDCA<TSource> WhenNotMatchedBySourceThenUpdate()
        {
            var whenNotMatchedQueryPart = new WhenNotMatchedQueryPart();
            whenNotMatchedQueryPart.QueryPartComponent = queryComponent;

            var thenUpdateQueryPart = new ThenUpdateQueryPart();
            thenUpdateQueryPart.QueryPartComponent = whenNotMatchedQueryPart;

            return new AfterWNMBySrcThenUOrDCA<TSource>(thenUpdateQueryPart);
        }


        public AfterWNMBySrcAndThenUCA<TSource> WhenNotMatchedBySourceAndThenUpdate(Expression<Func<TSource, bool>> predicate)
        {
            var whenNotMatchedQueryPart = new WhenNotMatchedQueryPart();
            whenNotMatchedQueryPart.QueryPartComponent = queryComponent;

            var andQueryPart = new AndQueryPart(predicate);
            andQueryPart.QueryPartComponent = whenNotMatchedQueryPart;

            var thenUpdateQueryPart = new ThenUpdateQueryPart();
            thenUpdateQueryPart.QueryPartComponent = andQueryPart;

            return new AfterWNMBySrcAndThenUCA<TSource>(thenUpdateQueryPart);
        }


        public AfterWNMBySrcThenUOrDCA<TSource> WhenNotMatchedBySourceThenDelete()
        {
            var whenNotMatchedQueryPart = new WhenNotMatchedQueryPart();
            whenNotMatchedQueryPart.QueryPartComponent = queryComponent;

            var thenDeleteQueryPart = new ThenDeleteQueryPart();
            thenDeleteQueryPart.QueryPartComponent = whenNotMatchedQueryPart;

            return new AfterWNMBySrcThenUOrDCA<TSource>(thenDeleteQueryPart);
        }

        public AllConditionsAndActions<TSource> WhenNotMatchedBySourceAndThenDelete(Expression<Func<TSource, object>> predicate)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
