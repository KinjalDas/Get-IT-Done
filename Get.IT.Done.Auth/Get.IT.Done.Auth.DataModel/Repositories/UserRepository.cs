using Get.IT.Done.Auth.DataModel.ApplicationUserRoles;
using Get.IT.Done.Auth.DataModel.ApplicationUsers;
using Get.IT.Done.Auth.DataModel.DTOs;
using Get.IT.Done.Auth.DataModel.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Get.IT.Done.Auth.DataModel.Repositories;

public class UserRepository(UserManager<ApplicationUser> userManager, 
    RoleManager<ApplicationUserRole> roleManager, 
    IConfiguration config) : IUserRepository
{
    public async Task<GeneralResponse> CreateAccount(UserDTO userDTO)
    {
        if (userDTO is null) return new GeneralResponse(false, "Model is empty");
        var newUser = new ApplicationUser()
        {
            Email = userDTO.Email,
            PasswordHash = userDTO.Password,
            UserName = userDTO.Email,
        };
        var user = await userManager.FindByEmailAsync(newUser.Email);
        if (user is not null) return new GeneralResponse(false, "User registered already");

        var createUser = await userManager.CreateAsync(newUser, userDTO.Password);
        if (!createUser.Succeeded) return new GeneralResponse(false, "Error occurred.. please try again");

        var checkUser = await roleManager.FindByNameAsync(userDTO.Role.ToString());
        if (checkUser is null)
            await roleManager.CreateAsync(new ApplicationUserRole() { Name = userDTO.Role.ToString() });

        await userManager.AddToRoleAsync(newUser, userDTO.Role.ToString());
        return new GeneralResponse(true, "Account Created");
    }

    public async Task<LoginResponse> Login(LoginDTO loginDTO)
    {
        if (loginDTO == null)
            return new LoginResponse(false, null!, "Login container is empty");

        var getUser = await userManager.FindByEmailAsync(loginDTO.Email);
        if (getUser is null)
            return new LoginResponse(false, null!, "User not found");

        bool checkUserPasswords = await userManager.CheckPasswordAsync(getUser, loginDTO.Password);
        if (!checkUserPasswords)
            return new LoginResponse(false, null!, "Invalid email/password");

        var getUserRole = await userManager.GetRolesAsync(getUser);
        var userSession = new UserSession(getUser.Id, getUser.NormalizedUserName, getUser.Email, getUserRole.First());
        string token = GenerateToken(userSession);
        return new LoginResponse(true, token!, "Login completed");
    }

    private string GenerateToken(UserSession user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Secret"]!));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var userClaims = new[]
        {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()!),
                new Claim(ClaimTypes.Name, user.Name!),
                new Claim(ClaimTypes.Email, user.Email!),
                new Claim(ClaimTypes.Role, user.Role!)
            };
        var token = new JwtSecurityToken(
            issuer: config["Jwt:ValidIssuer"],
            audience: config["Jwt:ValidAudience"],
            claims: userClaims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: credentials
            );
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
