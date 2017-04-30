using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleInjector;
using System;
using System.Diagnostics;

namespace Afina.Tests
{
    [TestClass]
    public abstract class TestBase
    {
        protected Container _container;

        public TestContext TestContext { get; set; }

        [TestInitialize]
        public virtual void Setup()
        {
            _container = new Container();
            _container.Options.AllowOverridingRegistrations = true;
            ConfigureContainer();
            Initialize();
        }
        public abstract void ConfigureContainer();
        public virtual void Initialize() { }
        [TestCleanup]
        public virtual void Cleanup()
        {
            _container.Dispose();
        }
        protected virtual void Log(string log)
        {
            Console.WriteLine(log);
            Trace.WriteLine(log);
        }
    }
}
