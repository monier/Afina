using System;
using Afina.DataAccess.AdoNet.Instrumentations;
using SimpleInjector;
using System.Data.Common;

namespace Afina.DataAccess.AdoNet.Tests.Instrumentations
{
    public abstract class QueryerTests : Afina.Tests.TestBase
    {
        public override void ConfigureContainer()
        {
            _container.Register<IConnectionStringProvider, ConnectionStringProvider>(Lifestyle.Transient);
            _container.Register(() => new Func<DbConnectionStringBuilder>(() => _container.GetInstance<DbConnectionStringBuilder>()));
            _container.Register<IQueryer, Queryer>(Lifestyle.Transient);
        }
        public virtual void OpenConnection()
        {
            var queryer = _container.GetInstance<IQueryer>();
            using (var connection = queryer.OpenNewConnection())
            {
                connection.Close();
            }
        }
    }
}
