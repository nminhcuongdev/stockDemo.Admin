using System.Net.Http.Json;
using System.Text.Json;
using StockDemo.Admin.Models;

namespace StockDemo.Admin.Services;

public class AuthService
{
    private static readonly JsonSerializerOptions JsonOptions = new(JsonSerializerDefaults.Web);

    private readonly IHttpClientFactory httpClientFactory;
    private readonly UserSession session;
    private readonly ApiAuthenticationStateProvider authStateProvider;

    public AuthService(
        IHttpClientFactory httpClientFactory,
        UserSession session,
        Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider authStateProvider)
    {
        this.httpClientFactory = httpClientFactory;
        this.session = session;
        this.authStateProvider = (ApiAuthenticationStateProvider)authStateProvider;
    }

    /// <summary>Attempts login; returns (success, errorMessage).</summary>
    public async Task<(bool Success, string? Error)> LoginAsync(LoginRequest request)
    {
        try
        {
            var client = httpClientFactory.CreateClient("StockDemoApi");
            using var response = await client.PostAsJsonAsync("api/users/login", request, JsonOptions);
            var payload = await response.Content.ReadFromJsonAsync<ApiResponse<LoginResponse>>(JsonOptions);

            if (payload is { Success: true, Data: not null })
            {
                await session.SignInAsync(payload.Data);
                authStateProvider.NotifyAuthenticationStateChanged();
                return (true, null);
            }

            return (false, payload?.Message ?? "Đăng nhập thất bại.");
        }
        catch (HttpRequestException ex)
        {
            return (false, $"Không kết nối được tới máy chủ API: {ex.Message}");
        }
        catch (Exception ex)
        {
            return (false, $"Đã xảy ra lỗi: {ex.Message}");
        }
    }

    public async Task LogoutAsync()
    {
        await session.SignOutAsync();
        authStateProvider.NotifyAuthenticationStateChanged();
    }
}
