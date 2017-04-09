using Afina.DataAccess.AdoNet.Instrumentations;
using Afina.DataAccess.Repositories;
using Afina.Models;
using System.Collections.Generic;

namespace Afina.DataAccess.AdoNet.Repositories
{
    public class DevelopperRepository : RepositoryBase, IDevelopperRepository
    {
        public DevelopperRepository(IQueryExecutor queryExecutor, IEntityMapHolder entityMapHolder) : base(queryExecutor, entityMapHolder)
        {
            _entityMapHolder.Register<Developper>((developper, result) =>
            {
                developper.Id = result.ReadValue<long>("Id");
                developper.ExternalId = result.ReadValue<string>("ExternalId");
                developper.Name = result.ReadValue<string>("Name");
            });
        }
        public void StoreDevelopper(Developper developper)
        {
            _queryExecutor.ExecuteNonQuery("InsertDevelopper"
                                    , new QueryParameter("externalId", developper.ExternalId)
                                    , new QueryParameter("name", developper.Name));
        }
        public IReadOnlyList<Developper> GetDeveloppers()
        {
            List<Developper> developpers = new List<Developper>();
            using (QueryResult result = _queryExecutor.Execute("GetAllDeveloppers"))
            {
                while (result.ReadNext())
                {
                    var developper = new Developper();
                    _entityMapHolder.MapEntity<Developper>(developper, result);
                    developpers.Add(developper);
                }
            }
            return developpers;
        }
        public Developper GetDevelopperByExternalId(string externalId)
        {
            Developper developper = null;
            using (QueryResult result = _queryExecutor.Execute("GetDevelopperByExternalId", new QueryParameter("externalId", externalId)))
            {
                if (result.ReadNext())
                {
                    developper = new Developper();
                    _entityMapHolder.MapEntity<Developper>(developper, result);
                }
            }
            return developper;
        }
        public Developper GetDevelopperById(long id)
        {
            Developper developper = null;
            using (QueryResult result = _queryExecutor.Execute("GetDevelopperById", new QueryParameter("id", id)))
            {
                if (result.ReadNext())
                {
                    developper = new Developper();
                    _entityMapHolder.MapEntity<Developper>(developper, result);
                }
            }
            return developper;
        }
    }
}
