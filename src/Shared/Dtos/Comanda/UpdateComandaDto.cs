using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Shared.Dtos.Produto;

namespace Shared.Dtos.Comanda;

public record UpdateComandaDto
{
    [JsonPropertyName("idUsuario")]
    [Range(1, int.MaxValue, ErrorMessage = "Id de usuário deve ser maior que zero")]
    public int? IdUsuario { get; set; }

    [JsonPropertyName("nomeUsuario")]
    [MaxLength(250, ErrorMessage = "Nome do usuário deve ter no máximo 250 caracteres")]
    public string NomeUsuario { get; set; }

    [JsonPropertyName("telefoneUsuario")]
    [Phone(ErrorMessage = "Formato de número de telefone do usuário inválido")]
    [MaxLength(15, ErrorMessage = "Telefone do usuário deve ter no máximo 15 caracteres")]
    public string TelefoneUsuario { get; set; }

    [JsonPropertyName("produtos")]
    public UpdateProdutoDto[] Produtos { get; set; }
}
