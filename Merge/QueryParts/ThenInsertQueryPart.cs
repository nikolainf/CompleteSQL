using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompleteSQL.Merge
{
    public sealed class ThenInsertQueryPart : MergeQueryPartDecorator
    {
        internal ThenInsertQueryPart(Type type)
        {

        }

        internal ThenInsertQueryPart() { }
        internal override string GetQueryPart()
        {
            return string.Concat(base.GetQueryPart(), "Then Insert");
        }
    }
}
