using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompleteSQL.Merge
{
    public abstract class MergeQueryPartDecorator : MergeQueryPartComponent
    {
        private MergeQueryPartComponent m_queryPartComponent;
        internal MergeQueryPartComponent QueryPartComponent
        {
            get
            {
                return m_queryPartComponent;
            }
            set
            {
                this.tableSchema = value.tableSchema;
                m_queryPartComponent = value;
                 
            }
        }
       
        internal override string GetQueryPart()
        {
            return QueryPartComponent != null 
                ? string.Concat(QueryPartComponent.GetQueryPart(), Environment.NewLine)
                : string.Empty;
        }

    }
}
