using Afina.DataAccess.AdoNet.Instrumentations;
using Afina.DataAccess.AdoNet.Sqlite.Infrastructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleInjector;
using System.Data.Common;

namespace Afina.DataAccess.AdoNet.Sqlite.Tests.Repositories
{
    [TestClass]
    [TestCategory("Afina.AdoNet.Sqlite.UserRepository")]
    public class UserRepositoryTests : AdoNet.Tests.Repositories.UserRepositoryTests
    {
        public override void ConfigureContainer()
        {
            base.ConfigureContainer();
            string connectionString = @"Data Source=.\Resources\Data\Db\afina.db;";
            _container.Register<DbProviderFactory, SqliteDbProviderFactory>(Lifestyle.Singleton);
            _container.RegisterInitializer<IConnectionStringProvider>(service => service.ConnectionString = connectionString);
            _container.Register<IEntityMapHolder, EntityMapHolder>(Lifestyle.Singleton);
            _container.Verify(VerificationOption.VerifyAndDiagnose);
        }
        [TestMethod]
        public override void GetUser()
        {
            base.GetUser();
        }
    }
}
