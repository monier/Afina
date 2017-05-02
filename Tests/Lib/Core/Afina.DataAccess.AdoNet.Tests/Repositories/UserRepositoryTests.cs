using Microsoft.VisualStudio.TestTools.UnitTesting;
using Afina.DataAccess.Repositories;
using Afina.DataAccess.AdoNet.Repositories;
using Afina.Models;

namespace Afina.DataAccess.AdoNet.Tests.Repositories
{
    public abstract class UserRepositoryTests : RepositoryTestBase
    {
        public override void ConfigureContainer()
        {
            base.ConfigureContainer();
            _container.Register<IUserRepository, UserRepository>();
        }
        public virtual void CreateUsers()
        {
            var userRepository = _container.GetInstance<IUserRepository>();
            var user = CreateNewUser("1");
            var name = user.Name;
            userRepository.StoreUser(user);
            user = userRepository.GetUser(name);
            Assert.IsTrue(user.Id > 0, "The user is successfully retrieved by its name");
            long id = user.Id;
            Log($"<{user.Name}> id is: {id}");
            user = userRepository.GetUser(id);
            Assert.IsTrue(user.Id > 0, "The user is successfully retrieved by its id");
            for (int i = 2; i <= 20; i++)
            {
                user = CreateNewUser(i.ToString());
                userRepository.StoreUser(user);
            }
            var users = userRepository.GetUsers();
            Assert.IsTrue(users.Count > 1, "All users are successfully retrieved");
            foreach (var usr in users)
                userRepository.DeleteUserById(usr.Id);
            users = userRepository.GetUsers();
            Assert.IsTrue(users.Count == 0, "All users are deleted successfully");
        }
        private User CreateNewUser(string suffix)
        {
            User user = new User();
            user.Name = $"User-{suffix}";
            user.Password = $"Password-{suffix}";
            return user;
        }
    }
}
