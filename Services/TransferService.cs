using StockDemo.Admin.Models;

namespace StockDemo.Admin.Services;

public class TransferService
{
    private readonly ApiClient api;
    public TransferService(ApiClient api) => this.api = api;

    public Task<ApiResponse<List<StockTransferDto>>> GetAllAsync()
        => api.GetAsync<List<StockTransferDto>>("api/stocktransfers");

    public Task<ApiResponse<StockTransferDto>> CreateAsync(TransferStockDto dto)
        => api.PostAsync<StockTransferDto>("api/stocktransfers", dto);
}
