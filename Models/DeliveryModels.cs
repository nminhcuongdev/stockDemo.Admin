namespace StockDemo.Admin.Models;

public class DeliveryOrderDto
{
    public int DeliveryOrderId { get; set; }
    public int ProductId { get; set; }
    public string PONumber { get; set; } = string.Empty;
    public DateTime DeliveryDate { get; set; }
    public int Quantity { get; set; }
    public string? QRCode { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public string Status { get; set; } = string.Empty;
    public ProductDto? Product { get; set; }
}
