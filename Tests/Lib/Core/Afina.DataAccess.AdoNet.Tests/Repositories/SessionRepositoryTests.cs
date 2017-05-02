using Afina.DataAccess.AdoNet.Repositories;
using Afina.DataAccess.Repositories;
using Afina.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Afina.DataAccess.AdoNet.Tests.Repositories
{
    public abstract class SessionRepositoryTests : RepositoryTestBase
    {
        public override void ConfigureContainer()
        {
            base.ConfigureContainer();
            _container.Register<ISessionRepository, SessionRepository>();
        }

        public virtual void CreateSessions()
        {
            var sessionRepository = _container.GetInstance<ISessionRepository>();
            var session = CreateNewSession("1");
            var externalId = session.ExternalId;
            sessionRepository.StoreSession(session);
            session = sessionRepository.GetSessionByExternalId(externalId);
            Assert.IsTrue(session.Id > 0, "The session is successfully retrieved by its externalId");
            long id = session.Id;
            Log($"<{session.ExternalId}> id is: {id}");
            session = sessionRepository.GetSessionById(id);
            Assert.IsTrue(session.Id > 0, "The session is successfully retrieved by its id");
            for (int i = 2; i <= 20; i++)
            {
                session = CreateNewSession(i.ToString());
                sessionRepository.StoreSession(session);
            }
            var sessions = sessionRepository.GetSessions();
            Assert.IsTrue(sessions.Count > 1, "All sessions are successfully retrieved");
            foreach (var sess in sessions)
                sessionRepository.DeleteSessionById(sess.Id);
            sessions = sessionRepository.GetSessions();
            Assert.IsTrue(sessions.Count == 0, "All sessions are succesfully deleted");
        }

        private Session CreateNewSession(string suffix)
        {
            Session session = new Session();
            session.ExternalId = Guid.NewGuid().ToString();
            session.EncryptionKey = $"EncryptionKey-{suffix}";
            session.CreationDate = DateTime.Now;
            session.LastAccessDate = DateTime.Now;
            session.TimeToLiveInSeconds = DateTime.Now.Second;
            return session;
        }
    }
}
