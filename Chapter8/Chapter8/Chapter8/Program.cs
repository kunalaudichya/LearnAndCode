using Chapter8.Application;
using Chapter8.Services;
using Chapter8.Services.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Chapter8
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            HttpClient client = new HttpClient();

            IGeocodingClient locationIqService = new GeocodingClient(client, config);
            IGeoLocationService geoService = new GeoLocationService(locationIqService);

            var handler = new LocationHandler();
            var display = new ConsoleDisplayService();

            var app = new GeocodingApplication(geoService, handler, display);

            await app.Run();
        }
    }
}