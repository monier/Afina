namespace Afina.DataAccess.AdoNet.Instrumentations
{
    /// <summary>
    /// Provides methods to map value from and to database
    /// </summary>
    public interface IDbValueMapper
    {
        /// <summary>
        /// Maps value to database format
        /// </summary>
        /// <param name="value">value to send to database</param>
        /// <returns>value mapped to database format</returns>
        object MapToDb(object value);
        /// <summary>
        /// Maps value from database
        /// </summary>
        /// <param name="value">value from database</param>
        /// <returns>value mapped from database</returns>
        object MapFromDb(object value);
    }
}
