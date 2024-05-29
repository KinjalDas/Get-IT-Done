namespace Get.IT.Done.Auth.DataModel.DTOs;

public record class GeneralResponse(bool Success, string Message);
public record class LoginResponse(bool Success, string Token, string Message);
