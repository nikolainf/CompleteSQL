using System;
using System.Linq.Expressions;

namespace CompleteSQL.Merge
{
    /// <summary>
    /// Contains all actions but WhenMatchedThenUpdate, WhenMatchedAndThenUpdate, WhenMatchedThenDelete and WhenMatchedAndThenDelete:
    /// In a MERGE statement, a 'WHEN MATCHED' clause with a search condition cannot appear after a 'WHEN MATCHED' clause with no search condition.
    /// Description: After When Mathced Then Update Or Delete Conditions Actions
    /// </summary>
    public sealed class AfterWMThenUOrDCA<TSource> : QueryStepBase 
    {
        internal AfterWMThenUOrDCA(QueryPartComponent queryComponent)
            : base(queryComponent)
        { 
        }

        #region WhenNotMatchedByTargetThenInsert
        public AllConditionsAndActions<TSource> WhenNotMatchedThenInsert()
        {
            throw new NotImplementedException();
        }

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
