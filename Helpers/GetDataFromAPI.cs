namespace LightF_API.Helpers
{
    public class GetDataFromAPI
    {
        private readonly HttpClient _httpClient;
        private readonly string _jsonMockDataFilePath;

        public GetDataFromAPI()
        {
            _httpClient = new HttpClient();
            _jsonMockDataFilePath = "Data/MockData.json";
        }

        public async Task<string?> GetJsonDataFromApi(string apiUrl)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

                // give jsonData a mocked default incase external API fails
                string jsonData = File.ReadAllText(_jsonMockDataFilePath);

                // Check if request was successful
                if (response.IsSuccessStatusCode)
                {
                    // Read JSON data from response body
                    jsonData = await response.Content.ReadAsStringAsync();
                }
                else
                {
                    // Log error message if request fails
                    Console.WriteLine($"Failed to retrieve JSON data from {apiUrl}. Status code: {response.StatusCode}.  Using Mock Data instead.");
                }
                return jsonData;
            }
            catch (HttpRequestException ex)
            {
                // Log exception if request fails
                Console.WriteLine($"Failed to retrieve JSON data from {apiUrl}. {ex.Message}");
                return null;
            }
        }
    }
}
