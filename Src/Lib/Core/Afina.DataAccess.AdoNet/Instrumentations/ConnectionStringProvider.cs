using System;
using System.Data.Common;

namespace Afina.DataAccess.AdoNet.Instrumentations
{
    public class ConnectionStringProvider : IConnectionStringProvider
    {
        public string ConnectionString { get; set; }
        private readonly Func<DbConnectionStringBuilder> _connectionStringBuilderFactory;
        public ConnectionStringProvider(Func<DbConnectionStringBuilder> connectionStringBuilderFactory)
        {
            _connectionStringBuilderFactory = connectionStringBuilderFactory;
        }
        public DbConnectionStringBuilder GetConnectionStringBuilder()
        {
            var builder = _connectionStringBuilderFactory();
            builder.ConnectionString = ConnectionString;
            return builder;
        }
    }
}
