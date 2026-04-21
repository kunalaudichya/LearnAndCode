using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Week3.Models;
using Week3.Repositories;
using Week3.Services;
using Xunit;

namespace Week3.Tests
{
    public class TumblrBlogServiceTests
    {
        private class FakeTumblrRepository : ITumblrRepository
        {
            public string LastBlogName { get; private set; }
            public int LastStartIndex { get; private set; }
            public int LastPostCount { get; private set; }
            public int CallCount { get; private set; }

            public TumblrApiResponse ResponseToReturn { get; set; }

            public Task<TumblrApiResponse> FetchBlogDataAsync(string blogName, int startIndex, int postCount)
            {
                CallCount++;
                LastBlogName = blogName;
                LastStartIndex = startIndex;
                LastPostCount = postCount;
                return Task.FromResult(ResponseToReturn);
            }
        }

        [Theory]
        [InlineData("1-1", 0, 1)]
        [InlineData("1-5", 0, 5)]
        [InlineData("2-5", 1, 4)]
        [InlineData("10-12", 9, 3)]
        public async Task ProcessBlogRequestAsync_ValidRange_CallsRepositoryCorrectly(
        string rawRange,
        int expectedStart,
        int expectedCount)
        {
            var repo = new FakeTumblrRepository
            {
                ResponseToReturn = new TumblrApiResponse
                {
                    Tumblelog = new TumbleLog { Title = "t" },
                    Posts = new List<TumblrPost>()
                }
            };

            var service = new TumblrBlogService(repo);

            await service.ProcessBlogRequestAsync("blog", rawRange);

            Assert.Equal(1, repo.CallCount);
            Assert.Equal("blog", repo.LastBlogName);
            Assert.Equal(expectedStart, repo.LastStartIndex);
            Assert.Equal(expectedCount, repo.LastPostCount);
        }

        [Theory]
        [InlineData("")]
        [InlineData("1")]
        [InlineData("1-")]
        [InlineData("-5")]
        [InlineData("a-b")]
        [InlineData("1-five")]
        [InlineData("1-5-7")]
        public async Task ProcessBlogRequestAsync_InvalidFormat_ThrowsAndDoesNotCallRepository(string rawRange)
        {
            var repo = new FakeTumblrRepository();
            var service = new TumblrBlogService(repo);

            var ex = await Assert.ThrowsAsync<Exception>(() =>
                service.ProcessBlogRequestAsync("blog", rawRange));

            Assert.Contains("Invalid format", ex.Message);
            Assert.Equal(0, repo.CallCount);
        }

        [Theory]
        [InlineData("0-5")]
        public async Task ProcessBlogRequestAsync_StartLessThanOne_ThrowsAndDoesNotCallRepository(string rawRange)
        {
            var repo = new FakeTumblrRepository();
            var service = new TumblrBlogService(repo);

            var ex = await Assert.ThrowsAsync<Exception>(() =>
                service.ProcessBlogRequestAsync("blog", rawRange));

            Assert.Contains("at least 1", ex.Message);
            Assert.Equal(0, repo.CallCount);
        }

        [Theory]
        [InlineData("5-4")]
        [InlineData("10-1")]
        public async Task ProcessBlogRequestAsync_StartGreaterThanEnd_ThrowsAndDoesNotCallRepository(string rawRange)
        {
            var repo = new FakeTumblrRepository();
            var service = new TumblrBlogService(repo);

            var ex = await Assert.ThrowsAsync<Exception>(() =>
                service.ProcessBlogRequestAsync("blog", rawRange));

            Assert.Contains("cannot be greater", ex.Message);
            Assert.Equal(0, repo.CallCount);
        }

        [Fact]
        public async Task ProcessBlogRequestAsync_NullResponse_ThrowsException()
        {
            var repo = new FakeTumblrRepository
            {
                ResponseToReturn = null
            };

            var service = new TumblrBlogService(repo);

            await Assert.ThrowsAsync<Exception>(() =>
                service.ProcessBlogRequestAsync("blog", "1-1"));
        }

    }
}

