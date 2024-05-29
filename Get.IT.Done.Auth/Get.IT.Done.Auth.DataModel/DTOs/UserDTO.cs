using Get.IT.Done.Auth.DataModel.Enums;
using System.ComponentModel.DataAnnotations;

namespace Get.IT.Done.Auth.DataModel.DTOs;

public class UserDTO
{
    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = string.Empty;

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;

    [DataType(DataType.ImageUrl)]
    public Uri? ProfilePicture { get; set; }

    [MaxLength(50)]
    [DataType(DataType.MultilineText)]
    public string? Address { get; set; }

    [RegularExpression("^[0-9]{12}$")]
    public string? AadharId { get; set; }

    [Required]
    public UserRole Role { get; set; }
}
