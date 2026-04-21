using Week3.Models;

namespace Week3.Repositories
{
    public interface ITumblrRepository
    {
        Task<TumblrApiResponse> FetchBlogDataAsync(string blogName, int startIndex, int postCount);
    }
}
