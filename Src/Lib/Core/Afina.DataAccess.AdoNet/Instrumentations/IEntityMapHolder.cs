using System;

namespace Afina.DataAccess.AdoNet.Instrumentations
{
    /// <summary>
    /// Provides methods to hold and reuse entity map
    /// </summary>
    public interface IEntityMapHolder
    {
        /// <summary>
        /// Registers a mapper for a type of entity
        /// </summary>
        /// <typeparam name="T">type of entity</typeparam>
        /// <param name="mapper">mapper to the entity</param>
        void Register<T>(Action<T, QueryResult> mapper) where T : class;
        /// <summary>
        /// Retrieves a mapper for a type of entity
        /// </summary>
        /// <typeparam name="T">type of entity</typeparam>
        /// <returns>mapper to the entity</returns>
        Action<T, QueryResult> Get<T>() where T : class;
        /// <summary>
        /// Maps an entity from a <see cref="QueryResult"/>.
        /// <para>The entity must be instantiated before calling this method.</para>
        /// </summary>
        /// <typeparam name="T">type of the entity</typeparam>
        /// <param name="entity">entity to map</param>
        /// <param name="queryResult">query result</param>
        void MapEntity<T>(T entity, QueryResult queryResult) where T : class;
    }

    /// <summary>
    /// Exception when an <see cref="IEntityMapHolder"/> doesn't hold a valid mapper for an entity
    /// </summary>
    public class NotRegisteredMapperException : Exception
    {
        public NotRegisteredMapperException() { }
        public NotRegisteredMapperException(string message) : base(message) { }
    }
}
