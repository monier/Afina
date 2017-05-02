using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace Afina.DataAccess.AdoNet.Instrumentations
{
    /// <summary>
    /// Provides method to retrieve the connection string
    /// </summary>
    public interface IConnectionStringProvider
    {
        /// <summary>
        /// Sets connection string
        /// </summary>
        /// <param name="connectionString">connection string</param>
        void SetConnectionString(string connectionString);
        /// <summary>
        /// Gets connection string
        /// </summary>
        /// <returns>connection string</returns>
        string GetConnectionString();
    }
}
