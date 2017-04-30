using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Afina.DataAccess.AdoNet.Sqlite.Tests.Repositories
{
    [TestClass]
    [TestCategory("Afina.AdoNet.Sqlite.SessionRepository")]
    public class SessionRepositoryTests : AdoNet.Tests.Repositories.SessionRepositoryTests
    {
        public override void ConfigureContainer()
        {
            base.ConfigureContainer();
            RepositoryHelper.ConfigureContainer(_container);
        }
        [TestMethod]
        public override void CreateSessions()
        {
            base.CreateSessions();
        }
    }
}
