using StockDemo.Admin.Models;

namespace StockDemo.Admin.Services;

public class LocationService
{
    private readonly ApiClient api;
    public LocationService(ApiClient api) => this.api = api;

    public Task<ApiResponse<List<LocationDto>>> GetAllAsync()
        => api.GetAsync<List<LocationDto>>("api/locations");

    public Task<ApiResponse<LocationDto>> CreateAsync(CreateLocationDto dto)
        => api.PostAsync<LocationDto>("api/locations", dto);

    public Task<ApiResponse<LocationDto>> UpdateAsync(int id, UpdateLocationDto dto)
        => api.PutAsync<LocationDto>($"api/locations/{id}", dto);

    public Task<ApiResponse<object>> DeleteAsync(int id)
        => api.DeleteAsync<object>($"api/locations/{id}");
}
