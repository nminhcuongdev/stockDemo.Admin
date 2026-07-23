using StockDemo.Admin.Models;

namespace StockDemo.Admin.Services;

public class StockTakeService
{
    private readonly ApiClient api;
    public StockTakeService(ApiClient api) => this.api = api;

    public Task<ApiResponse<List<StockTakeDto>>> GetAllAsync()
        => api.GetAsync<List<StockTakeDto>>("api/stocktakes");

    public Task<ApiResponse<StockTakeDto>> GetByIdAsync(int id)
        => api.GetAsync<StockTakeDto>($"api/stocktakes/{id}");

    /// <summary>Opens a session and records the variances; stock is untouched until Complete.</summary>
    public Task<ApiResponse<StockTakeDto>> CreateAsync(CreateStockTakeDto dto)
        => api.PostAsync<StockTakeDto>("api/stocktakes", dto);

    /// <summary>Reconciles on-hand quantities to the counted figures. Not reversible.</summary>
    public Task<ApiResponse<StockTakeDto>> CompleteAsync(int id)
        => api.PostAsync<StockTakeDto>($"api/stocktakes/{id}/complete", new { });
}
