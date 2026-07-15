using System.ComponentModel.DataAnnotations;

namespace StockDemo.Admin.Models;

public class ProductDto
{
    public int ProductId { get; set; }
    public string ProductCode { get; set; } = string.Empty;
    public string ProductName { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string Unit { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public int MinQuantity { get; set; }
    public int? MaxQuantity { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
}

public class CreateProductDto
{
    [Required(ErrorMessage = "Mã sản phẩm là bắt buộc")]
    [MaxLength(50)]
    public string ProductCode { get; set; } = string.Empty;

    [Required(ErrorMessage = "Tên sản phẩm là bắt buộc")]
    [MaxLength(200)]
    public string ProductName { get; set; } = string.Empty;

    [MaxLength(500)]
    public string? Description { get; set; }

    [Required(ErrorMessage = "Đơn vị tính là bắt buộc")]
    [MaxLength(50)]
    public string Unit { get; set; } = string.Empty;

    [Range(0, int.MaxValue, ErrorMessage = "Định mức tối thiểu phải >= 0")]
    public int MinQuantity { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "Định mức tối đa phải >= 0")]
    public int? MaxQuantity { get; set; }
}

public class UpdateProductDto
{
    [MaxLength(50)]
    public string? ProductCode { get; set; }

    [MaxLength(200)]
    public string? ProductName { get; set; }

    [MaxLength(500)]
    public string? Description { get; set; }

    [MaxLength(50)]
    public string? Unit { get; set; }

    public bool? IsActive { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "Định mức tối thiểu phải >= 0")]
    public int? MinQuantity { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "Định mức tối đa phải >= 0")]
    public int? MaxQuantity { get; set; }
}
