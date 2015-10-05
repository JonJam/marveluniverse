namespace MarvelUniverse.Communications.Encryption
{
    /// <summary>
    /// Interface for an encryption service.
    /// </summary>
    public interface IEncryptionService
    {
        /// <summary>
        /// Creates a MD5 hash of the string passed.
        /// </summary>
        /// <param name="stringToEncrypt">The string to encrypt.</param>
        /// <returns>The MD5 hash.</returns>
        string MD5Hash(string stringToEncrypt);
    }
}
