using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CompleteSQL.Merge
{
    /// <summary>
    /// Содержит все действия с условиями кроме WhenNotMatchedByTarget
    /// WhenNotMatched может быть только один раз:
    /// An action of type 'WHEN NOT MATCHED' cannot appear more than once in a 'INSERT' clause of a MERGE statement.
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    public class AfterWhenNotMatchedByTargetThenCA<TSource> : ConditionsAndActionsBase 
    {
        internal AfterWhenNotMatchedByTargetThenCA(MergeQueryPartComponent queryComponent) : base(queryComponent) { }

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
