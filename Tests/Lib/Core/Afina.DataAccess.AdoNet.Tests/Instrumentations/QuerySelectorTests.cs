using Afina.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Afina.DataAccess.AdoNet.Instrumentations;
using SimpleInjector;

namespace Afina.DataAccess.AdoNet.Tests.Instrumentations
{
    [TestClass]
    public abstract class QuerySelectorTests : TestBase
    {
        public override void ConfigureContainer()
        {
            _container.Register<IQuerySelector, QuerySelector>(Lifestyle.Singleton);
        }
        public virtual void SelectQueryFromDirectory(params string[] directories)
        {
            var querySelector = _container.GetInstance<IQuerySelector>();
            foreach (var directory in directories)
            {
                querySelector.AddQueriesFromDirectory(directory);
            }
            string query = querySelector.GetQuery("GetUserByName");
            Log(query);
            Assert.IsTrue(!string.IsNullOrWhiteSpace(query));
        }
    }
}
