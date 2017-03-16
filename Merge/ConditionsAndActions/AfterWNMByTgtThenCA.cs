using System;
using System.Linq.Expressions;

namespace CompleteSQL.Merge
{
    /// <summary>
    /// Contains all actions but WhenNotMatchedByTargetThenInsert and WhenNotMatchedByTargetAndThenInsert
    /// An action of type 'WHEN NOT MATCHED' cannot appear more than once in a 'INSERT' clause of a MERGE statement.
    /// Description: After When Not Matched By Target Then Conditions And Actions
    /// </summary>
    public sealed class AfterWNMByTgtThenCA<TSource> : ConditionAndActionBase 
    {
        internal AfterWNMByTgtThenCA(MergeQueryPartComponent queryComponent)
            : base(queryComponent)
        { }

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
