using Chapter8.Services;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Text;

namespace Chapter8.Tests;

public class GeocodingClientTests
{

    [Fact]
    public async Task SearchLocation_WhenSuccessAndJson_ReturnsDeserializedResults()
    {
        var json = """
            [
              {
                "lat": "12.34",
                "lon": "56.78",
                "display_name": "Addr",
                "display_place": "Place"
              }
            ]
            """;

        Uri? requested = null;

        var handler = new FakeHttpMessageHandler(req =>
        {
            requested = req.RequestUri;
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };
        });

        var httpClient = new HttpClient(handler);
        var config = CreateConfig(apiKey: "abc", baseUrl: "https://example.test/search");
        var client = new GeocodingClient(httpClient, config);

        var results = await client.SearchLocation("delhi");

        Assert.Single(results);
        Assert.Equal("12.34", results[0].Latitude);
        Assert.Equal("56.78", results[0].Longitude);
        Assert.Equal("Addr", results[0].DisplayName);
        Assert.Equal("Place", results[0].DisplayPlace);
    }

    [Fact]
    public async Task SearchLocation_WhenHttpNotSuccess_ReturnsEmptyList()
    {
        var handler = new FakeHttpMessageHandler(_ =>
            new HttpResponseMessage(HttpStatusCode.BadRequest)
            {
                Content = new StringContent("{}", Encoding.UTF8, "application/json")
            });

        var httpClient = new HttpClient(handler);
        var config = CreateConfig(apiKey: "k", baseUrl: "https://example.test/search");
        var client = new GeocodingClient(httpClient, config);

        var results = await client.SearchLocation("jaipur");

        Assert.Empty(results);
    }

    private static IConfiguration CreateConfig(string apiKey, string baseUrl)
    {
        return new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["API_KEY"] = apiKey,
                ["BASE_URL"] = baseUrl
            })
            .Build();
    }

    public class FakeHttpMessageHandler : HttpMessageHandler
    {
        private readonly Func<HttpRequestMessage, HttpResponseMessage> _handler;

        public FakeHttpMessageHandler(Func<HttpRequestMessage, HttpResponseMessage> handler)
        {
            _handler = handler;
        }

        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            return Task.FromResult(_handler(request));
        }
    }
}

