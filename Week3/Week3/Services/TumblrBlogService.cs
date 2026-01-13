using Week3.Models;
using Week3.Repositories;

namespace Week3.Services
{
    public class TumblrBlogService : IBlogService
    {
        private readonly ITumblrRepository _repository;
        public TumblrBlogService(ITumblrRepository repository)
        {
            _repository = repository;
        }
        public async Task ProcessBlogRequestAsync(string blogName, string rawRange)
        {
            PostRange range = ValidateAndParseRange(rawRange);

            int apiStart = range.Start - 1; //Convert to follow 0 based indexing
            int count = (range.End - range.Start) + 1;

            Console.WriteLine($"Fetching data for '{blogName}'...");

            TumblrApiResponse data = await _repository.FetchBlogDataAsync(blogName, apiStart, count);

            if (data?.Tumblelog == null)
            {
                throw new Exception("Blog not found or the API didn't return anything");
            }

            DisplayBlogResults(data, range);
        }

        private PostRange ValidateAndParseRange(string rawRange)
        {
            var parts = rawRange.Split('-');

            if (parts.Length != 2 || !int.TryParse(parts[0], out int start) || !int.TryParse(parts[1], out int end))
                throw new Exception("Invalid format. Please use 'Start-End' (Ex: 1-5).");

            if (start < 1) 
                throw new Exception("Start number must be at least 1.");

            if (start > end) 
                throw new Exception("Start number cannot be greater than the end number.");

            return new PostRange
            {
                Start = start,
                End = end,
            };
        }

        private static void DisplayBlogResults(TumblrApiResponse data, PostRange range)
        {
            Console.WriteLine($"\nTitle: {data.Tumblelog.Title}");
            Console.WriteLine($"Name: {data.Tumblelog.Name}");
            Console.WriteLine($"Description: {data.Tumblelog.Description}");
            Console.WriteLine($"No of posts: {data.TotalPosts}\n");

            int currentPostNo = range.Start;

            foreach (var post in data.Posts)
            {
                Console.Write($"{currentPostNo}. ");

                PrintPostImages(post);

                currentPostNo++;
            }
        }

        private static void PrintPostImages(TumblrPost post)
        {
            //If post contains multiple photos.
            if (post.Photos?.Any() == true)
            {
                foreach (var photo in post.Photos)
                {
                    Console.WriteLine(photo.PhotoUrl1280);
                }
            }
            //If a post only has a single photo.
            else if (!string.IsNullOrEmpty(post.PhotoUrl1280))
            {
                Console.WriteLine(post.PhotoUrl1280);
            }
            else
            {
                Console.WriteLine("[No Photo URL available]");
            }
        }
    }
}
