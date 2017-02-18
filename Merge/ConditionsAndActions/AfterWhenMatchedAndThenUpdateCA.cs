using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CompleteSQL.Merge
{
    /// <summary>
    /// Contains all actions but WhenMathcedThenUpdate and WhenMatchedAndTheUpdate:
    /// An action of type 'WHEN MATCHED' cannot appear more than once in a 'UPDATE' clause of a MERGE statement.
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    public sealed class AfterWhenMatchedAndThenUpdateCA<TSource> : ConditionsAndActionsBase
    {
        internal AfterWhenMatchedAndThenUpdateCA(MergeQueryPartComponent queryComponent): base(queryComponent)
        {
        }

        public AllConditionsAndActions<TSource> WhenMatchedThenDelete()
        {
            throw new NotImplementedException();
        }

        public AllConditionsAndActions<TSource> WhenMatchedAndThenDelete(Expression<Func<TSource, object>> predicate)
        {
            throw new NotImplementedException();
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
