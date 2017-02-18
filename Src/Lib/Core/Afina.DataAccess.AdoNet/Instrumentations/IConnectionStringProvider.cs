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
        /// Connection string
        /// </summary>
        string ConnectionString { get; set; }
        /// <summary>
        /// Gets the <see cref="DbConnectionStringBuilder"/> instance that can parse the connection string
        /// </summary>
        /// <returns><see cref="DbConnectionStringBuilder"/> instance that can parse the connection string</returns>
        DbConnectionStringBuilder GetConnectionStringBuilder();
    }
}
