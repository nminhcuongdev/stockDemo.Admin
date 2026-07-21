using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace StockDemo.Admin.Services;

/// <summary>
/// Lightweight in-memory localization (vi/en) with instant switching. The chosen
/// culture is persisted in protected local storage; components re-render via
/// <see cref="OnChanged"/> without a full page reload.
/// </summary>
public class LocalizationService
{
    public const string DefaultCulture = "vi";
    private const string StorageKey = "stockdemo_admin_culture";

    private readonly ProtectedLocalStorage storage;
    private bool loaded;

    public LocalizationService(ProtectedLocalStorage storage) => this.storage = storage;

    public string Culture { get; private set; } = DefaultCulture;

    public event Action? OnChanged;

    /// <summary>Localized lookup; falls back to the key when a translation is missing.</summary>
    public string this[string key] => Translations.Get(Culture, key);

    public async Task EnsureLoadedAsync()
    {
        if (loaded) return;
        loaded = true;
        try
        {
            var result = await storage.GetAsync<string>(StorageKey);
            if (result.Success && (result.Value == "vi" || result.Value == "en") && result.Value != Culture)
            {
                Culture = result.Value;
                OnChanged?.Invoke();
            }
        }
        catch
        {
            // JS interop unavailable during prerender; stays on the default culture.
        }
    }

    public async Task SetCultureAsync(string culture)
    {
        if (culture != "vi" && culture != "en") return;
        if (culture == Culture) return;

        Culture = culture;
        // Update the UI immediately; persistence must not gate the visible switch.
        OnChanged?.Invoke();

        try
        {
            await storage.SetAsync(StorageKey, culture);
        }
        catch
        {
            // Ignore storage errors; the in-memory switch still applies.
        }
    }
}
