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
        public void SelectQueryFromDirectory()
        {
            string directory = Path.Combine(AppContext.BaseDirectory, @"Resources/Data/Queries/");
            base.SelectQueryFromDirectory(directory);
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
