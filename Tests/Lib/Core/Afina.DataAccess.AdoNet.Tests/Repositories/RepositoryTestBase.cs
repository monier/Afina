using Afina.DataAccess.AdoNet.Instrumentations;
using Afina.Tests;
using SimpleInjector;
using System;
using System.IO;

namespace Afina.DataAccess.AdoNet.Tests.Repositories
{
    public abstract class RepositoryTestBase : TestBase
    {
        public override void ConfigureContainer()
        {
            _container.Register<IConnectionStringProvider, ConnectionStringProvider>(Lifestyle.Transient);
            _container.Register<IQueryer, Queryer>(Lifestyle.Transient);
            _container.Register<IQuerySelector, QuerySelector>(Lifestyle.Singleton);
            _container.Register<IQueryExecutor, QueryExecutor>(Lifestyle.Transient);
        }
        public override void Initialize()
        {
            base.Initialize();
            var querySelector = _container.GetInstance<IQuerySelector>();
            querySelector.AddQueriesFromDirectory(Path.Combine(AppContext.BaseDirectory, @"Resources\Data\Queries\"));
        }
    }
}
