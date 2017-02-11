using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompleteSQL.ConnectionStringParser
{
    interface IConnectionStringParser
    {
        string Parse(string nameOrConnectionString);
    }
}
