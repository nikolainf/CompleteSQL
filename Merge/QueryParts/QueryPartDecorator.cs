using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompleteSQL.Merge
{
    public abstract class QueryPartDecorator : QueryPartComponent
    {
        private QueryPartComponent m_queryPartComponent;
        internal QueryPartComponent QueryPartComponent
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
                ? QueryPartComponent.GetQueryPart()
                : string.Empty;
        }

    }
}
