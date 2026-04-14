using Chapter8.Models;

namespace Chapter8.Services
{
    public class LocationHandler
    {
        public GeoLocation? HandleResults(List<GeoLocation> results, int? choice)
        {
            if (!results.Any())
                return null;

            if (results.Count == 1)
                return results[0];

            if (choice == null || choice < 1 || choice > results.Count)
                return null;

            return results[choice.Value - 1];
        }
    }
}
