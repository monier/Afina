using System;

namespace Afina.Models
{
    /// <summary>
    /// Represents a session involving the server and an application
    /// </summary>
    public class Session
    {
        /// <summary>
        /// Internal session unique id
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Session's unique id that is exposed to third parties
        /// </summary>
        public string ExternalId { get; set; }
        /// <summary>
        /// Symmetric encryption key that is used to encrypt/decrypt data exchanged by the server and the application
        /// </summary>
        public string EncryptionKey { get; set; }
        /// <summary>
        /// Creation date of the session
        /// </summary>
        public DateTime CreationDate { get; set; }
        /// <summary>
        /// Last access date of the session
        /// </summary>
        public DateTime LastAccessDate { get; set; }
        /// <summary>
        /// Time to live in seconds of the session
        /// </summary>
        public int TimeToLiveInSeconds { get; set; }
    }
}
