using Afina.DataAccess.AdoNet.Instrumentations;
using SimpleInjector;

namespace Afina.DataAccess.AdoNet.Tests.Instrumentations
{
    public abstract class QueryerTests
    {
        protected Container _container;

        public abstract void Setup();
        public abstract void Cleanup();
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
