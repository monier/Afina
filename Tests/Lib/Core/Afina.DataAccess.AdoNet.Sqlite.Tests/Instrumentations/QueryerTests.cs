using Afina.DataAccess.AdoNet.Instrumentations;
using Afina.DataAccess.AdoNet.Sqlite.Infrastructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleInjector;
using System.Data.Common;

namespace Afina.DataAccess.AdoNet.Sqlite.Tests.Instrumentations
{
    [TestClass]
    [TestCategory("Afina.AdoNet.Sqlite.Queryer")]
    public class QueryerTests : AdoNet.Tests.Instrumentations.QueryerTests
    {
        public override void ConfigureContainer()
        {
            base.ConfigureContainer();
            string connectionString = @"Data Source=.\Resources\Data\Db\afina.db;";
            _container.Register<DbProviderFactory, SqliteDbProviderFactory>(Lifestyle.Singleton);
            _container.RegisterInitializer<IConnectionStringProvider>(service => service.ConnectionString = connectionString);
            _container.Verify(VerificationOption.VerifyAndDiagnose);
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
                        var id = queryer.ReadValue<long>(reader, "Id");
                        var username = queryer.ReadValue<string>(reader, "Name");
                        lastUsername = username;
                        var password = queryer.ReadValue<string>(reader, "Password");
                        counter++;
                        Log($"Id: {id}");
                        Log($"Name: {username}");
                        Log($"Password: {password}");
                        Log($"Counter: {counter}");
                    }
                }
                Assert.IsTrue(counter > 0, "Users retrieved from db");
                counter = 0;
                using (var reader = queryer.ExecuteReader(connection, (cmd) =>
                {
                    cmd.CommandText = "SELECT * FROM User WHERE Name = @name";
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Parameters.Add(queryer.CreateParameter(cmd, "@name", lastUsername));
                }))
                {
                    while (reader.Read())
                    {
                        var id = queryer.ReadValue<long>(reader, "Id");
                        var username = queryer.ReadValue<string>(reader, "Name");
                        var password = queryer.ReadValue<string>(reader, "Password");
                        counter++;
                        Log($"Id: {id}");
                        Log($"Name: {username}");
                        Log($"Password: {password}");
                        Log($"Counter: {counter}");
                    }
                }
                Assert.IsTrue(counter > 0, "Specific user found from db");
                connection.Close();
            }
        }
    }
}
