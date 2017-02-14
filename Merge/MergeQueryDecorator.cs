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
        public override string GetQueryPart()
        {
           return string.Concat(
               QueryPartComponent != null?QueryPartComponent.GetQueryPart(): string.Empty,
            GetQueryPart());

        }
    }
}
