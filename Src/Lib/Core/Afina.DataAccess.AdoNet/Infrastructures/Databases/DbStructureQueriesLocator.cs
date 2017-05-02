namespace Afina.DataAccess.AdoNet.Infrastructures.Databases
{
    public class DbStructureQueriesLocator : IDbStructureQueriesLocator
    {
        private string _directoryLocation = null;
        public void SetDirectoryLocation(string directoryLocation)
        {
            _directoryLocation = directoryLocation;
        }
        public string GetDirectoryLocation()
        {
            return _directoryLocation;
        }
        private string _extension = null;
        public void SetExtension(string extension)
        {
            _extension = extension;
        }
        public string GetExtension()
        {
            return _extension;
        }
    }
}
