using System.Text.Json.Serialization;

namespace Chapter8.Models
{
    public class ApiResponseModel
    {
        [JsonPropertyName("lat")]
        public string Latitude { get; set; }

        [JsonPropertyName("lon")]
        public string Longitude { get; set; }

        [JsonPropertyName("display_name")]
        public string DisplayName { get; set; }

        [JsonPropertyName("display_place")]
        public string DisplayPlace { get; set; }
    }
}
