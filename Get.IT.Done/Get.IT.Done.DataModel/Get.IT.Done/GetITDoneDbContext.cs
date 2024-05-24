using Get.IT.Done.DataModel.ServiceRequests;
using Get.IT.Done.DataModel.Services;
using Microsoft.EntityFrameworkCore;

namespace Get.IT.Done.DataModel;

public class GetITDoneDbContext : DbContext
{
    DbSet<Service> Services { get; set; }
    DbSet<ServiceRequest> ServiceRequests { get; set; }

    public GetITDoneDbContext(DbContextOptions<GetITDoneDbContext> options) : base(options)
    {      
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}
