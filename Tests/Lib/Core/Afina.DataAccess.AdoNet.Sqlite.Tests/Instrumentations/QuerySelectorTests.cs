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
    }
}
