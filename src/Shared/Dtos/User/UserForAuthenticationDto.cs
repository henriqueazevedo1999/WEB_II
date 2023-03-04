using System.ComponentModel.DataAnnotations;

namespace Shared.Dtos.User;

public record UserForAuthenticationDto
{
    [Required(ErrorMessage = "UserName é obrigatório")]
    public string UserName { get; init; }

    [Required(ErrorMessage = "Senha é obrigatória")]
    public string Password{ get; init; }
}
