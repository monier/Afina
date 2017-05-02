using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Afina.DataAccess.AdoNet.Sqlite.Tests.Repositories
{
    [TestClass]
    [TestCategory("Afina.AdoNet.Sqlite.UserRepository")]
    public class UserRepositoryTests : AdoNet.Tests.Repositories.UserRepositoryTests
    {
        public override void ConfigureContainer()
        {
            base.ConfigureContainer();
            RepositoryHelper.ConfigureContainer(_container);
        }
        [TestMethod]
        public override void CreateUsers()
        {
            base.CreateUsers();
        }
    }
}
