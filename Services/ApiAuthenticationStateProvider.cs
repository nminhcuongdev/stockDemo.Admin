using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;

namespace StockDemo.Admin.Services;

/// <summary>
/// Bridges <see cref="UserSession"/> into Blazor's authorization system so
/// &lt;AuthorizeView&gt; and [Authorize] pages reflect the JWT session.
/// </summary>
public class ApiAuthenticationStateProvider : AuthenticationStateProvider
{
    private static readonly AuthenticationState Anonymous =
        new(new ClaimsPrincipal(new ClaimsIdentity()));

    private readonly UserSession session;

    public ApiAuthenticationStateProvider(UserSession session) => this.session = session;

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        await session.EnsureLoadedAsync();

        if (!session.IsAuthenticated || session.Current is null)
        {
            return Anonymous;
        }

        var user = session.Current;
        var identity = new ClaimsIdentity(new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
            new Claim(ClaimTypes.Name, user.Username),
            new Claim("FullName", user.FullName),
            new Claim(ClaimTypes.Role, user.Role),
        }, authenticationType: "jwt");

        return new AuthenticationState(new ClaimsPrincipal(identity));
    }

    /// <summary>Call after a successful login or logout to refresh the UI.</summary>
    public void NotifyAuthenticationStateChanged() =>
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
}
