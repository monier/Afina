using System;
using Afina.DataAccess.AdoNet.Infrastructures.Databases;
using Afina.DataAccess.Infrastructures.Databases;
using Afina.DataAccess.AdoNet.Instrumentations;
using System.Data.Common;
using System.IO;

namespace Afina.DataAccess.AdoNet.Sqlite.Infrastructures.Databases
{
    public abstract class SqliteDatabase : AdoDatabase
    {
        public SqliteDatabase(IQueryer queryer, IConnectionStringProvider connectionStringProvider) : base(queryer, connectionStringProvider) { }
        public override abstract DatabaseVersion GetVersion();
        public override bool Exists()
        {
            var connectionStringBuilder = _connectionStringProvider.GetConnectionStringBuilder();
            if (connectionStringBuilder.ContainsKey("Data Source"))
                throw new Exception("The [Data Source] is not found in current connection string!");
            var filename = connectionStringBuilder["Data Source"].ToString();
            var exists = File.Exists(filename);
            return exists;
        }
        public override abstract void Create();
        public override abstract void Update();
    }
}
