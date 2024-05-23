using Get.IT.Done.Enums;
using System.ComponentModel.DataAnnotations;

namespace Get.IT.Done.DataModel.Services;

public class Service
{
    [Key]
    public Guid Id { get; set; }

    public ServiceType Type { get; set; }

    [MaxLength(50)]
    public string? Description { get; set; }
}
