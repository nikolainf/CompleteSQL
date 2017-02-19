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
            return string.Format("Merge Into {0} Using", m_targetTable);
        }
    }
}
