namespace Afina.DataAccess.Infrastructures.Databases
{
    /// <summary>
    /// Represents a database used by the system
    /// </summary>
    public interface IDatabase
    {
        /// <summary>
        /// Returns the database version number
        /// </summary>
        /// <returns>database version number</returns>
        DatabaseVersion GetVersion();
        /// <summary>
        /// Checks if the database exists
        /// </summary>
        /// <returns>true if the database exists</returns>
        bool Exists();
        /// <summary>
        /// Creates the database structures and objects
        /// </summary>
        void Create();
        /// <summary>
        /// Updates the database structures and objects
        /// </summary>
        void Update();
    }
}
