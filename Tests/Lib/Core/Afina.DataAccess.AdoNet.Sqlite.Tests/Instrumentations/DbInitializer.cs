using Afina.DataAccess.AdoNet.Infrastructures.Databases;
using Afina.DataAccess.AdoNet.Instrumentations;
using Afina.DataAccess.Infrastructures.Databases;
using SimpleInjector;
using System;
using System.IO;
using System.Threading;

namespace Afina.DataAccess.AdoNet.Sqlite.Tests.Instrumentations
{
    public static class DbInitializer
    {
        private static Mutex _mutex = new Mutex(false, "sqlite-dbInitializer");
        public static void InitializeDatabase(Container container)
        {
            string connectionString = @"Data Source=./Resources/Data/Db/afina.db;";
            var connectionStringProvider = container.GetInstance<IConnectionStringProvider>();
            connectionStringProvider.SetConnectionString(connectionString);
            var structureScriptsDirectory = Path.Combine(AppContext.BaseDirectory, @"Resources/Data/Structures/Tables/");
            var structureQueriesLocator = container.GetInstance<IDbStructureQueriesLocator>();
            structureQueriesLocator.SetDirectoryLocation(structureScriptsDirectory);
            structureQueriesLocator.SetExtension(".sql");
            _mutex.WaitOne(1000);
            var database = container.GetInstance<IDatabase>();
            database.Initialize();
            database.CreateOrUpdate();
            _mutex.ReleaseMutex();
        }
    }
}
