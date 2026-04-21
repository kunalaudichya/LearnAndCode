using System.Text.Json;
using Week3.Models;

namespace Week3.Repositories
{
    public class TumblrRepository : ITumblrRepository
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TumblrRepository(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<TumblrApiResponse> FetchBlogDataAsync(string blogName, int startIndex, int postCount)
        {
            HttpClient httpClient = _httpClientFactory.CreateClient();

            string url = $"https://{blogName}.tumblr.com/api/read/json?type=photo&num={postCount}&start={startIndex}";

            try
            {
                string rawResponse = await httpClient.GetStringAsync(url);

                // The raw response we get from Tumblr API v1 starts with 'var tumblr_api_read = ' and ends with ';'.
                // We remove these JavaScript "wrappers" so the string begins and ends with curly braces { }.
                string cleanJsonResponse = rawResponse.Replace("var tumblr_api_read = ", "")
                                                    .Trim()
                                                    .TrimEnd(';');

                // Tell the serializer to ignore differences in capital letters
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                // Convert the cleaned JSON string into a structured C# object (TumblrApiResponse)
                return JsonSerializer.Deserialize<TumblrApiResponse>(cleanJsonResponse, options);
            }
            catch(HttpRequestException ex)
            {
                if (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    throw new Exception($"The blog '{blogName}' could not be found. Please check the spelling.");
                }

                throw new Exception("Connection error: Please check your internet connection.");
            }
        }
    }
}
