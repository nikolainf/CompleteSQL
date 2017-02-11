using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompleteSQL.Mapping
{
    /// <summary>
    /// Mapping Table Attribute
    /// </summary>
    public class SqlTableAttribute : Attribute
    {
        /// <summary>
        /// Name of target table. If name of class is equal to target table name you can don't fill this property.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Name of schema
        /// </summary>
        public string Schema { get; set; }

        /// <summary>
        /// Name of DataBase
        /// </summary>
        public string DB { get; set; }
    }
}
