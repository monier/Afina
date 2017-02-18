using Afina.DataAccess.AdoNet.Instrumentations;
using Afina.DataAccess.AdoNet.Sqlite.Infrastructures;
using Microsoft.Data.Sqlite;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleInjector;
using System;
using System.Data.Common;
using System.Diagnostics;

namespace Afina.DataAccess.AdoNet.Sqlite.Tests.Instrumentations
{
    [TestClass]
    [TestCategory("Afina.AdoNet.Sqlite")]
    public class QueryerTests : AdoNet.Tests.Instrumentations.QueryerTests
    {
        [TestInitialize]
        public override void Setup()
        {
            _container = new Container();
            string connectionString = @"Data Source=.\Resources\Data\Db\afina.db;";
            _container.Register<DbProviderFactory, SqliteDbProviderFactory>(Lifestyle.Singleton);
            _container.Register<IConnectionStringProvider, ConnectionStringProvider>(Lifestyle.Transient);
            _container.RegisterInitializer<IConnectionStringProvider>(service => service.ConnectionString = connectionString);
            _container.Register(() => new Func<DbConnectionStringBuilder>(() => _container.GetInstance<DbConnectionStringBuilder>()));
            _container.Register<IQueryer, Queryer>(Lifestyle.Transient);
            _container.Verify(VerificationOption.VerifyAndDiagnose);
        }
        [TestCleanup]
        public override void Cleanup()
        {
            _container.Dispose();
        }
        [TestMethod]
        public override void OpenConnection()
        {
            base.OpenConnection();
        }
        [TestMethod]
        public void SelectUsers()
        {
            int counter = 0;
            var queryer = _container.GetInstance<IQueryer>();
            using (var connection = queryer.OpenNewConnection())
            {
                string lastUsername = "";
                using (var reader = queryer.ExecuteReader(connection, (cmd) =>
                  {
                      cmd.CommandText = "SELECT * FROM User";
                      cmd.CommandType = System.Data.CommandType.Text;
                  }))
                {
                    while (reader.Read())
                    {
                        var id = queryer.GetReaderValue<long>(reader, "Id");
                        var username = queryer.GetReaderValue<string>(reader, "Name");
                        lastUsername = username;
                        var password = queryer.GetReaderValue<string>(reader, "Password");
                        counter++;
                        Debug.WriteLine($"Id: {id}");
                        Debug.WriteLine($"Name: {username}");
                        Debug.WriteLine($"Password: {password}");
                        Debug.WriteLine($"Counter: {counter}");
                    }
                }
                using (var reader = queryer.ExecuteReader(connection, (cmd) =>
                {
                    cmd.CommandText = "SELECT * FROM User WHERE Name = @name";
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Parameters.Add(queryer.CreateParameter(cmd, "@name", lastUsername));
                }))
                {
                    while (reader.Read())
                    {
                        var id = queryer.GetReaderValue<long>(reader, "Id");
                        var username = queryer.GetReaderValue<string>(reader, "Name");
                        var password = queryer.GetReaderValue<string>(reader, "Password");
                        counter++;
                        Debug.WriteLine($"Id: {id}");
                        Debug.WriteLine($"Name: {username}");
                        Debug.WriteLine($"Password: {password}");
                        Debug.WriteLine($"Counter: {counter}");
                    }
                }
                connection.Close();
            }
        }
    }
}
