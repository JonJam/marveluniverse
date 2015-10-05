namespace MarvelUniverse.Communications.Serialization
{
    /// <summary>
    /// Interface for a JSON serializer.
    /// </summary>
    public interface IJsonSerializer
    {
        /// <summary>
        /// Deserialize the JSON string to the specified type.
        /// </summary>
        /// <typeparam name="T">The type to deserialize to.</typeparam>
        /// <param name="json">The JSON string.</param>
        /// <returns>The deserialized type.</returns>
        T Deserialize<T>(string json);
    }
}