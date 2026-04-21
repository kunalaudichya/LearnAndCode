using Chapter8.Models;

namespace Chapter8.Services.Interfaces
{
    public interface IGeoLocationService
    {
        Task<List<GeoLocation>> GetCoordinates(string location);
    }
}
