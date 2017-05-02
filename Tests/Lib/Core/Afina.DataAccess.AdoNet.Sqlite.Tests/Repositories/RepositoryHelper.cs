using Afina.DataAccess.AdoNet.Infrastructures.Databases;
using Afina.DataAccess.AdoNet.Instrumentations;
using Afina.DataAccess.AdoNet.Sqlite.Infrastructures;
using Afina.DataAccess.AdoNet.Sqlite.Infrastructures.Databases;
using Afina.DataAccess.AdoNet.Sqlite.Tests.Instrumentations;
using Afina.DataAccess.Infrastructures.Databases;
using SimpleInjector;
using System.Data.Common;

namespace Afina.DataAccess.AdoNet.Sqlite.Tests.Repositories
{
    public static class RepositoryHelper
    {
        public static void ConfigureContainer(Container container)
        {
            container.Register<IDatabase, SqliteDatabase>(Lifestyle.Transient);
            container.Register<IDbStructureQueriesLocator, DbStructureQueriesLocator>(Lifestyle.Singleton);
            container.Register<DbProviderFactory, SqliteDbProviderFactory>(Lifestyle.Singleton);
            container.Register<IConnectionStringProvider, ConnectionStringProvider>(Lifestyle.Singleton);
            container.Register<IEntityMapHolder, EntityMapHolder>(Lifestyle.Singleton);
            container.Register<IQueryer, SqliteQueryer>(Lifestyle.Transient);
            container.Verify(VerificationOption.VerifyAndDiagnose);
            DbInitializer.InitializeDatabase(container);
        }
    }
}
