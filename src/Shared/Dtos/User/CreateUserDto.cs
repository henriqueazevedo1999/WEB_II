using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Shared.Dtos.User;

public record CreateUserDto
{
    [Required(ErrorMessage = "Parâmetro obrigatório", AllowEmptyStrings = false)]
    [MaxLength(100, ErrorMessage = "Deve ter no máximo 100 caracteres")]
    [JsonPropertyName("nome")]
    public string FirstName { get; init; }

    [Required(ErrorMessage = "Parâmetro obrigatório", AllowEmptyStrings = false)]
    [MaxLength(100, ErrorMessage = "Deve ter no máximo 100 caracteres")]
    [JsonPropertyName("sobrenome")]
    public string LastName { get; init; }

    [Required(ErrorMessage = "Parâmetro obrigatório", AllowEmptyStrings = false)]
    [JsonPropertyName("username")]
    public string UserName { get; init; }

    [Required(ErrorMessage = "Parâmetro obrigatório", AllowEmptyStrings = false)]
    [JsonPropertyName("senha")]
    public string Password { get; init; }

    [Required(ErrorMessage = "Parâmetro obrigatório", AllowEmptyStrings = false)]
    [JsonPropertyName("email")]
    public string Email { get; init; }

    [Required(ErrorMessage = "Parâmetro obrigatório", AllowEmptyStrings = false)]
    [JsonPropertyName("telefone")]
    public string PhoneNumber { get; init; }

    public ICollection<string> Roles { get; init; }
}
