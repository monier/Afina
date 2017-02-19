using Microsoft.VisualStudio.TestTools.UnitTesting;
using Afina.DataAccess.Repositories;
using Afina.DataAccess.AdoNet.Repositories;

namespace Afina.DataAccess.AdoNet.Tests.Repositories
{
    public abstract class UserRepositoryTests : RepositoryTestBase
    {
        public override void ConfigureContainer()
        {
            base.ConfigureContainer();
            _container.Register<IUserRepository, UserRepository>();
        }
        public virtual void GetUser()
        {
            var userRepository = _container.GetInstance<IUserRepository>();
            var john = userRepository.GetUser("john");
            Assert.IsNotNull(john, "User <john> is not null");
            Assert.IsTrue(string.Compare("john", john.Name, true) == 0, "User <john> found");
            var billy = userRepository.GetUser("billy");
            Assert.IsNull(billy, "User <billy> is not in db");
        }
    }
}
