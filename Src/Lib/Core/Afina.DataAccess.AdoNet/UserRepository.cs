using Afina.DataAccess.AdoNet.Instrumentations;
using Afina.Models;
using System;
using System.Data;
using System.Data.Common;

namespace Afina.DataAccess.AdoNet
{
    public class UserRepository : IUserRepository
    {
        private readonly IQueryer _queryer;

        public UserRepository(IQueryer queryer)
        {
            _queryer = queryer;
        }

        public User GetUser(string username)
        {
            User user = null;
            using (DbConnection connection = _queryer.OpenNewConnection())
            {
                using (IDataReader reader = _queryer.ExecuteReader(connection, (command) =>
                 {
                     command.CommandType = System.Data.CommandType.StoredProcedure;
                     command.CommandText = "";
                 }))
                {
                    if (reader.Read())
                    {
                        user = new User();
                        user.Name = _queryer.GetReaderValue<string>(reader, "name");
                    }
                }
                connection.Close();
            }
            return user;
        }
    }
}
