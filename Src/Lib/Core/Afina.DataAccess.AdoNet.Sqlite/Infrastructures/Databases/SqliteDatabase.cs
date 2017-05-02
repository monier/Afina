using System;
using Afina.DataAccess.AdoNet.Infrastructures.Databases;
using Afina.DataAccess.Infrastructures.Databases;
using Afina.DataAccess.AdoNet.Instrumentations;
using System.Data.Common;
using System.IO;

namespace Afina.DataAccess.AdoNet.Sqlite.Infrastructures.Databases
{
    public class SqliteDatabase : AdoDatabase
    {
        public const string MemoryDataSource = ":memory:";
        private string _filename = null;
        public SqliteDatabase(IQueryer queryer, IConnectionStringProvider connectionStringProvider, DbProviderFactory dbProviderFactory, IDbStructureQueriesLocator dbStructureQueriesLocator) : base(queryer, connectionStringProvider, dbProviderFactory, dbStructureQueriesLocator)
        {
        }
        public override DatabaseVersion GetVersion()
        {
            return new DatabaseVersion(major: 0, minor: 1);
        }
        public override void Initialize()
        {
            var connectionStringBuilder = _dbProviderFactory.CreateConnectionStringBuilder();
            connectionStringBuilder.ConnectionString = _connectionStringBuilder.GetConnectionString();
            if (!connectionStringBuilder.ContainsKey("Data Source"))
                throw new Exception("The [Data Source] is not found in current connection string!");
            var dataSource = connectionStringBuilder["Data Source"].ToString();
            if (string.Compare(dataSource, MemoryDataSource, true) != 0)
            {
                var filename = Path.GetFileName(dataSource);
                var directory = Path.GetDirectoryName(dataSource);
                _filename = Path.Combine(AppContext.BaseDirectory, Path.Combine(directory, filename));
                var parentDirectory = Path.GetDirectoryName(_filename);
                Directory.CreateDirectory(parentDirectory);
            }
        }
        public override void CreateOrUpdate()
        {
            var files = Directory.GetFiles(_dbStructureQueriesLocator.GetDirectoryLocation(), $"*{_dbStructureQueriesLocator.GetExtension()}", SearchOption.AllDirectories);
            using (var connection = _queryer.OpenNewConnection())
            {
                foreach (var file in files)
                {
                    using (FileStream fileStream = new FileStream(file, FileMode.Open))
                    {
                        using (StreamReader sr = new StreamReader(fileStream))
                        {
                            var query = sr.ReadToEnd();
                            _queryer.ExecuteNonQuery(connection, command =>
                            {
                                command.CommandType = System.Data.CommandType.Text;
                                command.CommandText = query;
                            });
                        }
                    }
                }
            }
        }
        public override void Upgrade()
        {
        }
    }
}
