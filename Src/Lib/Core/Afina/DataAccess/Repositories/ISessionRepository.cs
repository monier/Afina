using Afina.Models;
using System.Collections.Generic;

namespace Afina.DataAccess.Repositories
{
    /// <summary>
    /// Repository for <see cref="Session"/>
    /// </summary>
    public interface ISessionRepository
    {
        /// <summary>
        /// Stores new session
        /// </summary>
        /// <param name="session">session to store</param>
        void StoreSession(Session session);
        /// <summary>
        /// Returns all sessions
        /// </summary>
        /// <returns>all sessions</returns>
        IReadOnlyList<Session> GetSessions();
        /// <summary>
        /// Gets session by its unique id
        /// </summary>
        /// <param name="id">session unique id</param>
        /// <returns>session data</returns>
        Session GetSessionById(long id);
        /// <summary>
        /// Gets session by its external id
        /// </summary>
        /// <param name="externalId">session external id</param>
        /// <returns>session data</returns>
        Session GetSessionByExternalId(string externalId);
        /// <summary>
        /// Deletes session by its id
        /// </summary>
        /// <param name="id">session id</param>
        void DeleteSessionById(long id);
    }
}
