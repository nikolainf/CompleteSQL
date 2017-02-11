using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompleteSQL.Mapping
{
    public class MappingColumn
    {
        public string Name { get; private set; }

        public bool AllowNulls { get; private set; }

        public Type Type { get; private set; }

        public MappingColumn(string name, bool allowNulls, Type type)
        {
            Name = name;
            AllowNulls = allowNulls;
            Type = type;
        }
    }
}
