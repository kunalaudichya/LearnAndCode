using Chapter8.Models;

namespace Chapter8.Services
{
    public class ConsoleDisplayService
    {
        public void ShowLocation(GeoLocation loc)
        {
            Console.WriteLine("\n--- LOCATION DETAILS ---");
            Console.WriteLine($"Name      : {loc.Name}");
            Console.WriteLine($"Address   : {loc.Address}");
            Console.WriteLine($"Latitude  : {loc.Latitude}");
            Console.WriteLine($"Longitude : {loc.Longitude}");
        }
    }
}
