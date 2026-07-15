using StockDemo.Admin.Models;

namespace StockDemo.Admin.Services;

/// <summary>Read access to stock-in and stock-out history (paginated endpoints).</summary>
public class MovementService
{
    // The list endpoints paginate; request a large page so the admin sees everything.
    private const int PageSize = 1000;

    private readonly ApiClient api;
    public MovementService(ApiClient api) => this.api = api;

    public async Task<ApiResponse<List<StockInDto>>> GetStockInsAsync()
    {
        var paged = await api.GetAsync<PagedResult<StockInDto>>($"api/stockins?pageSize={PageSize}");
        return Unwrap(paged);
    }

    public async Task<ApiResponse<List<StockOutDto>>> GetStockOutsAsync()
    {
        var paged = await api.GetAsync<PagedResult<StockOutDto>>($"api/stockouts?pageSize={PageSize}");
        return Unwrap(paged);
    }

    private static ApiResponse<List<T>> Unwrap<T>(ApiResponse<PagedResult<T>> paged) => new()
    {
        Success = paged.Success,
        Message = paged.Message,
        Errors = paged.Errors,
        Data = paged.Data?.Items ?? new List<T>(),
    };
}
