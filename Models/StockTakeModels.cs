namespace StockDemo.Admin.Models;

public class StockTakeDto
{
    public int StockTakeId { get; set; }
    public int LocationId { get; set; }
    public LocationDto? Location { get; set; }
    public string Status { get; set; } = "InProgress";
    public string? Note { get; set; }
    public int CreatedBy { get; set; }
    public UserDto? User { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? CompletedDate { get; set; }
    public List<StockTakeItemDto> Items { get; set; } = new();

    public bool IsCompleted => Status == "Completed";

    /// <summary>Lines whose counted quantity differs from what the system believed.</summary>
    public int VarianceLineCount => Items.Count(i => i.Variance != 0);

    /// <summary>Net units gained (positive) or lost (negative) across the session.</summary>
    public int NetVariance => Items.Sum(i => i.Variance);
}

public class StockTakeItemDto
{
    public int StockTakeItemId { get; set; }
    public int ProductId { get; set; }
    public ProductDto? Product { get; set; }
    public int SystemQuantity { get; set; }
    public int CountedQuantity { get; set; }
    public int Variance { get; set; }
}

public class CreateStockTakeDto
{
    public int LocationId { get; set; }
    public string? Note { get; set; }
    public int CreatedBy { get; set; }
    public List<StockTakeCountLineDto> Items { get; set; } = new();
}

public class StockTakeCountLineDto
{
    public int ProductId { get; set; }
    public int CountedQuantity { get; set; }
}
