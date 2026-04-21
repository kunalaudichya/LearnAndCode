using Microsoft.Extensions.DependencyInjection;
using Week3.Repositories;
using Week3.Services;

namespace Week3
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var serviceProvider = ConfigureServices();
            var blogService = serviceProvider.GetRequiredService<IBlogService>();

            Console.Write("Enter Tumblr blog name: ");
            string blogName = Console.ReadLine();

            Console.Write("Enter post range (Ex: 1-5): ");
            string range = Console.ReadLine();

            try
            {
                if (blogName != null && range != null)
                    await blogService.ProcessBlogRequestAsync(blogName, range);
                else
                    throw new Exception("Input data cannot be null.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n[Error]: {ex.Message}");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        private static IServiceProvider ConfigureServices()
        {
            return new ServiceCollection()
                .AddScoped<IBlogService, TumblrBlogService>() // Configure dependency injection
                .AddScoped<ITumblrRepository, TumblrRepository>()
                .AddHttpClient() // Required to make API calls
                .BuildServiceProvider();
        }
    }
}
