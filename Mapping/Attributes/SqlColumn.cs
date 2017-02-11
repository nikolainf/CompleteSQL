using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompleteSQL.Mapping
{
    public class SqlColumn : System.Attribute
    {
        public string Name { get; set; }

    }
}
