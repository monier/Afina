using Afina.DataAccess.AdoNet.Repositories;
using Afina.DataAccess.Repositories;
using Afina.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Afina.DataAccess.AdoNet.Tests.Repositories
{
    public abstract class ApplicationRepositoryTests : RepositoryTestBase
    {
        public override void ConfigureContainer()
        {
            base.ConfigureContainer();
            _container.Register<IApplicationRepository, ApplicationRepository>();
        }

        public virtual void CreateApplications()
        {
            var applicationRepository = _container.GetInstance<IApplicationRepository>();
            var application = CreateNewApplication("1");
            var externalId = application.ExternalId;
            applicationRepository.StoreApplication(application);
            application = applicationRepository.GetApplicationByExternalId(externalId);
            Assert.IsTrue(application.Id > 0, "The application is successfully retrieved by its externalId");
            long id = application.Id;
            Log($"<{application.Name}> id is: {id}");
            application = applicationRepository.GetApplicationById(id);
            Assert.IsTrue(application.Id > 0, "The application is successfully retrieved by its id");
            for (int i = 2; i <= 20; i++)
            {
                application = CreateNewApplication(i.ToString());
                applicationRepository.StoreApplication(application);
            }
            var applications = applicationRepository.GetApplications();
            Assert.IsTrue(applications.Count > 1, "All applications are successfully retrieved");
            foreach (var app in applications)
                applicationRepository.DeleteApplicationById(app.Id);
            applications = applicationRepository.GetApplications();
            Assert.IsTrue(applications.Count == 0, "All applications are succesfully deleted");
        }

        private Application CreateNewApplication(string suffix)
        {
            Application application = new Application();
            application.ExternalId = Guid.NewGuid().ToString();
            application.Name = $"Test-App-{suffix}";
            application.PrivateKey = $"private-key-{suffix}";
            application.PublicKey = $"public-key-{suffix}";
            return application;
        }
    }
}
