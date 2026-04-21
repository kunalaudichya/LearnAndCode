using Chapter8.Models;
using Chapter8.Services;

namespace Chapter8.Tests;

public class LocationHandlerTests
{
    [Fact]
    public void HandleResults_NoResults_ReturnsNull()
    {
        var handler = new LocationHandler();

        var selected = handler.HandleResults(new List<GeoLocation>(), choice: 1);

        Assert.Null(selected);
    }

    [Fact]
    public void HandleResults_SingleResult_ReturnsThatResult_IgnoresChoice()
    {
        var handler = new LocationHandler();
        var only = new GeoLocation { Latitude = 1, Longitude = 2, Name = "A", Address = "Addr" };

        var selected = handler.HandleResults(new List<GeoLocation> { only }, choice: null);

        Assert.Same(only, selected);
    }

    [Fact]
    public void HandleResults_MultipleResults_ValidChoice_ReturnsChosen1BasedIndex()
    {
        var handler = new LocationHandler();
        var first = new GeoLocation { Latitude = 1, Longitude = 2, Name = "A", Address = "A1" };
        var second = new GeoLocation { Latitude = 3, Longitude = 4, Name = "B", Address = "B1" };

        var selected = handler.HandleResults(new List<GeoLocation> { first, second }, choice: 2);

        Assert.Same(second, selected);
    }

    [Theory]
    [InlineData(null)]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(3)]
    public void HandleResults_MultipleResults_InvalidChoice_ReturnsNull(int? choice)
    {
        var handler = new LocationHandler();
        var results = new List<GeoLocation>
        {
            new() { Latitude = 1, Longitude = 2, Name = "A", Address = "A1" },
            new() { Latitude = 3, Longitude = 4, Name = "B", Address = "B1" }
        };

        var selected = handler.HandleResults(results, choice);

        Assert.Null(selected);
    }
}
