using Chapter8.Models;
using Chapter8.Services;
using Chapter8.Services.Interfaces;

namespace Chapter8.Tests;

public class GeoLocationServiceTests
{
    [Fact]
    public async Task GetCoordinates_MapsValidApiResults_AndSkipsInvalidCoordinates()
    {
        var client = new FakeGeocodingClient(new List<ApiResponseModel>
        {
            new()
            {
                Latitude = "22.5726",
                Longitude = "88.3639",
                DisplayPlace = "Kolkata",
                DisplayName = "Kolkata, West Bengal, India"
            },
            new()
            {
                Latitude = "not-a-number",
                Longitude = "88.0",
                DisplayPlace = "Bad",
                DisplayName = "Bad"
            }
        });

        var service = new GeoLocationService(client);

        var results = await service.GetCoordinates("kolkata");

        Assert.Single(results);
        Assert.Equal(22.5726, results[0].Latitude, precision: 4);
        Assert.Equal(88.3639, results[0].Longitude, precision: 4);
        Assert.Equal("Kolkata", results[0].Name);
        Assert.Equal("Kolkata, West Bengal, India", results[0].Address);
    }

    private sealed class FakeGeocodingClient : IGeocodingClient
    {
        private readonly List<ApiResponseModel> _results;

        public FakeGeocodingClient(List<ApiResponseModel> results)
        {
            _results = results;
        }

        public Task<List<ApiResponseModel>> SearchLocation(string query)
        {
            return Task.FromResult(_results);
        }
    }
}

