using System;
using System.Linq.Expressions;

namespace CompleteSQL.Merge
{
    /// <summary>
    /// Contains all actions but WhenMatchedThenDelete and WhenMatchedAndThenDelete:
    /// An action of type 'WHEN NOT MATCHED BY SOURCE' cannot appear more than once in a 'DELETE' clause of a MERGE statement.
    /// Description: After When Not Matched And Then Delete Conditions and Actions
    /// </summary>
    public sealed class AfterWNMBySrcAndThenDCA<TSource> : ConditionsAndActionsBase
    {
        internal AfterWNMBySrcAndThenDCA(MergeQueryPartComponent queryComponent) : base(queryComponent) { }

        #region WhenMatched

        // Здесь в предикате для методов с AND может быть сравнение атрибута из таргета или из источника или обоих между собой.

        public AllConditionsAndActions<TSource> WhenMatchedThenUpdate()
        {
            throw new NotImplementedException();
        }


        public AllConditionsAndActions<TSource> WhenMatchedAndThenUpdate(Expression<Func<TSource, object>> predicate)
        {
            throw new NotImplementedException();
        }

        public AllConditionsAndActions<TSource> WhenMatchedThenDelete()
        {
            throw new NotImplementedException();
        }

        public AllConditionsAndActions<TSource> WhenMatchedAndThenDelete(Expression<Func<TSource, object>> predicate)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region WhenNotMatchedByTargetThenInsert
        public AllConditionsAndActions<TSource> WhenNotMatchedThenInsert()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Инсерт, когда выполняется условие в predicate.
        /// </summary>
        /// <param name="predicate">Условие применяемое к source'у</param>
        /// <returns></returns>
        public AllConditionsAndActions<TSource> WhenNotMatchedAndThenInsert(Expression<Func<TSource, object>> predicate)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region WhenNotMatchedBySource
        // Здесь в предикате для методов с AND должно быть сравнение атрибута из таргета
        // Или любое другое выражение, но только не сравнение атрибута из источника

        public AllConditionsAndActions<TSource> WhenNotMatchedBySourceThenUpdate()
        {
            throw new NotImplementedException();
        }


        public AllConditionsAndActions<TSource> WhenNotMatchedBySourceAndThenUpdate(Expression<Func<TSource, object>> predicate)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}