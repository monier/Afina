namespace Afina.Models
{
    /// <summary>
    /// Represents an application that connects to the server
    /// </summary>
    public class Application
    {
        /// <summary>
        /// Internal application's unique id
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Application's unique id that is exposed to third parties
        /// </summary>
        public string ExternalId { get; set; }
        /// <summary>
        /// Application's name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Private key used to unencrypt authentication data from third parties
        /// </summary>
        public string PrivateKey { get; set; }
        /// <summary>
        /// Public key sent to third parties that they use to encrypt authentication data
        /// </summary>
        public string PublicKey { get; set; }
        /// <summary>
        /// Id of the developper who is responsible of the application
        /// </summary>
        public long DevelopperId { get; set; }
    }
}
