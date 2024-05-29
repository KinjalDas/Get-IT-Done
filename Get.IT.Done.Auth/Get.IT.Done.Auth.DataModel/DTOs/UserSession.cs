namespace Get.IT.Done.Auth.DataModel.DTOs;

public record UserSession(Guid? Id, string? Name, string? Email, string? Role);
