using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor.Services;
using StockDemo.Admin.Components;
using StockDemo.Admin.Services;

var builder = WebApplication.CreateBuilder(args);

// Blazor + interactive server components.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// MudBlazor UI.
builder.Services.AddMudServices();

// Typed HttpClient pointing at the StockDemo.API backend.
var apiBaseUrl = builder.Configuration["Api:BaseUrl"] ?? "http://localhost:5000/";
builder.Services.AddHttpClient("StockDemoApi", client =>
{
    client.BaseAddress = new Uri(apiBaseUrl);
});

// Auth: session-backed JWT + a custom AuthenticationStateProvider.
builder.Services.AddScoped<UserSession>();
builder.Services.AddScoped<LocalizationService>();
builder.Services.AddScoped<AuthenticationStateProvider, ApiAuthenticationStateProvider>();
builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();

// API-backed data services.
builder.Services.AddScoped<ApiClient>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<LocationService>();
builder.Services.AddScoped<StockService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<DashboardService>();
builder.Services.AddScoped<MovementService>();
builder.Services.AddScoped<TransferService>();
builder.Services.AddScoped<DeliveryOrderService>();
builder.Services.AddScoped<ReportService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
