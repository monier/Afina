namespace Afina.DataAccess.Infrastructures.Databases
{
    /// <summary>
    /// Represents the version number of the database
    /// </summary>
    public struct DatabaseVersion
    {
        /// <summary>
        /// Major version number
        /// </summary>
        public int Major { get; set; }
        /// <summary>
        /// Minor version number
        /// </summary>
        public int Minor { get; set; }
        /// <summary>
        /// Version number
        /// </summary>
        public int Version
        {
            get
            {
                return (Major * 1000) + Minor;
            }
        }
        public DatabaseVersion(int major, int minor)
        {
            Major = major;
            Minor = minor;
        }
    }
}
