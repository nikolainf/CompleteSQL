using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompleteSQL.Merge
{
    abstract public class ActionStepBase : QueryStepBase
    {
        internal ActionStepBase(QueryPartComponent queryComponent): base(queryComponent)
        {
           
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
