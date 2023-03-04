using Microsoft.AspNetCore.Identity;
using Shared.Dtos.User;

namespace Service.Contracts;

public interface IAuthenticationService
{
    Task<IdentityResult> RegisterUser(CreateUserDto createUserDto);
    Task<bool> ValidateUser(UserForAuthenticationDto userForAuthenticationDto);
    Task<string> CreateToken();
}
