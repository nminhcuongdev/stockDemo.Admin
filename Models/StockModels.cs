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

public class StockInDto
{
    public int StockInId { get; set; }
    public string? StockInCode { get; set; }
    public int ProductId { get; set; }
    public ProductDto? Product { get; set; }
    public int LocationId { get; set; }
    public LocationDto? Location { get; set; }
    public int Quantity { get; set; }
    public string? QRCode { get; set; }
    public int CreatedBy { get; set; }
    public UserDto? User { get; set; }
    public DateTime CreatedDate { get; set; }
}

public class StockOutDto
{
    public int StockOutId { get; set; }
    public string? StockOutCode { get; set; }
    public int ProductId { get; set; }
    public ProductDto? Product { get; set; }
    public int LocationId { get; set; }
    public LocationDto? Location { get; set; }
    public int Quantity { get; set; }
    public string? QRCode { get; set; }
    public int CreatedBy { get; set; }
    public UserDto? User { get; set; }
    public DateTime CreatedDate { get; set; }
}

public class StockTransferDto
{
    public int StockTransferId { get; set; }
    public int ProductId { get; set; }
    public ProductDto? Product { get; set; }
    public int FromLocationId { get; set; }
    public LocationDto? FromLocation { get; set; }
    public int ToLocationId { get; set; }
    public LocationDto? ToLocation { get; set; }
    public int Quantity { get; set; }
    public string? QRCode { get; set; }
    public int CreatedBy { get; set; }
    public UserDto? User { get; set; }
    public DateTime CreatedDate { get; set; }
}

public class TransferStockDto
{
    public int SourceStockId { get; set; }
    public int ToLocationId { get; set; }
    public int Quantity { get; set; }
    public int CreatedBy { get; set; }
}
