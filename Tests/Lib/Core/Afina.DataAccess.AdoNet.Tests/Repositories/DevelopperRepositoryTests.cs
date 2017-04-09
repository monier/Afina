using Afina.DataAccess.AdoNet.Repositories;
using Afina.DataAccess.Repositories;
using Afina.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Afina.DataAccess.AdoNet.Tests.Repositories
{
    public abstract class DevelopperRepositoryTests : RepositoryTestBase
    {
        public override void ConfigureContainer()
        {
            base.ConfigureContainer();
            _container.Register<IDevelopperRepository, DevelopperRepository>();
        }

        public virtual void CreateDeveloppers()
        {
            var developperRepository = _container.GetInstance<IDevelopperRepository>();
            var developper = CreateNewDevelopper("1");
            var externalId = developper.ExternalId;
            developperRepository.StoreDevelopper(developper);
            developper = developperRepository.GetDevelopperByExternalId(externalId);
            Assert.IsTrue(developper.Id > 0, "The developper is successfully retrieved by its externalId");
            long id = developper.Id;
            Log($"<{developper.Name}> id is: {id}");
            developper = developperRepository.GetDevelopperById(id);
            Assert.IsTrue(developper.Id > 0, "The developper is successfully retrieved by its id");
            for (int i = 2; i <= 20; i++)
            {
                developper = CreateNewDevelopper(i.ToString());
                developperRepository.StoreDevelopper(developper);
            }
            var applications = developperRepository.GetDeveloppers();
            Assert.IsTrue(applications.Count > 1, "All developpers are successfully retrieved");
        }

        private Developper CreateNewDevelopper(string suffix)
        {
            Developper developper = new Developper();
            developper.ExternalId = Guid.NewGuid().ToString();
            developper.Name = $"dev-{suffix}";
            return developper;
        }
    }
}
