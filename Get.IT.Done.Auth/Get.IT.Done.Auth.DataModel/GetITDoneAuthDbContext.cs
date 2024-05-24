using Get.IT.Done.Auth.DataModel.ApplicationUserRoles;
using Get.IT.Done.Auth.DataModel.ApplicationUsers;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Get.IT.Done.Auth.DataModel;

public class GetITDoneAuthDbContext : IdentityDbContext<ApplicationUser, ApplicationUserRole, Guid>
{
    public GetITDoneAuthDbContext(DbContextOptions<GetITDoneAuthDbContext> options) : base(options)
    {
    }
}
