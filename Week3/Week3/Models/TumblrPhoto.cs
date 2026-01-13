using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Week3.Models
{
    /// <summary>
    /// Represents an individual image entry within a Tumblr photoset.
    /// </summary>
    public class TumblrPhoto
    {
        [JsonPropertyName("photo-url-1280")]
        public string PhotoUrl1280 { get; set; }
    }
}
