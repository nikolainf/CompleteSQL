using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompleteSQL.Merge
{
    abstract public class ConditionAndActionBase
    {
        protected MergeQueryPartComponent queryComponent;

        internal ConditionAndActionBase(MergeQueryPartComponent queryComponent)
        {
            this.queryComponent = queryComponent;
        }

       
    }
}
