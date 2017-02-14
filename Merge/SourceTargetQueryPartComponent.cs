using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompleteSQL.Merge
{
    public sealed class SourceTargetQueryPartComponent : MergeQueryPartComponent
    {
        internal SourceTargetQueryPartComponent() { }
        internal override string GetQueryPart()
        {
            return "Merge Into Using";
        }
    }
}
