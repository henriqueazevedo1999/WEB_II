using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Shared.Dtos.Produto;

namespace Shared.Dtos.Comanda;

//error message resource name?
public record CreateComandaDto
{
    [Range(1, int.MaxValue, ErrorMessage = "Id de usuário deve ser informado e ser maior que zero")]
    [JsonPropertyName("idUsuario")]
    public int IdUsuario { get; init; }

    [JsonPropertyName("nomeUsuario")]
    [Required(AllowEmptyStrings = false, ErrorMessage = "Nome do usuário deve ser informado")]
    [MaxLength(250, ErrorMessage = "Nome do usuário deve ter no máximo 250 caracteres")]
    public string NomeUsuario { get; init; }

    [JsonPropertyName("telefoneUsuario")]
    [Required(AllowEmptyStrings = false, ErrorMessage = "Telefone do usuário deve ser informado")]
    [Phone(ErrorMessage = "Formato de número de telefone do usuário inválido")]
    [MaxLength(15, ErrorMessage = "Telefone do usuário deve ter no máximo 15 caracteres")]
    public string TelefoneUsuario { get; init; }

    [JsonPropertyName("produtos")]
    public CreateProdutoDto[] Produtos { get; init; }
}
