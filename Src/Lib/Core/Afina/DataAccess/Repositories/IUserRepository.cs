using Afina.Models;

namespace Afina.DataAccess.Repositories
{
    /// <summary>
    /// Repository for <see cref="Models.User"/>
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Retrieves user information
        /// </summary>
        /// <param name="username">user's name</param>
        /// <returns>user information</returns>
        User GetUser(string username);
    }
}
