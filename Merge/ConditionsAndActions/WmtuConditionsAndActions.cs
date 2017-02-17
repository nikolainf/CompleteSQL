using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompleteSQL.Merge
{
    /// <summary>
    /// Содержит все сравнения действия кроме WhenMatchedThenUpdate и WhenMatchedThenDelete
    /// </summary>
    public class WmtConditionsAndActions<TSource> : ConditionsAndActionsBase 
    {
        internal WmtConditionsAndActions(MergeQueryPartComponent queryComponent)
            : base(queryComponent)
        { 
        }

        public AllConditionsAndActions<TSource> WhenNotMatchedThenInsert()
        {
            throw new NotImplementedException();
        }

        public AllConditionsAndActions<TSource> WhenNotMatchedBySourceThenUpdate()
        {
            throw new NotImplementedException();
        }


        public AllConditionsAndActions<TSource> WhenNotMatchedBySourceThenDelete()
        {
            throw new NotImplementedException();
        }
    }
}
