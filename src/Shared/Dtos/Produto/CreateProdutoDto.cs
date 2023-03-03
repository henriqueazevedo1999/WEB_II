using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Shared.Dtos.Produto;

public record CreateProdutoDto
{
    [JsonPropertyName("id")]
    [Range(1, int.MaxValue, ErrorMessage = "Id do produto deve ser informado e ser maior que zero")]
    public int IdLista { get; init; }

    [JsonPropertyName("nome")]
    [Required(AllowEmptyStrings = false, ErrorMessage = "Nome do produto deve ser informado")]
    [MaxLength(ErrorMessage = "Nome do produto deve ter no máximo 250 caracteres")]
    public string Nome { get; init; }

    [JsonPropertyName("preco")]
    [Range(0, int.MaxValue, ErrorMessage = "Preço do produto deve ser maior ou igual a zero")]
    public int Preco { get; init; }
}