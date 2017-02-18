﻿using System;
using System.Data;
using System.Data.Common;

namespace Afina.DataAccess.AdoNet.Instrumentations
{
    public class Queryer : IQueryer
    {
        private readonly IConnectionStringProvider _connectionStringProvider;
        private readonly DbProviderFactory _providerFactory;

        public Queryer(IConnectionStringProvider connectionStringProvider, DbProviderFactory providerFactory)
        {
            _connectionStringProvider = connectionStringProvider;
            _providerFactory = providerFactory;
        }

        public DbConnection OpenNewConnection()
        {
            var connection = _providerFactory.CreateConnection();
            connection.ConnectionString = _connectionStringProvider.ConnectionString;
            connection.Open();
            return connection;
        }
        public IDataReader ExecuteReader(DbConnection connection, Action<DbCommand> actionOnCommand)
        {
            var command = connection.CreateCommand();
            actionOnCommand(command);
            return command.ExecuteReader();
        }
        public DbParameter CreateParameter(DbCommand command, string name, object value, Action<DbParameter> actionOnParameter = null)
        {
            var parameter = command.CreateParameter();
            parameter.ParameterName = name;
            parameter.Value = value;
            actionOnParameter?.Invoke(parameter);
            return parameter;
        }
        public T GetReaderValue<T>(IDataReader reader, string name)
        {
            return (T)reader[name];
        }
    }
}
