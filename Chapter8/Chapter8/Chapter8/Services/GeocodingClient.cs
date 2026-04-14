using Chapter8.Models;
using Chapter8.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace Chapter8.Services
{
    public class GeocodingClient : IGeocodingClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly string _baseUrl;
        public GeocodingClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiKey = configuration["API_KEY"];
            _baseUrl = configuration["BASE_URL"];
        }

        public async Task<List<ApiResponseModel>> SearchLocation(string location)
        {
            try
            {
                var url = $"{_baseUrl}?key={_apiKey}&q={location}";
                var httpResponse = await _httpClient.GetAsync(url);

                if (!httpResponse.IsSuccessStatusCode)
                {
                    Console.WriteLine($"API Error: {httpResponse.StatusCode}");
                    return new List<ApiResponseModel>();
                }

                var response = await httpResponse.Content.ReadAsStringAsync();

                var data = JsonSerializer.Deserialize<List<ApiResponseModel>>(response);

                return data ?? new List<ApiResponseModel>();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("Network error: " + ex.Message);
                return new List<ApiResponseModel>();
            }
            catch (TaskCanceledException)
            {
                Console.WriteLine("Request timed out.");
                return new List<ApiResponseModel>();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected error: " + ex.Message);
                return new List<ApiResponseModel>();
            }
        }
    }
}
