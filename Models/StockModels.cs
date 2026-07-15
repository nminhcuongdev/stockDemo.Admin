namespace StockDemo.Admin.Models;

public class StockDto
{
    public int StockId { get; set; }
    public int ProductId { get; set; }
    public int LocationId { get; set; }
    public int Quantity { get; set; }
    public string? QRCode { get; set; }
    public DateTime LastUpdated { get; set; }
    public ProductDto? Product { get; set; }
    public LocationDto? Location { get; set; }
}

public class LowStockItemDto
{
    public int ProductId { get; set; }
    public ProductDto? Product { get; set; }
    public int CurrentQuantity { get; set; }
    public int MinQuantity { get; set; }
    public int? MaxQuantity { get; set; }
    public int Shortage { get; set; }
}
