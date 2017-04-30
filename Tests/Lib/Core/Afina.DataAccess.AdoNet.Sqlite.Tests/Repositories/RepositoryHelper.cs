using Afina.DataAccess.AdoNet.Instrumentations;
using Afina.DataAccess.AdoNet.Sqlite.Infrastructures;
using SimpleInjector;
using System.Data.Common;

namespace Afina.DataAccess.AdoNet.Sqlite.Tests.Repositories
{
    public static class RepositoryHelper
    {
        public static void ConfigureContainer(Container container)
        {
            string connectionString = @"Data Source=.\Resources\Data\Db\afina.db;";
            container.Register<DbProviderFactory, SqliteDbProviderFactory>(Lifestyle.Singleton);
            container.RegisterInitializer<IConnectionStringProvider>(service => service.ConnectionString = connectionString);
            container.Register<IEntityMapHolder, EntityMapHolder>(Lifestyle.Singleton);
            container.Register<IQueryer, SqliteQueryer>(Lifestyle.Transient);
            container.Verify(VerificationOption.VerifyAndDiagnose);
        }
    }
}
