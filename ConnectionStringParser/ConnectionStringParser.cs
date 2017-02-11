using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompleteSQL.ConnectionStringParser
{
    /// <summary>
    /// Parser of connection strings
    /// </summary>
    internal class ConnectionStringParser : IConnectionStringParser
    {
        /// <summary>
        /// Parse connectionString
        /// </summary>
        /// <param name="nameOrConnectionString">Name of connection string in .config or connection string</param>
        /// <returns>connection string</returns>
        string IConnectionStringParser.Parse(string nameOrConnectionString)
        {
            // Firstly, try get connection string from config file
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings[nameOrConnectionString];

            if (connectionStringSettings != null)
                return connectionStringSettings.ConnectionString;

            // Validate to connection string. If it isn't valid DbConnectionStringBuilder throw ArgumentException
            DbConnectionStringBuilder connectionStribgBuilder = new DbConnectionStringBuilder();
            connectionStribgBuilder.ConnectionString = nameOrConnectionString;

            return nameOrConnectionString;
        }
    }
}
