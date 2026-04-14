using Chapter8.Models;
using Chapter8.Services;
using Chapter8.Services.Interfaces;

namespace Chapter8.Application
{
    public class GeocodingApplication
    {
        private readonly IGeoLocationService _geoLocationService;
        private readonly LocationHandler _locationHandler;
        private readonly ConsoleDisplayService _consoleDisplayService;

        public GeocodingApplication(
            IGeoLocationService geoLocationService,
            LocationHandler locationHandler,
            ConsoleDisplayService consoleDisplayService)
        {
            _geoLocationService = geoLocationService;
            _locationHandler = locationHandler;
            _consoleDisplayService = consoleDisplayService;
        }

        public async Task Run()
        {
            var input = GetInput();

            var results = await GetResults(input);

            HandleResults(results);
        }

        private string? GetInput()
        {
            Console.Write("Enter location: ");
            var input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Invalid input");
                return null;
            }

            return input;
        }

        private async Task<List<GeoLocation>> GetResults(string? input)
        {
            if (input == null)
                return new List<GeoLocation>();

            var results = await _geoLocationService.GetCoordinates(input);

            if (results.Count == 0)
                Console.WriteLine("No locations found");

            return results;
        }

        private void HandleResults(List<GeoLocation> results)
        {
            if (results.Count == 0)
                return;

            if (results.Count == 1)
            {
                _consoleDisplayService.ShowLocation(results[0]);
                return;
            }

            Console.WriteLine("\nMultiple locations found:");

            for (int i = 0; i < results.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {results[i].Address}");
            }

            Console.WriteLine("\nSelect a location (enter number): ");

            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Invalid selection");
                return;
            }

            var selected = _locationHandler.HandleResults(results, choice);

            if (selected == null)
            {
                Console.WriteLine("Invalid selection");
                return;
            }

            _consoleDisplayService.ShowLocation(selected);
        }
    }
}
