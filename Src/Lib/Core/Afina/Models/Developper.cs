namespace Afina.Models
{
    /// <summary>
    /// Represents a developper
    /// </summary>
    public class Developper
    {
        /// <summary>
        /// Internal developper's unique id
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Developper's unique external id
        /// </summary>
        public string ExternalId { get; set; }
        /// <summary>
        /// Developper's name
        /// </summary>
        public string Name { get; set; }
    }
}
