using AutoMapper;
using Contracts;
using Entities.ConfigurationModels;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Service.Contracts;
using Shared.Dtos.User;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Service;

public class AuthenticationService : IAuthenticationService
{
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;
    private readonly JwtConfiguration _jwtConfiguration;

    private User _user;

    public AuthenticationService(ILoggerManager logger
                               , IMapper mapper
                               , UserManager<User> userManager
                               , IOptions<JwtConfiguration> jwtConfiguration)
    {
        _logger = logger;
        _mapper = mapper;
        _userManager = userManager;
        _jwtConfiguration = jwtConfiguration.Value;
    }

    public async Task<string> CreateToken()
    {
        var signingCredentials = GetSigningCredentials();
        var claims = await GetClaims();
        var tokenOptions = GenerateTokenOptions(signingCredentials, claims);

        return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
    }

    private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
    {
        return new JwtSecurityToken
        (
            claims: claims,
            expires: DateTime.Now.AddMinutes(_jwtConfiguration.Expires),
            signingCredentials: signingCredentials
        );
    }

    private async Task<List<Claim>> GetClaims()
    {
        var roles = await _userManager.GetRolesAsync(_user);
        var claims = roles.Select(r => new Claim(ClaimTypes.Role, r)).ToList();

        claims.Add(new Claim(ClaimTypes.Name, _user.UserName));
        return claims;
    }

    private SigningCredentials GetSigningCredentials()
    {
        var key = Encoding.UTF8.GetBytes(_jwtConfiguration.SecretKey);
        var secret = new SymmetricSecurityKey(key);

        return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
    }

    public async Task<IdentityResult> RegisterUser(CreateUserDto createUserDto)
    {
        var user = _mapper.Map<User>(createUserDto);
        
        var result = await _userManager.CreateAsync(user, createUserDto.Password);

        if (result.Succeeded)
            await _userManager.AddToRolesAsync(user, createUserDto.Roles);

        return result;
    }

    public async Task<bool> ValidateUser(UserForAuthenticationDto userForAuthenticationDto)
    {
        _user = await _userManager.FindByNameAsync(userForAuthenticationDto.UserName);
        var result = _user != null && await _userManager.CheckPasswordAsync(_user, userForAuthenticationDto.Password);
        if (!result)
            _logger.LogWarn($"{nameof(ValidateUser)}: Authentication failed. Wrong user name or password.");

        return result;
    }
}
