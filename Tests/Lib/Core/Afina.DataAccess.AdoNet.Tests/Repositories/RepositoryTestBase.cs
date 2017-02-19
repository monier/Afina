using Afina.DataAccess.AdoNet.Instrumentations;
using Afina.Tests;
using SimpleInjector;
using System;
using System.Data.Common;
using System.IO;

namespace Afina.DataAccess.AdoNet.Tests.Repositories
{
    public abstract class RepositoryTestBase : TestBase
    {
        public override void ConfigureContainer()
        {
            _container.Register<IConnectionStringProvider, ConnectionStringProvider>(Lifestyle.Transient);
            _container.Register(() => new Func<DbConnectionStringBuilder>(() => _container.GetInstance<DbConnectionStringBuilder>()));
            _container.Register<IQueryer, Queryer>(Lifestyle.Transient);
            _container.Register<IQuerySelector, QuerySelector>(Lifestyle.Singleton);
            _container.Register<IQueryExecutor, QueryExecutor>(Lifestyle.Transient);
        }
        public override void Initialize()
        {
            base.Initialize();
            var querySelector = _container.GetInstance<IQuerySelector>();
            querySelector.AddQueries(Path.Combine(AppContext.BaseDirectory, @"Resources\Data\Queries\Master\Queries.xml"));
            querySelector.AddQueries(Path.Combine(AppContext.BaseDirectory, @"Resources\Data\Queries\Sqlite\Queries-Sqlite.xml"));
        }
    }
}
