using StockDemo.Admin.Models;

namespace StockDemo.Admin.Services;

public class UserService
{
    private readonly ApiClient api;
    public UserService(ApiClient api) => this.api = api;

    public Task<ApiResponse<List<UserDto>>> GetAllAsync()
        => api.GetAsync<List<UserDto>>("api/users");

    public Task<ApiResponse<UserDto>> CreateAsync(CreateUserDto dto)
        => api.PostAsync<UserDto>("api/users", dto);

    public Task<ApiResponse<UserDto>> UpdateAsync(int id, UpdateUserDto dto)
        => api.PutAsync<UserDto>($"api/users/{id}", dto);

    public Task<ApiResponse<object>> DeleteAsync(int id)
        => api.DeleteAsync<object>($"api/users/{id}");
}
