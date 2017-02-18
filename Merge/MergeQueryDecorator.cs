using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompleteSQL.Merge
{
    public abstract class MergeQueryPartDecorator : MergeQueryPartComponent
    {
        internal MergeQueryPartComponent QueryPartComponent { get; set; }

       
        internal override string GetQueryPart()
        {
            return QueryPartComponent != null ? QueryPartComponent.GetQueryPart() : string.Empty;
        }

    }
}
