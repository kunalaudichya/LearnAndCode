namespace Week3.Services
{
    public interface IBlogService
    {
        Task ProcessBlogRequestAsync(string blogName, string rawRange);
    }
}
