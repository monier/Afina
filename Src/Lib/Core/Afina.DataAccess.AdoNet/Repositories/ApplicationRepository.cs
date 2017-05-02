using Afina.DataAccess.AdoNet.Instrumentations;
using Afina.DataAccess.Repositories;
using Afina.Models;
using System.Collections.Generic;

namespace Afina.DataAccess.AdoNet.Repositories
{
    public class ApplicationRepository : RepositoryBase, IApplicationRepository
    {
        public ApplicationRepository(IQueryExecutor queryExecutor, IEntityMapHolder entityMapHolder) : base(queryExecutor, entityMapHolder)
        {
            _entityMapHolder.Register<Application>((application, result) =>
            {
                application.Id = result.ReadValue<long>("Id");
                application.ExternalId = result.ReadValue<string>("ExternalId");
                application.Name = result.ReadValue<string>("Name");
                application.PrivateKey = result.ReadValue<string>("PrivateKey");
                application.PublicKey = result.ReadValue<string>("PublicKey");
            });
        }
        public void StoreApplication(Application application)
        {
            _queryExecutor.ExecuteNonQuery("InsertApplication"
                                    , new QueryParameter("externalId", application.ExternalId)
                                    , new QueryParameter("name", application.Name)
                                    , new QueryParameter("privateKey", application.PrivateKey)
                                    , new QueryParameter("publicKey", application.PublicKey));
        }
        public IReadOnlyList<Application> GetApplications()
        {
            List<Application> applications = new List<Application>();
            using (QueryResult result = _queryExecutor.Execute("GetAllApplications"))
            {
                while (result.ReadNext())
                {
                    var application = new Application();
                    _entityMapHolder.MapEntity<Application>(application, result);
                    applications.Add(application);
                }
            }
            return applications;
        }
        public Application GetApplicationByExternalId(string externalId)
        {
            Application application = null;
            using (QueryResult result = _queryExecutor.Execute("GetApplicationByExternalId", new QueryParameter("externalId", externalId)))
            {
                if (result.ReadNext())
                {
                    application = new Application();
                    _entityMapHolder.MapEntity<Application>(application, result);
                }
            }
            return application;
        }
        public Application GetApplicationById(long id)
        {
            Application application = null;
            using (QueryResult result = _queryExecutor.Execute("GetApplicationById", new QueryParameter("id", id)))
            {
                if (result.ReadNext())
                {
                    application = new Application();
                    _entityMapHolder.MapEntity<Application>(application, result);
                }
            }
            return application;
        }
        public void DeleteApplicationById(long id)
        {
            _queryExecutor.ExecuteNonQuery("DeleteApplicationById", new QueryParameter("id", id));
        }
    }
}
