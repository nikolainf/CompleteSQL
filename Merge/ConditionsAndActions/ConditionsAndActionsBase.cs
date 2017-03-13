using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompleteSQL.Merge
{
    abstract public class ConditionsAndActionsBase
    {
        protected MergeQueryPartComponent queryComponent;

        internal ConditionsAndActionsBase(MergeQueryPartComponent queryComponent)
        {
            this.queryComponent = queryComponent;
        }

        public string GetMergeQuery()
        {
            return string.Concat(queryComponent.GetQueryPart(), ";");
        }

        public void Merge()
        {

        }
    }
}
