using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Get.IT.Done.Auth.DataModel.ApplicationUsers;

public class ApplicationUser : IdentityUser<Guid>
{
    public Uri? ProfilePicture { get; set; }

    [MaxLength(50)]
    public string? Address { get; set; }

    [RegularExpression("^[0-9]{12}$")]
    public string? AadharId { get; set; }
}
