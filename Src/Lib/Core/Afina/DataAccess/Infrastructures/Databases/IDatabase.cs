namespace Afina.DataAccess.Infrastructures.Databases
{
    /// <summary>
    /// Represents a database used by the system
    /// </summary>
    public interface IDatabase
    {
        /// <summary>
        /// Initialise l'accès à la base de données
        /// </summary>
        void Initialize();
        /// <summary>
        /// Returns the database version number
        /// </summary>
        /// <returns>database version number</returns>
        DatabaseVersion GetVersion();
        /// <summary>
        /// Creates the database structures and objects
        /// </summary>
        void CreateOrUpdate();
        /// <summary>
        /// Updates the database structures and objects
        /// </summary>
        void Upgrade();
    }
}
