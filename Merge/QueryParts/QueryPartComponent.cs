using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompleteSQL.Merge
{
    abstract public class QueryPartComponent
    {
        internal DataTableSchema tableSchema;
        internal abstract string GetQueryPart();
    }
}
