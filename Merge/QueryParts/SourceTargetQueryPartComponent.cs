using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompleteSQL.Merge
{
    public sealed class SourceTargetQueryPartComponent : MergeQueryPartComponent
    {
        private readonly string m_targetTable;
        internal SourceTargetQueryPartComponent(string targetTable)
        {
            m_targetTable = targetTable;
        }
        internal override string GetQueryPart()
        {
            string queryPart = string.Concat("Merge Into ", m_targetTable, " as tgt",
               "\r\n",
                "Using ", "#", m_targetTable, " as src");
            return queryPart;
        }
    }
}
