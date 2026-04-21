using System.Net;
using System.Text;
using Week3.Repositories;

namespace Week3.Tests;

public class TumblrRepositoryTests
{
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

    private HttpClient CreateClient(Func<HttpRequestMessage, HttpResponseMessage> handler)
    {
        return new HttpClient(new FakeHttpMessageHandler(handler));
    }

    private class FakeFactory : IHttpClientFactory
    {
        private readonly HttpClient _client;

        public FakeFactory(HttpClient client)
        {
            _client = client;
        }

        public HttpClient CreateClient(string name) => _client;
    }

    [Fact]
    public async Task FetchBlogDataAsync_ParsesResponse_WhenApiReturnsValidJson()
    {
        var json = """
        var tumblr_api_read = {
            "tumblelog": { "Title": "My Blog", "Name": "myblog", "Description": "desc" },
            "posts-total": 7,
            "posts": [ { "photo-url-1280": "u1" } ]
        };
        """;

        var client = CreateClient(_ =>
            new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(json, Encoding.UTF8)
            });

        var repo = new TumblrRepository(new FakeFactory(client));

        var result = await repo.FetchBlogDataAsync("blog", 0, 1);

        Assert.Equal("My Blog", result.Tumblelog.Title);
        Assert.Equal(7, result.TotalPosts);
        Assert.Single(result.Posts);
    }

    [Fact]
    public async Task FetchBlogDataAsync_ThrowsException_WhenBlogDoesNotExist()
    {
        var client = CreateClient(_ =>
            new HttpResponseMessage(HttpStatusCode.NotFound));

        var repo = new TumblrRepository(new FakeFactory(client));

        await Assert.ThrowsAsync<Exception>(() =>
            repo.FetchBlogDataAsync("missing", 0, 1));
    }
}