namespace Afina.DataAccess.AdoNet.Infrastructures.Databases
{
    /// <summary>
    /// Service permettant de localiser les scripts de création de la structure de la base de données
    /// </summary>
    public interface IDbStructureQueriesLocator
    {
        /// <summary>
        /// Assigne un répertoire où se trouvent les scripts
        /// </summary>
        /// <param name="directoryLocation">répertoire où se trouvent les scripts</param>
        void SetDirectoryLocation(string directoryLocation);
        /// <summary>
        /// Retourne le répertoire où se trouvent les scripts
        /// </summary>
        /// <returns>répertoire où se trouvent les scripts</returns>
        string GetDirectoryLocation();
        /// <summary>
        /// Assigne l'extension des fichiers qui contiennent les scripts
        /// </summary>
        /// <param name="extension">extension des fichiers qui contiennent les scripts</param>
        void SetExtension(string extension);
        /// <summary>
        /// Retourne l'extension des fichiers qui contiennent les scripts
        /// </summary>
        /// <returns>extension des fichiers qui contiennent les scripts</returns>
        string GetExtension();
    }
}
