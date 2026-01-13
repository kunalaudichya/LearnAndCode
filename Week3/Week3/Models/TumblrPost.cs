using System.Text.Json.Serialization;

namespace Week3.Models
{
    /// <summary>
    /// Represents a single post entry which may contain one or more images.
    /// </summary>
    public class TumblrPost
    {
        // For standard single photo posts
        [JsonPropertyName("photo-url-1280")]
        public string PhotoUrl1280 { get; set; }

        // For photosets (posts containing multiple photos)
        [JsonPropertyName("photos")]
        public List<TumblrPhoto> Photos { get; set; } = new List<TumblrPhoto>();
    }

}
