using System;
using System.Linq.Expressions;

namespace CompleteSQL.Merge
{
    /// <summary>
    /// Содержит полный набор сравнений и действий
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    public class AllConditionsAndActions<TSource> : ConditionsAndActionsBase 
    {
        internal AllConditionsAndActions(MergeQueryPartComponent queryComponent):base(queryComponent)
        { }

        #region WhenMatched
        // Здесь в предикате для методов с AND может быть сравнение атрибута из таргета или из источника или обоих между собой.

        public WmtConditionsAndActions<TSource> WhenMatchedThenUpdate()
        {
            var queryPart = new WhenMatchedQueryPart();
            queryPart.QueryPartComponent = queryComponent;

            return new WmtConditionsAndActions<TSource>(queryPart);

        }

       
        //public AllOperationsAndActions<TSource> WhenMatchedAndThenUpdate(Expression<Func<TSource, object>> predicate)
        //{
        //    throw new NotImplementedException();
        //}

        public AllConditionsAndActions<TSource> WhenMatchedThenDelete()
        {
            throw new NotImplementedException();
        }

        //public AllOperationsAndActions<TSource> WhenMatchedAndThenDelete(Expression<Func<TSource, object>> predicate)
        //{
        //    throw new NotImplementedException();
        //}

        #endregion

        #region WhenNotMatchedByTargetThenInsert
        public AllConditionsAndActions<TSource> WhenNotMatchedThenInsert()
        {
            throw new NotImplementedException();
        }

        //public AllOperationsAndActions<TSource> WhenNotMatchedAndThenInsert(Expression<Func<TSource, object>> predicate)
        //{
        //    throw new NotImplementedException();
        //}

        #endregion

        #region WhenNotMatchedBySource
        // Здесь в предикате для методов с AND должно быть сравнение атрибута из таргета
        // Или любое другое выражение, но только не сравнение атрибута из источника

        public AllConditionsAndActions<TSource> WhenNotMatchedBySourceThenUpdate()
        {
            throw new NotImplementedException();
        }

      
        //public AllOperationsAndActions<TSource> WhenNotMatchedBySourceAndThenUpdate(Expression<Func<TSource, object>> predicate)
        //{
        //    throw new NotImplementedException();
        //}


        public AllConditionsAndActions<TSource> WhenNotMatchedBySourceThenDelete()
        {
            throw new NotImplementedException();
        }

        //public AllOperationsAndActions<TSource> WhenNotMatchedBySourceAndThenDelete(Expression<Func<TSource, object>> predicate)
        //{
        //    throw new NotImplementedException();
        //}

        #endregion

     
    }
}
