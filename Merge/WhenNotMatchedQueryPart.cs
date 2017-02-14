using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompleteSQL.Merge
{
    public sealed class WhenNotMatchedQueryPart : MergeQueryPartDecorator
    {
        internal MergeQueryPartComponent PreviousPartQuery { get; set; }

        public override string GetQueryPart()
        {
            return string.Concat(base.GetQueryPart(), "When Not Matched");
        }
    }
}
