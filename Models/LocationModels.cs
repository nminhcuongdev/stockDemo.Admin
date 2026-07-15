using System.ComponentModel.DataAnnotations;

namespace StockDemo.Admin.Models;

public class LocationDto
{
    public int LocationId { get; set; }
    public string LocationCode { get; set; } = string.Empty;
    public string LocationName { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
}

public class CreateLocationDto
{
    [Required(ErrorMessage = "Mã vị trí là bắt buộc")]
    [MaxLength(50)]
    public string LocationCode { get; set; } = string.Empty;

    [Required(ErrorMessage = "Tên vị trí là bắt buộc")]
    [MaxLength(200)]
    public string LocationName { get; set; } = string.Empty;
}

public class UpdateLocationDto
{
    [MaxLength(50)]
    public string? LocationCode { get; set; }

    [MaxLength(200)]
    public string? LocationName { get; set; }

    public bool? IsActive { get; set; }
}
