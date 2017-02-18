using System;
using Afina.DataAccess.Infrastructures.Databases;
using Afina.DataAccess.AdoNet.Instrumentations;
using System.Data.Common;

namespace Afina.DataAccess.AdoNet.Sqlite.Infrastructures.Databases.Versions
{
    public class SqliteDatabaseV01 : SqliteDatabase
    {
        public SqliteDatabaseV01(IQueryer queryer, IConnectionStringProvider connectionStringProvider) : base(queryer, connectionStringProvider) { }

        public override DatabaseVersion GetVersion()
        {
            return new DatabaseVersion(major: 0, minor: 1);
        }
        public override void Create()
        {
            throw new NotImplementedException();
        }
        public override void Update()
        {
            throw new NotImplementedException();
        }
    }
}
