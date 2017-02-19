namespace Afina.DataAccess.AdoNet.Instrumentations
{
    /// <summary>
    /// Service that lets execute queries using <see cref="IQueryer"/> and <see cref="IQuerySelector"/> services
    /// </summary>
    public interface IQueryExecutor
    {
        /// <summary>
        /// Executes a query and return the result in an instance of <see cref="IDataReader"/>
        /// </summary>
        /// <param name="queryName">query name that can be retrieved by an instance of <see cref="IQuerySelector"/></param>
        /// <param name="parameters">parameters to pass to the query</param>
        /// <returns>result of the query in a <see cref="IDataReader"/></returns>
        QueryResult Execute(string queryName, params QueryParameter[] parameters);
    }
}
