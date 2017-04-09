using Afina.DataAccess.AdoNet.Instrumentations;

namespace Afina.DataAccess.AdoNet.Repositories
{
    /// <summary>
    /// Base-class for repositories
    /// </summary>
    public abstract class RepositoryBase
    {
        protected readonly IQueryExecutor _queryExecutor;
        protected readonly IEntityMapHolder _entityMapHolder;

        public RepositoryBase(IQueryExecutor queryExecutor, IEntityMapHolder entityMapHolder)
        {
            _queryExecutor = queryExecutor;
            _entityMapHolder = entityMapHolder;
        }
    }
}
