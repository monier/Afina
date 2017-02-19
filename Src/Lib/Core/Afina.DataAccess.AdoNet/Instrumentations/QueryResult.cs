using System;
using System.Collections.Generic;
using System.Data;

namespace Afina.DataAccess.AdoNet.Instrumentations
{
    /// <summary>
    /// Result of executed query
    /// </summary>
    public class QueryResult : IDisposable
    {
        private readonly IQueryer _queryer;
        
        public int RecordsAffected { get; private set; }
        public IDbConnection Connection { get; private set; }
        public IDataReader DataReader { get; private set; }

        public QueryResult(IQueryer queryer, IDataReader reader, IDbConnection connection)
        {
            _queryer = queryer;
            DataReader = reader;
            Connection = connection;
            RecordsAffected = DataReader.RecordsAffected;
        }
        /// <summary>
        /// Moves cursor to next result set
        /// </summary>
        /// <returns>true if result set exists</returns>
        public bool ReadNext()
        {
            return DataReader.Read();
        }
        /// <summary>
        /// Reads value from result set
        /// </summary>
        /// <typeparam name="T">type of the value to read</typeparam>
        /// <param name="name">name of the value</param>
        /// <returns>value from result set</returns>
        public T ReadValue<T> (string name)
        {
            return _queryer.ReadValue<T>(DataReader, name);
        }
        public void Dispose()
        {
            DataReader?.Dispose();
            Connection?.Dispose();
        }
    }
}
