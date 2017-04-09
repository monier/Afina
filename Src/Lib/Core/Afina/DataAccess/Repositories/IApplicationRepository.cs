using Afina.Models;
using System.Collections.Generic;

namespace Afina.DataAccess.Repositories
{
    /// <summary>
    /// Repository for <see cref="Models.Application"/>
    /// </summary>
    public interface IApplicationRepository
    {
        /// <summary>
        /// Stores new application
        /// </summary>
        /// <param name="application">application data</param>
        void StoreApplication(Application application);
        /// <summary>
        /// Returns all applications
        /// </summary>
        /// <returns>all applications</returns>
        IReadOnlyList<Application> GetApplications();
        /// <summary>
        /// Gets application by its external id
        /// </summary>
        /// <param name="externalId">application external id</param>
        /// <returns>application data</returns>
        Application GetApplicationByExternalId(string externalId);
        /// <summary>
        /// Gets application by its unique id
        /// </summary>
        /// <param name="id">application id</param>
        /// <returns>application data</returns>
        Application GetApplicationById(long id);
    }
}
