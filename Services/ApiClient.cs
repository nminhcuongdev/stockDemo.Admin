using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using StockDemo.Admin.Models;

namespace StockDemo.Admin.Services;

/// <summary>
/// Thin wrapper over the StockDemo.API HttpClient: attaches the JWT bearer token and
/// unwraps the ApiResponse&lt;T&gt; envelope into a uniform result.
/// </summary>
public class ApiClient
{
    private static readonly JsonSerializerOptions JsonOptions = new(JsonSerializerDefaults.Web);

    private readonly IHttpClientFactory httpClientFactory;
    private readonly UserSession session;

    public ApiClient(IHttpClientFactory httpClientFactory, UserSession session)
    {
        this.httpClientFactory = httpClientFactory;
        this.session = session;
    }

    private async Task<HttpClient> CreateClientAsync()
    {
        await session.EnsureLoadedAsync();
        var client = httpClientFactory.CreateClient("StockDemoApi");
        if (session.Token is { Length: > 0 } token)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
        return client;
    }

    public async Task<ApiResponse<T>> GetAsync<T>(string url)
        => await SendAsync<T>(HttpMethod.Get, url, null);

    public async Task<ApiResponse<T>> PostAsync<T>(string url, object? body)
        => await SendAsync<T>(HttpMethod.Post, url, body);

    public async Task<ApiResponse<T>> PutAsync<T>(string url, object? body)
        => await SendAsync<T>(HttpMethod.Put, url, body);

    public async Task<ApiResponse<T>> DeleteAsync<T>(string url)
        => await SendAsync<T>(HttpMethod.Delete, url, null);

    private async Task<ApiResponse<T>> SendAsync<T>(HttpMethod method, string url, object? body)
    {
        try
        {
            var client = await CreateClientAsync();
            using var request = new HttpRequestMessage(method, url);
            if (body is not null)
            {
                request.Content = JsonContent.Create(body, options: JsonOptions);
            }

            using var response = await client.SendAsync(request);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                return Fail<T>("Phiên đăng nhập đã hết hạn hoặc không có quyền truy cập.");
            }

            var raw = await response.Content.ReadAsStringAsync();

            // The API wraps most responses in ApiResponse<T>. Try that first.
            try
            {
                var payload = JsonSerializer.Deserialize<ApiResponse<T>>(raw, JsonOptions);
                if (payload is not null)
                {
                    return payload;
                }
            }
            catch (JsonException)
            {
                // Not an ApiResponse envelope — likely an ASP.NET ValidationProblemDetails.
            }

            if (!response.IsSuccessStatusCode)
            {
                return Fail<T>(ExtractProblemMessage(raw, (int)response.StatusCode));
            }

            return new ApiResponse<T> { Success = true };
        }
        catch (HttpRequestException ex)
        {
            return Fail<T>($"Không kết nối được tới máy chủ API: {ex.Message}");
        }
        catch (Exception ex)
        {
            return Fail<T>($"Đã xảy ra lỗi: {ex.Message}");
        }
    }

    private static ApiResponse<T> Fail<T>(string message) =>
        new() { Success = false, Message = message };

    /// <summary>Turns an ASP.NET ValidationProblemDetails body into a readable message.</summary>
    private static string ExtractProblemMessage(string raw, int statusCode)
    {
        try
        {
            using var doc = JsonDocument.Parse(raw);
            var root = doc.RootElement;

            if (root.TryGetProperty("errors", out var errors) && errors.ValueKind == JsonValueKind.Object)
            {
                var messages = new List<string>();
                foreach (var field in errors.EnumerateObject())
                {
                    if (field.Value.ValueKind == JsonValueKind.Array)
                    {
                        foreach (var msg in field.Value.EnumerateArray())
                        {
                            var text = msg.GetString();
                            if (!string.IsNullOrWhiteSpace(text)) messages.Add(text);
                        }
                    }
                }
                if (messages.Count > 0) return string.Join(" ", messages);
            }

            if (root.TryGetProperty("title", out var title) && title.ValueKind == JsonValueKind.String)
            {
                return title.GetString() ?? $"Lỗi máy chủ ({statusCode}).";
            }
        }
        catch (JsonException)
        {
            // Fall through to the generic message.
        }

        return $"Lỗi máy chủ ({statusCode}).";
    }
}
