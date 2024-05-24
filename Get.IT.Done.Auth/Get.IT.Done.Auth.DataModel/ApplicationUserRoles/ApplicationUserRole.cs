using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Get.IT.Done.Auth.DataModel.ApplicationUserRoles;

public class ApplicationUserRole : IdentityRole<Guid>
{
    [MaxLength(50)]
    public string RoleDescription { get; set; }
}
