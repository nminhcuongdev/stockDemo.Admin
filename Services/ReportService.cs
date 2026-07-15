using StockDemo.Admin.Models;

namespace StockDemo.Admin.Services;

public class ReportService
{
    private readonly ApiClient api;
    public ReportService(ApiClient api) => this.api = api;

    public Task<ApiResponse<StockMovementReportDto>> GetStockMovementAsync(DateTime from, DateTime to)
    {
        var f = from.ToString("yyyy-MM-dd");
        var t = to.ToString("yyyy-MM-dd");
        return api.GetAsync<StockMovementReportDto>($"api/reports/stock-movement?from={f}&to={t}");
    }
}
