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
    }
}
