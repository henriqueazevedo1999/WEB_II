using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.Dtos.Token;
using Shared.Dtos.User;

namespace Comandas.Presentation.Controllers;

[ApiController]
[Route("RestAPIFurb/[controller]")]
public class AuthenticationController : ControllerBase
{
    private readonly IServiceManager _service;

    public AuthenticationController(IServiceManager service)
    {
        _service = service;
    }

    /// <summary>
    /// Registra um novo usuário
    /// </summary>
    [HttpPost]
    [Authorize(Roles = "Gerente")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> RegisterUser([FromBody] CreateUserDto user)
    {
        var result = await _service.AuthenticationService.RegisterUser(user);
        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                ModelState.TryAddModelError(error.Code, error.Description);
            }
            return BadRequest(ModelState);
        }

        return StatusCode(201);
    }

    /// <summary>
    /// Cria um token para o usuário informado
    /// </summary>
    [HttpPost("login")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [ProducesResponseType(typeof(TokenDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDto userDto)
    {
        if (!await _service.AuthenticationService.ValidateUser(userDto))
            return Unauthorized();

        string token = await _service.AuthenticationService.CreateToken();
        return Ok(new TokenDto { Token = token });
    }
}