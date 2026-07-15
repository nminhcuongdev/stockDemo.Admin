using StockDemo.Admin.Models;

namespace StockDemo.Admin.Services;

public class StockService
{
    private readonly ApiClient api;
    public StockService(ApiClient api) => this.api = api;

    public Task<ApiResponse<List<StockDto>>> GetAllAsync()
        => api.GetAsync<List<StockDto>>("api/stocks");
}
