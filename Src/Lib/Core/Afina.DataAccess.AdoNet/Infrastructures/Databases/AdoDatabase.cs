using System;
using Afina.DataAccess.Infrastructures.Databases;
using System.Data.Common;
using Afina.DataAccess.AdoNet.Instrumentations;

namespace Afina.DataAccess.AdoNet.Infrastructures.Databases
{
    public abstract class AdoDatabase : IDatabase
    {
        protected readonly IQueryer _queryer;
        protected readonly IConnectionStringProvider _connectionStringProvider;
        public AdoDatabase(IQueryer queryer, IConnectionStringProvider connectionStringProvider)
        {
            _queryer = queryer;
            _connectionStringProvider = connectionStringProvider;
        }
        public abstract DatabaseVersion GetVersion();
        public abstract bool Exists();
        public abstract void Create();
        public abstract void Update();
    }
}
