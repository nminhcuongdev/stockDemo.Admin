using StockDemo.Admin.Models;

namespace StockDemo.Admin.Services;

public class DeliveryOrderService
{
    private readonly ApiClient api;
    public DeliveryOrderService(ApiClient api) => this.api = api;

    public Task<ApiResponse<List<DeliveryOrderDto>>> GetAllAsync()
        => api.GetAsync<List<DeliveryOrderDto>>("api/deliveryorders");
}
