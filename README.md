# StockDemo.Admin — Blazor Admin Panel

[![CI](https://github.com/nminhcuongdev/stockDemo.Admin/actions/workflows/ci.yml/badge.svg)](https://github.com/nminhcuongdev/stockDemo.Admin/actions/workflows/ci.yml)

A data-administration web app for the **StockDemo** warehouse system, built with
**ASP.NET Core Blazor Web App (.NET 8, Interactive Server)** and **MudBlazor**.
It consumes the existing **StockDemo.API** over HTTP with JWT authentication — no
duplicate business logic or database access.

## Features

- **JWT login** against `POST /api/users/login`; the token is stored in the browser's
  protected local storage and flows into a custom `AuthenticationStateProvider`, so
  `[Authorize]` pages and `<AuthorizeView>` work as usual.
- **Dashboard** — headline counts (products, locations, total on-hand quantity, low-stock
  count) plus a low-stock table.
- **Products** — full CRUD (create / edit / soft-delete) with search and paging.
- **Locations** — full CRUD with search and paging.
- **Stocks** — read-only on-hand view with product/location/QR search.
- **Low-stock alerts** — products below their reorder level.
- **Users** — list, create, edit (role / active), and deactivate.
- Light/dark theme toggle, responsive MudBlazor layout.

## Architecture

```
Components/
  Pages/       Login, Home (dashboard), Products, Locations, Stocks, LowStock, Users
  Dialogs/     ProductDialog, LocationDialog, UserDialog (add/edit forms)
  Layout/      MainLayout (MudBlazor chrome + auth), NavMenu
Models/        DTOs mirroring StockDemo.API's contracts + ApiResponse<T> envelope
Services/
  UserSession                    in-memory + ProtectedLocalStorage JWT session
  ApiAuthenticationStateProvider bridges the session into Blazor auth
  ApiClient                      HttpClient wrapper: attaches Bearer, unwraps ApiResponse<T>
  AuthService / *Service         one typed service per API area
```

## Configuration

`appsettings.json`:

```json
"Api": { "BaseUrl": "http://localhost:5000/" }
```

Point `Api:BaseUrl` at wherever StockDemo.API is running (the Docker Compose stack in
`../stockdemo.API` exposes it on host port 5000).

## Running

1. Start the backend (from `../stockdemo.API`): `docker compose up -d`
2. Run this app: `dotnet run`
3. Open the printed URL and sign in with a StockDemo user account.
