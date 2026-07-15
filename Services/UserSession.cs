using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using StockDemo.Admin.Models;

namespace StockDemo.Admin.Services;

/// <summary>
/// Holds the signed-in user for the current circuit and persists it in the browser's
/// protected local storage so a page refresh keeps the session.
/// </summary>
public class UserSession
{
    private const string StorageKey = "stockdemo_admin_session";
    private readonly ProtectedLocalStorage storage;
    private bool loaded;

    public UserSession(ProtectedLocalStorage storage) => this.storage = storage;

    public LoginResponse? Current { get; private set; }

    public bool IsAuthenticated => Current is not null && Current.ExpiresAt > DateTime.Now;

    public string? Token => IsAuthenticated ? Current!.Token : null;

    /// <summary>Loads the persisted session on first use (safe to call repeatedly).</summary>
    public async Task EnsureLoadedAsync()
    {
        if (loaded) return;
        try
        {
            var result = await storage.GetAsync<LoginResponse>(StorageKey);
            if (result.Success && result.Value is not null)
            {
                Current = result.Value;
            }
        }
        catch
        {
            // JS interop is unavailable during prerender; the session loads once interactive.
        }
        loaded = true;
    }

    public async Task SignInAsync(LoginResponse login)
    {
        Current = login;
        loaded = true;
        await storage.SetAsync(StorageKey, login);
    }

    public async Task SignOutAsync()
    {
        Current = null;
        loaded = true;
        try
        {
            await storage.DeleteAsync(StorageKey);
        }
        catch
        {
            // Ignore storage errors on sign-out.
        }
    }
}
