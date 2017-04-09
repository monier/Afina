using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Afina.DataAccess.AdoNet.Sqlite.Tests.Repositories
{
    [TestClass]
    [TestCategory("Afina.AdoNet.Sqlite.ApplicationRepository")]
    public class ApplicationRepositoryTests : AdoNet.Tests.Repositories.ApplicationRepositoryTests
    {
        public override void ConfigureContainer()
        {
            base.ConfigureContainer();
            RepositoryHelper.ConfigureContainer(_container);
        }
        [TestMethod]
        public override void CreateApplications()
        {
            base.CreateApplications();
        }
    }
}
