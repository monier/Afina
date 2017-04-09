using Afina.Models;
using System.Collections.Generic;

namespace Afina.DataAccess.Repositories
{
    /// <summary>
    /// Repository for <see cref="Models.Developper"/>
    /// </summary>
    public interface IDevelopperRepository
    {
        /// <summary>
        /// Stores new developper
        /// </summary>
        /// <param name="developper">developper data</param>
        void StoreDevelopper(Developper developper);
        /// <summary>
        /// Gets all developpers
        /// </summary>
        /// <returns>all developpers</returns>
        IReadOnlyList<Developper> GetDeveloppers();
        /// <summary>
        /// Gets developper by his external id
        /// </summary>
        /// <param name="externalId">developper's external id</param>
        /// <returns>developper data</returns>
        Developper GetDevelopperByExternalId(string externalId);
        /// <summary>
        /// Gets developper by his internal id
        /// </summary>
        /// <param name="id">developper's internal id</param>
        /// <returns>developper data</returns>
        Developper GetDevelopperById(long id);
    }
}
