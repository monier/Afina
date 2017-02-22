using Afina.DataAccess.AdoNet.Instrumentations;
using Afina.DataAccess.Repositories;
using Afina.Models;

namespace Afina.DataAccess.AdoNet.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IQueryExecutor _queryExecutor;
        private readonly IEntityMapHolder _entityMapHolder;

        public UserRepository(IQueryExecutor queryExecutor, IEntityMapHolder entityMapHolder)
        {
            _queryExecutor = queryExecutor;
            _entityMapHolder = entityMapHolder;

            _entityMapHolder.Register<User>((user, result) =>
            {
                user.Id = result.ReadValue<long>("Id");
                user.Name = result.ReadValue<string>("Name");
                user.Password = result.ReadValue<string>("Password");
            });
        }

        public User GetUser(string username)
        {
            User user = null;
            using(QueryResult result = _queryExecutor.Execute("GetUserByName", new QueryParameter("name", username)))
            {
                if (result.ReadNext())
                {
                    user = new User();
                    _entityMapHolder.MapEntity(user, result);
                }
            }
            return user;
        }
    }
}
