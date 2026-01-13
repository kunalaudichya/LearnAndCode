using System.Text.Json.Serialization;

namespace Week3.Models
{
    /// <summary>
    /// Represents the Main container of Tumblr Api Response
    /// </summary>
    public class TumblrApiResponse
    {
        [JsonPropertyName("tumblelog")]
        public TumbleLog Tumblelog { get; set; }

        [JsonPropertyName("posts-total")]
        public int TotalPosts { get; set; }

        [JsonPropertyName("posts")]
        public List<TumblrPost> Posts { get; set; } = new List<TumblrPost>();
    }
}
