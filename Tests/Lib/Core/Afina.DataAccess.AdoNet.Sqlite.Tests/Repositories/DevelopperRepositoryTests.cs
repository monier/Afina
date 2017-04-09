using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Afina.DataAccess.AdoNet.Sqlite.Tests.Repositories
{
    [TestClass]
    [TestCategory("Afina.AdoNet.Sqlite.DevelopperRepository")]
    public class DevelopperRepositoryTests : AdoNet.Tests.Repositories.DevelopperRepositoryTests
    {
        public override void ConfigureContainer()
        {
            base.ConfigureContainer();
            RepositoryHelper.ConfigureContainer(_container);
        }
        [TestMethod]
        public override void CreateDeveloppers()
        {
            base.CreateDeveloppers();
        }
    }
}
