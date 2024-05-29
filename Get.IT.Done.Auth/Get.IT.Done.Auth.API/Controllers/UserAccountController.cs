using Get.IT.Done.Auth.DataModel.DTOs;
using Get.IT.Done.Auth.DataModel.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Get.IT.Done.Auth.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserAccountController(IUserRepository userRepository) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register(UserDTO userDTO)
    {
        var response = await userRepository.CreateAccount(userDTO);
        return Ok(response);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDTO loginDTO)
    {
        var response = await userRepository.Login(loginDTO);
        return Ok(response);
    }
}
