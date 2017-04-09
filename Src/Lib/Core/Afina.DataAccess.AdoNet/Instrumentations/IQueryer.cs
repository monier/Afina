using System;
using System.Data;
using System.Data.Common;

namespace Afina.DataAccess.AdoNet.Instrumentations
{
    /// <summary>
    /// Provides methods to query to database
    /// </summary>
    public interface IQueryer
    {
        /// <summary>
        /// Opens new connection to database
        /// </summary>
        /// <returns>opened connection</returns>
        DbConnection OpenNewConnection();
        /// <summary>
        /// Executes a query and return an instance of <see cref="IDataReader"/>
        /// </summary>
        /// <param name="connection">connection to database</param>
        /// <param name="actionOnCommand">method to invoke on <see cref="DbCommand"/> object</param>
        /// <returns>instance of <see cref="IDataReader"/> containing the query result</returns>
        IDataReader ExecuteReader(DbConnection connection, Action<DbCommand> actionOnCommand);
        /// <summary>
        /// Executes a query and return the affected rows count
        /// </summary>
        /// <param name="connection">connection to database</param>
        /// <param name="actionOnCommand">method to invoke on <see cref="DbCommand"/> object</param>
        /// <returns>affected rows count</returns>
        int ExecuteNonQuery(DbConnection connection, Action<DbCommand> actionOnCommand);
        /// <summary>
        /// Creates a parameter to pass to the instance of <see cref="DbCommand"/> that executes a query
        /// </summary>
        /// <param name="command">command that executes the query</param>
        /// <param name="name">name of the parameter</param>
        /// <param name="value">value of the parameter</param>
        /// <param name="actionOnParameter">method to invoke on the <see cref="DbParameter"/> object</param>
        /// <returns>parameter to pass to an instance of <see cref="DbCommand"/> that executes a query</returns>
        DbParameter CreateParameter(DbCommand command, string name, object value, Action<DbParameter> actionOnParameter = null);
        /// <summary>
        /// Reads value from a <see cref="IDataReader"/>
        /// </summary>
        /// <typeparam name="T">type of the value</typeparam>
        /// <param name="reader">instance of <see cref="IDataReader"/></param>
        /// <param name="name">name of the field containing the value</param>
        /// <returns>value from the <see cref="IDataReader"/></returns>
        T ReadValue<T>(IDataReader reader, string name);
        /// <summary>
        /// Reads value from a <see cref="IDataReader"/>
        /// </summary>
        /// <param name="reader">instance of <see cref="IDataReader"/></param>
        /// <param name="index">index of the field containing the value</param>
        /// <returns></returns>
        object ReadValue(IDataReader reader, int index);
    }
}
