using System.ComponentModel.DataAnnotations;

namespace StockDemo.Admin.Models;

public class UserDto
{
    public int UserId { get; set; }
    public string Username { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? LastLoginDate { get; set; }
}

public class CreateUserDto
{
    [Required(ErrorMessage = "Tên đăng nhập là bắt buộc")]
    [MaxLength(50)]
    public string Username { get; set; } = string.Empty;

    [Required(ErrorMessage = "Mật khẩu là bắt buộc")]
    [MinLength(6, ErrorMessage = "Mật khẩu tối thiểu 6 ký tự")]
    public string Password { get; set; } = string.Empty;

    [Required(ErrorMessage = "Họ tên là bắt buộc")]
    [MaxLength(100)]
    public string FullName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Vai trò là bắt buộc")]
    public string Role { get; set; } = "Staff";
}

public class UpdateUserDto
{
    [MaxLength(100)]
    public string? FullName { get; set; }

    public string? Role { get; set; }

    public bool? IsActive { get; set; }
}
