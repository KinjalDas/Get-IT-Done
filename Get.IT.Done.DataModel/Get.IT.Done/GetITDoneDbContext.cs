using Get.IT.Done.DataModel.ServiceRequests;
using Get.IT.Done.DataModel.Services;
using Get.IT.Done.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Get.IT.Done.DataModel;

public class GetITDoneDbContext : IdentityDbContext<User>
{
    DbSet<Service> Services { get; set; }
    DbSet<ServiceRequest> ServiceRequests { get; set; }

    public GetITDoneDbContext(DbContextOptions options) : base(options)
    {      
    }
}
