using Get.IT.Done.Auth.DataModel.DTOs;
using Get.IT.Done.Auth.DataModel.DTOs;

namespace Get.IT.Done.Auth.DataModel.Repositories.Interfaces;

public interface IUserRepository
{
    Task<GeneralResponse> CreateAccount(UserDTO userDTO);
    Task<LoginResponse> Login(LoginDTO loginDTO);
}
