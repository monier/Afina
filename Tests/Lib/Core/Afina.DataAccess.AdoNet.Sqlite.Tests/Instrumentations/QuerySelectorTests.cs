using Afina.DataAccess.AdoNet.Instrumentations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Afina.DataAccess.AdoNet.Sqlite.Tests.Instrumentations
{
    [TestClass]
    [TestCategory("Afina.AdoNet.Sqlite.QuerySelector")]
    public class QuerySelectorTests: AdoNet.Tests.Instrumentations.QuerySelectorTests
    {
        [TestMethod]
        public void SelectQueryFromFiles()
        {
            string master = Path.Combine(AppContext.BaseDirectory, @"Resources\Data\Queries\Master\Queries.xml");
            base.SelectQueryFromFiles(master);
        }
        [TestMethod]
        public void SelectUnexistingQuery()
        {
            Assert.ThrowsException<QueryNotFoundException>(() =>
            {
                var querySelector = _container.GetInstance<IQuerySelector>();
                querySelector.GetQuery("NonExistingQuery");
            }, "Exception raised when query string is not found");
        }
    }
}
