using StockDemo.Admin.Models;

namespace StockDemo.Admin.Services;

public class ProductService
{
    private readonly ApiClient api;
    public ProductService(ApiClient api) => this.api = api;

    public Task<ApiResponse<List<ProductDto>>> GetAllAsync()
        => api.GetAsync<List<ProductDto>>("api/products");

    public Task<ApiResponse<ProductDto>> CreateAsync(CreateProductDto dto)
        => api.PostAsync<ProductDto>("api/products", dto);

    public Task<ApiResponse<ProductDto>> UpdateAsync(int id, UpdateProductDto dto)
        => api.PutAsync<ProductDto>($"api/products/{id}", dto);

    public Task<ApiResponse<object>> DeleteAsync(int id)
        => api.DeleteAsync<object>($"api/products/{id}");
}
