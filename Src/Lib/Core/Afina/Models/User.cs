using System.Security;

namespace Afina.Models
{
    /// <summary>
    /// Represents an user in the system
    /// </summary>
    public class User
    {
        /// <summary>
        /// User's unique id
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// User's name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Password derived from real user's password hash
        /// </summary>
        /// <remarks>User's real password is never sent to the server</remarks>
        public string Password { get; set; }
    }
}
