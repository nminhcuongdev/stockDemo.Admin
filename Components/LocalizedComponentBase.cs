using Microsoft.AspNetCore.Components;
using StockDemo.Admin.Services;

namespace StockDemo.Admin.Components;

/// <summary>
/// Base class for pages/components that display localized text. Subscribes to
/// <see cref="LocalizationService.OnChanged"/> so the component re-renders instantly
/// when the language is switched. Use <c>@inherits LocalizedComponentBase</c> and
/// reference strings via <c>L["key"]</c>.
/// </summary>
public abstract class LocalizedComponentBase : ComponentBase, IDisposable
{
    [Inject] protected LocalizationService L { get; set; } = default!;

    // OnInitialized (sync) is separate from OnInitializedAsync, which pages override
    // for data loading — so subscribing here never clashes with a page's own init.
    protected override void OnInitialized() => L.OnChanged += HandleLanguageChanged;

    private void HandleLanguageChanged() => InvokeAsync(StateHasChanged);

    public virtual void Dispose() => L.OnChanged -= HandleLanguageChanged;
}
