using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompleteSQL.Merge
{
    public sealed class WhenNotMatchedThenInsertQueryPart : MergeQueryPartDecorator
    {
        internal MergeQueryPartComponent PreviousPartQuery { get; set; }


        public override string GetQueryPart()
        {
           return "WHEN NOT MATCHED THEN INSERT";

        }
    }
}
