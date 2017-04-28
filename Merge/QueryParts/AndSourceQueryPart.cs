using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CompleteSQL.Merge
{
    public sealed class AndSourceQueryPart : QueryPartDecorator
    {
        LambdaExpression m_predicate;
        internal AndSourceQueryPart(Expression expr)
        {
            m_predicate = (LambdaExpression)expr;
        }

        internal override string GetQueryPart()
        {

            string predicate =  m_predicate.BuildPredicate("src");


            return string.Concat(base.GetQueryPart(), " And ", predicate);
        }


     
       

       
    }
}
