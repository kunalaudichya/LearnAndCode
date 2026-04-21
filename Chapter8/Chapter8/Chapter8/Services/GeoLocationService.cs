using Chapter8.Models;
using Chapter8.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace Chapter8.Services
{
    public class GeoLocationService: IGeoLocationService
    {
        private readonly IGeocodingClient _geoCodingClient;
        public GeoLocationService(IGeocodingClient geoCodingClient)
        {
            _geoCodingClient = geoCodingClient;
        }

        public async Task<List<GeoLocation>> GetCoordinates(string location)
        {
            var apiResults = await _geoCodingClient.SearchLocation(location);

            return apiResults
                .Select(MapToGeoLocation)
                .Where(x => x != null)
                .ToList();
        }

        private GeoLocation? MapToGeoLocation(ApiResponseModel x)
        {
            if (!double.TryParse(x.Latitude, out double lat) ||
                !double.TryParse(x.Longitude, out double lon))
                return null;

            return new GeoLocation
            {
                Latitude = lat,
                Longitude = lon,
                Name = x.DisplayPlace,
                Address = x.DisplayName
            };
        }
    }
}
