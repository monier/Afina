using Afina.Models;
using System.Collections.Generic;

namespace Afina.DataAccess.Repositories
{
    /// <summary>
    /// Repository for <see cref="Models.User"/>
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Inserts new user
        /// </summary>
        /// <param name="user">new user</param>
        void StoreUser(User user);
        /// <summary>
        /// Retrieves all users information
        /// </summary>
        /// <returns>users information</returns>
        IReadOnlyList<User> GetUsers();
        /// <summary>
        /// Retrieves user information
        /// </summary>
        /// <param name="username">user's name</param>
        /// <returns>user information</returns>
        User GetUser(string username);
        /// <summary>
        /// Retrieves user information
        /// </summary>
        /// <param name="id">user's id</param>
        /// <returns>user information</returns>
        User GetUser(long id);
        /// <summary>
        /// Deletes user by his id
        /// </summary>
        /// <param name="id">user id</param>
        void DeleteUserById(long id);
    }
}
