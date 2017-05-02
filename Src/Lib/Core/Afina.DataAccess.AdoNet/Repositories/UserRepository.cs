using Afina.DataAccess.AdoNet.Instrumentations;
using Afina.DataAccess.Repositories;
using Afina.Models;
using System.Collections.Generic;

namespace Afina.DataAccess.AdoNet.Repositories
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        public UserRepository(IQueryExecutor queryExecutor, IEntityMapHolder entityMapHolder) : base(queryExecutor, entityMapHolder)
        {
            _entityMapHolder.Register<User>((user, result) =>
            {
                user.Id = result.ReadValue<long>("Id");
                user.Name = result.ReadValue<string>("Name");
                user.Password = result.ReadValue<string>("Password");
            });
        }

        public void StoreUser(User user)
        {
            _queryExecutor.ExecuteNonQuery("InsertUser"
                                    , new QueryParameter("name", user.Name)
                                    , new QueryParameter("password", user.Password));
        }
        public IReadOnlyList<User> GetUsers()
        {
            List<User> users = new List<User>();
            using (QueryResult result = _queryExecutor.Execute("GetAllUsers"))
            {
                while (result.ReadNext())
                {
                    var user = new User();
                    _entityMapHolder.MapEntity<User>(user, result);
                    users.Add(user);
                }
            }
            return users;
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
        public User GetUser(long id)
        {
            User user = null;
            using (QueryResult result = _queryExecutor.Execute("GetUserById", new QueryParameter("id", id)))
            {
                if (result.ReadNext())
                {
                    user = new User();
                    _entityMapHolder.MapEntity(user, result);
                }
            }
            return user;
        }
        public void DeleteUserById(long id)
        {
            _queryExecutor.ExecuteNonQuery("DeleteUserById", new QueryParameter("id", id));
        }
    }
}
