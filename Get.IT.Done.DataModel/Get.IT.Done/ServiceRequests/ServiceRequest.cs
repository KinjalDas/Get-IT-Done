using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace Get.IT.Done.DataModel.ServiceRequests;

public class ServiceRequest
{
    public Guid Id { get; set; }

    [ForeignKey("User")]
    public Guid UserId { get; set; }

    [ForeignKey("Service")]
    public Guid ServiceId { get; set; }

    public Point ServiceLocation { get; set; }

    public DateTime ServiceRequestedTimeTamp { get; set; }
}
