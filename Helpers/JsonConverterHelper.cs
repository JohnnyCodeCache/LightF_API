using Newtonsoft.Json;

namespace LightF_API.Helpers
{
    public class JsonConverterHelper
    {
        public static List<T> DeserializeJsonList<T>(string jsonString)
        {
            try
            {
                // Deserialize JSON string to list of C# objects
                List<T> objects = JsonConvert.DeserializeObject<List<T>>(jsonString);
                return objects;
            }
            catch (JsonException ex)
            {
                // Handle any JSON serialization errors
                Console.WriteLine($"Failed to deserialize JSON: {ex.Message}");
                return null; // Return null if deserialization fails
            }
        }
    }
}
