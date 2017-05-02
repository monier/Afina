using System;
using System.Data.Common;

namespace Afina.DataAccess.AdoNet.Instrumentations
{
    public class ConnectionStringProvider : IConnectionStringProvider
    {
        private string _connectionString = null;
        public void SetConnectionString(string connectionString)
        {
            _connectionString = connectionString;
        }
        public string GetConnectionString()
        {
            return _connectionString;
        }
    }
}
