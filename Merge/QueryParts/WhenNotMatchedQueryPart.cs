using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompleteSQL.Merge
{
    public sealed class WhenNotMatchedQueryPart : QueryPartDecorator
    {
        private bool m_byTarget;
        public WhenNotMatchedQueryPart(bool byTarget)
        {
            m_byTarget = byTarget;
        }
        internal QueryPartComponent PreviousPartQuery { get; set; }

        internal override string GetQueryPart()
        {
            return string.Concat(base.GetQueryPart(), Environment.NewLine, "When Not Matched",!m_byTarget? " By Source":string.Empty);
        }
    }
}
