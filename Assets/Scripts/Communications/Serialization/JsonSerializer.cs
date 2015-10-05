namespace MarvelUniverse.Communications.Serialization
{
    using Newtonsoft.Json;
    using UnityEngine;

    /// <summary>
    /// JSON serializer.
    /// </summary>
    public class JsonSerializer : IJsonSerializer
    {
        /// <summary>
        /// Deserialize the JSON string to the specified type.
        /// </summary>
        /// <typeparam name="T">The type to deserialize to.</typeparam>
        /// <param name="json">The JSON string.</param>
        /// <returns>The deserialized type.</returns>
        public T Deserialize<T>(string json)
        {
            T returnValue = default(T);
            
            if (!string.IsNullOrEmpty(json))
            {
                returnValue = JsonConvert.DeserializeObject<T>(json);
            }

            return returnValue;
        }
    }
}
