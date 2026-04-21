using Chapter8.Models;

namespace Chapter8.Services.Interfaces
{
    public interface IGeocodingClient
    {
        Task<List<ApiResponseModel>> SearchLocation(string query);
    }
}
