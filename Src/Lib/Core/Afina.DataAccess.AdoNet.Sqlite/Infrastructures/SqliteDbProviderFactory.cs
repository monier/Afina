using System.Data.Common;
using Microsoft.Data.Sqlite;

namespace Afina.DataAccess.AdoNet.Sqlite.Infrastructures
{
    /// <summary>
    /// Implements the <see cref="DbProviderFactory"/> for Sqlite
    /// </summary>
    public class SqliteDbProviderFactory : DbProviderFactory
    {
        public override DbCommand CreateCommand()
        {
            return new SqliteCommand();
        }
        public override DbConnection CreateConnection()
        {
            return new SqliteConnection();
        }
        public override DbConnectionStringBuilder CreateConnectionStringBuilder()
        {
            return new SqliteConnectionStringBuilder();
        }
        public override DbParameter CreateParameter()
        {
            return new SqliteParameter();
        }
    }
}
