using System.IO;

namespace Afina.DataAccess.AdoNet.Instrumentations
{
    /// <summary>
    /// Provides methods to select queries
    /// </summary>
    public interface IQuerySelector
    {
        /// <summary>
        /// Gets the query string by it's name
        /// </summary>
        /// <param name="name">name of the query</param>
        /// <returns>query string</returns>
        string GetQuery(string name);
        /// <summary>
        /// Adds queries to current selector from xml file.
        /// </summary>
        /// <param name="filename">xml file containing queries</param>
        void AddQueries(string filename);
        /// <summary>
        /// Adds queries to current selector from xml stream.
        /// <para>Existing queries will be updated/changed.</para>
        /// </summary>
        /// <param name="stream">stream containing queries</param>
        void AddQueries(Stream stream);
    }
}
