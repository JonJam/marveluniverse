namespace MarvelUniverse.Communications.Serialization
{
    using System.IO;
    using System.Runtime.Serialization.Json;
    using System.Text;

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
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));

                using (MemoryStream memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(json)))
                {
                    returnValue = (T)serializer.ReadObject(memoryStream);
                }
            }

            return returnValue;
        }
    }
}
