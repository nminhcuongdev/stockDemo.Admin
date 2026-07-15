using StockDemo.Admin.Models;

namespace StockDemo.Admin.Services;

public record DashboardStats(
    int ProductCount,
    int LocationCount,
    int TotalQuantity,
    int LowStockCount);

public class DashboardService
{
    private readonly ApiClient api;
    public DashboardService(ApiClient api) => this.api = api;

    public Task<ApiResponse<List<LowStockItemDto>>> GetLowStockAsync()
        => api.GetAsync<List<LowStockItemDto>>("api/stockalerts/low-stock");

    /// <summary>Aggregates a few headline numbers from the existing list endpoints.</summary>
    public async Task<DashboardStats> GetStatsAsync()
    {
        var products = await api.GetAsync<List<ProductDto>>("api/products");
        var locations = await api.GetAsync<List<LocationDto>>("api/locations");
        var stocks = await api.GetAsync<List<StockDto>>("api/stocks");
        var lowStock = await api.GetAsync<List<LowStockItemDto>>("api/stockalerts/low-stock");

        return new DashboardStats(
            ProductCount: products.Data?.Count ?? 0,
            LocationCount: locations.Data?.Count ?? 0,
            TotalQuantity: stocks.Data?.Sum(s => s.Quantity) ?? 0,
            LowStockCount: lowStock.Data?.Count ?? 0);
    }
}
