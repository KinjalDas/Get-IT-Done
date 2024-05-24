using Get.IT.Done.DataModel.Services;
using NetTopologySuite.Geometries;
using System.ComponentModel.DataAnnotations;

namespace Get.IT.Done.DataModel.ServiceRequests;

public class ServiceRequest
{
    [Key]
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public Guid ServiceId { get; set; }
    public Service Service { get; set; }

    public Point ServiceLocation { get; set; }

    public DateTime ServiceRequestedTimeTamp { get; set; }
}
