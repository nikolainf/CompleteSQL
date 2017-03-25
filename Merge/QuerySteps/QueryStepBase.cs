using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompleteSQL.Merge
{
    abstract public class QueryStepBase
    {
        protected QueryPartComponent queryComponent;

        internal QueryStepBase(QueryPartComponent queryComponent)
        {
            this.queryComponent = queryComponent;
        }

       
    }
}
