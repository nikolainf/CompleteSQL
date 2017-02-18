using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CompleteSQL.Merge
{
    /// <summary>
    /// Contains all actions but WhenNotMatchedBySourceThenUpdate, WhenNotMatchedBySourceAndThenUpdate,
    /// WhenNotMatchedBySourceThenDelete and WhenNotMatchedBySourceAndThenDelete
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    public sealed class AfterWhenNotMatchedBySourceThenUpdateCA<TSource> : ConditionsAndActionsBase
    {
        internal AfterWhenNotMatchedBySourceThenUpdateCA(MergeQueryPartComponent queryComponent)
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
    }
}
