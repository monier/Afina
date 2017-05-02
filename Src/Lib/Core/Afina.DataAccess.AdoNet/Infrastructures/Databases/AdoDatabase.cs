using System;
using Afina.DataAccess.Infrastructures.Databases;
using System.Data.Common;
using Afina.DataAccess.AdoNet.Instrumentations;

namespace Afina.DataAccess.AdoNet.Infrastructures.Databases
{
    public abstract class AdoDatabase : IDatabase
    {
        protected readonly IQueryer _queryer;
        protected readonly IConnectionStringProvider _connectionStringBuilder;
        protected readonly DbProviderFactory _dbProviderFactory;
        protected readonly IDbStructureQueriesLocator _dbStructureQueriesLocator;
        public AdoDatabase(IQueryer queryer, IConnectionStringProvider connectionStringBuilder, DbProviderFactory dbProviderFactory, IDbStructureQueriesLocator dbStructureQueriesLocator)
        {
            _queryer = queryer;
            _connectionStringBuilder = connectionStringBuilder;
            _dbProviderFactory = dbProviderFactory;
            _dbStructureQueriesLocator = dbStructureQueriesLocator;
        }
        public abstract DatabaseVersion GetVersion();
        public abstract void Initialize();
        public abstract void CreateOrUpdate();
        public abstract void Upgrade();
    }
}
