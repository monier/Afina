using Afina.DataAccess.AdoNet.Infrastructures.Databases;
using Afina.DataAccess.AdoNet.Instrumentations;
using Afina.DataAccess.AdoNet.Sqlite.Infrastructures;
using Afina.DataAccess.AdoNet.Sqlite.Infrastructures.Databases;
using Afina.DataAccess.Infrastructures.Databases;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleInjector;
using System.Collections.Generic;
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
            _container.Register<IDatabase, SqliteDatabase>(Lifestyle.Transient);
            _container.Register<IDbStructureQueriesLocator, DbStructureQueriesLocator>(Lifestyle.Singleton);
            _container.Register<DbProviderFactory, SqliteDbProviderFactory>(Lifestyle.Singleton);
            _container.Register<IConnectionStringProvider, ConnectionStringProvider>(Lifestyle.Singleton);
            _container.Verify(VerificationOption.VerifyAndDiagnose);
            DbInitializer.InitializeDatabase(_container);
        }
        [TestMethod]
        public override void OpenConnection()
        {
            base.OpenConnection();
        }
        [TestMethod]
        public void SelectUsers()
        {
            var queryer = _container.GetInstance<IQueryer>();
            using (var connection = queryer.GetConnection())
            {
                queryer.ExecuteNonQuery(connection, command =>
                {
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "INSERT INTO User"
                                            + " (Name, Password)"
                                            + " VALUES ('John', 'JohnPass')"
                                            + " ,('Jack', 'JackPass')";
                });
                string lastUsername = "";
                List<long> ids = new List<long>();
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
                        Log($"Id: {id}");
                        Log($"Name: {username}");
                        Log($"Password: {password}");
                        ids.Add(id);
                    }
                }
                Assert.IsTrue(ids.Count > 0, "Users retrieved from db");
                bool specificUserFound = false;
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
                        Log($"Id: {id}");
                        Log($"Name: {username}");
                        Log($"Password: {password}");
                        specificUserFound = true;
                    }
                }
                Assert.IsTrue(specificUserFound, "Specific user found from db");
                foreach(var id in ids)
                {
                    queryer.ExecuteNonQuery(connection, (cmd) =>
                    {
                        cmd.CommandText = "DELETE FROM User WHERE Id = @id";
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.Parameters.Add(queryer.CreateParameter(cmd, "@id", id));
                    });
                }
                connection.Close();
            }
        }
    }
}
