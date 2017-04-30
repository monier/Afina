using Afina.DataAccess.AdoNet.Instrumentations;
using Afina.DataAccess.Repositories;
using Afina.Models;
using System;
using System.Collections.Generic;

namespace Afina.DataAccess.AdoNet.Repositories
{
    public class SessionRepository : RepositoryBase, ISessionRepository
    {
        public SessionRepository(IQueryExecutor queryExecutor, IEntityMapHolder entityMapHolder) : base(queryExecutor, entityMapHolder)
        {
            _entityMapHolder.Register<Session>((session, result) =>
            {
                session.Id = result.ReadValue<long>("Id");
                session.ExternalId = result.ReadValue<string>("ExternalId");
                session.EncryptionKey = result.ReadValue<string>("EncryptionKey");
                session.CreationDate = result.ReadValue<DateTime>("CreationDate");
                session.LastAccessDate = result.ReadValue<DateTime>("LastAccessDate");
                session.TimeToLiveInSeconds = result.ReadValue<int>("TimeToLiveInSeconds");
            });
        }
        public void StoreSession(Session session)
        {
            _queryExecutor.ExecuteNonQuery("InsertSession"
                                    , new QueryParameter("externalId", session.ExternalId)
                                    , new QueryParameter("encryptionKey", session.EncryptionKey)
                                    , new QueryParameter("creationDate", session.CreationDate)
                                    , new QueryParameter("lastAccessDate", session.LastAccessDate)
                                    , new QueryParameter("timeToLiveInSeconds", session.TimeToLiveInSeconds));
        }
        public IReadOnlyList<Session> GetSessions()
        {
            List<Session> sessions = new List<Session>();
            using (QueryResult result = _queryExecutor.Execute("GetAllSessions"))
            {
                while (result.ReadNext())
                {
                    var session = new Session();
                    _entityMapHolder.MapEntity<Session>(session, result);
                    sessions.Add(session);
                }
            }
            return sessions;
        }
        public Session GetSessionById(long id)
        {
            Session session = null;
            using (QueryResult result = _queryExecutor.Execute("GetSessionById", new QueryParameter("id", id)))
            {
                if (result.ReadNext())
                {
                    session = new Session();
                    _entityMapHolder.MapEntity<Session>(session, result);
                }
            }
            return session;
        }
        public Session GetSessionByExternalId(string externalId)
        {
            Session session = null;
            using (QueryResult result = _queryExecutor.Execute("GetSessionByExternalId", new QueryParameter("externalId", externalId)))
            {
                if (result.ReadNext())
                {
                    session = new Session();
                    _entityMapHolder.MapEntity<Session>(session, result);
                }
            }
            return session;
        }
    }
}
